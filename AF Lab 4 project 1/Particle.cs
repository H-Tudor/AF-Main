namespace AF_Lab_4_project_1 {
	public class Particle {
		public static Random rnd = new Random();
		static int rate_disappearance = 20, rate_doubling = 30;
		static int radius = 30, nr = 3;

		public bool is_delete;
		public PointF Location { get; private set; }

		public Particle(int width_max, int height_max) {
			Location = new PointF(rnd.Next(width_max), rnd.Next(height_max));
			is_delete = false;
		}

		public Particle(Particle parent) {
			is_delete = false;
			Location = GenerateLocation(parent.Location);
		}

		public PointF GenerateLocation(PointF location) {
			float a = (float)(rnd.NextDouble() * Math.PI * 2);
			float t = rnd.Next(radius);

			float x = location.X + (float)(t * Math.Sin(a));
			float y = location.Y + (float)(t * Math.Cos(a));

			return new PointF(x, y);
		}

		public void Draw(Graphics handler) {
			handler.DrawEllipse(Pens.Black, Location.X - 2, Location.Y - 2, 5, 5);
		}

		public List<Particle> Tick() {
			List<Particle> new_particles = new List<Particle>();

			int x = rnd.Next(100);
			if(x < rate_doubling) {
				int t = rnd.Next(nr) + 1;

				for(int i = 0; i < t; i++) {
					new_particles.Add(new Particle(this));
				}

			} else if(x < rate_disappearance) {
				this.is_delete = true;
			}

			return new_particles;
		}

	}
}
