namespace Factory.BankAccounts;

public abstract class BankAccount
{
    public required string AccountNumber { get; set; }
    public required string OwnerName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}
