using AF_Lab_3_project_1;

namespace AF_Lab_3_project_1 {
	public partial class Form1: Form {
		public Form1() {
			InitializeComponent();
			GraphicsHandler graphics = new GraphicsHandler();
			graphics.InitGraph(pictureBox1);

			PointF bounds;
			for(float i = 0; i < Math.PI / 2; i+= 0.01f) {
				//bounds = Engine.GeneratePolygonPoints(pictureBox1.Width / 2, )
			}
		}

		private void Form1_Load(object sender, EventArgs e) {

		}
	}
}