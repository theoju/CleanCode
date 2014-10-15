//--------------------------------------------------------------------------
// <copyright file="Form1.cs" company="none ">
//     Copyright (CPOL) 1.02 Design IT Right
//     THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CODE 
//     PROJECT OPEN LICENSE ("LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT 
//     AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS 
//     AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS PROHIBITED.
//     BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HEREIN, YOU ACCEPT 
//     AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. THE AUTHOR GRANTS 
//     YOU THE RIGHTS CONTAINED HEREIN IN CONSIDERATION OF YOUR ACCEPTANCE OF 
//     SUCH TERMS AND CONDITIONS. IF YOU DO NOT AGREE TO ACCEPT AND BE BOUND 
//     BY THE TERMS OF THIS LICENSE, YOU CANNOT MAKE ANY USE OF THE WORK.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

using System;

namespace CleanCodeDemoAllInOne
{
    using System.IO;
    using System.Windows.Forms;

    using CleanCodeDemoAllInOne.Properties;

    /// <summary>
    ///     MainForm for the CleanCode Demo All In One example application
    /// </summary>
    public partial class SingleContactManagerForm : Form
    {
        // private const fields
        #region -------------------- Constants and Fields --------------------
        private const string LogFileName = @"c:\temp\CleanCodeDemoLogFile.log";
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        ///     Initializes a new instance of the <see cref="SingleContactManagerForm" /> class.
        /// </summary>
        public SingleContactManagerForm()
        {
            InitializeComponent();
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static bool CanSave(Contact contact)
        {
            OperationResult operationResult;

            operationResult = null;

            if (string.IsNullOrEmpty(contact.FirstName))
            {
                operationResult = new OperationResult("First name not set.");
            }

            if (string.IsNullOrEmpty(contact.LastName))
            {
                if (operationResult == null)
                {
                    operationResult = new OperationResult("Last name not set.");
                }
                else
                {
                    operationResult.Errors.Add("Last name not set;");
                }
            }

            return operationResult ?? new OperationResult();
        }

        private static OperationResult CanLoad()
        {
            // TODO: (TJ) Need to be implemented
            return new OperationResult();
        }

        private static OperationResult CanDelete()
        {
            // TODO: (TJ) Need to be implemented
            return new OperationResult();
        }

        private static Contact LoadContactInformation()
        {
            // TODO: (TJ) Load contact from DB, file, registry, remote call etc.
            return CreateDummyContact();
        }

        private static Contact CreateDummyContact()
        {
            return new Contact { FirstName = @"All in One", MiddleName = @"Duplo", LastName = @"Man", PhoneNumber = @"(555)CleanCode-All" };
        }

        private static OperationResult Save(Contact contact)
        {
            // NOTE: (TJ) success would be the real result in a real implementation.
            // bool success;

            // TODO: (TJ) Execute Save operation to DB, file, registry, remote call etc.
            return new OperationResult();

            // NOTE: (TJ) success would be the real result in a real implementation.
            // return success;
        }

        private OperationResult Delete()
        {
            SuspendLayout();
            DeleteUiElements();
            ResumeLayout();
            Refresh();

            // TODO: (TJ) Normally this could/would include any checks for success.
            return new OperationResult();
        }

        private Contact CreateContactFromUserInput()
        {
            return new Contact
                   {
                       FirstName = this.firstNameTextBox.Text, 
                       MiddleName = this.middleNameTextBox.Text, 
                       LastName = this.lastNameTextBox.Text, 
                       PhoneNumber = this.phoneNumberTextBox.Text
                   };
        }

        // Helper methods
        private void DisplayContact(Contact contact)
        {
            SuspendLayout();
            LoadContactIntoUi(contact);
            ResumeLayout();
            Refresh();
        }

        private void LoadContactIntoUi(Contact contact)
        {
            this.firstNameTextBox.Text = contact.FirstName;
            this.middleNameTextBox.Text = contact.MiddleName;
            this.lastNameTextBox.Text = contact.LastName;
            this.phoneNumberTextBox.Text = contact.PhoneNumber;
        }

        private void DeleteUiElements()
        {
            this.firstNameTextBox.Text = null;
            this.middleNameTextBox.Text = null;
            this.lastNameTextBox.Text = null;
            this.phoneNumberTextBox.Text = null;
        }

        private void UpdateStatusStrip(string statusText)
        {
            SuspendLayout();
            UpdateStatusStripeLabel(statusText);
            ResumeLayout();
            Refresh();
        }

        private void UpdateStatusStripeLabel(string statusText)
        {
            this.toolStripStatusLabel1.Text = statusText;
        }

        #endregion

        #region -------------------- EventHandlers --------------------
        private void Button1_Click(object sender, EventArgs e)
        {
            OperationResult operationResult;
            TextWriter textWriter;

            textWriter = new StreamWriter(LogFileName);

            textWriter.WriteLine("{0}  {1}", DateTime.Now, LoggingResources.SingleContactManagerForm_SaveContactStarting);

            operationResult = CanLoad();
            if (!operationResult)
            {
                textWriter.WriteLine(
                    "{0}  {1}", DateTime.Now, string.Format(LoggingResources.SingleContactManagerForm_SaveContact_Failed, operationResult));
            }
            else
            {
                Contact contact;

                contact = CreateContactFromUserInput();

                operationResult = Save(contact);

                textWriter.WriteLine("{0}  {1}", DateTime.Now, LoggingResources.SingleContactManagerForm_SaveContactCompleted);
            }

            UpdateStatusStrip(operationResult.ToString());

            textWriter.Close();
            textWriter.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OperationResult operationResult;
            TextWriter textWriter;

            textWriter = new StreamWriter(LogFileName);

            textWriter.WriteLine("{0}  {1}", DateTime.Now, LoggingResources.SingleContactManagerForm_LoadContactStarting);

            operationResult = CanLoad();
            if (!operationResult)
            {
                textWriter.WriteLine(
                    "{0}  {1}", DateTime.Now, string.Format(LoggingResources.SingleContactManagerForm_LoadContact_Failed, operationResult));
            }
            else
            {
                Contact contact;

                contact = LoadContactInformation();

                DisplayContact(contact);

                textWriter.WriteLine("{0}  {1}", DateTime.Now, LoggingResources.SingleContactManagerForm_LoadContactCompleted);
            }

            UpdateStatusStrip(operationResult.ToString());

            textWriter.Close();
            textWriter.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OperationResult operationResult;
            TextWriter textWriter;

            textWriter = new StreamWriter(LogFileName);

            textWriter.WriteLine("{0}  {1}", DateTime.Now, LoggingResources.SingleContactManagerForm_DeleteStarting);

            operationResult = CanDelete();

            textWriter.WriteLine(
                "{0}  {1}",
                DateTime.Now,
                operationResult && Delete()
                    ? LoggingResources.SingleContactManagerForm_DeleteCompleted
                    : string.Format(LoggingResources.SingleContactManagerForm_SaveContact_Failed, operationResult));

            UpdateStatusStrip(operationResult.ToString());

            textWriter.Close();
            textWriter.Dispose();
        }

        #endregion
    }
}