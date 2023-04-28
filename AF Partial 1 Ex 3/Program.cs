namespace AF_Partial_1_Ex_3 {
	internal class Program {
		static void Main(string[] args) {
			ProcessData("data03.in");
		}

		public static void ProcessData(string filename) {
			TextReader load = new StreamReader(filename);
			string buffer;
			string[] content_buffer, data_buffer;
			int i; double d;

			double[,] values = new double[101, 4];

			while((buffer = load.ReadLine()) != null) {
				content_buffer = buffer.Split(',');
				foreach(string entry in content_buffer) { 
					data_buffer = entry.Split(' ');
					i = int.Parse(data_buffer[0]);
					d = double.Parse(data_buffer[1]);

					values[i, 0]++;
					values[i, 1] += d;
					values[i, 2] = values[i, 2] > d ? d : values[i, 2];
					values[i, 3] = values[i, 3] < d ? d : values[i, 3];
				}
			}
			load.Close();

			TextWriter save = new StreamWriter("data03.out");
			for(i = 0; i < 101; i++) {
				if(values[i, 0] == 0)
					continue;

				Console.WriteLine($"dataId: {i}, med: {values[i, 1] / values[i, 0]}" +
					$", min: {values[i, 2]}, max: {values[i, 3]}");	
			}
		}
	}
}