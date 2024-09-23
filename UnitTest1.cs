using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerfaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44349/Auth/RegisterUser");
            By FirstName = By.XPath("//div/input[@id='Fname']");
            By LastName = By.XPath("//div/input[@id='Lname']");
            By male = By.XPath("//div/input[@value='M']");
            By Female = By.XPath("//div/input[@value='F']");
            By birthdate = By.XPath("//div/input[@id='Dateofbirth']");
            By phoneNumber = By.XPath("//div/input[@id='Phonenumber']");
            By email = By.XPath("//div/input[@id='Email']");
            By image = By.XPath("//div/input[@id='ImageFileUser']");
            By Password = By.XPath("//div/input[@id='myPass']");
            By confirmPass = By.XPath("//div/input[@id='myPass2']");
            By submit = By.XPath("//div/button[@type='submit']");
            Thread.Sleep(5000);
            driver.FindElement(FirstName).SendKeys("Doa'a");
            driver.FindElement(LastName).SendKeys("Isleem");
            driver.FindElement(Female).Click();
            driver.FindElement(birthdate).SendKeys("07/14/2001");
            driver.FindElement(phoneNumber).SendKeys("0785852158");
            driver.FindElement(email).SendKeys("doaasaleem12@gmail.com");
            driver.FindElement(image).SendKeys("C:\\Users\\ZAID\\Desktop\\cvpic.jpg");
            driver.FindElement(Password).SendKeys("123456");
            driver.FindElement(confirmPass).SendKeys("123456");
            driver.FindElement(submit).Click();
            var expectedURL = "https://localhost:44349/Auth/Login";
            var actual = driver.Url;
            Assert.AreEqual(expectedURL , actual ,"Actual url not equal the expected ");
            Console.WriteLine("Test completed sucess ");
            //Thread.Sleep(10000);
            driver.Quit();
           
        }
    }
}