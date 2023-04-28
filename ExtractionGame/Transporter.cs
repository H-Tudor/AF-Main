using System.Drawing;

namespace ExtractionGame {
	public class Transporter: Robot {
		public Transporter() : base() {

		}
		public override void Draw(Graphics handler) {
			int size = 7;
			handler.FillEllipse(Brushes.Purple, absLocation.X - size, absLocation.Y - size, 2 * size + 1, 2 * size + 1);
			handler.DrawEllipse(Pens.Black, absLocation.X - size, absLocation.Y - size, 2 * size + 1, 2 * size + 1);
		}
	}
}
