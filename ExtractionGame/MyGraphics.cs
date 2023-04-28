using System.Drawing;
using System.Windows.Forms;

namespace ExtractionGame {
	public class MyGraphics {
		PictureBox display;
		Bitmap bmp;
		public Graphics grp;
		Color backColor = Color.FromArgb(120, 120, 120);
		public int resX, resY;

		public void InitGraph(PictureBox display) {
			this.display = display;
			bmp = new Bitmap(display.Width, display.Height);
			grp = Graphics.FromImage(bmp);
			ClearGraph();
			RefreshGraph();
			resX = display.Width;
			resY = display.Height;
		}

		public void ClearGraph() {
			grp.Clear(backColor);
		}

		public void RefreshGraph() {
			this.display.Image = bmp;
		}

	}
}
