using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternGameInput
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {balance}");
        }

        public void Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount}, balance is now {balance}");
            }
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public interface ICommand
    {
        void call();
    }

    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        private Action action;
        private int amount;
        public enum Action
        {
            Deposit, Withdraw
        }

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public void call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    break;
                case Action.Withdraw:
                    account.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 50)
            };
            Console.WriteLine(ba);

            foreach (var c in commands)
            {
                c.call();
            }
            Console.ReadLine();
        }
    }


}
