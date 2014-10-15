//--------------------------------------------------------------------------
// <copyright file="ContractExtensions.cs" company="none ">
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

using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics.Contracts
{
    /// <summary>
    /// Enables factoring legacy if-then-throw into separate methods for reuse and full control over thrown exception and arguments
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [Conditional("CONTRACTS_FULL")]
    public sealed class ContractArgumentValidatorAttribute : Attribute
    {
    }

    /// <summary>
    /// Enables writing abbreviations for contracts that get copied to other methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [Conditional("CONTRACTS_FULL")]
    public sealed class ContractAbbreviatorAttribute : Attribute
    {
    }

    /// <summary>
    /// Allows setting contract and tool options at assembly, type, or method granularity.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    [Conditional("CONTRACTS_FULL")]
    public sealed class ContractOptionAttribute : Attribute
    {
        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractOptionAttribute"/> class.
        /// </summary>
        /// <param name="category">
        /// The category. 
        /// </param>
        /// <param name="setting">
        /// The setting. 
        /// </param>
        /// <param name="toggle">
        /// If set to <c>true</c> [toggle]. 
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "category", 
            Justification = "Build-time only attribute")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "setting", 
            Justification = "Build-time only attribute")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "toggle", 
            Justification = "Build-time only attribute")]
        public ContractOptionAttribute(string category, string setting, bool toggle)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractOptionAttribute"/> class.
        /// </summary>
        /// <param name="category">
        /// The category. 
        /// </param>
        /// <param name="setting">
        /// The setting. 
        /// </param>
        /// <param name="value">
        /// The value. 
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "category", 
            Justification = "Build-time only attribute")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "setting", 
            Justification = "Build-time only attribute")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", 
            Justification = "Build-time only attribute")]
        public ContractOptionAttribute(string category, string setting, string value)
        {
        }

        #endregion
    }
}