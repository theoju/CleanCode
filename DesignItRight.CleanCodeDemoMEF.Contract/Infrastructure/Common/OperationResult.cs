//--------------------------------------------------------------------------
// <copyright file="OperationResult.cs" company="Omnicell Inc.">
//     Copyright (c) Omnicell Inc. All rights reserved.
//
//     Reproduction or transmission in whole or in part, in 
//     any form or by any means, electronic, mechanical, or otherwise, is 
//     prohibited without the prior written consent of the copyright owner.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Jungeblut.Infrastructure.Common
{
    /// <summary>
    /// Operation result object contain the information if an operation was sucessful and if and which warnings or errors occurred.
    /// </summary>
    [Serializable]
    public class OperationResult
    {
        #region ---------------------- Constructor ---------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="reason">The reason.</param>
        public OperationResult(bool success, string reason)
        {
            this.Warnings = new List<string>();
            this.Errors = new List<string>();
            this.Success = success;

            if (!string.IsNullOrEmpty(reason))
            {
                if (success)
                {
                    this.Warnings.Add(reason);
                }
                else
                {
                    this.Errors.Add(reason);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class for a failed operation.
        /// </summary>
        /// <param name="reason">The reason.</param>
        public OperationResult(string reason)
            : this(false, reason)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class for an successful operation.
        /// </summary>
        public OperationResult()
            : this(true, string.Empty)
        {
        }
        #endregion

        #region ---------------------- Properties ---------------------
        /// <summary>
        /// Gets a value indicating whether this <see cref="OperationResult"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; private set; }

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <value>The warnings.</value>
        public IList<string> Warnings { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public IList<string> Errors { get; private set; }
        #endregion

        #region ---------------------- Public Methods ---------------------
        // Implemented operators
        #region operator ==
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="operationResult">The result.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>The operationResult of the operator.</returns>
        public static bool operator ==(OperationResult operationResult, bool value)
        {
            return operationResult != null && operationResult.Success == value;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="operationResult">The result.</param>
        /// <returns>The operationResult of the operator.</returns>
        public static bool operator ==(bool value, OperationResult operationResult)
        {
            return operationResult == value;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="result1">The result1.</param>
        /// <param name="result2">The result2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(OperationResult result1, OperationResult result2)
        {
            if ((object)result1 == null)
            {
                return (object)result2 == null;
            }

            if ((object)result2 == null)
            {
                return (object)result1 == null;
            }

            return result1 != null && result2 != null && result1.Success == result2.Success && result1.Errors == result2.Errors && result1.Warnings == result2.Warnings;
        }
        #endregion

        #region operator !=
        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="operationResult">The result.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>The operationResult of the operator.</returns>
        public static bool operator !=(OperationResult operationResult, bool value)
        {
            return !(operationResult == value);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="operationResult">The result.</param>
        /// <returns>The operationResult of the operator.</returns>
        public static bool operator !=(bool value, OperationResult operationResult)
        {
            return !(value == operationResult);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="result1">The result1.</param>
        /// <param name="result2">The result2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(OperationResult result1, OperationResult result2)
        {
            return !(result1 == result2);
        }
        #endregion

        // public static methods
        #region explicit conversion
        /// <summary>
        /// Performs an explicit conversion from <see cref="OperationResult"/> to <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="operationResult">The result.</param>
        /// <returns>The operationResult of the conversion.</returns>
        public static implicit operator bool(OperationResult operationResult)
        {
            return operationResult.Success;
        }
        #endregion

        // Override object methods
        #region Equals
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == (OperationResult)obj;
        }
        #endregion

        #region ToString
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            // declare local variables
            StringBuilder stringBuilder;
            string warnings;

            stringBuilder = new StringBuilder(ErrorsToString());

            warnings = WarningsToString();
            if (!string.IsNullOrEmpty(warnings))
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.AppendLine();
                }

                stringBuilder.Append(warnings);
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region ErrorsToString
        /// <summary>
        /// Warningses to string.
        /// </summary>
        /// <returns>Returns the errors as a string.</returns>
        public string ErrorsToString()
        {
            // declare local variables
            StringBuilder stringBuilder;
            bool firstOccurance;

            stringBuilder = new StringBuilder();
            firstOccurance = true;

            foreach (string error in this.Errors)
            {
                if (!firstOccurance)
                {
                    stringBuilder.AppendLine();
                }
                else
                {
                    firstOccurance = false;
                }

                stringBuilder.Append(error);
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region WarningsToString
        /// <summary>
        /// Warnings to string.
        /// </summary>
        /// <returns>Returns the warnings as a string.</returns>
        public string WarningsToString()
        {
            // declare local variables
            StringBuilder stringBuilder;
            bool firstOccurance;

            stringBuilder = new StringBuilder();
            firstOccurance = true;

            foreach (string warning in this.Warnings)
            {
                if (!firstOccurance)
                {
                    stringBuilder.AppendLine();
                }
                else
                {
                    firstOccurance = false;
                }

                stringBuilder.Append(warning);
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region GetHashCode
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #endregion
    }
}
