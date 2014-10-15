//--------------------------------------------------------------------------
// <copyright file="DummyExampleContactPersistence.cs" company="none ">
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
using DesignItRight.CleanCodeDemo.ContactManagement;

namespace DesignItRight.Internal.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// Example implementation of the contact persistence with dummy code
    /// </summary>
    public class DummyExampleContactPersistence : IContactPersistence
    {
        #region -------------------- Constants and Fields --------------------
        private readonly ILogger logger;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyExampleContactPersistence"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        public DummyExampleContactPersistence(ILogger logger)
        {
            Contract.Requires(logger != null);
            Contract.Ensures(this.logger == logger);

            this.logger = logger;
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
        /// The operation result. 
        /// </returns>
        public OperationResult Save(IContact contact)
        {
            return CanSave(contact);
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
            //// NOTE: (TJ) here would the real logic go. Just return TRUE in this case.
            return new OperationResult();
        }

        /// <summary>
        /// Loads the contact object.
        /// </summary>
        /// <returns>
        /// The stored contact object 
        /// </returns>
        public IContact Load()
        {
            //// NOTE: (TJ) here would the real logic go. Just return a dummy contact in this case. 
            return CreateDummyContact();
        }

        /// <summary>
        /// Determines whether the contact can be loaded.
        /// </summary>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        public OperationResult CanLoad()
        {
            //// NOTE: (TJ) here would the real logic go. Just return TRUE in this case.
            return new OperationResult();
        }

        /// <summary>
        /// Deletes the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// The operation result. 
        /// </returns>
        public OperationResult Delete(IContact contact)
        {
            //// NOTE: (TJ) here would the real logic go. Just return the CanDelete result in this case.   
            return CanDelete(contact);
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
            //// NOTE: (TJ) here would the real logic go. Just return TRUE in this case.
            return new OperationResult();
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static Contact CreateDummyContact()
        {
            Contract.Ensures(Contract.Result<Contact>() != null);

            return new Contact { FirstName = @"Code Contract", MiddleName = @"Duplo", LastName = @"Man", PhoneNumber = @"(555)CleanCode-Man-Con" };
        }

        #endregion
    }
}