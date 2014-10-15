//--------------------------------------------------------------------------
// <copyright file="OperationResult.cs" company="none ">
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

namespace CleanCodeDemoAllInOne
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Operation Result contains the information about the success of an operation and/or warnings and errors about issues.
    /// </summary>
    [Serializable]
    public class OperationResult
    {
        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        /// <param name="success">
        /// If set to <c>true</c> [success]. 
        /// </param>
        /// <param name="message">
        /// Error or Warning message based on Success value. 
        /// </param>
        private OperationResult(bool success, string message)
        {
            Errors = new List<string>();
            Warnings = new List<string>();

            Success = success;

            if (!string.IsNullOrEmpty(message))
            {
                if (Success)
                {
                    Warnings.Add(message);
                }
                else
                {
                    Errors.Add(message);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class for a failed operation.
        /// </summary>
        /// <param name="error">
        /// The error. 
        /// </param>
        public OperationResult(string error)
            : this(false, error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class for an successful operation.
        /// </summary>
        public OperationResult()
            : this(true, null)
        {
        }

        #endregion

        #region -------------------- Public Properties --------------------

        /// <summary>
        /// Gets a value indicating whether this <see cref="OperationResult"/> is success.
        /// </summary>
        /// <value>
        /// <c>true</c> if success; otherwise, <c>false</c> . 
        /// </value>
        public bool Success { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors. 
        /// </value>
        public IList<string> Errors { get; private set; }

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <value>
        /// The warnings. 
        /// </value>
        public IList<string> Warnings { get; private set; }
        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="operationResult1">
        /// The operation result1. 
        /// </param>
        /// <param name="operationResult2">
        /// The operation result2. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator ==(OperationResult operationResult1, OperationResult operationResult2)
        {
            if ((object)operationResult1 == null)
            {
                return (object)operationResult2 == null;
            }

            if ((object)operationResult2 == null)
            {
                return (object)operationResult1 == null;
            }

            return operationResult1 != null && operationResult2 != null && operationResult1.Success == operationResult2.Success
                   && operationResult1.Errors == operationResult2.Errors && operationResult1.Warnings == operationResult2.Warnings;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="operationResult">
        /// The operation result. 
        /// </param>
        /// <param name="value">
        /// If set to <c>true</c> [value]. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator ==(OperationResult operationResult, bool value)
        {
            return operationResult != null && operationResult.Success == value;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="value">
        /// If set to <c>true</c> [value]. 
        /// </param>
        /// <param name="operationResult">
        /// The operation result. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator ==(bool value, OperationResult operationResult)
        {
            return operationResult == value;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="operationResult1">
        /// The operation result1. 
        /// </param>
        /// <param name="operationResult2">
        /// The operation result2. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator !=(OperationResult operationResult1, OperationResult operationResult2)
        {
            return !(operationResult1 == operationResult2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="operationResult">
        /// The operation result. 
        /// </param>
        /// <param name="value">
        /// If set to <c>true</c> [value]. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator !=(OperationResult operationResult, bool value)
        {
            return !(operationResult == value);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="value">
        /// If set to <c>true</c> [value]. 
        /// </param>
        /// <param name="operationResult">
        /// The operation result. 
        /// </param>
        /// <returns>
        /// The result of the operator. 
        /// </returns>
        public static bool operator !=(bool value, OperationResult operationResult)
        {
            return !(operationResult == value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CleanCodeDemoAllInOne.OperationResult"/> to <see cref="System.Boolean"/> .
        /// </summary>
        /// <param name="operationResult">
        /// The operation result. 
        /// </param>
        /// <returns>
        /// The result of the conversion. 
        /// </returns>
        public static implicit operator bool(OperationResult operationResult)
        {
            return operationResult.Success;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance. 
        /// </returns>
        public override string ToString()
        {
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

        /// <summary>
        /// Creates a string of the errors.
        /// </summary>
        /// <returns>
        /// String of errors 
        /// </returns>
        public string ErrorsToString()
        {
            return ListToString(Errors);
        }

        /// <summary>
        /// The warnings to string.
        /// </summary>
        /// <returns>
        /// The warnings to string. 
        /// </returns>
        public string WarningsToString()
        {
            return ListToString(Warnings);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="System.Object"/> to compare with this instance. 
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c> . 
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == (OperationResult)obj;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static string ListToString(IEnumerable<string> list)
        {
            StringBuilder stringBuilder;
            bool initialExecution;

            stringBuilder = new StringBuilder();
            initialExecution = true;

            foreach (var message in list)
            {
                if (initialExecution)
                {
                    initialExecution = false;
                }
                else
                {
                    stringBuilder.AppendLine();
                }

                stringBuilder.Append(message);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}