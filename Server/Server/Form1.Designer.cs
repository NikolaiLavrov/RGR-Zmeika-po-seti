namespace Server
{
	partial class Form1
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
			this.main_timer = new System.Windows.Forms.Timer(this.components);
			this.port_Lab = new System.Windows.Forms.Label();
			this.ip_Lab = new System.Windows.Forms.Label();
			this.port_TB = new System.Windows.Forms.TextBox();
			this.ip_TB = new System.Windows.Forms.TextBox();
			this.disconnectBtn = new System.Windows.Forms.Button();
			this.connectBtn = new System.Windows.Forms.Button();
			this.log_LB = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// main_timer
			// 
			this.main_timer.Tick += new System.EventHandler(this.main_timer_Tick);
			// 
			// port_Lab
			// 
			this.port_Lab.AutoSize = true;
			this.port_Lab.Location = new System.Drawing.Point(217, 19);
			this.port_Lab.Name = "port_Lab";
			this.port_Lab.Size = new System.Drawing.Size(30, 12);
			this.port_Lab.TabIndex = 15;
			this.port_Lab.Text = "Port :";
			this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ip_Lab
			// 
			this.ip_Lab.AutoSize = true;
			this.ip_Lab.Location = new System.Drawing.Point(78, 18);
			this.ip_Lab.Name = "ip_Lab";
			this.ip_Lab.Size = new System.Drawing.Size(21, 12);
			this.ip_Lab.TabIndex = 14;
			this.ip_Lab.Text = "IP :";
			this.ip_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// port_TB
			// 
			this.port_TB.Location = new System.Drawing.Point(253, 15);
			this.port_TB.Name = "port_TB";
			this.port_TB.Size = new System.Drawing.Size(100, 22);
			this.port_TB.TabIndex = 13;
			this.port_TB.Text = "6666";
			// 
			// ip_TB
			// 
			this.ip_TB.Location = new System.Drawing.Point(104, 15);
			this.ip_TB.Name = "ip_TB";
			this.ip_TB.Size = new System.Drawing.Size(100, 22);
			this.ip_TB.TabIndex = 12;
			this.ip_TB.Text = "127.0.0.1";
			// 
			// disconnectBtn
			// 
			this.disconnectBtn.Enabled = false;
			this.disconnectBtn.Location = new System.Drawing.Point(229, 50);
			this.disconnectBtn.Name = "disconnectBtn";
			this.disconnectBtn.Size = new System.Drawing.Size(105, 35);
			this.disconnectBtn.TabIndex = 11;
			this.disconnectBtn.Text = "disconnectBtn";
			this.disconnectBtn.UseVisualStyleBackColor = true;
			this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
			// 
			// connectBtn
			// 
			this.connectBtn.Location = new System.Drawing.Point(104, 50);
			this.connectBtn.Name = "connectBtn";
			this.connectBtn.Size = new System.Drawing.Size(105, 35);
			this.connectBtn.TabIndex = 10;
			this.connectBtn.Text = "connectBtn";
			this.connectBtn.UseVisualStyleBackColor = true;
			this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
			// 
			// log_LB
			// 
			this.log_LB.FormattingEnabled = true;
			this.log_LB.ItemHeight = 12;
			this.log_LB.Location = new System.Drawing.Point(11, 104);
			this.log_LB.Margin = new System.Windows.Forms.Padding(2);
			this.log_LB.Name = "log_LB";
			this.log_LB.Size = new System.Drawing.Size(434, 424);
			this.log_LB.TabIndex = 9;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 538);
			this.Controls.Add(this.port_Lab);
			this.Controls.Add(this.ip_Lab);
			this.Controls.Add(this.port_TB);
			this.Controls.Add(this.ip_TB);
			this.Controls.Add(this.disconnectBtn);
			this.Controls.Add(this.connectBtn);
			this.Controls.Add(this.log_LB);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer main_timer;
		private System.Windows.Forms.Label port_Lab;
		private System.Windows.Forms.Label ip_Lab;
		private System.Windows.Forms.TextBox port_TB;
		private System.Windows.Forms.TextBox ip_TB;
		private System.Windows.Forms.Button disconnectBtn;
		public System.Windows.Forms.Button connectBtn;
		private System.Windows.Forms.ListBox log_LB;
	}
}

