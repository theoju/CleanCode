//--------------------------------------------------------------------------
// <copyright file="IContactPersistence.cs" company="Omnicell Inc.">
//     Copyright (c) Omnicell Inc. All rights reserved.
//
//     Reproduction or transmission in whole or in part, in 
//     any form or by any means, electronic, mechanical, or otherwise, is 
//     prohibited without the prior written consent of the copyright owner.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

using Jungeblut.Infrastructure.Common;

namespace Jungeblut.LegoDemo.ContactManagement
{
    public interface IContactPersistence
    {
        #region ---------------------- Methods ----------------------
        #region Save
        /// <summary>
        /// Saves the specified contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The operation result.</returns>
        OperationResult Save(IContact contact);
        #endregion

        #region CanSave
        /// <summary>
        /// Determines whether the contact can be saved.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>Operation Result including information about success of execution</returns>
        OperationResult CanSave(IContact contact);
        #endregion

        #region Load
        /// <summary>
        /// Loads the contact object.
        /// </summary>
        /// <returns>The stored contact object</returns>
        IContact Load();
        #endregion

        #region CanLoad
        /// <summary>
        /// Determines whether the contact can be loaded.
        /// </summary>
        /// <returns>Operation Result including information about success of execution</returns>
        OperationResult CanLoad();
        #endregion

        #region Delete
        /// <summary>
        /// Deletes the specified contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The operation result.</returns>
        OperationResult Delete(IContact contact);
        #endregion

        #region CanDelete
        /// <summary>
        /// Determines whether the specified contact can be deleted.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>Operation Result including information about success of execution</returns>
        OperationResult CanDelete(IContact contact);
        #endregion
        #endregion
    }
}
