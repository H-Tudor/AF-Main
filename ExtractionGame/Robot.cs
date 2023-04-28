using System.Drawing;

namespace ExtractionGame {
	public abstract class Robot {
		public PointF mapLocation;
		public PointF absLocation;
		
		public Robot() { }

		public void SetOnMap(PointF toSet) {
			mapLocation = toSet;
		}
		
		public abstract void Draw(Graphics handler);
	}
}
