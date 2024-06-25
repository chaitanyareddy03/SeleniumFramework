using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.PageObjects;
using SeleniumFramework.Utilities;

namespace SeleniumFramework.Tests;

[Parallelizable(ParallelScope.Children)]
public class LoginTest : Base
{
    [Test, Category("Smoke")]
    [TestCase("testuser1503@gmail.com", "testuser12")]
    public void Login_ValidCredentials_ShouldLoginSuccessfully(string username, string password)
    {
        try
        {
            var layoutPage = new LayoutPage(GetDriver());
            var loginPage = layoutPage.NavigateToLoginPage();
            var myAccountPage = loginPage.PerformLogin(username, password);
            //myAccountPage.WaitForAccountPageDisplay();
            var menuItems = myAccountPage.GetSideMenu();
            var itemNames = menuItems.Select(item => item.Text).ToList();
            
        }
        catch (Exception e)
        {
            TestContext.WriteLine(e);
            throw;
        }
    }

    [Test]
    [TestCase("testAdmin@gmail.com", "test@12", TestName = "Login_With_Valid_UserName_And_Invalid_Password")]
    [TestCase("test1@gmail.com", "test@12",TestName = "Login_With_Invalid_UserName_And_Valid_Password")]
    [TestCase("", "",TestName = "Login_With_Empty_UserName_And_Valid_Password")]
    [Parallelizable(ParallelScope.All)]
    public void Login_InvalidCredentials_ShouldShowErrorMessage(string username, string password)
    {
        try
        {
            var layoutPage = new LayoutPage(GetDriver());
            var loginPage = layoutPage.NavigateToLoginPage();
            var myAccountPage = loginPage.PerformLogin(username, password);
            string error = loginPage.GetLblErrorMessageElement().Text;
            Assert.That(error, Does.Contain("Warning").IgnoreCase);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}