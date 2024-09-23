using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class ShoppingCartPage
    {

        IWebDriver _driver;
        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }
        By CheckOut = By.XPath("//div/a[contains(text() , 'Checkout')]");
        public void ClickOnCheckOut()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement expireElement = _driver.FindElement(By.XPath("//div/a[contains(text() , 'Checkout')]"));
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", expireElement, CheckOut);

           //_driver.FindElement(CheckOut).Click();

        }
    }
}

 
