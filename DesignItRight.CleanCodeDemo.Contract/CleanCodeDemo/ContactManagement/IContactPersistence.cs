//--------------------------------------------------------------------------
// <copyright file="IContactPersistence.cs" company="none ">
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

namespace DesignItRight.CleanCodeDemo.ContactManagement
{
    using DesignItRight.Infrastructure.Common;

    /// <summary>
    ///   The i contact persistence.
    /// </summary>
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
        ///   Loads the contact object.
        /// </summary>
        /// <returns> The stored contact object </returns>
        IContact Load();

        /// <summary>
        ///   Determines whether the contact can be loaded.
        /// </summary>
        /// <returns> Operation Result including information about success of execution </returns>
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
}