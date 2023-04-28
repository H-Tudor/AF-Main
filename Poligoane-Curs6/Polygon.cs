using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Polygons {
	public class Polygon {
		public PointF[] points;
		public static Random rnd = new Random();

		public int length { get { return points.Length; } }

		public Polygon(int n, int maxX, int maxY) {
			points = new PointF[n];
			for(int i = 0; i < n; i++) {
				points[i] = new PointF(rnd.Next(maxX), rnd.Next(maxY));
			}
		}

		public Matrix PolygonToMatrix() {
			Matrix toReturn = new Matrix(points.Length);

			for(int i = 0; i < points.Length; i++) {
				toReturn.Values[0, i] = (int)points[i].X;
				toReturn.Values[1, i] = (int)points[i].Y;
			}

			return toReturn;
		}

		public Polygon(string fileName) {
			TextReader reader = new StreamReader(fileName);
			List<string> lines = new List<string>();

			string buffer;
			while((buffer = reader.ReadLine()) != null) {
				lines.Add(buffer);
			}
			reader.Close();

			points = new PointF[lines.Count];
			for(int i = 0; i < points.Length; i++) {
				points[i] = new PointF(float.Parse(lines[i].Split(' ')[0]), float.Parse(lines[i].Split(' ')[1]));
			}
		}

		public Polygon(int a) {
			points = new PointF[a];
		}

		public float Perimeter() {
			float toReturn = 0;
			for(int i = 0; i < points.Length; i++)
				toReturn += MyMath.Distance(points[i], points[(i + 1) % points.Length]);

			return toReturn;
		}

		public PointF CenterOfGravity() {
			float toReturnX = 0;
			float toReturnY = 0;

			for(int i = 0; i < points.Length; i++) {
				toReturnX += points[i].X;
				toReturnY += points[i].Y;
			}
			return new PointF(toReturnX / points.Length, toReturnY / points.Length);
		}

		public float Area() {
			float area = 0;
			for(int i = 0; i < points.Length; i++) {
				area += (points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X) * 0.5f;
			}
			return area;
		}

		public void Draw(Graphics handler) {
			handler.DrawPolygon(Pens.Black, points);
		}


		public static Polygon PolygonTranslate(Polygon polygon, PointF translation) {
			Matrix PolygonMatrix = polygon.PolygonToMatrix();
			Matrix ModifierMatrix = new Matrix(polygon.points.Length, translation);

			Matrix TranslatedPolygonMatrix = PolygonMatrix + ModifierMatrix;
			return TranslatedPolygonMatrix.MatrixToPolygon();
		}

		public static Polygon PolygonScale(Polygon polygon, float fx, float fy) {
			// fx = scale_factor_x
			// fy = scale_factor_y

			Matrix ModifierMatrix = new Matrix(2, 2);
			Matrix PolygonMatrix = polygon.PolygonToMatrix();

			ModifierMatrix.Values = new float[2, 2] {
				{ fx, 0 },
				{ 0, fy }
			};

			//M.Values[0, 0] = fx;
			//M.Values[0, 1] = 0;
			//M.Values[1, 0] = 0;
			//M.Values[1, 1] = fy;

			Matrix ScaledPolygonMatrix = ModifierMatrix * PolygonMatrix;
			return ScaledPolygonMatrix.MatrixToPolygon();
		}

		public static Polygon PolygonRotate(Polygon polygon, float angle, PointF center) {
			Matrix ModifierMatrix = new Matrix(2, 2);
			Matrix PolygonMatrix = polygon.PolygonToMatrix();
			Matrix CenterPointMatrix = new Matrix(polygon.points.Length, center);

			ModifierMatrix.Values = new float[2, 2] {
				{ (float)Math.Cos(angle), -(float)Math.Sin(angle) },
				{ (float)Math.Sin(angle),  (float)Math.Cos(angle) }
			};

			//M.Values[0, 0] = (float)Math.Cos(angle);
			//M.Values[0, 1] = (float)Math.Sin(angle) * -1;
			//M.Values[1, 0] = (float)Math.Sin(angle);
			//M.Values[1, 1] = (float)Math.Cos(angle);

			Matrix RotatedPolygonMatrix = ModifierMatrix * (PolygonMatrix - CenterPointMatrix) + CenterPointMatrix;
			return RotatedPolygonMatrix.MatrixToPolygon();
		}
	}
}
