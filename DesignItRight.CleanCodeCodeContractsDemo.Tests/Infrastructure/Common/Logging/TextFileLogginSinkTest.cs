//--------------------------------------------------------------------------
// <copyright file="TextFileLogginSinkTest.cs" company="none ">
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

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignItRight.Infrastructure.Common.Logging
{
    /// <summary>
    /// This class contains parameterized unit tests for TextFileLoggingSink
    /// </summary>
    [PexClass(typeof(TextFileLoggingSink))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public class TextFileLoggingSinkTest
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Test stub for Write(String)
        /// </summary>
        /// <param name="target">
        /// The target. 
        /// </param>
        /// <param name="message">
        /// The message. 
        /// </param>
        [PexMethod]
        public void Write([PexAssumeUnderTest] TextFileLoggingSink target, string message)
        {
            target.Write(message);

            // TODO: add assertions to method TextFileLoggingSinkTest.Write(TextFileLoggingSink, String)
        }

        #endregion
    }
}