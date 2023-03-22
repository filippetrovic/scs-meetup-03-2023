using System;
using ApprovalTests;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class HelloWorldTest
    {
        [Fact]
        public void TestDeposit()
        {
            Account account = new Account();
            account.Deposit(500);
            Approvals.Verify(account.PrintStatement());
        }

        [Fact]
        public void TestWithdraw()
        {
            Account account = new Account();
            account.Withdraw(100);
            Approvals.Verify(account.PrintStatement());
        }

        [Fact]
        public void TestEmptyAccount()
        {
            Account account = new Account();
            Approvals.Verify(account.PrintStatement());
        }
    }

    public class Account
    {
        public string PrintStatement()
        {
            if (Amount != 0)
            {
                return $"""
            Date        Amount  Balance
            {TransactionDate}  {Amount} {Balance}
            """;
            }
            else
            {
                return $"""
            Date        Amount  Balance
            """;
            }
        }

        public void Deposit(int amount)
        {
            Amount += amount;
            Balance = Amount;
            TransactionDate = DateOnly.Parse("24.12.2015");
        }


        private DateOnly TransactionDate { get; set; }
        private int Amount { get; set; }
        public int Balance { get; set; }

        public void Withdraw(int amount)
        {
            Amount -= amount;
            Balance = Amount;
            TransactionDate = DateOnly.Parse("23.08.2016");
        }
    }
}