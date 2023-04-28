using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Polygons {
	public class Matrix {
		public static Random rnd = new Random();
		public static Matrix Empty;

		public float[,] Values { get; set; }

		private void Base(int n, int m) {
			Values = new float[n, m];
		}

		public Matrix(int n, int m) {
			Base(n, m);
		}

		public Matrix(int n, PointF A) {
			Values = new float[2, n];
			for(int i = 0; i < n; i++) {
				Values[0, i] = A.X;
				Values[1, i] = A.Y;
			}
		}

		public Matrix(string fileName) {
			TextReader reader = new StreamReader(fileName);
			List<string> lines = new List<string>();

			string buffer;
			while((buffer = reader.ReadLine()) != null) {
				lines.Add(buffer);
			}
			reader.Close();

			int n = lines.Count;
			int m = lines[0].Split(' ').Length;
			Base(n, m);

			for(int i = 0; i < n; i++) {
				string[] local = lines[i].Split(' ');
				for(int j = 0; j < m; j++) {
					Values[i, j] = int.Parse(local[j]);
				}
			}
		}

		public Polygon MatrixToPolygon() {
			Polygon toReturn = new Polygon(Values.GetLength(1));

			for(int i = 0; i < Values.GetLength(1); i++) {
				toReturn.points[i].X = Values[0, i];
				toReturn.points[i].Y = Values[1, i];
			}

			return toReturn;
		}

		public Matrix(int n) {
			Values = new float[2, n];
		}

		public Matrix(int n, int m, int min, int max) {
			Values = new float[n, m];

			for(int i = 0; i < n; i++) {
				for(int j = 0; j < m; j++) {
					Values[i, j] = rnd.Next(min, max);
				}
			}
		}

		public static Matrix operator +(Matrix A, Matrix B) {
			if(A.Values.GetLength(0) != B.Values.GetLength(0) || A.Values.GetLength(1) != B.Values.GetLength(1))
				return Empty;

			Matrix toReturn = new Matrix(A.Values.GetLength(0), A.Values.GetLength(1));
			for(int i = 0; i < A.Values.GetLength(0); i++) {
				for(int j = 0; j < A.Values.GetLength(1); j++) {
					toReturn.Values[i, j] = A.Values[i, j] + B.Values[i, j];
				}
			}

			return toReturn;
		}

		public static Matrix operator -(Matrix A, Matrix B) {
			if(A.Values.GetLength(0) != B.Values.GetLength(0) || A.Values.GetLength(1) != B.Values.GetLength(1))
				return Empty;

			Matrix toReturn = new Matrix(A.Values.GetLength(0), A.Values.GetLength(1));
			for(int i = 0; i < A.Values.GetLength(0); i++) {
				for(int j = 0; j < A.Values.GetLength(1); j++) {
					toReturn.Values[i, j] = A.Values[i, j] - B.Values[i, j];
				}
			}

			return toReturn;
		}
		public static Matrix operator *(Matrix A, Matrix B) {
			int rows = A.Values.GetLength(0);
			int cols = B.Values.GetLength(1);

			if(A.Values.GetLength(0) != cols)
				return Empty;

			Matrix toReturn = new Matrix(rows, cols);
			for(int i = 0; i < rows; i++) {
				for(int j = 0; j < cols; j++) {
					toReturn.Values[i, j] = 0;

					for(int k = 0; k < rows; k++) {
						toReturn.Values[i, j] += A.Values[i, k] * B.Values[k, j];
					}
				}
			}

			return toReturn;
		}

		public List<string> View() {
			List<string> toReturn = new List<string>();

			string buffer;
			for(int i = 0; i < Values.GetLength(0); i++) {
				buffer = "";
				for(int j = 0; j < Values.GetLength(1); j++)
					buffer += Values[i, j];
				toReturn.Add(buffer);
			}

			return toReturn;
		}
	}
}
