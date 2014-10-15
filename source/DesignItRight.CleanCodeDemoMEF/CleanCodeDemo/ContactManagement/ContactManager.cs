//--------------------------------------------------------------------------
// <copyright file="ContactManager.cs" company="none ">
//     Copyright (CPOL) 1.02 Design IT Right
//
//     THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CODE 
//     PROJECT OPEN LICENSE ("LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT 
//     AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS 
//     AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS PROHIBITED.
//
//     BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HEREIN, YOU ACCEPT 
//     AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. THE AUTHOR GRANTS 
//     YOU THE RIGHTS CONTAINED HEREIN IN CONSIDERATION OF YOUR ACCEPTANCE OF 
//     SUCH TERMS AND CONDITIONS. IF YOU DO NOT AGREE TO ACCEPT AND BE BOUND 
//     BY THE TERMS OF THIS LICENSE, YOU CANNOT MAKE ANY USE OF THE WORK.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;

using DesignItRight.Infrastructure.Common;
using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.Properties;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// The contact manager.
    /// </summary>
    [Export(typeof(IContactManager))]
    public class ContactManager : IContactManager
    {
        #region -------------------- Constants and Fields --------------------
        private readonly ILogger logger;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        [ImportingConstructor]
        public ContactManager(ILogger logger)
        {
            this.logger = logger;
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
        }

        #endregion

        #region -------------------- Public Properties --------------------

        /// <summary>
        ///   Gets or sets the contact persistence.
        /// </summary>
        /// <value> The contact persistence. </value>
        [Import]
        public Lazy<IContactPersistence> ContactPersistence { get; set; }
        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Saves the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult Save(IContact contact)
        {
            OperationResult operationResult;

            this.logger.Log(LoggingResources.ContactManager_SaveContactStarting);

            operationResult = CanSave(contact);

            if (operationResult)
            {
                operationResult = ContactPersistence.Value.Save(contact);
            }

            this.logger.Log(
                operationResult
                    ? LoggingResources.ContactManager_SaveContactCompleted
                    : string.Format(LoggingResources.ContactManager_SaveContact_Failed, operationResult));

            return operationResult;
        }

        /// <summary>
        /// Determines whether the contact can be saved.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult CanSave(IContact contact)
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

            if (operationResult == null)
            {
                ContactPersistence.Value.CanSave(contact);
            }

            return operationResult ?? new OperationResult();
        }

        /// <summary>
        /// Loads the contact object.
        /// </summary>
        /// <returns>
        /// The stored contact object 
        /// </returns>
        public IContact Load()
        {
            OperationResult operationResult;
            IContact contact;

            this.logger.Log(LoggingResources.ContactManager_LoadContactStarting);

            operationResult = CanLoad();
            if (!operationResult)
            {
                contact = null;

                this.logger.Log(
                    string.Format(LoggingResources.ContactManager_LoadContactFailed, operationResult));
            }
            else
            {
                contact = ContactPersistence.Value.Load();

                this.logger.Log(
                    contact == null
                        ? string.Format(
                            LoggingResources.ContactManager_LoadContactFailed, LoggingResources.ContactManager_LoadFailedContactWasNull)
                        : LoggingResources.ContactManager_LoadContactCompleted);
            }

            return contact;
        }

        /// <summary>
        /// Determines whether the contact can be loaded.
        /// </summary>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult CanLoad()
        {
            //// Note: (TJ) Here would be additionally logic besides the shown one.
            return ContactPersistence.Value.CanLoad();
        }

        /// <summary>
        /// Deletes the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult Delete(IContact contact)
        {
            OperationResult operationResult;

            this.logger.Log(LoggingResources.ContactManager_DeleteContactStarting);

            operationResult = CanDelete(contact);
            if (!operationResult)
            {
                this.logger.Log(
                    string.Format(LoggingResources.ContactManager_DeleteContactFailed, operationResult));
            }
            else
            {
                operationResult = ContactPersistence.Value.Delete(contact);

                this.logger.Log(
                    contact == null
                        ? string.Format(
                            LoggingResources.ContactManager_DeleteContactFailed, LoggingResources.ContactManager_LoadFailedContactWasNull)
                        : LoggingResources.ContactManager_DeleteContactCompleted);
            }

            return operationResult;
        }

        /// <summary>
        /// Determines whether the specified contact can be deleted.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult CanDelete(IContact contact)
        {
            //// Note: (TJ) Here would be additionally logic besides the shown one.
            return ContactPersistence.Value.CanDelete(contact);
        }

        #endregion
    }
}