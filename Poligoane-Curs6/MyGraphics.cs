using System;
using System.Drawing;
using System.Windows.Forms;

namespace Polygons {
	public class MyGraphics {
		Bitmap bmp;
		public Graphics g;
		PictureBox display;
		Color bkColor = Color.LightBlue;
		public int resX, resY;

		public MyGraphics(PictureBox display) {
			this.display = display;
			resX = display.Width;
			resY = display.Height;
			bmp = new Bitmap(display.Width, display.Height);
			g = Graphics.FromImage(bmp);
		}

		public void Refresh() {
			display.Image = bmp;
		}

		public void Clear() {
			g.Clear(bkColor);
		}
	}
}
