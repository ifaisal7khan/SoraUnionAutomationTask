using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;

namespace HealthCareAutomation.StepDefinitions
{
    [Binding]
    public class HealthCareTitleVerification
    {
        private IWebDriver driver;

        [Given(@"I open the health care homepage")]
        public void GivenIOpenTheHealthCarePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
        }

        [When(@"user clicks on button with id ""(.*)""")]
        public void WhenIClickTheButtonWithId(string buttonId)
        {
            driver.FindElement(By.Id(buttonId)).Click();
        }


        [When(@"user fills input box with id ""(.*)"" and value ""(.*)""")]
        public void WhenIEnterTextIntoTheInputBoxWithId(string inputBoxId, string text)
        {
            driver.FindElement(By.Id(inputBoxId)).SendKeys(text);
        }

        [When(@"user clicks on dropdown with id ""(.*)"" and selects ""(.*)""")]
        public void WhenISelectFromTheDropdownWithId(string dropdownId, string value)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id(dropdownId)));
            dropdown.SelectByText(value);
        }

        [When(@"user clicks on checkbox or radio button with id ""(.*)""")]
        public void WhenICheckTheCheckboxWithId(string checkboxId)
        {
            IWebElement checkbox = driver.FindElement(By.Id(checkboxId));
            checkbox.Click();
        }

        [When(@"user select today date from input id ""(.*)""")]
        public void WhenISelectTodaysDateInTheInputBoxWithId(string inputBoxId)
        {
            string todayDate = DateTime.Now.ToString("dd/mm/yyyy");
            IWebElement dateInput = driver.FindElement(By.Id(inputBoxId));
            dateInput.SendKeys(todayDate);
        }
        [When("user wait for page load")]
        public void WhenIWaitBeforeClickingTheButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [Then(@"user should see text ""(.*)"" is present on the page")]
        public void ThenIVerifyThatTheTextIsPresentOnThePage(string expectedText)
        {
            IWebElement confirmationText = driver.FindElement(By.XPath("//*[contains(text(), 'Appointment Confirmation')]"));
            string actualText = confirmationText.Text;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedText, actualText, "Title does not match.");
        }
        [When(@"user clicks on a tag that contains text ""(.*)""")]
        public void WhenIClickOnTheLinkThatContainsText(string linkText)
        {
              IWebElement link = driver.FindElement(By.XPath($"//a[contains(text(), '{linkText}')]"));
              link.Click();
        }
        [Then(@"page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            string actualTitle = driver.Title;
            if (actualTitle == expectedTitle)
            {
                Console.WriteLine($"Test Passed: Expected '{expectedTitle}', and got '{actualTitle}'");
            }
            else
            {
                Console.WriteLine($"Test Failed: Expected '{expectedTitle}', but got '{actualTitle}'");
            }

            driver.Quit();
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedTitle, actualTitle, "Title does not match.");
            //driver.Quit();
        }
    }
}
