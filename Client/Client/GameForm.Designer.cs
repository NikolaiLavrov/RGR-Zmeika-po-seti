namespace Client
{
	partial class GameForm
	{
	
		private System.ComponentModel.IContainer components = null;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.main_PN = new System.Windows.Forms.Panel();
			this.fruit_PB = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.myColor_LB = new System.Windows.Forms.Label();
			this.hint_LB = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.w_LB = new System.Windows.Forms.Label();
			this.s_LB = new System.Windows.Forms.Label();
			this.a_LB = new System.Windows.Forms.Label();
			this.d_LB = new System.Windows.Forms.Label();
			this.printer_TM = new System.Windows.Forms.Timer(this.components);
			this.main_PN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fruit_PB)).BeginInit();
			this.SuspendLayout();
			// 
			// main_PN
			// 
			this.main_PN.BackColor = System.Drawing.Color.DarkKhaki;
			this.main_PN.Controls.Add(this.fruit_PB);
			this.main_PN.Location = new System.Drawing.Point(12, 12);
			this.main_PN.Name = "main_PN";
			this.main_PN.Size = new System.Drawing.Size(1200, 700);
			this.main_PN.TabIndex = 0;
			// 
			// fruit_PB
			// 
			this.fruit_PB.BackColor = System.Drawing.Color.Red;
			this.fruit_PB.Location = new System.Drawing.Point(1180, 0);
			this.fruit_PB.Name = "fruit_PB";
			this.fruit_PB.Size = new System.Drawing.Size(20, 20);
			this.fruit_PB.TabIndex = 0;
			this.fruit_PB.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(74, 760);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1：";
			// 
			// myColor_LB
			// 
			this.myColor_LB.BackColor = System.Drawing.Color.Fuchsia;
			this.myColor_LB.Location = new System.Drawing.Point(257, 760);
			this.myColor_LB.Name = "myColor_LB";
			this.myColor_LB.Size = new System.Drawing.Size(44, 40);
			this.myColor_LB.TabIndex = 2;
			// 
			// hint_LB
			// 
			this.hint_LB.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.hint_LB.ForeColor = System.Drawing.Color.White;
			this.hint_LB.Location = new System.Drawing.Point(337, 746);
			this.hint_LB.Name = "hint_LB";
			this.hint_LB.Size = new System.Drawing.Size(510, 79);
			this.hint_LB.TabIndex = 3;
			this.hint_LB.Text = "hint_LB...";
			this.hint_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.Location = new System.Drawing.Point(870, 729);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 26);
			this.label4.TabIndex = 4;
			this.label4.Text = "label4：";
			// 
			// w_LB
			// 
			this.w_LB.BackColor = System.Drawing.SystemColors.Control;
			this.w_LB.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.w_LB.Location = new System.Drawing.Point(1081, 740);
			this.w_LB.Name = "w_LB";
			this.w_LB.Size = new System.Drawing.Size(45, 43);
			this.w_LB.TabIndex = 5;
			this.w_LB.Text = "W";
			this.w_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// s_LB
			// 
			this.s_LB.BackColor = System.Drawing.SystemColors.Control;
			this.s_LB.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.s_LB.Location = new System.Drawing.Point(1081, 793);
			this.s_LB.Name = "s_LB";
			this.s_LB.Size = new System.Drawing.Size(45, 43);
			this.s_LB.TabIndex = 6;
			this.s_LB.Text = "S";
			this.s_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// a_LB
			// 
			this.a_LB.BackColor = System.Drawing.SystemColors.Control;
			this.a_LB.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.a_LB.Location = new System.Drawing.Point(1030, 793);
			this.a_LB.Name = "a_LB";
			this.a_LB.Size = new System.Drawing.Size(45, 43);
			this.a_LB.TabIndex = 7;
			this.a_LB.Text = "A";
			this.a_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// d_LB
			// 
			this.d_LB.BackColor = System.Drawing.SystemColors.Control;
			this.d_LB.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.d_LB.Location = new System.Drawing.Point(1132, 793);
			this.d_LB.Name = "d_LB";
			this.d_LB.Size = new System.Drawing.Size(45, 43);
			this.d_LB.TabIndex = 8;
			this.d_LB.Text = "D";
			this.d_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// printer_TM
			// 
			this.printer_TM.Interval = 50;
			this.printer_TM.Tick += new System.EventHandler(this.printer_TM_Tick);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.OliveDrab;
			this.ClientSize = new System.Drawing.Size(1225, 854);
			this.Controls.Add(this.d_LB);
			this.Controls.Add(this.a_LB);
			this.Controls.Add(this.s_LB);
			this.Controls.Add(this.w_LB);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.hint_LB);
			this.Controls.Add(this.myColor_LB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.main_PN);
			this.Name = "GameForm";
			this.Text = "GameForm";
			this.Load += new System.EventHandler(this.GameForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
			this.main_PN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fruit_PB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel main_PN;
		private System.Windows.Forms.PictureBox fruit_PB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label myColor_LB;
		private System.Windows.Forms.Label hint_LB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label w_LB;
		private System.Windows.Forms.Label s_LB;
		private System.Windows.Forms.Label a_LB;
		private System.Windows.Forms.Label d_LB;
		private System.Windows.Forms.Timer printer_TM;
	}
}
