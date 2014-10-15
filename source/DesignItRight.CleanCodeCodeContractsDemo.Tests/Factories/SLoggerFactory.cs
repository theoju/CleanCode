//--------------------------------------------------------------------------
// <copyright file="SLoggerFactory.cs" company="none ">
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

using Microsoft.Moles.Framework.Behaviors;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Explorable;

namespace DesignItRight.Infrastructure.Common.Logging.Moles
{
    /// <summary>
    /// A factory for DesignItRight.Infrastructure.Common.Logging.Moles.SLogger instances
    /// </summary>
    public static class SLoggerFactory
    {
        #region -------------------- Public Methods --------------------

        /// <summary>
        /// A factory for DesignItRight.Infrastructure.Common.Logging.Moles.SLogger instances
        /// </summary>
        /// <param name="loggingSink_iLoggingSink">
        /// The logging Sink_i Logging Sink. 
        /// </param>
        /// <param name="__callBase_b">
        /// The __call Base_b. 
        /// </param>
        /// <param name="__instanceBehavior_iBehavior">
        /// The __instance Behavior_i Behavior. 
        /// </param>
        [PexFactoryMethod(typeof(SLogger))]
        public static SLogger Create(
            ILoggingSink loggingSink_iLoggingSink, 
            bool __callBase_b, 
            IBehavior __instanceBehavior_iBehavior
            )
        {
            SLogger sLogger = PexInvariant.CreateInstance<SLogger>();
            PexInvariant.SetField
                (sLogger, "loggingSink", loggingSink_iLoggingSink);
            PexInvariant.SetField(sLogger, "__callBase", __callBase_b);
            PexInvariant.SetField
                (sLogger, "__instanceBehavior", __instanceBehavior_iBehavior);
            PexInvariant.CheckInvariant(sLogger);
            return sLogger;

            // TODO: Edit factory method of SLogger
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }

        #endregion
    }
}