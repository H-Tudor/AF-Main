using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Lab {
	internal class Program {
		static void Main(string[] args) {
			int[] data = ArrayGetFile("input.txt");

			int length = 0, max_length = 0, i = 0;

			while(i < data.Length) {
				while(data[i] % 2 == 0) {
					length++;
					i++;

					if(i == data.Length)
						break;
				}

				if(length > max_length) {
					max_length = length;
				}
				length = 0;
				i++;
			}

			Console.WriteLine("");
		}

		static int[] ArrayGetFile(string filename) {
			TextReader load = new StreamReader(filename);

			string[] buffer = load.ReadLine().Split(' ');
			int[] array = new int[buffer.Length];

			for(int i = 0; i < buffer.Length; i++) {
				array[i] = int.Parse(buffer[i]);
			}

			return array;
		}
	}
}
