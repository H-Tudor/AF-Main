namespace AF_Lab_4_project_1 {
	public partial class MainForm: Form {
		MyGraphics graphics = new MyGraphics();
		Map demo = new Map();

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			graphics.InitGraph(pictureBox1);
			demo.width = pictureBox1.Width;
			demo.height = pictureBox1.Height;
			demo.Init(50);

			graphics.backColor = Color.AliceBlue;
			graphics.ClearGraph();

			demo.Draw(graphics.grp);
			timer1.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			demo.Tick();
			demo.Draw(graphics.grp);
		}
	}
}