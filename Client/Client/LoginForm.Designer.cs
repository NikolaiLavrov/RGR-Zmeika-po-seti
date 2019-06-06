namespace Client
{
	partial class LoginForm
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

		#region Windows Form 
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ip_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.connect_BT = new System.Windows.Forms.Button();
            this.login_PN = new System.Windows.Forms.Panel();
            this.color_PN = new System.Windows.Forms.Panel();
            this.changeColor_right_BT = new System.Windows.Forms.Button();
            this.colorView_LB = new System.Windows.Forms.Label();
            this.changeColor_left_BT = new System.Windows.Forms.Button();
            this.start_BT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.changer_TM = new System.Windows.Forms.Timer(this.components);
            this.login_PN.SuspendLayout();
            this.color_PN.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(-13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello zmeika!";
            // 
            // ip_TB
            // 
            this.ip_TB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ip_TB.Location = new System.Drawing.Point(109, 17);
            this.ip_TB.Name = "ip_TB";
            this.ip_TB.Size = new System.Drawing.Size(128, 26);
            this.ip_TB.TabIndex = 1;
            this.ip_TB.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(57, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(57, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port : ";
            // 
            // port_TB
            // 
            this.port_TB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.port_TB.Location = new System.Drawing.Point(132, 76);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(105, 26);
            this.port_TB.TabIndex = 3;
            this.port_TB.Text = "6666";
            // 
            // connect_BT
            // 
            this.connect_BT.BackColor = System.Drawing.Color.LightGreen;
            this.connect_BT.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.connect_BT.Location = new System.Drawing.Point(109, 132);
            this.connect_BT.Name = "connect_BT";
            this.connect_BT.Size = new System.Drawing.Size(95, 46);
            this.connect_BT.TabIndex = 5;
            this.connect_BT.Text = "connect";
            this.connect_BT.UseVisualStyleBackColor = false;
            this.connect_BT.Click += new System.EventHandler(this.connect_BT_Click);
            // 
            // login_PN
            // 
            this.login_PN.Controls.Add(this.ip_TB);
            this.login_PN.Controls.Add(this.connect_BT);
            this.login_PN.Controls.Add(this.label2);
            this.login_PN.Controls.Add(this.label3);
            this.login_PN.Controls.Add(this.port_TB);
            this.login_PN.Location = new System.Drawing.Point(12, 101);
            this.login_PN.Name = "login_PN";
            this.login_PN.Size = new System.Drawing.Size(309, 203);
            this.login_PN.TabIndex = 6;
            // 
            // color_PN
            // 
            this.color_PN.Controls.Add(this.changeColor_right_BT);
            this.color_PN.Controls.Add(this.colorView_LB);
            this.color_PN.Controls.Add(this.changeColor_left_BT);
            this.color_PN.Controls.Add(this.start_BT);
            this.color_PN.Controls.Add(this.label4);
            this.color_PN.Location = new System.Drawing.Point(387, 101);
            this.color_PN.Name = "color_PN";
            this.color_PN.Size = new System.Drawing.Size(309, 203);
            this.color_PN.TabIndex = 7;
            this.color_PN.Visible = false;
            // 
            // changeColor_right_BT
            // 
            this.changeColor_right_BT.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.changeColor_right_BT.Location = new System.Drawing.Point(210, 81);
            this.changeColor_right_BT.Name = "changeColor_right_BT";
            this.changeColor_right_BT.Size = new System.Drawing.Size(28, 48);
            this.changeColor_right_BT.TabIndex = 10;
            this.changeColor_right_BT.Text = ">";
            this.changeColor_right_BT.UseVisualStyleBackColor = true;
            this.changeColor_right_BT.Click += new System.EventHandler(this.changeColor_right_BT_Click);
            // 
            // colorView_LB
            // 
            this.colorView_LB.BackColor = System.Drawing.Color.Black;
            this.colorView_LB.Location = new System.Drawing.Point(118, 81);
            this.colorView_LB.Name = "colorView_LB";
            this.colorView_LB.Size = new System.Drawing.Size(77, 48);
            this.colorView_LB.TabIndex = 9;
            // 
            // changeColor_left_BT
            // 
            this.changeColor_left_BT.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.changeColor_left_BT.Location = new System.Drawing.Point(75, 81);
            this.changeColor_left_BT.Name = "changeColor_left_BT";
            this.changeColor_left_BT.Size = new System.Drawing.Size(28, 48);
            this.changeColor_left_BT.TabIndex = 8;
            this.changeColor_left_BT.Text = "<";
            this.changeColor_left_BT.UseVisualStyleBackColor = true;
            this.changeColor_left_BT.Click += new System.EventHandler(this.changeColor_left_BT_Click);
            // 
            // start_BT
            // 
            this.start_BT.BackColor = System.Drawing.Color.LightGreen;
            this.start_BT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_BT.Location = new System.Drawing.Point(118, 152);
            this.start_BT.Name = "start_BT";
            this.start_BT.Size = new System.Drawing.Size(77, 35);
            this.start_BT.TabIndex = 7;
            this.start_BT.Text = "start_BT";
            this.start_BT.UseVisualStyleBackColor = false;
            this.start_BT.Click += new System.EventHandler(this.start_BT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(70, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ss：";
            // 
            // changer_TM
            // 
            this.changer_TM.Interval = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(333, 316);
            this.Controls.Add(this.color_PN);
            this.Controls.Add(this.login_PN);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "loginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.login_PN.ResumeLayout(false);
            this.login_PN.PerformLayout();
            this.color_PN.ResumeLayout(false);
            this.color_PN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ip_TB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox port_TB;
		private System.Windows.Forms.Button connect_BT;
		private System.Windows.Forms.Panel login_PN;
		private System.Windows.Forms.Panel color_PN;
		private System.Windows.Forms.Button start_BT;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button changeColor_right_BT;
		private System.Windows.Forms.Label colorView_LB;
		private System.Windows.Forms.Button changeColor_left_BT;
		private System.Windows.Forms.Timer changer_TM;
	}
}

