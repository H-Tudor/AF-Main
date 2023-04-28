using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Lab_2_project_1 {
	public class Campaign {
		private List<string> maps;
		private int crtLevel;

		public Campaign() {
			maps = new List<string>();
			crtLevel = -1;
		}

		public void AddMap(string map) { 
			maps.Add(map);
		}

		public string GetNextMap() {
			crtLevel++;
			if(crtLevel == maps.Count) {
				return "";
			}

			return maps[crtLevel];
		}

	}
}
