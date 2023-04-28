using System.Drawing;

namespace AF_Lab_2_project_1 {
	public class Player {
		public int loc_x, loc_y;

		public int lives;

		public Player(int loc_x, int loc_y) {
			this.loc_x = loc_x;
			this.loc_y = loc_y;
			this.lives = 5;
		}

		public void MoveUp() {
			if(Engine.CanMove(loc_x, loc_y - 1) == true && lives > 0) {
				loc_y--;
			}
		}

		public void MoveDown() {
			if(Engine.CanMove(loc_x, loc_y + 1) == true && lives > 0) {
				loc_y++;
			}
		}

		public void MoveLeft() {
			if(Engine.CanMove(loc_x - 1, loc_y) == true && lives > 0) {
				loc_x--;
			}
		}

		public void MoveRight() {
			if(Engine.CanMove(loc_x + 1, loc_y) == true && lives > 0) {
				loc_x++;
			}
		}

		public void Draw(MyGraphics handler) {
			if(lives <= 0)
				return;

			Color fillColor = Color.Yellow;
			Color drawColor = Color.Orange;

			float x = loc_x * Engine.d_width;
			float y = loc_y * Engine.d_height;

			handler.grp.FillEllipse(new SolidBrush(fillColor), x, y, Engine.d_width, Engine.d_height);
			handler.grp.DrawEllipse(new Pen(drawColor), x, y, Engine.d_width, Engine.d_height);
		}
	}

}
