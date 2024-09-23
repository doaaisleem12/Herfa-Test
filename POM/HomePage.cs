using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class HomePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        By Product = By.XPath("//li/a[contains (text() ,'Products')]");
        public void ClickOnProductInHeader()
        {
            _driver.FindElement(Product).Click();
        }
    }
}
