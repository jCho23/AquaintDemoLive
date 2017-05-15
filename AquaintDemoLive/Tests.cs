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
			app.WaitForElement(x => x.Class("android.widget.EditText").Index(0), timeout: TimeSpan.FromSeconds(80));
			//PRO-TIP: 'WaitForElement' is extremely useful when you need to slow down the test for the elements to populate on the page
			app.Tap(x => x.Class("android.widget.EditText").Index(0));
			app.EnterText("juneDemo");
			app.DismissKeyboard();
			app.Tap(x => x.Class("android.widget.Button"));
			//PRO-TIP: The test steps taken above will NOT appear in Test Cloud becuase I did not put screenshots

			app.Tap("acquaintanceListFloatingActionButton");
			app.Screenshot("Let's start by Tapping on the Floating Action Button to add a new contact");
			//PRO-TIP: Screenshots will enable to view the step definition in the Test Cloud portal 

			#region FirstName
			app.Tap("firstNameField");
			app.Screenshot("Then we Tapped on the 'First Name' Text Field");
			app.EnterText("Bill");
			app.Screenshot("We typed in our first name, 'Bill'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region LastName
			app.Tap("lastNameField");
			app.Screenshot("Next we Tapped on the 'Last Name' Text Field");
			app.EnterText("Gates");
			app.Screenshot("We typed in our first name, 'Gates'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region CompanyName
			app.Tap("companyField");
			app.Screenshot("Then we Tapped on the 'Company' Text Field");
			app.EnterText("Microsoft");
			app.Screenshot("We typed in our company, 'Microsoft'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region JobTitle
			app.Tap("jobTitleField");
			app.Screenshot("Then we Tapped on the 'Title' Text Field");
			app.EnterText("CEO");
			app.Screenshot("We typed in our title, 'CEO'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region PhoneNumber
			app.Tap("phoneNumberField");
			app.Screenshot("Then we Tapped on the 'Phone Number' Text Field");
			app.EnterText("1111111111");
			app.Screenshot("We typed in our phone number, '1111111111'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			app.Tap("acquaintanceSaveButton");
			app.Screenshot("Lastly, we saved our new contact");
		}

		[Test]
		public void CheckContactTest()
		{
			app.WaitForElement(x => x.Class("android.widget.EditText").Index(0), timeout: TimeSpan.FromSeconds(80));
			app.Tap(x => x.Class("android.widget.EditText").Index(0));
			app.Screenshot("Let's start by tapping on the 'Text Edit' Field");
			app.EnterText("juneDemo");
			app.Screenshot("We entered in our credentials");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			app.Tap(x => x.Class("android.widget.Button"));
			app.Screenshot("Then we Tapped on the 'Continue' Button");

			app.Tap("Gates, Bill");
			//PRO-TIP: We are using the name becuase it's the least brittle element 
			app.Screenshot("We confirmed our contact that we made");
		}

	}
}
