using NUnit.Framework;
using BankAccountApp;

namespace BankAccountApp.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount("123456789", 1000); // Инициализация с начальным балансом 1000
        }

        [Test]
        public void Test_AccountCreation_WithValidBalance()
        {
            // Arrange
            var account = new BankAccount("123", 500);

            // Assert
            Assert.That(account.GetBalance(), Is.EqualTo(500));
        }

        [Test]
        public void Test_AccountCreation_WithInvalidBalance()
        {
            // Arrange & Assert
            Assert.Throws<ArgumentException>(() => new BankAccount("123", -500));
        }

        [Test]
        public void Test_Deposit_Success()
        {
            // Act
            _account.Deposit(500);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(1500));
        }

        [Test]
        public void Test_Deposit_WithInvalidAmount()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _account.Deposit(-500));
            Assert.Throws<ArgumentException>(() => _account.Deposit(0));
        }

        [Test]
        public void Test_Withdraw_Success()
        {
            // Act
            _account.Withdraw(500);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(500));
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(1500));
        }

        [Test]
        public void Test_Withdraw_WithInvalidAmount()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _account.Withdraw(-500));
            Assert.Throws<ArgumentException>(() => _account.Withdraw(0));
        }




        //Тест с нулевым балансом при создании счета
        [Test]
        public void Test_AccountCreation_WithZeroBalance()
        {
            // Arrange
            var account = new BankAccount("123", 0);

            // Assert
            Assert.That(account.GetBalance(), Is.EqualTo(0));
        }




        //Тест на депозит с нулевой или отрицательной суммой
        [Test]
        public void Test_Deposit_WithZeroAmount()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _account.Deposit(0));
        }
        [Test]
        public void Test_Deposit_WithNegativeAmount()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _account.Deposit(-100));
        }




        //Тест на снятие денег при балансе 0
        [Test]
        public void Test_Withdraw_FromZeroBalance()
        {
            // Arrange
            var account = new BankAccount("123", 0);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }







        //Тест на попытку снятия суммы больше текущего баланса
        [Test]
        public void Test_Withdraw_WithAmountGreaterThanBalance()
        {
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(2000));
        }




        //Тест на корректную работу с большими суммами
        [Test]
        public void Test_Deposit_WithLargeAmount()
        {
            // Act
            _account.Deposit(1000000);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(1001000)); // Исходный баланс 1000 + 1000000 = 1001000
        }

        [Test]
        public void Test_Withdraw_WithLargeAmount()
        {
            // Arrange
            double largeAmount = 500; // Или любое значение, не превышающее текущий баланс

            // Act
            _account.Withdraw(largeAmount);

            // Assert
            Assert.That(_account.GetBalance(), Is.EqualTo(1000 - largeAmount)); // Новый баланс после снятия
        }









        //Тест с нулевым значением суммы при снятии денег
        [Test]
        public void Test_Withdraw_WithZeroAmount()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _account.Withdraw(0));
        }





    }
}

