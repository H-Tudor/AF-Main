using System;
using System.Drawing;

namespace ExtractionGame {
	public class Map {
		Tile[,] tiles;
		public static Random rnd = new Random();

		public int n {
			get { return tiles.GetLength(0); }
		}

		public int m {
			get { return tiles.Length; }
		}

		public Map(int n, int m) {
			tiles = new Tile[n, m];
			for(int i = 0; i < n; i++) {
				for(int j = 0; j < m; j++) {
					tiles[i, j] = new Tile(0, 0, 0, new PointF(i, j));
				}

			}
		}

		public void Draw(Graphics handler) {
			for(int i = 0; i < tiles.GetLength(0); i++) {
				for(int j = 0; j < tiles.GetLength(1); j++) {
					tiles[i, j].Draw(handler);
				}
			}
		}

		public void SetRobot(Robot r, int i, int j) {
			tiles[i, j].SetRobot(r);
		}

		public void SetCrystals(Point center, int power, int radius, int value) {
			for(int i = 0; i < power; i++) {
				int x = center.X + rnd.Next(-radius, radius + 1);
				int y = center.Y + rnd.Next(-radius, radius + 1);
				if(x >= 0 && y >= 0 && x < n && y < m) {
					tiles[x, y].AddCrystals(value);
				}
			}
		}
	}
}
