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
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		Socket socketClient;
		Thread listenThread;
		IPEndPoint EP;
		byte[] data = new byte[10024];
		bool IsConnect;
		int my_id = -1;

		private void connect_BT_Click(object sender, EventArgs e)
		{
			try
			{
				if (ip_TB.Text != "" && port_TB.Text != "")
				{
					ListBox.CheckForIllegalCrossThreadCalls = false;
					socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					EP = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));
					socketClient.Connect(EP);
					listenThread = new Thread(socketReceive);
					listenThread.IsBackground = true;
					listenThread.Start();
					IsConnect = true;
					color_PN.Location = login_PN.Location;
					login_PN.Visible = false;
					color_PN.Visible = true;
				}
				else
				{
					MessageBox.Show("Пожалуйста, введите информацию");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
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
							if (line[0] == "joinSuccess")
							{
								my_id = int.Parse(line[1]);
							}
							else if (line[0] == "color" && line[1] == "true")
							{
								GameForm gameForm = new GameForm();
								gameForm.Ready(my_id, nowColor, socketClient);
								this.Hide();
								gameForm.ShowDialog();
								this.Close();
							}
							else if (line[0] == "color" && line[1] == "false")
							{
								MessageBox.Show("Другой участник выбрал этот цвет, попробуйте другой!");
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

		
		Color[] ava_color = { Color.Black, Color.White, Color.Yellow, Color.Blue };
		int nowColor = 0;

		private void start_BT_Click(object sender, EventArgs e)
		{
			socketClient.Send(Encoding.Default.GetBytes("`color," + nowColor + ","));
		}

		private void changeColor_left_BT_Click(object sender, EventArgs e)
		{
			
			if (nowColor == 0) { nowColor = ava_color.Length - 1; }
			else { nowColor -= 1; }
			colorView_LB.BackColor = ava_color[nowColor];
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			LoginForm.CheckForIllegalCrossThreadCalls = false;
		}

		private void changeColor_right_BT_Click(object sender, EventArgs e)
		{
			
			if (nowColor == ava_color.Length - 1) { nowColor = 0; }
			else { nowColor += 1; }
			colorView_LB.BackColor = ava_color[nowColor];
		}
	}
}
