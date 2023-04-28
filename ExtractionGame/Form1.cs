using System.Windows.Forms;

namespace ExtractionGame {
	public partial class Form1: Form {
		public Form1() {
			InitializeComponent();
			Engine.g = new MyGraphics();

			Engine.g.InitGraph(pictureBox1);
			Engine.map = new Map(20, 30);
			Engine.InitTest();
			Engine.map.Draw(Engine.g.grp);

			Engine.g.RefreshGraph();

		}
	}
}
