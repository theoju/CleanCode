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
namespace CleanCodeTheUgly
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    ///     MainForm for the CleanCode Demo All In One example application
    /// </summary>
    public partial class Form1 : Form
    {
        #region -------------------- Constructors and Destructors --------------------
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static Contact LoadContactInformation()
        {
            //// TODO: (TJ) Load contact from DB, file, registry, remote call etc.
            return CreateDummyContact();
        }

        private static Contact CreateDummyContact()
        {
            return new Contact { FirstName = @"The Ugly One", MiddleName = @"Duplo", LastName = @"Man", PhoneNumber = @"(555)CleanCode-The_Ugly" };
        }

        private Contact CrCoFrUsIn()
        {
            return new Contact
                       {
                           FirstName = this.firstNameTextBox.Text, 
                           MiddleName = this.middleNameTextBox.Text, 
                           LastName = this.lastNameTextBox.Text, 
                           PhoneNumber = this.phoneNumberTextBox.Text
                       };
        }

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

            this.toolStripStatusLabel1.Text = statusText;

            ResumeLayout();
            Refresh();
        }

        #endregion

        #region -------------------- EventHandlers --------------------
        private void Button1_Click(object sender, EventArgs e)
        {
            const string LgNm = @"c:\temp\CleanCodeDemoLogFile.log";
            TextWriter txWr;
            Contact obj;
            StringBuilder didIGetItRight;

            txWr = new StreamWriter(LgNm);

            txWr.WriteLine("{0}  {1}", DateTime.Now, "Starting saving contact information.");

            obj = CrCoFrUsIn();
            didIGetItRight = new StringBuilder();

            if (string.IsNullOrEmpty(obj.FirstName))
            {
                didIGetItRight.AppendLine("First name not set. ");
            }

            if (string.IsNullOrEmpty(obj.LastName))
            {
                didIGetItRight.AppendLine("Last name not set.");
            }

            if (didIGetItRight.Length > 0)
            {
                txWr.WriteLine("{0}  {1}", DateTime.Now, string.Format("Error: Could not save contact. {0}", didIGetItRight));
            }
            else
            {
                //// TODO: (TJ) Execute Save operation to DB, file, registry, remote call etc.
            }

            UpdateStatusStrip(didIGetItRight.ToString());

            txWr.WriteLine("{0}  {1}", DateTime.Now, "Contact information saved.");

            txWr.Close();
            txWr.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            const string LogFileName = @"c:\temp\CleanCodeDemoLogFile.log";

            TextWriter textWriter;
            Contact contact;

            textWriter = new StreamWriter(LogFileName);

            textWriter.WriteLine("{0}  {1}", DateTime.Now, "Starting loading contact information.");

            contact = LoadContactInformation();

            DisplayContact(contact);

            textWriter.WriteLine("{0}  {1}", DateTime.Now, "Contact information loaded.");

            UpdateStatusStrip(string.Empty);

            textWriter.Close();
            textWriter.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            DeleteUiElements();

            //// TODO: (TJ) Execute Delete operation on DB, file registry, remote call. 
            ResumeLayout();
            Refresh();
        }

        #endregion
    }
}