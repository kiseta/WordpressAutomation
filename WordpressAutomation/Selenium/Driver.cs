using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WordpressAutomation
{
    public class Driver
    {

    public static IWebDriver Instance { 
					get; set; 
				}

		public static string BaseAddress { 
					get { return "http://localhost/testsite/"; }
				}

		public static void Initialize(){
						Instance = new ChromeDriver();
						TurnOnWait();
				}

		public static void Close() {
            Instance.Close();
        }

		public static void Wait(TimeSpan timeSpan){
						Thread.Sleep((int) timeSpan.TotalSeconds * 1000);
				}

		public static void NoWait(Action action) {
					TurnOffWait();
					action();
					TurnOnWait();
				}

		private static void TurnOnWait(){
					Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
				}

		private static void TurnOffWait(){
			Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
		}
	}
}