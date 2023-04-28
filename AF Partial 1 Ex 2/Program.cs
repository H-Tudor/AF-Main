namespace AF_Partial_1_Ex_2 {
	internal class Program {
		static void Main(string[] args) {
			GetList("data02.in");
		}

		public static bool[,] ConvertToBin(byte[] list) {
			bool[,] pixels = new bool[list.Length , 8];

			for(int i = 0; i < pixels.Length; i++) { }

			return pixels;
		}

		public static byte[] GetList(string filename) {
			List<byte> list = new List<byte>();
			TextReader reader = new StreamReader(filename);
			string buffer;
			byte t;
			bool[] v;
			int k;

			while((buffer = reader.ReadLine()) != null) {
				t = byte.Parse(buffer);
				v = new bool[8];
				k = 0;

				while(t != 0) {
					if((t % 2) == 1)
						v[k] = true;
					else
						v[k] = false;

					k++;
					t /= 2;
				}

				for(int j = 7; j >= 0; j--) {
					if(v[j])
						Console.Write("X");
					else
						Console.Write(" ");
				}
				Console.WriteLine();

				//list.Add(byte.Parse(buffer));
			}

			//return list.ToArray();

			int n = list.Count;
			byte[] bytes = new byte[n];

			for(int i = 0; i < n; i++) {
				bytes[i] = list[i];
			}

			return bytes;
		}
	}
}