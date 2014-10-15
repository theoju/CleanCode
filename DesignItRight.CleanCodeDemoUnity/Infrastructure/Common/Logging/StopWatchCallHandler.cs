//--------------------------------------------------------------------------
// <copyright file="StopWatchCallHandler.cs" company="none ">
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
using System.Diagnostics;

using Microsoft.Practices.Unity.InterceptionExtension;

namespace DesignItRight.Infrastructure.Common.Logging
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class StopWatchCallHandler : ICallHandler
    {
        #region -------------------- Public Properties --------------------

        /// <summary>
        ///   Order in which the handler will be executed
        /// </summary>
        public int Order { get; set; }
        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Implement this method to execute your handler processing.
        /// </summary>
        /// <param name="input">
        /// Inputs to the current call to the target. 
        /// </param>
        /// <param name="getNext">
        /// Delegate to execute to get the next delegate in the handler chain. 
        /// </param>
        /// <returns>
        /// Return value from the target. 
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn;

            try
            {
                Stopwatch stopwatch;
                string className;
                string methodName;

                className = input.MethodBase.DeclaringType.Name;
                methodName = input.MethodBase.Name;

                stopwatch = new Stopwatch();

                stopwatch.Start();

                methodReturn = getNext()(input, getNext);

                stopwatch.Stop();

                Debug.WriteLine(string.Format("Executing on object {0} method {1} took: {2}ms", className, methodName, stopwatch.ElapsedMilliseconds));
            }
            catch (Exception exception)
            {
                throw;
            }

            return methodReturn;
        }

        #endregion
    }
}