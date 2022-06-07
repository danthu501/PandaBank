using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PandaBank.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            //Arrange
            Accounts accounts = new Accounts("Test", 300, "SEK");


            //Act

            var actualName = accounts._Name;
            var expectedName = "Test";
            var actualAmount = accounts._Balance;
            var expectedAmount = 300;


            //Assert

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAmount, actualAmount);
            

        }
        [TestMethod]
        public void AddAccount_Test()
        {
            
            Customer customer = new Customer("Test", "test1234");
            Accounts accounts = new Accounts("Testkonto", 300, "SEK");

            customer.AddAccounts(accounts);

            var Test = customer.ListOfAccounts[0];
            var actual = accounts;

            Assert.AreEqual(Test, actual);
        }
        [TestMethod]
        public void withdraw_Money_Test()
        {
            Accounts accounts = new Accounts("Testkonto", 500, "SEK");
            Customer customer = new Customer("Test", "test1234");
            customer.AddAccounts(accounts);

            
            var test = customer.IntrestAmount(accounts);


            Assert.AreEqual(test, accounts._Balance);
           

        }
    }
}
