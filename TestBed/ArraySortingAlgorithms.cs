namespace TestBed {
	public class ArraySortingAlgorithms {

		void BubbleSort(int[] v) {
			int k = 0;
			bool sorted;

			do {
				sorted = true;

				for(int i = 0; i < v.Length - 1 - k; i++) {
					if(v[i] > v[i + 1]) {
						(v[i], v[i + 1]) = (v[i + 1], v[i]);
						sorted = false;
					}
				}
				k++;
			} while(!sorted);
		}


		void InsertionSort(int[] v) {
			for(int i = 1; i < v.Length; i++) {
				for(int j = i; j > 0 && v[j] < v[j - 1]; j--) {
					(v[j], v[j - 1]) = (v[j - 1], v[j]);
				}
			}
		}


		void SelectionSort(int[] v) {
			int min, p_min;
			for(int i = 0; i < v.Length - 1; i++) {
				min = v[i];
				p_min = i;
				for(int j = i + 1; j < v.Length; j++) {
					if(v[j] < min) {
						min = v[j];
						p_min = j;
					}
				}
				(v[p_min], v[i]) = (v[i], v[p_min]);
			}
		}


		int[] MergeSort(int[] n) {
			if(n.Length == 1)
				return n;

			int[] a = new int[n.Length / 2];
			int[] b = new int[n.Length / 2 + 1];

			for(int i = 0; i < a.Length / 2; i++) {
				a[i] = n[i];
			}

			for(int i = n.Length; i < n.Length; i++) {
				b[i - n.Length] = n[i];
			}

			a = MergeSort(a);
			b = MergeSort(b);
			return Merge(a, b);
		}


		void QuickSort(int[] v, int lo, int hi) {
			Random rnd = new Random();

			if(lo < hi) {
				int index = rnd.Next(lo, hi + 1);
				(v[index], v[lo]) = (v[lo], v[index]);

				int k = lo;
				for(int i = lo + 1; i <= hi; i++) {
					if(v[i] < v[lo]) {
						k++;
						(v[i], v[k]) = (v[k], v[i]);
					}
				}

				(v[k], v[lo]) = (v[lo], v[k]);

				QuickSort(v, lo, k - 1);
				QuickSort(v, k + 1, hi);
			}
		}


		int[] Merge(int[] a, int[] b) {
			int[] c = new int[a.Length + b.Length];
			int i = 0, j = 0, k = 0;

			while(i < a.Length && j < b.Length) {
				if(a[i] <= b[j]) {
					c[k] = a[i];
					i++;
				} else {
					c[k] = b[j];
					j++;
				}
				k++;
			}

			while(i < a.Length) {
				c[k] = a[i];
				i++;
				k++;
			}

			while(j < b.Length) {
				c[k] = b[j];
				j++;
				k++;
			}

			return c;
		}
	}
}
