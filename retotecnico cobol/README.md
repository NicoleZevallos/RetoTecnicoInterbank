# README - Reto técnico Interbank

## Introducción
Este proyecto es una aplicación de línea de comandos (CLI) realizada en C#, que tiene el objetivo de procesas un archivo CSV con información sobre transacciones financieras.
Su propósito es leer los datos del archivo, validarlos y generar un reporte con el balance final, la transacción de mayor monto y el conteo de transacciones por tipo (Crédito y Débito).

## Instrucciones de Ejecución
### Pasos para ejecutar la aplicación:
#### Opción 1: Ejecutar desde el código fuente
Si prefieres ejecutar el proyecto directamente desde el código fuente, sigue estos pasos:

1. Clona o descarga el proyecto en tu máquina.
2. Abre una terminal y navega hasta el directorio del proyecto.
3. Ejecuta el siguiente comando para restaurar las dependencias:

   ```sh
   dotnet restore
   ```
4. Ejecutar la aplicación con:
   ```sh
   dotnet run
   ```
5. Se solicitará la ruta del archivo CSV. Ingresar la ruta completa al archivo deseado.

#### Opción 2: Ejecutar el ejecutable
Si no deseas instalar dependencias ni usar comandos de la terminal, puedes ejecutar el archivo .exe en la carpeta build del proyecto.

1. Navega a la carpeta build dentro del directorio del proyecto.
2. Encuentra el archivo "retotecnico cobol.exel"
3. Haz doble clic en retotecnico cobol.exe para ejecutar el programa.

## Enfoque y Solución
El programa sigue los siguientes pasos:
1. Solicita al usuario la ruta del archivo CSV y valida su existencia.
2. Lee el contenido del archivo y valida el formato de los datos.
3. Almacena las transacciones en una lista, asegurando que solo se procesen datos válidos.
4. Calcula el balance final, la transacción con mayor monto y el conteo de transacciones por tipo.
5. Muestra el reporte en la consola con la información procesada.

## Estructura del Proyecto
```
/Proyecto
│── Program.cs  # Archivo principal que contiene la lógica del programa.
│── Models/
│   └── Transaction.cs  # Clase que representa una transacción financiera.
│── build
|   └── retotecnico cobol.exe  # Ejecutable del programa.
│── README.md  # Documentación del proyecto.
|── data.csv  # Archivo input de ejemplo obtenido de rama original
```

