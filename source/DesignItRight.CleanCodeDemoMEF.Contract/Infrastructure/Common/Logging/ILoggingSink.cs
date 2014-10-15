//--------------------------------------------------------------------------
// <copyright file="ILoggingSink.cs" company="Omnicell Inc.">
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
    public interface ILoggingSink
    {
        #region ---------------------- Methods ----------------------
        #region Write
        /// <summary>
        /// Writes the specified message to the log sink
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);
        #endregion
        #endregion
    }
}
