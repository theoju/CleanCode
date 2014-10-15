//--------------------------------------------------------------------------
// <copyright file="ContactManagerTest.cs" company="none ">
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
using System.IO.Preparations;

using DesignItRight.Infrastructure.Common;
using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.Internal.CleanCodeDemo.ContactManagement;
using DesignItRight.Internal.CleanCodeDemo.ContactManagement.Moles;

using Microsoft.Moles.Framework.Moles;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// This class contains parameterized unit tests for ContactManager
    /// </summary>
    [PexClass(typeof(ContactManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ContactManagerTest
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Test stub for CanDelete(IContact)
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        [PexMethod]
        public OperationResult CanDelete([PexAssumeUnderTest] ContactManager target, IContact contact)
        {
            OperationResult result = target.CanDelete(contact);
            return result;

            // TODO: add assertions to method ContactManagerTest.CanDelete(ContactManager, IContact)
        }

        /// <summary>
        /// Test stub for CanLoad()
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        [PexMethod]
        public OperationResult CanLoad([PexAssumeUnderTest] ContactManager target)
        {
            OperationResult result = target.CanLoad();
            return result;

            // TODO: add assertions to method ContactManagerTest.CanLoad(ContactManager)
        }

        /// <summary>
        /// Test stub for CanSave(IContact)
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        [PexMethod]
        public OperationResult CanSave([PexAssumeUnderTest] ContactManager target, IContact contact)
        {
            OperationResult result = target.CanSave(contact);
            return result;

            // TODO: add assertions to method ContactManagerTest.CanSave(ContactManager, IContact)
        }

        /// <summary>
        /// Test stub for .ctor(ILogger, IContactPersistence)
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        /// <param name="contactPersistence">
        /// The contact Persistence. 
        /// </param>
        [PexMethod]
        public ContactManager Constructor(ILogger logger, IContactPersistence contactPersistence)
        {
            ContactManager target = new ContactManager(logger, contactPersistence);
            return target;

            // TODO: add assertions to method ContactManagerTest.Constructor(ILogger, IContactPersistence)
        }

        /// <summary>
        /// Test stub for Delete(IContact)
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        [PexMethod]
        public OperationResult Delete([PexAssumeUnderTest] ContactManager target, IContact contact)
        {
            OperationResult result = target.Delete(contact);
            return result;

            // TODO: add assertions to method ContactManagerTest.Delete(ContactManager, IContact)
        }

        /// <summary>
        /// Test stub for Load()
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        [PexMethod]
        public IContact Load([PexAssumeUnderTest] ContactManager target)
        {
            IContact result = target.Load();
            return result;

            // TODO: add assertions to method ContactManagerTest.Load(ContactManager)
        }

        /// <summary>
        /// Test stub for Save(IContact)
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        [PexMethod]
        [PexAllowedException(typeof(MoleNotImplementedException))]
        public OperationResult Save([PexAssumeUnderTest] ContactManager target, IContact contact)
        {
            OperationResult result = target.Save(contact);
            return result;

            // TODO: add assertions to method ContactManagerTest.Save(ContactManager, IContact)
        }

        /// <summary>
        /// The save throws mole not implemented exception 55.
        /// </summary>
        [TestMethod]
        [Ignore]
        [PexDescription("this test requires to run under the Pex profiler in order to reproduce")]
        [PexNotReproducible]
        [HostType("Moles")]
        public void SaveThrowsMoleNotImplementedException55()
        {
            Logger logger;
            SDummyExampleContactPersistence sDummyExampleContactPersistence;
            ContactManager contactManager;
            OperationResult operationResult;
            TextFileLoggingSink s0 = new TextFileLoggingSink();
            logger = LoggerFactory.Create(s0);
            sDummyExampleContactPersistence =
                new SDummyExampleContactPersistence((ILogger)logger);
            contactManager = ContactManagerFactory.Create
                (logger, (IContactPersistence)sDummyExampleContactPersistence);
            FileStreamPreparation.Prepare();
            Contact s1 = new Contact();
            s1.FirstName = null;
            s1.MiddleName = null;
            s1.LastName = null;
            s1.PhoneNumber = null;
            operationResult = Save(contactManager, s1);
        }

        #endregion
    }
}