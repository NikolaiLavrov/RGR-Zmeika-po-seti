using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
	public partial class GameForm : Form
	{
		public GameForm()
		{
			InitializeComponent();
		}
	

		private struct SnackBody
		{
			public int id;
			public bool isHead;
			public int x, y;

			public SnackBody(int id, bool isHead, int x, int y)
			{
				this.id = id;
				this.isHead = isHead;
				this.x = x;
				this.y = y;
			}
		}


		Socket socketClient;
		Thread listenThread;
		IPEndPoint EP;
		byte[] data = new byte[10024];

		int myColor = 0, enemyColor = 0;
		int id, enemy_id;
		List<SnackBody> view;
		Point fruit;
		Color[] ava_color = { Color.Black, Color.White, Color.Yellow, Color.Blue };

		public void Ready(int id, int myColor, Socket socketClient)
		{
			try
			{
				this.id = id;
				if (id == 0) { enemy_id = 1; }
				else { enemy_id = 0; }
				this.myColor = myColor;
				myColor_LB.BackColor = ava_color[myColor];
				view = new List<SnackBody>();
				view.Add(new SnackBody(id, true, 1, 31));
				for (int i = 1; i <= 4; i++)
				{
					view.Add(new SnackBody(id, false, 1, 31 + i));
				}
				view.Add(new SnackBody(enemy_id, true, 60, 31));
				for (int i = 1; i <= 4; i++)
				{
					view.Add(new SnackBody(enemy_id, false, 60, 31 + i));
				}
				fruit = new Point(10, 10);
				this.socketClient = socketClient;
				listenThread = new Thread(socketReceive);
				listenThread.IsBackground = true;
				listenThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void socketReceive()
		{
			int recvLength = 0;
			try
			{
				do
				{
					recvLength = socketClient.Receive(data);
					if (recvLength > 0)
					{
						string command = Encoding.Default.GetString(data).Trim();
						Array.Clear(data, 0, data.Length);
						//MessageBox.Show(command);
						string[] commands = command.Split('`');
						for (int i = 1; i < commands.Length; i++)
						{
							string[] line = commands[i].Split(',');
				
							if (line[0] == "colorset")
							{
								enemyColor = int.Parse(line[1]);
								hint_LB.Text = "colorset";
							}
							else if (line[0] == "screen")
							{
								fruit = new Point(int.Parse(line[1]), int.Parse(line[2]));
								int count = int.Parse(line[3]);
								view.Clear();
								for (int j = 0; j < count; j++)
								{
									view.Add(new SnackBody(int.Parse(line[4 + (j * 4)]), bool.Parse(line[5 + (j * 4)]), int.Parse(line[6 + (j * 4)]), int.Parse(line[7 + (j * 4)])));
								}
							}
							else if(line[0] == "end")
							{
								if (line[1] == "win")
								{
									hint_LB.Text = "win";
								}
								else if (line[1] == "lose")
								{
									hint_LB.Text = "lose";
								}
								else if (line[1] == "fare")
								{
									hint_LB.Text = "fare";
								}
								printer_TM.Stop();
							}
						
						}
					}
				} while (true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void printer_TM_Tick(object sender, EventArgs e)
		{
			PrintScreen();
		}

		private void PrintScreen()
		{
			try
			{
			
				foreach (Control c in main_PN.Controls)
				{
					c.Dispose();
				}
				main_PN.Controls.Clear();
				foreach (SnackBody body in view)
				{
					PictureBox temp = new PictureBox();
					temp.Location = new Point((body.x - 1) * 20, (body.y - 1) * 20);
					temp.Size = new Size(20, 20);
					if (body.id == id)
					{
						if (body.isHead) temp.BackColor = Color.Red;
						else temp.BackColor = ava_color[myColor];
					}
					else
					{
						if (body.isHead) temp.BackColor = Color.Red;
						else temp.BackColor = ava_color[enemyColor];
					}
					main_PN.Controls.Add(temp);
				}
				PictureBox f = new PictureBox();
				f.Location = new Point((fruit.X - 1) * 20, (fruit.Y - 1) * 20);
				f.Size = new Size(20, 20);
				f.BackColor = Color.Purple;
				main_PN.Controls.Add(f);
			}
			catch (Exception ex)
			{
			}
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			socketClient.Send(Encoding.Default.GetBytes("`ready,"));
			Control.CheckForIllegalCrossThreadCalls = false;
			printer_TM.Start();
		}

		#region KeyDown KeyUp

		bool Wpress = false, Apress = false, Spress = false, Dpress = false;

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.W && !Wpress)
				{
			
					socketClient.Send(Encoding.Default.GetBytes("`way,w,"));
					Wpress = true;
					w_LB.BackColor = Color.FromArgb(135, 51, 36);
				}
				if (e.KeyCode == Keys.A && !Apress)
				{
			
					socketClient.Send(Encoding.Default.GetBytes("`way,a,"));
					Apress = true;
					a_LB.BackColor = Color.FromArgb(135, 51, 36);
				}
				if (e.KeyCode == Keys.S && !Spress)
				{
		
					socketClient.Send(Encoding.Default.GetBytes("`way,s,"));
					Spress = true;
					s_LB.BackColor = Color.FromArgb(135, 51, 36);
				}
				if (e.KeyCode == Keys.D && !Dpress)
				{
			
					socketClient.Send(Encoding.Default.GetBytes("`way,d,"));
					Dpress = true;
					d_LB.BackColor = Color.FromArgb(135, 51, 36);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void GameForm_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.W && Wpress)
				{
				
					Wpress = false;
					w_LB.BackColor = SystemColors.Control;
				}
				if (e.KeyCode == Keys.A && Apress)
				{
			
					Apress = false;
					a_LB.BackColor = SystemColors.Control;
				}
				if (e.KeyCode == Keys.S && Spress)
				{
				
					Spress = false;
					s_LB.BackColor = SystemColors.Control;
				}
				if (e.KeyCode == Keys.D && Dpress)
				{
			
					Dpress = false;
					d_LB.BackColor = SystemColors.Control;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion
	}
}
