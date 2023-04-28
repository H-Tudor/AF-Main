using System;

namespace AF_Curs_2_project_1 {
	internal class Program {
		static void Main(string[] args) {
			int n = int.Parse(Console.ReadLine());


			int max, min;
			//CountingMethod(n, out max, out min);
			SortingMethod(n, out max, out min);

			Console.WriteLine($"Max: {max}");
			Console.WriteLine($"Max: {min}");
			Console.ReadKey();
		}

		private static void SortingMethod(int n, out int max, out int min) {
			int k = 0;
			max = 0;
			min = 0;
			int[] digits = new int[16];
			while(n != 0) {
				digits[k] = n % 10;
				k++;
				n /= 10;
			}

			for(int i = 0; i < k - 1; i++) {
				for(int j = i + 1; j < k; j++) {
					if(digits[i] > digits[j]) {
						(digits[j], digits[i]) = (digits[i], digits[j]);
					}
				}
			}

			// Max
			for(int i = 0; i < k; i++) {
				max = max * 10 + digits[i];
			}

			//Min
			if(digits[0] == 0) {
				for(int i = 1; i < k; i++) {
					if(digits[i] != 0) {
						(digits[0], digits[i]) = (digits[i], digits[0]);
						break;
					}
				}
			}

			for(int i = 0; i < k; i++) {
				max = max * 10 + digits[i];
			}
		}

		private static void CountingMethod(int n, out int max, out int min) {
			int[] digits = new int[10];

			while(n != 0) {
				digits[n % 10]++;
				n /= 10;
			}

			max = 0;
			min = 0;
			// Max
			for(int i = 9; i >= 0; i--) {
				for(int j = 0; j < digits[i]; j++) {
					max = max * 10 + i;
				}
			}

			// Min
			if(digits[0] != 0) {
				for(int i = 1; i < 10; i++) {
					if(digits[i] != 0) {
						min = i;
						digits[i]--;
						break;
					}
				}
				for(int i = 0; i < digits[0]; i++) {
					min *= 10;
				}
			}

			for(int i = 1; i < 10; i++) {
				for(int j = 0; j < digits[i]; j++) {
					min = min * 10 + i;
				}
			}
		}
	}
}
