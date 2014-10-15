//--------------------------------------------------------------------------
// <copyright file="LoggingBehavior.cs" company="none ">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace DesignItRight.Infrastructure.Common.Logging
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LoggingBehavior : IInterceptionBehavior
    {
        #region -------------------- Constants and Fields --------------------
        private const bool DefaultWillExecuteBehavior = false;

        private readonly ILogger logger;
        #endregion

        #region -------------------- Constructors and Destructors --------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehavior"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger. 
        /// </param>
        public LoggingBehavior(ILogger logger)
        {
            Contract.Requires(logger != null);

            this.logger = logger;
        }

        #endregion

        #region -------------------- Public Properties --------------------

        /// <summary>
        ///   Gets a value indicating whether this behavior will actually do anything when invoked.
        /// </summary>
        public bool WillExecute
        {
            get { return DefaultWillExecuteBehavior; }
        }
        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Implement this method to execute your behavior processing.
        /// </summary>
        /// <param name="input">
        /// Inputs to the current call to the target. 
        /// </param>
        /// <param name="getNext">
        /// Delegate to execute to get the next delegate in the behavior chain. 
        /// </param>
        /// <returns>
        /// Return value from the target. 
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn;
            string className;
            string methodName;

            className = input.MethodBase.DeclaringType.Name;
            methodName = input.MethodBase.Name;

            try
            {
                WriteStartLogEntryToLogger(className, methodName, input);

                methodReturn = getNext()(input, getNext);

                WriteCompleteLogEntryToLogger(className, methodName, methodReturn);
            }
            catch (Exception exception)
            {
                WriteOperationFailedLogEntryToLogger(className, methodName, exception);

                throw;
            }

            return methodReturn;
        }

        /// <summary>
        /// Returns the interfaces required by the behavior for the objects it intercepts.
        /// </summary>
        /// <returns>
        /// The required interfaces. 
        /// </returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private void WriteStartLogEntryToLogger(string className, string methodName, IMethodInvocation input)
        {
            string logMessage;

            logMessage = string.Format(
                "Entering on object {0} method {1} with following parameter: {2}", className, methodName, input.Arguments);

            this.logger.Log(logMessage);

            Debug.WriteLine(logMessage);
        }

        private void WriteCompleteLogEntryToLogger(string className, string methodName, IMethodReturn methodReturn)
        {
            string logMessage;

            logMessage = string.Format(
                "Complete on object {0} method {1} with following result: {2}", className, methodName, methodReturn.ReturnValue);

            this.logger.Log(logMessage);

            Debug.WriteLine(logMessage);
        }

        private void WriteOperationFailedLogEntryToLogger(string className, string methodName, Exception exception)
        {
            string logMessage;

            logMessage = string.Format(
                "Failed to execute on object {0} method {1} with following exception: {2}", className, methodName, exception.Message);

            this.logger.Log(logMessage);

            Debug.WriteLine(logMessage);
        }

        #endregion
    }
}