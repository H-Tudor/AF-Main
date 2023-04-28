global using System;
global using System.Collections.Generic;
global using System.Drawing;
global using System.Windows.Forms;
global using System.Linq;

namespace AF_Lab_4_project_1 {
	internal static class Program {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
		}
	}
}