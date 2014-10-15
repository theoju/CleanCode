//--------------------------------------------------------------------------
// <copyright file="IContact.cs" company="Omnicell Inc.">
//     Copyright (c) Omnicell Inc. All rights reserved.
//
//     Reproduction or transmission in whole or in part, in 
//     any form or by any means, electronic, mechanical, or otherwise, is 
//     prohibited without the prior written consent of the copyright owner.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

namespace Jungeblut.LegoDemo.ContactManagement
{
    /// <summary>
    /// Interface for a simple Contact
    /// </summary>
    public interface IContact
    {
        #region ---------------------- Properties ----------------------
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        string PhoneNumber { get; set; }
        #endregion
    }
}