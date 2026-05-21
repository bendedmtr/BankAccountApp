namespace BankAccountApp
{
    public class BankAccount
    {
        private double _balance;
        private readonly string _owner;
        private readonly TransactionHistory _history;

        // owner nem lehet null/üres, initialBalance nem lehet negatív
        public BankAccount(string owner, double initialBalance = 0)
        {
            if (string.IsNullOrEmpty(owner))
            {
                throw new ArgumentException(nameof(owner));
            }
            else if(initialBalance < 0)
            {
                throw new ArgumentException(nameof(owner));
            }
            else
            {
                _balance = initialBalance;
                _owner = owner;
            }
        }

        public string GetOwner()
        {
            return _owner;
        }

        public double GetBalance()
        {
            return _balance;
        }

        // Visszatér false ha amount <= 0
        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            else
            {
                _balance += amount;
                return true;
            }
        }

        // Visszatér false ha amount <= 0 vagy nincs elég fedezet
        public bool Withdraw(double amount)
        {
            if(amount <= 0 || _balance < amount)
            {
                return false;
            }
            else
            {
                _balance -= amount;
                return true;
            }
        }

        // Visszatér false ha target null, amount érvénytelen, vagy nincs fedezet
        public bool Transfer(BankAccount target, double amount)
        {
            if (target == null || amount <= 0 || amount > _balance)
            {
                return false;
            }
            else
            {
                target._balance += amount;
                _balance -= amount;
                return true;
            }
        }

        public TransactionHistory GetHistory()
        {
            return _history;
        }
    }
}
