//--------------------------------------------------------------------------
// <copyright file="Program.cs" company="none ">
//     Copyright (CPOL) 1.02 Design IT Right
//     THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CODE 
//     PROJECT OPEN LICENSE ("LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT 
//     AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS 
//     AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS PROHIBITED.
//     BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HEREIN, YOU ACCEPT 
//     AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. THE AUTHOR GRANTS 
//     YOU THE RIGHTS CONTAINED HEREIN IN CONSIDERATION OF YOUR ACCEPTANCE OF 
//     SUCH TERMS AND CONDITIONS. IF YOU DO NOT AGREE TO ACCEPT AND BE BOUND 
//     BY THE TERMS OF THIS LICENSE, YOU CANNOT MAKE ANY USE OF THE WORK.
// </copyright>
// <author>Theo Jungeblut</author>
//--------------------------------------------------------------------------


namespace CleanCodeDemoUnity
{
    using System;
    using System.Windows.Forms;

    using DesignItRight.Infrastructure.Common.Logging;
    using DesignItRight.Internal.CleanCodeDemo.ContactManagement;
    using DesignItRight.CleanCodeDemo.ContactManagement;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    ///   The program.
    /// </summary>
    internal static class Program
    {
        #region -------------------- Constants and Fields --------------------
        private static UnityContainer unityContainer;

        private static SingleContactManagerForm singleContactManagerForm;
        #endregion

        #region -------------------- Internal Methods --------------------

        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExecuteUnitystrapper();
            InitializeMainForm();

            Application.Run(singleContactManagerForm);
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static void ExecuteUnitystrapper()
        {
            unityContainer = new UnityContainer();

            // Type mapping -> every time an ILoggingSink is required a new instance will be created
            unityContainer.RegisterType<ILoggingSink, TextFileLoggingSink>();

            // Type mapping -> the logger will be created as a Singleton
            unityContainer.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());

            // Add new Extension for Interception
            unityContainer.AddNewExtension<Interception>();

            // Configure Interception for Logger
            unityContainer.RegisterType<IContactPersistence, DummyExampleContactPersistence>(
                new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingBehavior>(), new InterceptionBehavior<StopWatchBehavior>());

            unityContainer.RegisterType<IContactManager, ContactManager>(
                new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingBehavior>(), new InterceptionBehavior<StopWatchBehavior>());
        }

        private static void InitializeMainForm()
        {
            singleContactManagerForm = unityContainer.Resolve<SingleContactManagerForm>();
        }

        #endregion
    }
}