//--------------------------------------------------------------------------
// <copyright file="TextFileLoggingSink.cs" company="none ">
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

using System.ComponentModel.Composition;
using System.IO;

namespace DesignItRight.Infrastructure.Common.Logging
{
    /// <summary>
    /// The text file logging sink.
    /// </summary>
    [Export(typeof(ILoggingSink))]
    public class TextFileLoggingSink : ILoggingSink
    {
        // private const fields
        #region -------------------- Constants and Fields --------------------
        private const string LogFileName = @"c:\temp\CleanCodeDemoLogFile.log";
        #endregion

        #region -------------------- Public Methods --------------------

        /// <summary>
        /// Writes the specified message to a text file.
        /// </summary>
        /// <param name="message">
        /// The message. 
        /// </param>
        public void Write(string message)
        {
            using (TextWriter textWriter = new StreamWriter(LogFileName))
            {
                textWriter.WriteLine(message);
                textWriter.Close();
            }
        }

        #endregion
    }
}