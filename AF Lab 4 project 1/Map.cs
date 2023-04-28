namespace AF_Lab_4_project_1 {
	public class Map {
		
		public int width, height;
		public List<Particle> Particles;
		public List<Particle> TickList;

		public Map() {
			Particles = new List<Particle>();
		}

		public void Init(int n) {
			for(int i = 0; i < n; i++) {
				Particles.Add(new Particle(width, height));
			}
		}

		public void Draw(Graphics handler) { 
			foreach(Particle p in Particles) {
				p.Draw(handler);
			}
		}
	
		public void Tick() {
			TickList = new List<Particle>();
			foreach(Particle p in Particles) {
				TickList.AddRange(p.Tick());
			}
			Particles = Particles.FindAll((Particle a) => !a.is_delete);
			Particles.AddRange(TickList.FindAll((Particle a) => (
					(a.Location.X > 0 && a.Location.X < width) && (a.Location.Y > 0 && a.Location.Y < height)
				)));
		}
	}
}
