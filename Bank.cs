using System;
using System.Security.Cryptography.X509Certificates;
namespace AtmApp{
public class CardHolder {
    string firstName;
    string lastName;
    string accountNumber;
    string pin;
    double balance;
    public CardHolder(string firstName, string lastName, string accountNumber, string pin, double balance) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.accountNumber = accountNumber;
        this.pin = pin;
        this.balance = balance;
    }

   public string GetFullName() {
        return this.firstName + " " + this.lastName;
    }

    public double GetBalance() {
        return this.balance;
    }
    public void SetBalance(double balance) {
        this.balance = balance;
    }

    public string GetAccountNumber() {
        return this.accountNumber;
    }
    public void SetAccountNumber(string accountNumber) {
        this.accountNumber = accountNumber;
    }

    public string GetPin() {
        return this.pin;
    }


    public void Transfer(CardHolder receiver, double amount) {
        this.balance -= amount;
        receiver.balance += amount;
    } 

    public void PrintBalance() {
        Console.WriteLine("Your balance is: " + this.balance);
    }

    public void PrintAccountInfo() {
        Console.WriteLine("Account Number: " + this.accountNumber);
        Console.WriteLine("Full Name: " + this.GetFullName());
        Console.WriteLine("Balance: " + this.balance);
    }
}
}