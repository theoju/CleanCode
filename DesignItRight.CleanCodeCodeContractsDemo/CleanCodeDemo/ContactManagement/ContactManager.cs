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

using System.Diagnostics.Contracts;

using DesignItRight.Infrastructure.Common;
using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.Properties;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// Example implementation of the contact manager
    /// </summary>
    public class ContactManager : IContactManager
    {
        #region -------------------- Constants and Fields --------------------
        private readonly ILogger logger;
        private readonly IContactPersistence contactPersistence;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        /// <param name="contactPersistence">
        /// The contact persistence. 
        /// </param>
        public ContactManager(ILogger logger, IContactPersistence contactPersistence)
        {
            Contract.Requires(logger != null);
            Contract.Requires(contactPersistence != null);
            Contract.Ensures(this.logger == logger);
            Contract.Ensures(this.contactPersistence == contactPersistence);

            this.logger = logger;
            this.contactPersistence = contactPersistence;
        }

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
                operationResult = this.contactPersistence.Save(contact);
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
            Contract.Ensures(Contract.Result<OperationResult>() != null);
            Contract.Ensures((contact == null && Contract.Result<OperationResult>() == false) || contact != null);

            OperationResult operationResult;

            operationResult = ValidateContactIsNotNull(contact);

            if (operationResult)
            {
                if (string.IsNullOrEmpty(contact.FirstName))
                {
                    operationResult.AddErrorMessage("First name not set.");
                }

                if (string.IsNullOrEmpty(contact.LastName))
                {
                    operationResult.AddErrorMessage("Last name not set;");
                }
            }

            if (operationResult)
            {
                this.contactPersistence.CanSave(contact);
            }

            return operationResult;
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

            Contract.Assert(operationResult != null);

            if (!operationResult)
            {
                contact = null;

                this.logger.Log(string.Format(LoggingResources.ContactManager_LoadContactFailed, operationResult));
            }
            else
            {
                contact = this.contactPersistence.Load();

                this.logger.Log(
                    contact == null
                        ? string.Format(LoggingResources.ContactManager_LoadContactFailed, LoggingResources.ContactManager_LoadFailedContactWasNull)
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
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            //// Note: (TJ) Here would be additionally logic besides the shown one.
            return this.contactPersistence.CanLoad();
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
                this.logger.Log(string.Format(LoggingResources.ContactManager_DeleteContactFailed, operationResult));
            }
            else
            {
                operationResult = this.contactPersistence.Delete(contact);

                this.logger.Log(
                    contact == null
                        ? string.Format(LoggingResources.ContactManager_DeleteContactFailed, LoggingResources.ContactManager_LoadFailedContactWasNull)
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
            Contract.Ensures(Contract.Result<OperationResult>() != null);
            Contract.Ensures((contact == null && Contract.Result<OperationResult>() == false) || contact != null);

            OperationResult operationResult;

            operationResult = ValidateContactIsNotNull(contact);

            //// Note: (TJ) Here would be additionally logic besides the shown one.
            return operationResult ? this.contactPersistence.CanDelete(contact) : operationResult;
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static OperationResult ValidateContactIsNotNull(IContact contact)
        {
            Contract.Ensures(Contract.Result<OperationResult>() != null);
            Contract.Ensures((contact == null && Contract.Result<OperationResult>() == false) || contact != null);

            return contact == null ? new OperationResult("LoggingResources.ContactManager_ContactIsNull") : new OperationResult();
        }

        // Code Contracts helper methods
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.contactPersistence != null);
            Contract.Invariant(this.logger != null);
        }

        #endregion
    }
}