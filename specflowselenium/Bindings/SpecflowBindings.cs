using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace specflowselenium.Bindings
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;

    [Binding]
    class SpecflowBindings
    {
        private static IWebDriver Driver;
        
        [AfterScenario]
        public static void CloseBrowser()
        {
            Driver.Quit();;
        }

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            Driver = new FirefoxDriver();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        [When(@"I click on the '(.*)'")]
        public void WhenIClickOnThe(string Link)
        {
            Driver.FindElement(By.PartialLinkText(Link)).Click();        
        }

        [Then(@"a link with text '(.*)' must be present")]
        public void ThenALinkWithTextMustBePresent(string LinkText)
        {
            IWebElement webElement =  new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(
                driver => driver.FindElement(By.PartialLinkText(LinkText)));
            Assert.IsTrue(webElement.Displayed);
        }

        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void ThenTheBoxMustContainAtIndex(string BoxValue, string ExpectedValue, string Index)
        {
            IWebElement root = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(driver =>
                driver.FindElement(By.XPath(String.Format("//h2[text()='{0}']/parent::div", BoxValue))));
            var ActualValue = root.FindElement(By.XPath($"ul/li[{Index}]/a")).Text;

            Assert.AreEqual(ExpectedValue, ActualValue);
        }
    }
}
