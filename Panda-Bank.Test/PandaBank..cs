using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaBank;

namespace Panda_Bank.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WithdrawMoney_Negative_Money_Test()
        {
            //Arrange 
            Customer test = new Customer();

            //Act

            //Assert
        }

        [TestMethod]
        [Description("This test about checking if ideal body weight" + "Of man with 180 cm height is equal to 72.5 ")]
        [Owner("Anas + Robin")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_Gender_M_And_Height_180_Return_72_5()
        {
            /// AAA 
            /// Arraange 
            WeightCalculator sut = new WeightCalculator
            {
                Gender = 'm',
                Height = 180
            };

            // Act
            var actual = sut.GetIdealBodyWeight();
            var expected = 72.5;

            // Assert
            Assert.AreEqual(expected, actual);
            //Assert.AreNotEqual(expected, actual);
        }
    }
}
