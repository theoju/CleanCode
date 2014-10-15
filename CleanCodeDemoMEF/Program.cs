﻿//--------------------------------------------------------------------------
// <copyright file="Program.cs" company="none ">
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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CleanCodeDemoMEF
{
    /// <summary>
    /// The program.
    /// </summary>
    internal static class Program
    {
        #region -------------------- Constants and Fields --------------------
        private static CompositionContainer compositionContainer;

        private static SingleContactManagerForm singleContactManagerForm;
        #endregion

        #region -------------------- Internal Methods --------------------

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeMainForm();
            ExecuteMEFBootstrapper();

            Application.Run(singleContactManagerForm);
        }

        #endregion

        #region -------------------- Private Methods --------------------
        private static void ExecuteMEFBootstrapper()
        {
            AggregateCatalog catalog;

            catalog = new AggregateCatalog(
                new AssemblyCatalog(Assembly.GetExecutingAssembly()), 
                new DirectoryCatalog(Path.GetDirectoryName(Application.ExecutablePath)));

            compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(singleContactManagerForm);
        }

        private static void InitializeMainForm()
        {
            singleContactManagerForm = new SingleContactManagerForm();
        }

        #endregion
    }
}