using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Curs_2_project_2 {
	internal class Program {
		static void Main(string[] args) {
			int[] frecv = new int[2000];

			int number;
			string buffer;
			string[] local;
			TextReader load = new StreamReader(@"..\..\data.in");
			while((buffer = load.ReadLine()) != null) {
				local = buffer.Split(' ');
				for(int i = 0; i < local.Length; i++) {
					number = int.Parse(local[i]);

					if(number > -1000 && number < 1000) {
						frecv[number + 1000]++;
					}
				}
			}

			int counter = 0;
			for(int i = frecv.Length; i >= 0; i--) {
				if(counter == 2) {
					break;
				} else if(frecv[i] == 0) {
					Console.WriteLine($"Number #{counter}: {i - 1000}");
					counter++;
				}
			}

		}
	}
}
