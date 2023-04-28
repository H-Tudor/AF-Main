using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AF_Lab_2_project_1 {
	public enum GameState {
		NotStarted,
		Started,
		Lost,
		Win
	}


	internal class Engine {
		public static int[,] Map;
		public static string selected_level;
		public static float d_width, d_height;
		public static List<Monster> monsters = new List<Monster>();
		public static Player player_1;
		public static int diamonds = 0;
		public static bool game_started = false;
		public static Campaign campaign;
		public static bool is_campaign = false;

		public static void Draw(MyGraphics handler) {
			handler.ClearGraph();
			float x, y;


			for(int i = 0; i < Map.GetLength(0); i++) {
				for(int j = 0; j < Map.GetLength(1); j++) {
					switch(Map[i, j]) {
						case 1:
							x = j * d_width;
							y = i * d_height;
							handler.grp.DrawRectangle(Pens.Black, x, y, d_width, d_height);
							handler.grp.FillRectangle(Brushes.Gray, x, y, d_width, d_height);
							break;
						case 2:
							break; // start
						case 3:
							x = j * d_width;
							y = i * d_height;
							handler.grp.DrawEllipse(Pens.Green, x, y, d_width, d_height);
							//handler.grp.FillRectangle(Brushes.Gray, x, y, d_width, d_height);
							break; // end
						case 4:
							break; // unallocated
						case 8:
							break; // unallocated
						case 9:
							// diamond
							handler.grp.FillEllipse(Brushes.Turquoise, j * d_width, i * d_height, d_width, d_height);
							handler.grp.DrawEllipse(Pens.Black, j * d_width, i * d_height, d_width, d_height);
							break;
					}
				}
			}
			player_1.Draw(handler);

			foreach(Monster monster in monsters) {
				monster.Draw(handler);
			}


			string lives = player_1.lives.ToString();
			Font font = new Font("Arial", 14, FontStyle.Bold);

			handler.grp.DrawString(lives, font, Brushes.Red, new Point(10, 10));
			handler.grp.DrawString(diamonds.ToString(), font, Brushes.White, new Point(50, 10));
			handler.grp.DrawString(GameStatus.ToString(), font, Brushes.Green, new Point(10, 35));



			handler.RefreshGraph();
		}

		public static GameState GameStatus {
			get {
				if(game_started == false)
					return GameState.NotStarted;
				else if(player_1.lives <= 0)
					return GameState.Lost;
				else if(diamonds <= 0 && Map[player_1.loc_x, player_1.loc_y] == 3)
					return GameState.Win;
				else
					return GameState.Started;
			}
		}

		public static void Tick() {
			foreach(Monster monster in monsters) {
				monster.Tick();
			}

			if(HasCollided(player_1) && player_1.lives > 0) {
				player_1.lives--;
			} else if(Map[player_1.loc_x, player_1.loc_y] == 9) {
				Map[player_1.loc_x, player_1.loc_y] = 0;
				diamonds--;
			}

			if(GameStatus == GameState.Win) {
				if(is_campaign) {
					string map = campaign.GetNextMap();
					LoadMap(map);
				}
			}
		}

		public static bool CanMove(int loc_x, int loc_y) {
			if(Map[loc_y, loc_x] != 1) {
				return true;
			}
			return false;
		}

		public static bool IsMonster(int loc_x, int loc_y) {
			foreach(Monster monster in monsters) {
				if(monster.loc_x == loc_x && monster.loc_y == loc_y) {
					return true;
				}
			}

			return false;
		}

		public static void LoadMap(string file_name) {
			Map = FileGetMatrix(file_name);
		}

		public static void GetDisplayDelta(MyGraphics handler) {
			d_width = (float)(handler.res_x / Map.GetLength(1));
			d_height = (float)(handler.res_y / Map.GetLength(0));
		}

		static int[,] FileGetMatrix(string file_name) {
			string buffer;

			TextReader file = new StreamReader(file_name);
			List<string> file_lines = new List<string>();

			while((buffer = file.ReadLine()) != null) {
				file_lines.Add(buffer);
			}

			file.Close();

			int matrix_lines = file_lines.Count;
			int matrix_columns = file_lines[0].Split(' ').Length;
			int[,] array = new int[matrix_lines, matrix_columns];

			monsters.Clear();
			string[] line_buffer;
			for(int i = 0; i < matrix_lines; i++) {
				line_buffer = file_lines[i].Split(' ');
				for(int j = 0; j < matrix_columns; j++) {
					array[i, j] = int.Parse(line_buffer[j]);
					if(array[i, j] == 5 || array[i, j] == 6 || array[i, j] == 7) {
						monsters.Add(new Monster(j, i, array[i, j]));
					} else if(array[i, j] == 2) {
						player_1 = new Player(j, i);
					} else if(array[i, j] == 9) {
						diamonds++;
					}
				}
			}

			return array;
		}

		public static bool HasCollided(Player player) {
			foreach(Monster monster in monsters) {
				if(player.loc_x == monster.loc_x && player.loc_y == monster.loc_y) {
					return true;
				}
			}

			return false;
		}
	}
}
