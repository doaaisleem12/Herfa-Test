using Bytescout.Spreadsheet;
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
    public class ContactUs_AssistantMethods
    {
        public static void FillContactForm(Contact contact)
        {
            ContactUsPage contactUsPage = new ContactUsPage(ManageDriver.driver);
            contactUsPage.EnterName(contact.name);
            contactUsPage.EnterEmail(contact.email);
            contactUsPage.EnterSubject(contact.subject);
            contactUsPage.EnterPhoneNumber(contact.phone);
            contactUsPage.EnterMessage(contact.message);
            contactUsPage.ClickCheckBox();
            contactUsPage.ClickSubmitButton();
        }

        public static Contact ReadContactDataFromExcel(int row)
        {
            Contact contact  = new Contact();
            Worksheet worksheet = CommonMethod.ReadExcel("ContactUs");

            contact.name = Convert.ToString(worksheet.Cell(row, 2).Value);
            contact.phone = (string)worksheet.Cell(row, 4).Value;
            contact.email = (string)worksheet.Cell(row, 3).Value;
            contact.subject = Convert.ToString(worksheet.Cell(row, 5).Value);
            contact.message = Guid.NewGuid().ToString () + Convert.ToString( worksheet.Cell(row, 6).Value);
            return contact;
        }

        public static bool CheckSuccessSendMessage( string message)
        {
            bool isDataExist = false;
            string query = "Select COUNT(*) from contactus_fp where message = :message";

            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                connection.Open();

                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":message", message));

                int result = Convert.ToInt32(command.ExecuteScalar());

                isDataExist = result > 0;
            }

            return isDataExist;
        }
    }
}
 
