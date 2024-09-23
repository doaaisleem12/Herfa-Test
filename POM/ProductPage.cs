using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class ProductPage
    {
        IWebDriver _driver;
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }
        By ShoppingCart = By.XPath("//div/div[3]/ul/li/a");
        By AddProduct= By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div[2]/div[1]/form/button/p/i");
        public void ClickOnShoppingCart()
        {
            _driver.FindElement(ShoppingCart).Click();
        }
        public void ClickOnAddProduct()
        {
            _driver.FindElement(AddProduct).Click();
        }
    }
}
