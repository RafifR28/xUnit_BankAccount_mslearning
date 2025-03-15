using System;
using Xunit;
using BankAccountApp;

namespace BankAccountApp.UnitTests
{
    public class BankAccountTest
    {
        [Fact]
        public void Credit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Credit(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Debit_ValidAmount_DecreasesBalance()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Debit(50);

            // Assert
            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void Debit_InsufficientBalance_ThrowsException()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Debit(150));
        }

        [Fact]
        public void Transfer_ValidAmount_TransfersBalance()
        {
            // Arrange
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);

            // Act
            fromAccount.Transfer(toAccount, 50);

            // Assert
            Assert.Equal(50, fromAccount.Balance);
            Assert.Equal(100, toAccount.Balance);
        }

        [Fact]
        public void Transfer_InsufficientBalance_ThrowsException()
        {
            // Arrange
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<Exception>(() => fromAccount.Transfer(toAccount, 150));
        }

        [Fact]
        public void Transfer_ExceedsLimitForDifferentOwners_ThrowsException()
        {
            // Arrange
            var fromAccount = new BankAccount("123", 1000, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);

            // Act & Assert
            Assert.Throws<Exception>(() => fromAccount.Transfer(toAccount, 600));
        }

        [Fact]
        public void GetBalance_ReturnsCorrectBalance()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            var balance = account.GetBalance();

            // Assert
            Assert.Equal(100, balance);
        }

        [Fact]
        public void CalculateInterest_ReturnsCorrectInterest()
        {
            // Arrange
            var account = new BankAccount("123", 1000, "John Doe", "Savings", DateTime.Now);

            // Act
            var interest = account.CalculateInterest(0.05);

            // Assert
            Assert.Equal(50, interest);
        }

        [Fact]
        public void Credit_NegativeAmount_DoesNotChangeBalance()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Credit(-50);

            // Assert
            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void Debit_NegativeAmount_DoesNotChangeBalance()
        {
            // Arrange
            var account = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);

            // Act
            account.Debit(-50);

            // Assert
            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void Transfer_NegativeAmount_DoesNotChangeBalance()
        {
            // Arrange
            var fromAccount = new BankAccount("123", 100, "John Doe", "Savings", DateTime.Now);
            var toAccount = new BankAccount("456", 50, "Jane Doe", "Savings", DateTime.Now);

            // Act
            fromAccount.Transfer(toAccount, -50);

            // Assert
            Assert.Equal(100, fromAccount.Balance);
            Assert.Equal(50, toAccount.Balance);
        }

        [Fact]
        public void CalculateInterest_ZeroBalance_ReturnsZeroInterest()
        {
            // Arrange
            var account = new BankAccount("123", 0, "John Doe", "Savings", DateTime.Now);

            // Act
            var interest = account.CalculateInterest(0.05);

            // Assert
            Assert.Equal(0, interest);
        }
    }

    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public string Owner { get; }
        public string AccountType { get; }
        public DateTime CreatedDate { get; }

        public BankAccount(string accountNumber, decimal initialBalance, string owner, string accountType, DateTime createdDate)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Owner = owner;
            AccountType = accountType;
            CreatedDate = createdDate;
        }

        public void Credit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0)
            {
                return;
            }
            
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for debit");
            }
            
            Balance -= amount;
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                return;
            }

            if (this.Balance < amount)
            {
                throw new Exception("Insufficient funds for transfer");
            }
            
            if (this.Owner != toAccount.Owner && amount > 500)
            {
                throw new Exception("Transfer amount exceeds limit for different account owners");
            }

            this.Debit(amount);
            toAccount.Credit(amount);
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public decimal CalculateInterest(double interestRate)
        {
            return Balance * (decimal)interestRate;
        }
    }
}