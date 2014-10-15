﻿//--------------------------------------------------------------------------
// <copyright file="ILoggingSink.cs" company="none ">
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

namespace DesignItRight.Infrastructure.Common.Logging
{
    /// <summary>
    /// Interface for a logging sink
    /// </summary>
    [ContractClass(typeof(LoggingSinkContract))]
    public interface ILoggingSink
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Writes the specified message to the log sink
        /// </summary>
        /// <param name="message">
        /// The message. 
        /// </param>
        void Write(string message);
        #endregion
    }

    /// <summary>
    /// The logging sink contract.
    /// </summary>
    [ContractClassFor(typeof(ILoggingSink))]
    internal abstract class LoggingSinkContract : ILoggingSink
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="message">
        /// The message. 
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Write(string message)
        {
            Contract.Requires(!string.IsNullOrEmpty(message));

            throw new NotImplementedException();
        }

        #endregion
    }
}