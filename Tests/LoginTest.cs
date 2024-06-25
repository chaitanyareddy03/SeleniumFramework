using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumFramework.PageObjects;
using SeleniumFramework.Utilities;

namespace SeleniumFramework.Tests;

public class LoginTest : Base
{
    [Test]
    [TestCase("testuser1503@gmail.com", "testuser12")]
    public void Login_ValidCredentials_ShouldLoginSuccessfully(string username, string password)
    {
        try
        {
            var layoutPage = new LayoutPage(GetDriver());
            var loginPage = layoutPage.NavigateToLoginPage();
            var myAccountPage = loginPage.PerformLogin(username, password);
            var menuItems = myAccountPage.GetSideMenu();
            var itemNames = menuItems.Select(item => item.Text).ToList();
            Assert.That(itemNames, Does.Contain("Edit Account"));
            Assert.That(itemNames, Does.Contain("Logout"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [Test]
    [TestCase("testAdmin@gmail.com", "test@12", TestName = "Login_With_Valid_UserName_And_Invalid_Password")]
    [TestCase("test1@gmail.com", "test@12",TestName = "Login_With_Invalid_UserName_And_Valid_Password")]
    [TestCase("", "",TestName = "Login_With_Empty_UserName_And_Valid_Password")]
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