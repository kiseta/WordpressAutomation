using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
	[TestClass]
    public class LoginTests: WordpressTests
	{

        [TestMethod]
        public void Admin_User_Can_Login()
        {

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }

    }
}
