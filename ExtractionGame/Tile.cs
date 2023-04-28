using System.Drawing;

namespace ExtractionGame {
	public class Tile {
		int crystal;
		int processedCrystals;
		int fog;
		public PointF mapLocation;
		public PointF absLocation;
		public static int dX = 20, dY = 20;
		public Robot robot;

		public Tile(int crystal, int processedCrystals, int fog, PointF mapLocation) {
			this.crystal = crystal;
			this.processedCrystals = processedCrystals;
			this.fog = fog;
			this.mapLocation = mapLocation;
			this.absLocation = new PointF(mapLocation.X * dX, mapLocation.Y * dY);
		}
		public void Draw(Graphics handler) {
			handler.FillRectangle(Brushes.White, absLocation.X, absLocation.Y, dX, dY);
			handler.DrawRectangle(Pens.Black, absLocation.X, absLocation.Y, dX, dY);
			if(robot != null)
				robot.Draw(handler);
			if(crystal != 0) {
				PointF[] points = Engine.RegularPolygon(new PointF(this.absLocation.X + dX / 2, this.absLocation.Y + dY / 2), dX / 3, dY / 2, 8, 0);
				handler.DrawPolygon(Pens.Blue, points);
				handler.DrawString(crystal.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, absLocation);
			}
		}
		public void SetRobot(Robot toSet) {
			this.robot = toSet;
			this.robot.mapLocation = this.mapLocation;
			float X = this.absLocation.X + dX / 2;
			float Y = this.absLocation.Y + dY / 2;
			this.robot.absLocation = new PointF(X, Y);
		}
		public void AddCrystals(int value) {
			this.crystal += value;
		}
	}
}
