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

using System;

using DesignItRight.Infrastructure.Common;
using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.CleanCodeDemo.ContactManagement;

using Microsoft.Practices.Unity;

namespace DesignItRight.Internal.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// The dummy example contact persistence.
    /// </summary>
    public class DummyExampleContactPersistence : IContactPersistence
    {
        #region -------------------- Constants and Fields --------------------
        private ILogger logger;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyExampleContactPersistence"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        [InjectionConstructor]
        public DummyExampleContactPersistence(ILogger logger)
        {
            this.logger = logger;
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
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
            //// NOTE: (TJ) here would the real logic go. Just return the CanSave result in this case.   
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
            return new Contact
                   {
                       FirstName = @"CleanCode", 
                       MiddleName = @"Duplo", 
                       LastName = @"Man", 
                       PhoneNumber = @"(555)CleanCode-Man-Unity"
                   };
        }

        #endregion
    }
}