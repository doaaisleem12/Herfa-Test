﻿using Bytescout.Spreadsheet;
using HerfaTest.Data;
using HerfaTest.Helpers;
using HerfaTest.POM;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.AssistantMethods
{
    public class UserRegister_AssistantMethods
    {
        public static void FillRegisterForm(User user)
        {
            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);
            userRegisterPage.EnterFirstName(user.firstName);
            userRegisterPage.EnterLastName(user.lastName);
            userRegisterPage.EnterEmail(user.email);
            userRegisterPage.EnterBirthdate(user.Birthdate);
            userRegisterPage.EnterPhoneNumber(user.phoneNumber);
            if (user.gender == Gender.Male)
            {
                userRegisterPage.ClickMaleButton();
            }
            else if (user.gender == Gender.Female)
            {
                userRegisterPage.ClickFemaleButton();
            }
            userRegisterPage.EnterPassword(user.password);
            userRegisterPage.EnterConfirmPassword(user.confirmPassword);
            userRegisterPage.ClickSubmitButton();
        }

        public static User ReadRegisterDataFromExcel(int row)
        {
            User user = new User();
            Worksheet worksheet = CommonMethod.ReadExcel("Register");

            user.firstName = Convert.ToString(worksheet.Cell(row, 2).Value);
            user.lastName = (string)worksheet.Cell(row, 3).Value;
            user.email = (string)worksheet.Cell(row, 4).Value;
            user.phoneNumber = Convert.ToString(worksheet.Cell(row, 5).Value);
            user.gender = (Gender)Enum.Parse(typeof(Gender), (string)worksheet.Cell(row, 6).Value);
            user.Birthdate = Convert.ToString(worksheet.Cell(row, 7));
            user.password = Convert.ToString(worksheet.Cell(row, 8).Value);
            user.confirmPassword = Convert.ToString(worksheet.Cell(row, 9).Value);
            return user;
        }

        public static bool CheckSuccessRegister(string email)
        {
            bool isDataExist = false;
            string query = "Select count(*) from login_fp where email = :value";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":value", email));

                int result = Convert.ToInt32(command.ExecuteScalar());

                isDataExist = result > 0;
                return isDataExist;

            }
        }
    }
}