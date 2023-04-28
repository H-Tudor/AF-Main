using System;
using System.Windows.Forms;

namespace AF_Lab_2_project_1 {
	public partial class MainForm: Form {
		MyGraphics graphics = new MyGraphics();

		public MainForm() {
			InitializeComponent();
		}

		public void Draw() { }

		private void Form1_Load(object sender, EventArgs e) {
			graphics.InitGraph(pictureBox1);
			Engine.game_started = false;
			Engine.LoadMap($@"C:\Projects\@Facultate\Algoritmi Fundamentali\AF Main\AF Lab 2 project 1\Maps\{Engine.selected_level}");
			Engine.GetDisplayDelta(graphics);
			Engine.Draw(graphics);
		}

		private void timer1_Tick(object sender, EventArgs e) {
			Engine.Tick();
			Engine.Draw(graphics);

			//if(Engine.GameStatus != GameState.NotStarted) {
			//	timer1.Stop();
			//	if(Engine.GameStatus == GameState.Win) { } else if(Engine.GameStatus == GameState.Lost) { }
			//}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.W:
					Engine.player_1.MoveUp();
					break;
				case Keys.S:
					Engine.player_1.MoveDown();
					break;
				case Keys.A:
					Engine.player_1.MoveLeft();
					break;
				case Keys.D:
					Engine.player_1.MoveRight();
					break;
				case Keys.Space:
					timer1.Enabled = !timer1.Enabled;
					Engine.game_started = !Engine.game_started;
					break;
			}
			Engine.Draw(graphics);
		}
	}
}
