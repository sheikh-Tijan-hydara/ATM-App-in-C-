 using System;
using System.Security.Cryptography.X509Certificates;

namespace AtmApp{
public class Program {
    public static void Main(string[] args){
         void PrintOptions() {
            Console.WriteLine("Select an option below: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Print Balance");
            Console.WriteLine("5. Print Account Info");
            Console.WriteLine("6. Exit");
        }
        void Deposit(CardHolder currentAccount) {
            Console.WriteLine("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            currentAccount.SetBalance(currentAccount.GetBalance() + amount);
            Console.WriteLine("**************************************");
            Console.WriteLine("Thank you your balance is now: " + currentAccount.GetBalance()); 
            Console.WriteLine("**************************************");           
        }

        void Withdraw(CardHolder currentUser){
            Console.WriteLine("Enter the amount you want to withdraw: ");
            double amount = double.Parse(Console.ReadLine());
            if(currentUser.GetBalance() < amount){
                Console.WriteLine("Insufficient amount in your account");
            }else{
            currentUser.SetBalance(currentUser.GetBalance() - amount);
            Console.WriteLine("**************************************");
            Console.WriteLine("Thank you your balance is now: " + currentUser.GetBalance());
            Console.WriteLine("**************************************");            
            }
        }

        void Transfer (CardHolder currentUser, CardHolder receiver){
            Console.WriteLine("Enter the amount you want to transfer: ");
            double amount = double.Parse(Console.ReadLine());
             if(currentUser.GetBalance() < amount){
                Console.WriteLine("Insufficient amount in your account");
            }else{
            currentUser.SetBalance(currentUser.GetBalance() - amount);
            receiver.SetBalance(receiver.GetBalance() + amount);
            Console.WriteLine("**************************************");
            Console.WriteLine("You have successfully transfered");
            Console.WriteLine(amount + " to " + receiver.GetFullName());
            Console.WriteLine("**************************************");
            }
        }

        void PrintAccountInfo(CardHolder currentUser){
            Console.WriteLine("**************************************");
            Console.WriteLine("Account Name: " + currentUser.GetFullName());
            Console.WriteLine("Account Number: " + currentUser.GetAccountNumber());
            Console.WriteLine("Account Balance: " + currentUser.GetBalance());
            Console.WriteLine("**************************************");
        }
         List<CardHolder> cardHolders = new List<CardHolder>();
         cardHolders.Add(new CardHolder("Tijan", "Jallow", "123434789", "1234", 1000));
         cardHolders.Add(new CardHolder("Sheikh", "Hydara", "987654321", "4321", 500));
         cardHolders.Add(new CardHolder("Tima", "SHeikh", "123456789", "1234", 1400));
         cardHolders.Add(new CardHolder("Hydara", "Gaye", "987654321", "4321", 500));
         

            Console.WriteLine("Welcome to Tijan Bank");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter your account number");
            string accountNumber = "";
            CardHolder currentUser;

            while(true){
                try{
                accountNumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.GetAccountNumber() == accountNumber);  
                if(currentUser != null){
                    break;
                }else{
                    Console.WriteLine("Invalid account number, please try again");
                }   
                }catch{
                    Console.WriteLine("Invalid account number, please try again");
                }            
            }
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter your pin");
            string pin = "";
            while(true){
                try{
                pin = Console.ReadLine();
                if(currentUser.GetPin() == pin){
                    break;
                }else{
                    Console.WriteLine("Invalid pin, please try again");
                }   
                }catch{
                    Console.WriteLine("Invalid pin, please try again");
                }            
            }

            Console.WriteLine("Welcome " + currentUser.GetFullName());
            Console.WriteLine("**************************************");
            while(true){
                PrintOptions();
                int option = int.Parse(Console.ReadLine());
                if(option == 1){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    Deposit(currentUser);
                }else if(option == 2){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    Withdraw(currentUser);
                }else if(option == 3){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Enter the account number of the person you want to transfer to: ");
                    string receiverAccountNumber = Console.ReadLine();
                    CardHolder receiver = cardHolders.FirstOrDefault(a => a.GetAccountNumber() == receiverAccountNumber);
                    if(receiver != null){
                        Transfer(currentUser, receiver);
                    }else{
                        Console.WriteLine("Invalid account number");
                    }
                }else if(option == 4){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    currentUser.PrintBalance();
                }else if(option == 5){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    PrintAccountInfo(currentUser);
                }else if(option == 6){
                    Console.WriteLine("Please wait while we process your request");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Thank you for banking with us");
                    break;
                }else{
                    Console.WriteLine("Invalid option");
                }
            }
    }
}
}