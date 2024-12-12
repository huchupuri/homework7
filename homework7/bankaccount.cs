using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    public enum AccountType { debit, credit, savings };

    /// <summary>
    /// класс банковского счета
    /// </summary>
    class BankAccount
    {
        private uint id;
        private static uint autoID = 0;
        private decimal balance;
        private AccountType accountType;

        /// <summary>
        /// конструктор с введенным ID
        /// </summary>
        public BankAccount(uint id, decimal balance, AccountType accountType)
        {
            this.id = id;
            this.balance = balance;
            this.accountType = accountType;
        }

        /// <summary>
        /// конструктор с генерируемым ID
        /// </summary>
        public BankAccount(decimal balance, AccountType accountType)
        {
            this.id = GenerateID();
            this.balance = balance;
            this.accountType = accountType;
        }

        /// <summary>
        /// генерация ID
        /// </summary>
        private uint GenerateID()
        {
            autoID++;
            return autoID;
        }

        /// <summary>
        /// перевод средств
        /// </summary>
        public bool Transfer(BankAccount account, decimal amount)
        {
            if (account.WithdrawCash(amount))
            {
                balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// установка нового значения ID
        /// </summary>
        public void SetID(uint id)
        {
            this.id = id;
        }

        /// <summary>
        /// установка нового значения баланса
        /// </summary>
        public void SetBalance(decimal balance)
        {
            this.balance = balance;
        }

        /// <summary>
        /// установка нового значения типа аккаунта
        /// </summary>
        public void SetAccountType(AccountType accountType)
        {
            this.accountType = accountType;
        }

        /// <summary>
        /// вывод номера аккаунта
        /// </summary>
        public uint GetID()
        {
            return id;
        }

        /// <summary>
        /// вывод типа аккаунта
        /// </summary>
        public decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// вывод типа аккаунта
        /// </summary>
        public AccountType GetAccountType()
        {
            return accountType;
        }

        /// <summary>
        /// вывод информации по клиенту
        /// </summary>
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {id}, Баланс: {balance:N}, Тип счета: {accountType}\n");
        }

        /// <summary>
        /// снятие денег
        /// </summary>
        public bool WithdrawCash(decimal cash)
        {
            if ((balance - cash) > 0)
            {
                balance -= cash;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// пополнение счета
        /// </summary>
        public void Deposit(decimal cash)
        {
            balance += cash;
        }
    }
}
