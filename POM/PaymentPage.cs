using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class PaymentPage
    {
        IWebDriver _driver;
        public PaymentPage(IWebDriver driver) {
                _driver = driver; 
        }
        By CardholderName = By.XPath("//div/input[@name='cardholderame']");
        By CardNumber = By.XPath("//div/input[@name='cardNumber']");
        By CVV = By.XPath("//div/input[@name='cvv']");
        By ExpireDate = By.XPath("//div/input[@name='expire']");// By.CssSelector("input[placeholder='--/--/----']")
        By RememberMe = By.XPath("//div/input[@name='rememberMe']");
        By PayButton = By.XPath("//button[@type='submit']");
        By BackLink = By.XPath("//a/u[contains(text(), 'Back')]");

        public void EnterCardholderName(string value) {
            _driver.FindElement(CardholderName).SendKeys(value);
        }
        public void EnterCardNumber(string value)
        {
            _driver.FindElement(CardNumber).SendKeys(value);
        }
        public void EnterCVV(string value)
        {
            _driver.FindElement(CVV).SendKeys(value);
        }
        public void EnterExpireDate(string ExpireDate)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement expireElement = _driver.FindElement(By.Name("expire"));
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", expireElement, ExpireDate);
        }
        public void ClickRememberMe()
        {
            _driver.FindElement(RememberMe).Click();
        }
        public void ClickPayButton()
        {
            _driver.FindElement(PayButton).Click();
        }
        public void ClickBackLink()
        {
            _driver.FindElement(BackLink).Click();
        }

    }
}
