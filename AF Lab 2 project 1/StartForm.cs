using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AF_Lab_2_project_1 {
	public partial class StartForm: Form {
		public StartForm() {
			InitializeComponent();
		}

		private void StartForm_Load(object sender, EventArgs e) {
			GetMapFiles();

		}

		private void GetMapFiles() {
			string[] dir_files = Directory.GetFiles(@"C:\Projects\@Facultate\Algoritmi Fundamentali\AF Main\AF Lab 2 project 1\Maps");

			foreach(string file_path in dir_files) {
				string local = Path.GetFileName(file_path);
				comboBox1.Items.Add(local);
			}
			comboBox1.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e) {
			Engine.is_campaign = false;
			Engine.selected_level = comboBox1.SelectedItem.ToString();
			new MainForm().ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e) {
			Engine.campaign = new Campaign();
			
			foreach(string file_path in comboBox1.Items)
				Engine.campaign.AddMap(file_path);

			Engine.is_campaign = true;
			Engine.selected_level = Engine.campaign.GetNextMap();
			new MainForm().ShowDialog();
		}
	}
}
