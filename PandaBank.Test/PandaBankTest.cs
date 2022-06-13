using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PandaBank.Test
{
    [TestClass]
    public class PandaBankTest
    {

        [TestMethod]
        public void AddAccount_Test()
        {
            
            Customer customer = new Customer("Test", "test1234");
            Accounts accounts = new Accounts("Testkonto", 300, "SEK");

            customer.AddAccounts(accounts);

            var actual = customer.ListOfAccounts[0]._Balance;
            var expected = 300;
            var actualName = customer.ListOfAccounts[0]._Name;
            var expectedName = "Testkonto"; 

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedName, actualName);
        }
        [TestMethod]
        public void create_Customer()
        {
            Admin admin = new Admin();
            Customer customer = new Customer("Test", "Test1234");
            admin.ListOfCustomers.Add(customer);

            var actual = admin.ListOfCustomers[0];
            var expected = customer;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ExchangeRate_Test_When_Sending_100_SEK_And_Recives_100_SEK()
        {
            Customer customer = new Customer("Test", "Test1234");
            Accounts account1 = new Accounts("Testkonto", 300, "SEK");
            Accounts account2 = new Accounts("Testkonto", 300, "SEK");

            customer.ListOfAccounts.Add(account1);
            customer.ListOfAccounts.Add(account2);


            decimal actual = customer.ExchangeRate(customer.ListOfAccounts[0], customer.ListOfAccounts[1], 100);
            decimal expected = 100;


            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ExchangeRate_Test_When_Converting_100_GBP_To_SEK_()
        {
            //Arrange
            Customer customer = new Customer("Test", "Test1234");
            Accounts account1 = new Accounts("Testkonto", 300, "GBP");
            Accounts account2 = new Accounts("Testkonto", 300, "SEK");

            customer.ListOfAccounts.Add(account1);
            customer.ListOfAccounts.Add(account2);

            Accounts FirstAccount = customer.ListOfAccounts[0];
            Accounts SecondAccount = customer.ListOfAccounts[1];

            var ExchangeRate = LoginUser.currencyChange[2];
            
            //Act

            decimal actual = customer.ExchangeRate(FirstAccount, SecondAccount, 100);
            decimal expected = 100 / ExchangeRate; 
              

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ExchangeRate_Test_When_converting_100_USD_To_GBP()
        {
            //Arrange
            Customer customer = new Customer("Test", "Test1234");
            Accounts account1 = new Accounts("Testkonto", 300, "EUR");
            Accounts account2 = new Accounts("Testkonto", 300, "USD");

            customer.ListOfAccounts.Add(account1);
            customer.ListOfAccounts.Add(account2);

            Accounts FirstAccount = customer.ListOfAccounts[0];
            Accounts SecondAccount = customer.ListOfAccounts[1];

            var ExchangeRate = (LoginUser.currencyChange[1]/LoginUser.currencyChange[3]);

            //Act

            decimal actual = customer.ExchangeRate(FirstAccount, SecondAccount, 100);
            decimal expected = 100 / ExchangeRate;


            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_If_customer_U1_Added_By_AdminSetup_Method()
        {
            Admin admin = new Admin();
            admin.AdminSetup();

            var actual = admin.ListOfCustomers[0].UserName;
            var expected = "Hanna";

            Assert.AreEqual(actual, expected);



            
        }

    }
}
