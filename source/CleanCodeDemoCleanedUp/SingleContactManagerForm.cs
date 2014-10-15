//--------------------------------------------------------------------------
// <copyright file="SingleContactManagerForm.cs" company="none ">
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
namespace CleanCodeDemoCleanedUp
{
    using System;
    using System.Windows.Forms;

    using DesignItRight.CleanCodeDemo.ContactManagement;
    using DesignItRight.Infrastructure.Common;
    using DesignItRight.Internal.CleanCodeDemo.ContactManagement;

    /// <summary>
    ///     MainForm for the CleanCode Demo All In One example application
    /// </summary>
    public partial class SingleContactManagerForm : Form
    {
        #region -------------------- Constants and Fields --------------------
        private IContactManager contactManager;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        ///     Initializes a new instance of the <see cref="SingleContactManagerForm" /> class.
        /// </summary>
        public SingleContactManagerForm()
        {
            InitializeComponent();
            Initialize();
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private void Initialize()
        {
            this.contactManager = new ContactManager();
        }

        private void SaveContact()
        {
            OperationResult operationResult;
            IContact contact;

            contact = CreateContactFromUserInput();

            operationResult = this.contactManager.Save(contact);

            UpdateStatusStrip(operationResult.ToString());
        }

        private void LoadContact()
        {
            OperationResult operationResult;

            operationResult = this.contactManager.CanLoad();
            if (operationResult)
            {
                IContact contact;

                contact = this.contactManager.Load();
                if (contact != null)
                {
                    DisplayContact(contact);
                }
            }

            UpdateStatusStrip(operationResult.ToString());
        }

        private void DeleteContact()
        {
            OperationResult operationResult;
            IContact contact;

            contact = CreateContactFromUserInput();

            operationResult = this.contactManager.Delete(contact);
            if (operationResult)
            {
                CleareUiElements();
            }

            UpdateStatusStrip(operationResult.ToString());
        }

        // Helper methods unchanged
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

        private void DisplayContact(IContact contact)
        {
            SuspendLayout();
            LoadContactIntoUi(contact);
            ResumeLayout();
            Refresh();
        }

        private void LoadContactIntoUi(IContact contact)
        {
            this.firstNameTextBox.Text = contact.FirstName;
            this.middleNameTextBox.Text = contact.MiddleName;
            this.lastNameTextBox.Text = contact.LastName;
            this.phoneNumberTextBox.Text = contact.PhoneNumber;
        }

        private void CleareUiElements()
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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadContact();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        #endregion
    }
}