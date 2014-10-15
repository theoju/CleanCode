//--------------------------------------------------------------------------
// <copyright file="Contact.cs" company="none. ">
//     Copyright (CPOL) 1.02 Theo Jungeblut
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

namespace CleanCodeTheUgly
{
    using System;

    /// <summary>
    /// The contact contains the details about a contact
    /// </summary>
    public class Contact
    {
        #region -------------------- Public Properties --------------------

        /// <summary>
        ///   Gets or sets the first name.
        /// </summary>
        /// <value> The first name. </value>
        public string FirstName { get; set; }

        /// <summary>
        ///   Gets or sets the name of the middle.
        /// </summary>
        /// <value> The name of the middle. </value>
        public string MiddleName { get; set; }

        /// <summary>
        ///   Gets or sets the last name.
        /// </summary>
        /// <value> The last name. </value>
        public string LastName { get; set; }

        /// <summary>
        ///   Gets or sets the phone number.
        /// </summary>
        /// <value> The phone number. </value>
        public string PhoneNumber { get; set; }
        #endregion
    }
}