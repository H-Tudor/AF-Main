namespace AF_Lab_3_project_1 {
	public static class Engine {
		public static PointF[] GeneratePolygonPoints(PointF center, float radius, int nr_of_points, float rotation_angle) {
			PointF[] bounds = new PointF[nr_of_points];
			float alpha = (float)(((Math.PI * 2) / 2) * nr_of_points);

			/// x' = x + radius * cos(alpha)
			/// y' = y + radius * sin(alpha)
			
			for(int i = 0; i < nr_of_points; i++) {
				float x = center.X + radius * (float)Math.Cos(i * alpha + rotation_angle);
				float y = center.Y + radius * (float)Math.Sin(i * alpha + rotation_angle);
				bounds[i] = new PointF(x, y);
			}

			return bounds;
		}


	}
}
