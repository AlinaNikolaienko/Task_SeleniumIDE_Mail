using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Drafts
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://mail.ukr.net//desktop#sendmsg";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheDraftsTest()
        {
            driver.FindElement(By.CssSelector("span.sidebar__list-link-name")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='content']/aside/button")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [mouseDownAt | xpath=.//*[@id='content']/aside/button | ]]
            driver.FindElement(By.XPath(".//*[@id='content']/aside/button")).Click();
            try
            {
                Assert.AreEqual("Написати листа", driver.FindElement(By.CssSelector("button.default.compose")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.Navigate().GoToUrl(baseURL + "desktop#sendmsg");
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.default.send")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Name("toInput")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Name("toInput")).Click();
            driver.FindElement(By.Name("toInput")).Clear();
            driver.FindElement(By.Name("toInput")).SendKeys("alina@mail.com");
            driver.FindElement(By.Name("subject")).Click();
            driver.FindElement(By.Name("subject")).Clear();
            driver.FindElement(By.Name("subject")).SendKeys("Hello!");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("#10002 > span.sidebar__list-link-count"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.CssSelector("#10002 > span.sidebar__list-link-name")).Click();
            driver.FindElement(By.XPath(".//*[@id='10002']/span[4]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
