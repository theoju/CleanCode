// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactManagerTest.CanSave.g.cs" company="">
// </copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
// <summary>
//   The contact manager test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DesignItRight.Infrastructure.Common;
using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.Internal.CleanCodeDemo.ContactManagement;
using DesignItRight.Internal.CleanCodeDemo.ContactManagement.Moles;

using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// The contact manager test.
    /// </summary>
    public partial class ContactManagerTest
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// The can save 75.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave75()
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
            operationResult = CanSave(contactManager, null);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(false, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        /// <summary>
        /// The can save 304.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave304()
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
            Contact s1 = new Contact();
            s1.FirstName = null;
            s1.MiddleName = null;
            s1.LastName = null;
            s1.PhoneNumber = null;
            operationResult = CanSave(contactManager, s1);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(false, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        /// <summary>
        /// The can save 820.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave820()
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
            Contact s1 = new Contact();
            s1.FirstName = "\0";
            s1.MiddleName = null;
            s1.LastName = null;
            s1.PhoneNumber = null;
            operationResult = CanSave(contactManager, s1);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(false, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        /// <summary>
        /// The can save 169.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave169()
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
            Contact s1 = new Contact();
            s1.FirstName = null;
            s1.MiddleName = null;
            s1.LastName = "\0";
            s1.PhoneNumber = null;
            operationResult = CanSave(contactManager, s1);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(false, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        /// <summary>
        /// The can save 834.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave834()
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
            Contact s1 = new Contact();
            s1.FirstName = "\0";
            s1.MiddleName = null;
            s1.LastName = "\0";
            s1.PhoneNumber = null;
            operationResult = CanSave(contactManager, s1);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(true, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        /// <summary>
        /// The can save 7501.
        /// </summary>
        [TestMethod]
        [PexGeneratedBy(typeof(ContactManagerTest))]
        public void CanSave7501()
        {
            Logger logger;
            DummyExampleContactPersistence dummyExampleContactPersistence;
            ContactManager contactManager;
            OperationResult operationResult;
            TextFileLoggingSink s0 = new TextFileLoggingSink();
            logger = LoggerFactory.Create(s0);
            dummyExampleContactPersistence =
                DummyExampleContactPersistenceFactory.Create(logger);
            contactManager = ContactManagerFactory.Create
                (logger, dummyExampleContactPersistence);
            operationResult = CanSave(contactManager, null);
            Assert.IsNotNull(operationResult);
            Assert.AreEqual(false, operationResult.Success);
            Assert.IsNotNull(contactManager);
        }

        #endregion
    }
}