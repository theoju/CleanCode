//--------------------------------------------------------------------------
// <copyright file="ContactManagerFactory.cs" company="none ">
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

using DesignItRight.Infrastructure.Common.Logging;

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Explorable;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// A factory for DesignItRight.CleanCodeDemo.ContactManagement.ContactManager instances
    /// </summary>
    public static class ContactManagerFactory
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// A factory for DesignItRight.CleanCodeDemo.ContactManagement.ContactManager instances
        /// </summary>
        /// <param name="logger_iLogger">
        /// The logger_i Logger. 
        /// </param>
        /// <param name="contactPersistence_iContactPersistence">
        /// The contact Persistence_i Contact Persistence. 
        /// </param>
        [PexFactoryMethod(typeof(ContactManager))]
        public static ContactManager Create(
            ILogger logger_iLogger, 
            IContactPersistence contactPersistence_iContactPersistence
            )
        {
            ContactManager contactManager = PexInvariant.CreateInstance<ContactManager>();
            PexInvariant.SetField(contactManager, "logger", logger_iLogger);
            PexInvariant.SetField(
                contactManager, 
                "contactPersistence", 
                contactPersistence_iContactPersistence);
            PexInvariant.CheckInvariant(contactManager);
            return contactManager;

            // TODO: Edit factory method of ContactManager
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }

        #endregion
    }
}