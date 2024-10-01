using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using HerfaTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerfaTest.AssistantMethods;
using HerfaTest.Data;

namespace HerfaTest.TestMethods
{
    [TestClass]
    public class ContactUs_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\ZAID\\Desktop\\HerfaTest\\");

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            extentReports.Flush();
            ManageDriver.CloseDriver();
        }

        [TestMethod]
        public void TestValidData()
        {
            var test = extentReports.CreateTest("TestSuccessSendMessage", "verify that the user can send a message with vaild data ");

            try
            {
                CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(2);

                ContactUs_AssistantMethods.FillContactForm(contact1);

                Thread.Sleep(2000);
                bool expectedMessage = true;
                bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                Console.WriteLine("Message check completed successfully.");

                //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                test.Pass("Success Send Message");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethod.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }

        }
        [TestMethod]
        public void TestInvalidName()
        {
            var test = extentReports.CreateTest("TestInvalidName");
            for (int i = 3; i <= 5; i++)
            {
                try
                {
                    CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                    Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(i);

                    ContactUs_AssistantMethods.FillContactForm(contact1);

                    Thread.Sleep(2000);
                    bool expectedMessage = false;
                    bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                    Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                    Console.WriteLine("Message check completed successfully.");
                    //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                    test.Pass($"TC{i} Passed");
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethod.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }

            }


        }

        [TestMethod]
        public void TestInvalidEmail()
        {
            var test = extentReports.CreateTest("TestInvalidEmail");

            for (int i = 6; i <= 9; i++)
            {
                try
                {
                    CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                    Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(i);

                    ContactUs_AssistantMethods.FillContactForm(contact1);

                    Thread.Sleep(2000);

                    bool expectedMessage = false;
                    bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                    Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                    Console.WriteLine("Message check completed successfully.");
                    //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                    test.Pass($"TC{i} Passed");
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethod.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }
        }
        [TestMethod]
        public void TestPhoneNumber()
        {
            var test = extentReports.CreateTest("TestInvalidPhoneNumber");

            for (int i = 10; i <= 12; i++)
            {
                try
                {
                    CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                    Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(i);

                    ContactUs_AssistantMethods.FillContactForm(contact1);

                    Thread.Sleep(2000);

                    bool expectedMessage = false;
                    bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                    Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                    Console.WriteLine("Message check completed successfully.");
                    // Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                    test.Pass($"TC{i} Passed");
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethod.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }

        }
        [TestMethod]
        public void TestSubject()
        {
            var test = extentReports.CreateTest("TestInvalidSubject");

            try
            {
                CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(13);

                ContactUs_AssistantMethods.FillContactForm(contact1);

                Thread.Sleep(2000);
                bool expectedMessage = false;
                bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                Console.WriteLine("Message check completed successfully.");

                //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                test.Pass("TC13 Passed");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethod.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }
        [TestMethod]
        public void TestEmptySubject()
        {
            var test = extentReports.CreateTest("TestInvalidSubject");

            try
            {
                CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(14);

                ContactUs_AssistantMethods.FillContactForm(contact1);

                Thread.Sleep(2000);
                bool expectedMessage = true;
                bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                Console.WriteLine("Message check completed successfully.");

                //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                test.Pass("TC14 Passed");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethod.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }

        [TestMethod]
        public void TestMessage()
        {
            var test = extentReports.CreateTest("TestInvalidMessage");

            for (int i = 15; i <= 16; i++)
            {
                try
                {
                    CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                    Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(i);

                    ContactUs_AssistantMethods.FillContactForm(contact1);

                    Thread.Sleep(2000);

                    bool expectedMessage = false;
                    bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                    Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                    Console.WriteLine("Message check completed successfully.");
                    //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                    test.Pass($"TC{i} Passed");
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethod.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }

        }
        [TestMethod]
        public void TestEmptyForm()
        {
            var test = extentReports.CreateTest("TestEmptyForm");

        
                try
                {
                    CommonMethod.NavigateToURL("https://localhost:44349/Home/ContactUs");
                    Contact contact1 = ContactUs_AssistantMethods.ReadContactDataFromExcel(17);

                    ContactUs_AssistantMethods.FillContactForm(contact1);

                    Thread.Sleep(2000);
                bool expectedMessage = true;
                bool actualMessage = ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message);
                Assert.AreEqual(expectedMessage, actualMessage, "The actual message does not match the expected message.");
                Console.WriteLine("Message check completed successfully.");

                //Assert.IsTrue(ContactUs_AssistantMethods.CheckSuccessSendMessage(contact1.message));



                test.Pass("TC17 Passed");
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    string screenShotPath = CommonMethod.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }

        }
    }

