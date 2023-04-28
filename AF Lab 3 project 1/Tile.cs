namespace AF_Lab_3_project_1 {
	public class Tile {
		public int Crystal { get; private set; }

		public int ProcessCrystal { get; private set; }

		public int Fog{ get; private set; }
	
		public Tile(int crystal) {
			Crystal = crystal;
		}

		public void Draw(Graphics handler) { }
	}
}
