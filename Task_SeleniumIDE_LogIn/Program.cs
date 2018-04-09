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
    public class LogIN
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
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
        public void TheLogINTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            try
            {
                Assert.AreEqual("Google", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("lst-ib")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Пошук Google", driver.FindElement(By.Name("btnK")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("mail.ukr.net");
            driver.FindElement(By.Name("btnK")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Почта @ ukr.net - украинская электронная почта • Создать емейл")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Почта @ ukr.net - украинская электронная почта • Создать емейл")).Click();
            driver.FindElement(By.Id("id-2")).Clear();
            driver.FindElement(By.Id("id-2")).SendKeys("qwerty123");
            driver.FindElement(By.Id("id-1")).Clear();
            driver.FindElement(By.Id("id-1")).SendKeys("qwerty.for.test@ukr.net");
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//button[@type='submit']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("qwerty.for.test@ukr.net" == driver.FindElement(By.CssSelector("span.msglist__empty-email")).Text) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
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

