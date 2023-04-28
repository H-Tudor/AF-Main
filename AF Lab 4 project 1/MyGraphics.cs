namespace AF_Lab_4_project_1 {
	public class MyGraphics {
		PictureBox display;
		Bitmap bmp;
		public Graphics grp;
		public Color backColor = Color.FromArgb(200, 200, 180);
		public int res_x, res_y;

		public MyGraphics() { }

		public void InitGraph(PictureBox display) {
			this.display = display;
			this.res_x = display.Width;
			this.res_y = display.Height;
			this.bmp = new Bitmap(display.Width, display.Height);
			this.grp = Graphics.FromImage(bmp);
			ClearGraph();
			RefreshGraph();
		}

		public void ClearGraph() {
			this.grp.Clear(backColor);
			RefreshGraph();
		}

		public void RefreshGraph() {
			this.display.Image = bmp;
		}
	}
}
