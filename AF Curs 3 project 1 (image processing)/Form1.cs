namespace AF_Curs_3_project_1__image_processing_ {
	public partial class MainForm: Form {
		int k = 127;

		public MainForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			Bitmap source;

			source = new Bitmap(@"C:\Projects\@Facultate\Algoritmi Fundamentali\AF Main\AF Curs 3 project 1 (image processing)\Images\test_img.jpg");
			source_pb.Image = source;

			destination_pb.Image = TransformImage(source, Transformation_Brighten);
		}

		public Bitmap TransformImage(Bitmap source, Func<Color, Color> transformMethod) {
			Bitmap result = new Bitmap(source.Width, source.Height);

			for(int i = 0; i < source.Width; i++) {
				for(int j = 0; j < source.Height; j++) {
					result.SetPixel(i, j, transformMethod(source.GetPixel(i, j)));
				}
			}

			return result;
		}

		public Color Transformation_Identical(Color pixel) => pixel;

		public Color Transformation_Invert(Color pixel) => Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);

		public Color Transformation_Darken(Color pixel) => Color.FromArgb(Math.Max(pixel.R - k, 0), Math.Max(pixel.G - k, 0), Math.Max(pixel.B - k, 0));

		public Color Transformation_Brighten(Color pixel) => Color.FromArgb(Math.Min(pixel.R + k, 0), Math.Min(pixel.G + k, 255), Math.Min(pixel.B + k, 255));




	}
}