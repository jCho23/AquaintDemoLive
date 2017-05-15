using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AquaintDemoLive
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);

			app.Screenshot("App Launched");
			//This is an easy way to make sure that the app successfully launches before the tests begin
			app.WaitForElement(x => x.Marked("setupDataPartitionPhraseField"), timeout: TimeSpan.FromSeconds(80));
			//'app.WaitForElement' is inputed here because we want all the elements that we want to interact with to populate before we run any tests
		}

		[Test]
		public void Repl()
		{
			app.Repl();
			//The REPL is a console-like environment in which the developer enters expressions or commands
			//It will then evaluate those expressions, and display the results to the user
		}


		[Test]
		public void AddContactTest()
		//PRO-TIP: Naming conventions of tests should reflect a behavioral user action 
		{

		}

	}
}
