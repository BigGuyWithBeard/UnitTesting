// The 'using' statement for Test Tools is in GlobalUsings.cs
// using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTesting.CustomerAccounts;

namespace UnitTesting.CustomerAccounts.Tests
{
    /// <summary>
    /// Tests for CustomerAccount class
    /// </summary>
    [TestClass]
    public class UnitCustomerAccount
    {
        /// <summary>
        /// create a new object and call the debit method with values that we expect to work
        /// </summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {

            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            CustomerAccount account = new CustomerAccount("Mr. Homer Simpson", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }

        /// <summary>
        /// create a new object and call the debit method with a negative amount, which should throw an exception
        /// </summary>
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00; // debit amount is less than zero
            CustomerAccount account = new CustomerAccount("Mr. Homer Simpson", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        /// <summary>
        /// create a new object and call the debit method with an amount larger than the balance, which should throw an exception
        /// </summary>
        [TestMethod]
        public void Debit_WhenInsufficentBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00; // debit amount is larger than the balance
            CustomerAccount account = new CustomerAccount("Mr. Homer Simpson", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }


    }
}