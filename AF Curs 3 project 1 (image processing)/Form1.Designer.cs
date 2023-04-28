namespace AF_Curs_3_project_1__image_processing_ {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			source_pb = new PictureBox();
			destination_pb = new PictureBox();
			((System.ComponentModel.ISupportInitialize)source_pb).BeginInit();
			((System.ComponentModel.ISupportInitialize)destination_pb).BeginInit();
			SuspendLayout();
			// 
			// source_pb
			// 
			source_pb.Location = new Point(17, 19);
			source_pb.Name = "source_pb";
			source_pb.Size = new Size(540, 540);
			source_pb.SizeMode = PictureBoxSizeMode.CenterImage;
			source_pb.TabIndex = 0;
			source_pb.TabStop = false;
			// 
			// destination_pb
			// 
			destination_pb.Location = new Point(732, 19);
			destination_pb.Name = "destination_pb";
			destination_pb.Size = new Size(540, 540);
			destination_pb.SizeMode = PictureBoxSizeMode.CenterImage;
			destination_pb.TabIndex = 1;
			destination_pb.TabStop = false;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1284, 661);
			Controls.Add(destination_pb);
			Controls.Add(source_pb);
			Name = "Form1";
			Text = "Image Processing";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)source_pb).EndInit();
			((System.ComponentModel.ISupportInitialize)destination_pb).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox source_pb;
		private PictureBox destination_pb;
	}
}