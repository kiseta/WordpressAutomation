using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests
{
	public class WordpressTests
	{

		[TestInitialize]
		public void Init(){
			Driver.Initialize();
			PostCreator.Initialize();

			LoginPage.GoTo();
			LoginPage.LoginAs("admin").WithPassword("pass").Login();
		}


		[TestCleanup]
		public void Cleanup(){

			PostCreator.Cleanup();
			Driver.Close();
		}

	}
}
