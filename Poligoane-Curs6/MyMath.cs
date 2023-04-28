using System;
using System.Drawing;

namespace Polygons {
	public static class MyMath {
		public static float Distance(PointF A, PointF B) {
			return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
		}

	}
}
