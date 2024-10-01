using HerfaTest.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class ContactUsPage
    {
        IWebDriver _driver;

        public ContactUsPage(IWebDriver driver)
        {
            _driver = driver;
        }



        By name = By.XPath("//div/input[@id='Name']");
        By email = By.XPath("//div/input[@id='Email'] ");
        By Phone = By.XPath("//div/input[@id='Phonenumber']");
        By subject = By.XPath("//div/input[@id='Subject']");
        By message = By.XPath("//div/textarea[@id='Message']");
        By checkBox = By.XPath("//div/input[@id='copy']");
        By submitButton = By.XPath("//div/button[contains(text(), 'Submit')]");

        public void EnterName(string value)
        {
            IWebElement element = CommonMethod.WaitAndFindElement(name);
            CommonMethod.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethod.WaitAndFindElement(email);
            CommonMethod.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterPhoneNumber(string value)
        {
            IWebElement element = CommonMethod.WaitAndFindElement(Phone);
            CommonMethod.HighlightElement(element);
           
            element.SendKeys(value);
        }
        public void EnterSubject(string value)
        {
            IWebElement element = CommonMethod.WaitAndFindElement(subject);
            CommonMethod.HighlightElement(element);
            element.SendKeys(value);
        }
        public void EnterMessage(string value)
        {
            IWebElement element = CommonMethod.WaitAndFindElement(message);
            CommonMethod.HighlightElement(element);
            element.SendKeys(value);
        }
        public void ClickCheckBox()
        {
            CommonMethod.WaitAndFindElement(checkBox).Click();
        }
        public void ClickSubmitButton()
        {
            CommonMethod.WaitAndFindElement(submitButton).Click();
        }


    }
}
