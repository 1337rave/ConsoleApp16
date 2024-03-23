using System;

// Delegate declaration for events
public delegate void CreditCardEventHandler(object sender, EventArgs e);

// Credit Card class
public class CreditCard
{
    // Class fields
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string PIN { get; set; }
    public decimal CreditLimit { get; set; }
    public decimal Balance { get; private set; }

    // Events
    public event CreditCardEventHandler AccountCredited;
    public event CreditCardEventHandler FundsSpent;
    public event CreditCardEventHandler CreditStarted;
    public event CreditCardEventHandler LimitReached;
    public event CreditCardEventHandler PINChanged;

    // Constructor
    public CreditCard(string cardNumber, string cardHolderName, DateTime expiryDate, string pin, decimal creditLimit, decimal balance)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        ExpiryDate = expiryDate;
        PIN = pin;
        CreditLimit = creditLimit;
        Balance = balance;
    }

    // Method to credit account
    public void CreditAccount(decimal amount)
    {
        Balance += amount;
        OnAccountCredited(EventArgs.Empty);
    }

    // Method to spend funds
    public void SpendFunds(decimal amount)
    {
        Balance -= amount;
        OnFundsSpent(EventArgs.Empty);
    }

    // Method to start using credit
    public void StartCredit()
    {
        OnCreditStarted(EventArgs.Empty);
    }

    // Method to check if credit limit reached
    public void CheckLimit()
    {
        if (Balance >= CreditLimit)
        {
            OnLimitReached(EventArgs.Empty);
        }
    }

    // Method to change PIN
    public void ChangePIN(string newPIN)
    {
        PIN = newPIN;
        OnPINChanged(EventArgs.Empty);
    }

    // Methods to trigger events
    protected virtual void OnAccountCredited(EventArgs e)
    {
        AccountCredited?.Invoke(this, e);
    }

    protected virtual void OnFundsSpent(EventArgs e)
    {
        FundsSpent?.Invoke(this, e);
    }

    protected virtual void OnCreditStarted(EventArgs e)
    {
        CreditStarted?.Invoke(this, e);
    }

    protected virtual void OnLimitReached(EventArgs e)
    {
        LimitReached?.Invoke(this, e);
    }

    protected virtual void OnPINChanged(EventArgs e)
    {
        PINChanged?.Invoke(this, e);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage of CreditCard class
        CreditCard card = new CreditCard("1234567890123456", "John Doe", DateTime.Now.AddYears(3), "1234", 1000m, 500m);

        // Subscribing to events
        card.AccountCredited += (sender, e) => Console.WriteLine("Account credited!");
        card.FundsSpent += (sender, e) => Console.WriteLine("Funds spent!");
        card.CreditStarted += (sender, e) => Console.WriteLine("Credit usage started!");
        card.LimitReached += (sender, e) => Console.WriteLine("Credit limit reached!");
        card.PINChanged += (sender, e) => Console.WriteLine("PIN changed!");

        // Calling methods to trigger events
        card.CreditAccount(200m);
        card.SpendFunds(100m);
        card.StartCredit();
        card.CheckLimit();
        card.ChangePIN("4321");

        Console.ReadLine();
    }
}
