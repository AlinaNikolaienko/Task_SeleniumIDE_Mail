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
    public class ROZETKALGUpTo10000uah
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
        public void TheROZETKALGUpTo10000uahTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("lst-ib")).GetAttribute("value"));
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
            driver.FindElement(By.Id("lst-ib")).SendKeys("rozetka");
            driver.FindElement(By.Name("btnK")).Click();
            try
            {
                Assert.AreEqual("rozetka - Пошук Google", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector(".r>a")).Click();
            try
            {
                Assert.AreEqual("Интернет-магазин ROZETKA™: фототехника, видеотехника, аудиотехника, компьютеры и компьютерные комплектующие", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Бытовая техника")).Click();
            try
            {
                Assert.AreEqual("Бытовая техника - Rozetka.ua | Магазин бытовой техники в Киеве, Харькове, Одессе, Львове: цена, отзывы, продажа, купить оптом бытовую технику", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Стиральные машины")).Click();
            try
            {
                Assert.AreEqual("Стиральные машины - Rozetka.ua | Стиральная машина в Киеве, Харькове, Одессе, Львове: цена, отзывы, продажа, купить оптом стиральную машину", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("LG")).Click();
            try
            {
                Assert.AreEqual("Стиральные машины LG купить в Киеве: цена, отзывы, продажа | Rozetka.ua", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("price[max]")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("price[max]")).Click();
            driver.FindElement(By.Id("price[max]")).Clear();
            driver.FindElement(By.Id("price[max]")).SendKeys("10000");
            driver.FindElement(By.Id("submitprice")).Click();
            driver.FindElement(By.LinkText("Стиральная машина узкая LG FH0B8ND + 0% кредит+ бесплатное подключение в подарок!")).Click();
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
