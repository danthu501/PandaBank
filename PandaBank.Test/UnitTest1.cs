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

            var Test = customer.ListOfAccounts[0]._Balance;
            var actual = 300;

            Assert.AreEqual(Test, actual);
        }
        [TestMethod]
        public void create_Customer()
        {
            Admin admin = new Admin();
            Customer customer = new Customer("Test", "Test1234");
            admin.ListOfCustomers.Add(customer);

            var test = admin.ListOfCustomers[0];
            var actual = customer.UserName;
            Assert.AreEqual(test.UserName, actual);

            
            
           

        }

        [TestMethod]
        public void ExchangeRate_Test_When_Sending_100_SEK_And_Reciver_100_SEK()
        {
            Customer customer = new Customer("Test", "Test1234");
            Accounts account1 = new Accounts("Testkonto", 300, "SEK");
            Accounts account2 = new Accounts("Testkonto", 300, "SEK");

            customer.AddAccounts(account1);
            customer.AddAccounts(account2);


            decimal test = customer.ExchangeRate(customer.ListOfAccounts[0], customer.ListOfAccounts[1], 100);
            decimal actual = 100;


            Assert.AreEqual(test, actual);

        }
        [TestMethod]
        public void ExchangeRate_Test_When_Sending_100_GBP_And_Reciver_In_SEK()
        {
            //Arrange
            Customer customer = new Customer("Test", "Test1234");
            Accounts account1 = new Accounts("Testkonto", 300, "GBP");
            Accounts account2 = new Accounts("Testkonto", 300, "SEK");

            customer.AddAccounts(account1);
            customer.AddAccounts(account2);

            Accounts FirstAccount = customer.ListOfAccounts[0];
            Accounts SecondAccount = customer.ListOfAccounts[1];

            var ExchangeRate = LoginUser.currencyChange[2];
            
            //Act
            

            decimal test = customer.ExchangeRate(FirstAccount, SecondAccount, 100);
            decimal actual = 100 / ExchangeRate; 
              

            //Assert
            Assert.AreEqual(test, actual);

        }
    }
}
