﻿using HerfaTest.Helpers;
using HerfaTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.AssistantMethods
{
    public class Login_AssistantMethods
    {
        public static void FillLoginForm(string email, string password)
        {
            LoginPage loginPage = new LoginPage(ManageDriver.driver);
            loginPage.EnterEmailAdd(email);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();

        }
    }
}
