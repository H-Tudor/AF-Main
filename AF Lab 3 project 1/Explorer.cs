namespace AF_Lab_3_project_1 {
	public class Explorer: Robot {

		public Explorer(): base() {

		}



		public override void Draw(Graphics handler) {
			handler.FillEllipse(Brushes.Black, MapLocation.X - size, MapLocation.Y - size, 2 * size + 1, 2 * size + 1);
			handler.DrawEllipse(Pens.Red, MapLocation.X - size, MapLocation.Y - size, 2 * size + 1, 2 * size + 1);
		}
	}
}
