using System;
using System.Drawing;

namespace AF_Lab_2_project_1 {
	public enum MonsterType {
		HorizontalDirection,
		VerticalDirection,
		FullDirection
	}


	internal class Monster {

		public int loc_x, loc_y;
		public MonsterType type;
		public int dx = 0, dy = 0;
		public static Random rnd = new Random();

		public Monster(int loc_x, int loc_y, int type) {
			this.loc_x = loc_x;
			this.loc_y = loc_y;
			int t;
			switch(type) {
				case 5:
					this.type = MonsterType.HorizontalDirection;

					dy = 0;
					t = rnd.Next(2);
					if(t == 0)
						dx = -1;
					else
						dx = 1;

					break;
				case 6:
					this.type = MonsterType.VerticalDirection;

					dx = 0;
					t = rnd.Next(2);
					if(t == 0)
						dy = -1;
					else
						dy = 1;

					break;
				case 7:
					this.type = MonsterType.FullDirection;

					t = rnd.Next(2);
					if(t == 0)
						dx = -1;
					else
						dx = 1;

					t = rnd.Next(2);
					if(t == 0)
						dy = -1;
					else
						dy = 1;

					break;
			}
		}

		public void Tick() {

			if(!Engine.CanMove(loc_x + dx, loc_y + dy)) {
				switch(type) {
					case MonsterType.HorizontalDirection:
						dx *= -1;
						break;
					case MonsterType.VerticalDirection:
						dy *= -1;
						break;
					case MonsterType.FullDirection:
						if(Engine.Map[loc_x + dx, loc_y] == 1)
							dx *= -1;
						else
							dy *= -1;
						break;
				}
			} else {
				switch(type) {
					case MonsterType.HorizontalDirection:
						loc_x += dx;
						break;
					case MonsterType.VerticalDirection:
						loc_y += dy;
						break;
					case MonsterType.FullDirection:
						loc_x += dx;
						loc_x += dx;
						break;
				}
			}
		}


		public void Draw(MyGraphics handler) {

			float x = loc_x * Engine.d_width;
			float y = loc_y * Engine.d_height;

			Color fillColor = Color.Black;
			Color drawColor = Color.Black;

			switch(type) {
				case MonsterType.HorizontalDirection:
					fillColor = Color.Green;
					drawColor = Color.LightGreen;
					break;
				case MonsterType.VerticalDirection:
					fillColor = Color.Blue;
					drawColor = Color.LightBlue;
					break;
				case MonsterType.FullDirection:
					fillColor = Color.Red;
					drawColor = Color.DarkRed;
					break;
			}

			handler.grp.FillEllipse(new SolidBrush(fillColor), x, y, Engine.d_width, Engine.d_height);
			handler.grp.DrawEllipse(new Pen(drawColor), x, y, Engine.d_width, Engine.d_height);
		}
	}
}
