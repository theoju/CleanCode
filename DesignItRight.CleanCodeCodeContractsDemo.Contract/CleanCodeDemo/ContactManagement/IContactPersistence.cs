//--------------------------------------------------------------------------
// <copyright file="IContactPersistence.cs" company="none ">
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
using System.Diagnostics.Contracts;

using DesignItRight.Infrastructure.Common;

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    /// <summary>
    /// Interface for the persistence object responsible for Contracts
    /// </summary>
    [ContractClass(typeof(ContactPersistenceContract))]
    public interface IContactPersistence
    {
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
        OperationResult Save(IContact contact);

        /// <summary>
        /// Determines whether the contact can be saved.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        OperationResult CanSave(IContact contact);

        /// <summary>
        /// Loads the contact object.
        /// </summary>
        /// <returns>
        /// The stored contact object 
        /// </returns>
        IContact Load();

        /// <summary>
        /// Determines whether the contact can be loaded.
        /// </summary>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        OperationResult CanLoad();

        /// <summary>
        /// Deletes the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// The operation result. 
        /// </returns>
        OperationResult Delete(IContact contact);

        /// <summary>
        /// Determines whether the specified contact can be deleted.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// Operation Result including information about success of execution 
        /// </returns>
        OperationResult CanDelete(IContact contact);
        #endregion
    }

    /// <summary>
    /// The contact persistence contract.
    /// </summary>
    [ContractClassFor(typeof(IContactPersistence))]
    internal abstract class ContactPersistenceContract : IContactPersistence
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OperationResult Save(IContact contact)
        {
            Contract.Requires(contact != null);
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// The can save.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OperationResult CanSave(IContact contact)
        {
            Contract.Requires(contact != null);
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IContact Load()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The can load.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OperationResult CanLoad()
        {
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OperationResult Delete(IContact contact)
        {
            Contract.Requires(contact != null);
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// The can delete.
        /// </summary>
        /// <param name="contact">
        /// The contact. 
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public OperationResult CanDelete(IContact contact)
        {
            Contract.Requires(contact != null);
            Contract.Ensures(Contract.Result<OperationResult>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}