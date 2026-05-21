namespace BankAccountApp
{
    public class TransactionHistory
    {
        private readonly List<(string Type, double Amount)> _transactions;

        public TransactionHistory()
        {
            _transactions = new List<(string, double)>();
        }

        // type nem lehet null/üres, amount > 0
        public void AddTransaction(string type, double amount)
        {
            if (string.IsNullOrEmpty(type) || amount <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                _transactions.Add((type, amount));
            }
        }

        public int GetTransactionCount()
        {
            return _transactions.Count;
        }

        // Formátum: "Deposit: 100.00" — null ha nincs tranzakció
        public string? GetLastTransaction()
        {
            if (_transactions.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return $"{_transactions[_transactions.Count() - 1].Type}: {Math.Round(_transactions[_transactions.Count() - 1].Amount, 2)}";
            }
        }

        public double GetTotalDeposited()
        {
            return _transactions.Where(x => x.Type == "Deposit").ToList().Sum(y => y.Amount);
        }

        public double GetTotalWithdrawn()
        {
            return _transactions.Where(x => x.Type == "Withdrawal").ToList().Sum(y => y.Amount);
        }

        public void Clear()
        {
            _transactions.Clear();
        }
    }
}
