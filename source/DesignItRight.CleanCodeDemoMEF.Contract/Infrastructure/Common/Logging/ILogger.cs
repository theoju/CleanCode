//--------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Omnicell Inc.">
//     Copyright (c) Omnicell Inc. All rights reserved.
//
//     Reproduction or transmission in whole or in part, in 
//     any form or by any means, electronic, mechanical, or otherwise, is 
//     prohibited without the prior written consent of the copyright owner.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------

namespace Jungeblut.Infrastructure.Common.Logging
{
    public interface ILogger
    {
        #region ---------------------- Methods ----------------------
        #region Log
        /// <summary>
        /// Logs the specified message to the logger sink
        /// </summary>
        /// <param name="message">The message.</param>
        void Log(string message);
        #endregion
        #endregion
    }
}