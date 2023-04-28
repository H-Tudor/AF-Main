using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExtractionGame {
	public static class Engine {
		public static List<Robot> robots = new List<Robot>();
		public static Map map;
		public static MyGraphics g;

		public static void InitTest() {
			Robot T1 = new Exploiter();
			map.SetRobot(T1, 1, 2);
			
			Robot T2 = new Explorer();
			map.SetRobot(T2, 3, 5);
			
			Robot T3 = new Explorer();
			map.SetRobot(T3, 6, 4);
			
			Robot T4 = new Transporter();
			map.SetRobot(T4, 3, 4);
			
			Robot T5 = new Transporter();
			map.SetRobot(T5, 4, 4);
		
			map.SetCrystals(new Point(7, 9), 20, 5, 1);
			map.SetCrystals(new Point(1, 3), 200, 5, 100);
		}

		public static PointF[] RegularPolygon(PointF absLocation, float radius, int n, float rotAngle) {
			float alpha = (float)(Math.PI * 2 / n);
			PointF[] toR = new PointF[n];
			for(int i = 0; i < n; i++) {
				float x = absLocation.X + radius * (float)Math.Cos(i * alpha + rotAngle);
				float y = absLocation.Y + radius * (float)Math.Sin(i * alpha + rotAngle);
				toR[i] = new PointF(x, y);
			}
			return toR;
		}

		public static PointF[] RegularPolygon(PointF absLocation, float radiusX, float radiusY, int n, float rotAngle) {
			float alpha = (float)(Math.PI * 2 / n);
			PointF[] toR = new PointF[n];
			for(int i = 0; i < n; i++) {
				float x = absLocation.X + radiusX * (float)Math.Cos(i * alpha + rotAngle);
				float y = absLocation.Y + radiusY * (float)Math.Sin(i * alpha + rotAngle);
				toR[i] = new PointF(x, y);
			}
			return toR;
		}
	}
}
