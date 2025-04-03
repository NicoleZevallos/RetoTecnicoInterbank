using retotecnico_cobol.Models;
using System.Globalization;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la ruta del archivo CSV: ");
        string? filePath = "";

        // Bucle para obtener una ruta valida para ejecutar el programa
        while (true)
        {
            Console.Write("Ingrese la ruta del archivo CSV (o escriba 'exit' para salir): ");
            filePath = Console.ReadLine();

            // Validar si la entrada esta vacía
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Por favor, ingrese la ruta del archivo CSV");
            }

            //Validar si el usuario quiere salir del programa
            if(filePath.ToLower() == "exit")
            {
                Console.WriteLine("Terminando el programa");
                return;
            }

            //Validar si la ruta es valida
            if(File.Exists(filePath))
            {
                break;
            }
            
            //Pedir otra ruta, si la ruta ingresada falla uno de los checks anteriores
            Console.WriteLine("El archivo CSV no existe en la ruta enviada, intentelo de nuevo, o escriba 'exit' para salir");
        }

        //Crear lista de transacciones
        List<Transaction> transactions = new List<Transaction>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string? header = reader.ReadLine();

                //Verificar que es un archivo valido y tiene el header correcto
                if (string.IsNullOrWhiteSpace(header) || !header.Equals("id,tipo,monto", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Error el formato del archivo CSV no es válido. ");
                    return;
                }

                //Leer archivo línea por línea
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    //Verificar que no haya una línea vacia
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("Error: Se encontró una línea vacía en el archivo csv.");
                        return;
                    }

                    var values = line.Split(',');

                    //Verificar que el archivo tenga datos validos
                    if(values.Length != 3 || !int.TryParse(values[0], out int id) ||
                       (values[1].Trim() != "Crédito" && values[1].Trim() != "Débito") ||
                       !decimal.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                    {
                        //Informar al usuario que el archivo tenía datos invalidos y cerrar el programa
                        Console.WriteLine("Error: Se econtró una línea con formato incorrecto");
                        return;
                    }

                    //Añadir la transacción a la lista de transacciones
                    transactions.Add(new Transaction(id, values[1].Trim(), amount));
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Error al procesar el archivo: " + ex.Message);
            return;
        }

        //Cálculo de balance final
        decimal finalBalance = transactions.Where(t => t.Type == "Crédito").Sum(t => t.Amount)
                            - transactions.Where(t => t.Type == "Débito").Sum(t =>t.Amount);
        
        //Cálculo de la mayor transacción realizada
        var biggestTransaction = transactions.OrderByDescending(t => t.Amount).FirstOrDefault();

        //Conteo de transacciones de crédito y transacciones de debíto
        int totalCredits = transactions.Count(t => t.Type == "Crédito");
        int totalDebits = transactions.Count(t => t.Type == "Débito");

        //Escribir reporte de transacciones

        Console.WriteLine("Reporte de Transacciones");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Balance Final: " + finalBalance.ToString("F2"));
        if(biggestTransaction != null)
        {
            Console.WriteLine("Transacción de Mayor Monto: ID " + biggestTransaction.Id + " - " + biggestTransaction.Amount.ToString("F2"));
        }
        Console.WriteLine("Conteo de transacciones: Crédito: " + totalCredits + " Débito: " + totalDebits);
    }
}