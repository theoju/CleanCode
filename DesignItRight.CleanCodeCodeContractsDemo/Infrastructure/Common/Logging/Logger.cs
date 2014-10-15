//--------------------------------------------------------------------------
// <copyright file="Logger.cs" company="none ">
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
    /// Example implementation of a logger based on the ILogger interface
    /// </summary>
    public class Logger : ILogger
    {
        #region -------------------- Constants and Fields --------------------
        private readonly ILoggingSink loggingSink;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="loggingSink">
        /// The logging sink. 
        /// </param>
        public Logger(ILoggingSink loggingSink)
        {
            Contract.Requires(loggingSink != null);
            Contract.Ensures(this.loggingSink == loggingSink);

            this.loggingSink = loggingSink;
        }

        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Logs the specified message to the logger sink
        /// </summary>
        /// <param name="message">
        /// The message. 
        /// </param>
        public void Log(string message)
        {
            string formatedMessage;

            // NOTE: (TJ) Start of some dummy logic. Normally you would find additionally log logic here like log status handling.
            formatedMessage = string.Format("{0}  {1}", DateTime.Now, message);

            // NOTE: (TJ) End of some dummy logic.
            if (!string.IsNullOrEmpty(formatedMessage))
            {
                this.loggingSink.Write(formatedMessage);
            }
        }

        #endregion

        #region -------------------- Private Methods --------------------
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.loggingSink != null);
        }

        #endregion
    }
}