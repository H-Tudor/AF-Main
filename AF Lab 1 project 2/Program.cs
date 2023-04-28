using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Lab_1_project_2 {
	internal class Program {
		static void Main(string[] args) {
			int n = int.Parse(Console.ReadLine());
			int[] array = ArrayGetConsoleBuffered(n);

			int start_pos = 0, end_pos = n;

			for(int i = 0; i < n; i++) {
				if(array[i] % 2 == 1) {
					start_pos = i;
					break;
				}
			}

			end_pos = n - 1;
			while(array[end_pos] % 2 == 0) { end_pos--; }

			int sum = 0;
			for(int i = start_pos; i <= end_pos; i++) {
				sum += array[i];
			}

			Console.WriteLine(sum);
			Console.ReadKey();
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

		static int[] ArrayGetFileBuffered(string filename) {
			TextReader load = new StreamReader(filename);
			int n = int.Parse(load.ReadLine());
			int[] v = new int[n];
			int k = 0;
			string buffer;

			while((buffer = load.ReadLine()) != null) {
				string[] b = buffer.Split(' ');
				for(int i = 0; i < b.Length; i++) {
					v[k] = int.Parse(b[i]);
					k++;
				}
			}
			return v;
		}


		static int[] ArrayGetConsole() {
			string[] buffer = Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			int[] array = new int[buffer.Length];

			for(int i = 0; i < buffer.Length; i++) {
				array[i] = int.Parse(buffer[i]);
			}

			return array;
		}
	}
}
