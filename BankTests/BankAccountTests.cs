using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCore.BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Rissard�o da massa", beginningBalance);

            account.Debit(debitAmmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "D�bito incorreto");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmmount = -100.00;

            var account = new BankAccount("Rissard�o no vermelho", beginningBalance);

            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmmount));
            try
            {
                account.Debit(debitAmmount);

                Assert.Fail("Deveria ter lan�ado exce��o");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalace_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmmount = 100;

            var account = new BankAccount("Rissard�o doidao", beginningBalance);

            try
            {
                account.Debit(debitAmmount);

                Assert.Fail("Deveria ter lan�ado exce��o");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

    }
}