using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AF_Curs_1 {
	public partial class Form1: Form {
		Random rnd;


		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			rnd = new Random();
			int[] array = new int[5];
			int[] frecv = new int[15];

			for(int i = 0; i < 5; i++) {
				array[i] = rnd.Next(2, 15);
				frecv[array[i]]++;
				listBox1.Items.Add(array[i].ToString());
			}

			int max = frecv[0];
			int min = frecv[0];
			int cont2 = 0;
			for(int i = 1; i < 15; i++) {
				if(frecv[i] > max) {
					max = frecv[i];
				}

				if(frecv[i] < min) {
					min = frecv[i];
				}

				if(frecv[i] == 2) {
					cont2++;
				}
			}


			string buffer = "";
			for(int i = 0; i < 15; i++) {
				buffer += frecv[i] + " ";
			}
			listBox1.Items.Add(buffer);

			if(max == 5) {
				label1.Text = "5";
			} else if(max == 4) {
				label1.Text = "4";
			} else if(max == 3) {
				if(cont2 == 1) {
					label1.Text = "3 & 2";
				} else {
					label1.Text = "3";
				}
			} else if(max == 2) {
				if(cont2 == 2) {
					label1.Text = "2 & 2";
				} else {
					label1.Text = "2";
				}
			} else {
				label1.Text = "No Case";
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			MessageBox.Show("Hello, World!");
		}

		private void button1_MouseEnter(object sender, EventArgs e) {
			this.BackColor = Color.Yellow;
		}

		private void button1_MouseLeave(object sender, EventArgs e) {
			this.BackColor = Color.White;
		}
	}
}
