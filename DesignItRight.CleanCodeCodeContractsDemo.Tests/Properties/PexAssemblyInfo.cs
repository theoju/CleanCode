//--------------------------------------------------------------------------
// <copyright file="PexAssemblyInfo.cs" company="none ">
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
using System.Globalization;
using System.IO;
using System.Text;

using DesignItRight.Infrastructure.Common.Logging;
using DesignItRight.Infrastructure.Common.Logging.Moles;

using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Moles;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Suppression;
using Microsoft.Pex.Framework.Using;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("DesignItRight.CleanCodeCodeContractsDemo")]
[assembly: PexInstrumentAssembly("DesignItRight.CleanCodeCodeContractsDemo.Contract")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "DesignItRight.CleanCodeCodeContractsDemo.Contract")]

// Microsoft.Pex.Framework.Moles
[assembly: PexAssumeContractEnsuresFailureAtBehavedSurface]
[assembly: PexChooseAsBehavedCurrentBehavior]
[assembly: PexSuppressStaticFieldStore("DesignItRight.Properties.LoggingResources", "resourceMan")]
[assembly: PexSuppressExplorableEvent(typeof(SLogger))]
[assembly: PexUseType(typeof(Logger))]
[assembly: PexUseType(typeof(SLogger))]
[assembly: PexUseType(typeof(TextFileLoggingSink))]
[assembly: PexUseType(typeof(TextFileLoggingSink))]
[assembly: PexInstrumentType(typeof(TimeZoneInfo))]
[assembly: PexInstrumentType(typeof(EncoderReplacementFallback))]
[assembly: PexInstrumentType(typeof(DecoderReplacementFallback))]
[assembly: PexInstrumentType(typeof(EncoderFallback))]
[assembly: PexInstrumentType(typeof(DecoderFallback))]
[assembly: PexInstrumentType(typeof(TextWriter))]
[assembly: PexInstrumentType("mscorlib", "System.Text.UTF8Encoding+UTF8Encoder")]
[assembly: PexInstrumentType(typeof(EncoderExceptionFallback))]
[assembly: PexInstrumentType("mscorlib", "System.Mda+StreamWriterBufferedDataLost")]
[assembly: PexInstrumentType("mscorlib", "System.Text.EncoderNLS")]
[assembly: PexInstrumentType(typeof(Encoder))]
[assembly: PexInstrumentType(typeof(Buffer))]
[assembly: PexInstrumentType(typeof(FileStream))]
[assembly: PexInstrumentType(typeof(DaylightTime))]