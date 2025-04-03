namespace retotecnico_cobol.Models
{
    class Transaction
    {
        public int Id { get; }
        public string Type { get; }
        public decimal Amount { get; }

        public Transaction(int id, string type, decimal amount)
        {
            Id = id;
            Type = type;
            Amount = amount;
        }
    }
}