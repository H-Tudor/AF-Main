using System;

namespace Others {
	public class Matrix<T> {
		public T[,] values


		public Matrix<T>(): this(2, 2) { }

		public Matrix<T>(int rows, int cols) {
			values = new T[rows, cols];
		}


		public T[] operator +() {

	}
	}
}