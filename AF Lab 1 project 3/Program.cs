using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_lab_1_project_3 {
	internal class Program {
		static void Main(string[] args) {
			int n = int.Parse(Console.ReadLine());
			int[] v = ArrayGetConsoleBuffered(n);
			int length = 0, max_length = 0;
			int start_pos = 0, end_pos = n -1;

			for(int i = 0; i < n; i++) {
				if(v[i] == 0) {
					length++;
				} else {
					if(length > max_length) {
						max_length = length;
						start_pos = i - length;
						end_pos = i  - 1;
					}
					length = 0;
				}
			}
			Console.WriteLine(start_pos + ' ' + end_pos);
		}

		static int[] ArrayGetConsoleBuffered(int n) {
			int[] v = new int[n];
			int k = 0;
			string buffer;

			while((buffer = Console.ReadLine()) != null) {
				string[] b = buffer.Split(' ');
				for(int i = 0; i < b.Length; i++) {

					v[k] = int.Parse(b[i]);
					k++;
				}
			}
			return v;
		}
	}
}
