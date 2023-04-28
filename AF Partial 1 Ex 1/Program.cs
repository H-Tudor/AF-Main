namespace AF_Partial_1_Ex_1 {
	internal class Program {
		static void Main(string[] args) {
			DisplayMedian(SortList(GetList("data01.in")));			
		}

		public static void DisplayMedian(float[] list) {
			Console.WriteLine(list[list.Length / 2]);
		}

		public static float[] SortList(float[] list) {
			bool sorted;
			int k = 0;
			float temp;

			do {
				sorted = true;

				for(int i = 0; i < list.Length - 1 - k; i++) {
					if(list[i] > list[i + 1]) {
						temp = list[i];
						list[i] = list[i + 1];
						list[i + 1] = temp;
						sorted = false;
					}
				}
				k++;
			} while(!sorted);

			return list;		
		}


		public static float[] GetList(string filename) {
			List<float> list = new List<float>();
			TextReader reader = new StreamReader(filename);
			string buffer;

			while((buffer = reader.ReadLine()) != null) {
				foreach(string s in buffer.Split(' ')) {
					list.Add(float.Parse(s));
				}
			}

			//return list.ToArray();

			int n = list.Count;
			float[] floats = new float[n];

			for(int i = 0; i < n; i++) {
				floats[i] = list[i];
			}

			return floats;
		}
	}
}