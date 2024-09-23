using HerfaTest.Helpers;
using HerfaTest.POM;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.TestMethods
{
    [TestClass]
    public class PaymentTestMethods
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ManageDriver.MaximizeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            ManageDriver.CloseDriver();
        }
       
        [TestMethod]
        //done 1
        public void TestEmptyCardDataSubmission()
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            Thread.Sleep(2000);
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            /*ShoppingCartPage shoppingCart= new ShoppingCartPage(ManageDriver.driver);
            shoppingCart.ClickOnCheckOut();*/

            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("");
            PaymentPage.EnterCardNumber("");
            PaymentPage.EnterCVV("");
            PaymentPage.EnterExpireDate("");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC1");
            Console.WriteLine("TC1 Completed Successfully");

        }
        [TestMethod]
        //done 2
        public void TestIncorrectVisaCard() {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("Mohammad");
            PaymentPage.EnterCardNumber("8888888888888888");
            PaymentPage.EnterCVV("000");
            PaymentPage.EnterExpireDate("2025-02");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC2");
            Console.WriteLine("TC2 Completed Successfully");

        }
        [TestMethod]
        //done  3
        public void TestInsufficientBalance()
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("Iyad Mohammad");
            PaymentPage.EnterCardNumber("8765432187654321");
            PaymentPage.EnterCVV("844");
            PaymentPage.EnterExpireDate("2026-01");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC3");
            Console.WriteLine("TC3 Completed Successfully");
        }
        [TestMethod]
        //Done 4 
        public void TestVisaCardPaymentProcess()
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("AhmadOmari");
            PaymentPage.EnterCardNumber("1234123412340000");
            PaymentPage.EnterCVV("357");
            PaymentPage.EnterExpireDate("2030-10");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/ShoppingCart";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC4");
            Console.WriteLine("TC4 Completed Successfully");
        }

        [TestMethod]
        //Done 5 
        public void TestMissingCVV() {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("BatoolJarrah");
            PaymentPage.EnterCardNumber("5555666677778907");
            PaymentPage.EnterCVV("");
            PaymentPage.EnterExpireDate("2025-03");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC5");
            Console.WriteLine("TC5 Completed Successfully");
        }
        [TestMethod]
        // Done 6
        public void TestIncorrectExpiryDateFormat()
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("BatoolJarrah");
            PaymentPage.EnterCardNumber("5555666677778907");
            PaymentPage.EnterCVV("379");
            PaymentPage.EnterExpireDate("2025/3");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC6");
            Console.WriteLine("TC6 Completed Successfully");
        }

        [TestMethod]
        // Done 7
        public void TestExpiredCard()//Bug 
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("qusayqa");
            PaymentPage.EnterCardNumber("5555666677778888");
            PaymentPage.EnterCVV("555");
            PaymentPage.EnterExpireDate("2023-02");
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/PayForTheOrder";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC7");
            Console.WriteLine("TC7 Completed Successfully");
        }
        [TestMethod] 
        //Done 8
        public void TestBackLink()
        {
            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
           LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            //HomePage homePage = new HomePage(ManageDriver.driver);
            //homePage.ClickOnProductInHeader();
            //Thread.Sleep(2000);
            //ProductPage productPage = new ProductPage(ManageDriver.driver);
            //productPage.ClickOnAddProduct();
            //productPage.ClickOnShoppingCart();
           // Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.ClickBackLink();
            Thread.Sleep(5000);
            var Expected = "https://localhost:44349/User/ShoppingCart";
                var Actual = ManageDriver.driver.Url;

                Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC8");
                Console.WriteLine("TC8 Completed Successfully");
            }
        [TestMethod]
        //test9

        public void TestRememberMe()
        {

            CommonMethod.NavigateToURL("https://localhost:44349/Auth/Login");
            Thread.Sleep(2000);
            LoginPage LoginPage = new LoginPage(ManageDriver.driver);
            LoginPage.EnterEmailAdd("INNABinnab@hotmail.com");
            LoginPage.EnterPassword("123456");
            LoginPage.ClickLoginButton();
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(ManageDriver.driver);
            homePage.ClickOnProductInHeader();
            Thread.Sleep(2000);
            ProductPage productPage = new ProductPage(ManageDriver.driver);
            productPage.ClickOnAddProduct();
            productPage.ClickOnShoppingCart();
            Thread.Sleep(2000);
            CommonMethod.NavigateToURL("https://localhost:44349/User/PayForTheOrder");
            Thread.Sleep(2000);
            PaymentPage PaymentPage = new PaymentPage(ManageDriver.driver);
            PaymentPage.EnterCardholderName("AhmadOmari");
            PaymentPage.EnterCardNumber("1234123412340000");
            PaymentPage.EnterCVV("357");
            PaymentPage.EnterExpireDate("2030-10");
            PaymentPage.ClickRememberMe();
            PaymentPage.ClickPayButton();
            Thread.Sleep(5000);

            var Expected = "https://localhost:44349/User/ShoppingCart";
            var Actual = ManageDriver.driver.Url;

            Assert.AreEqual(Expected, Actual, "Actual URL not equal the expected URL_TC9");
            Console.WriteLine("TC9 Completed Successfully");
        }
        }

    }

