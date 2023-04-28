namespace AF_Lab_3_project_1 {
	public abstract class Robot {
		public PointF MapLocation { get; protected set; }

		public int size = 10;


		public Robot() { }

		public void SetLocation(PointF destination) {
			MapLocation = destination;
		}

		public abstract void Draw(Graphics handler);
	}
}
