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

namespace Server
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}	

	
		Socket SocketServer, SocketClient1, SocketClient2;      // sockets 
		Thread ReceiveThread1, ReceiveThread2;      
		byte[] data1 = new byte[10024];     
		byte[] data2 = new byte[10024];
		bool IsConnected;
		bool p0r = false, p1r = false;		
		bool start = false;
    public bool nextWays = false;
    int speed = 600;
		Point fruit;
		Player p0, p1;
    bool test = false;

    public bool newWaysTest()
    {
      return nextWays;
    }

    public bool getConnected()
    {
      return test;
    }


		private void Form1_Load(object sender, EventArgs e)
		{
			
			IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ipaddress in iphostentry.AddressList)
			{
				
				if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					ip_TB.Text = ipaddress.ToString();
				}
			}
			ListBox.CheckForIllegalCrossThreadCalls = false;
			p0 = new Player(0, -1);
			p1 = new Player(1, -1);
			main_timer.Start();
			GetFruit();
		}

		private void connectBtn_Click(object sender, EventArgs e)
		{
      test = true;
			try
			{
				SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     
				IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));       //setting server ip and port
				SocketServer.Bind(ep);
				SocketServer.Listen(2);
				IsConnected = true;
				log_LB.Items.Add("Socket Server！");
				log_LB.Update();
				connectBtn.Enabled = false;
				disconnectBtn.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			
			try
			{
				ReceiveThread1 = new Thread(ReceiveData1);     
				ReceiveThread1.IsBackground = true;    
				ReceiveThread1.Start();         

				ReceiveThread2 = new Thread(ReceiveData2);
				ReceiveThread2.IsBackground = true;
				ReceiveThread2.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			breakConnection();
		}

		private void disconnectBtn_Click(object sender, EventArgs e)
		{
			if (breakConnection())      //обрыва server
			{
				log_LB.Items.Add("[System] : diconnect");
			}
			connectBtn.Enabled = true;
			disconnectBtn.Enabled = false;
		}

		private bool breakConnection()
		{
			try
			{
				if (null != SocketClient1 && SocketClient1.Connected == true)
				{
					SocketClient1.Shutdown(SocketShutdown.Both);
					SocketClient1.Close();
				}
				if (null != SocketClient2 && SocketClient2.Connected == true)
				{
					SocketClient2.Shutdown(SocketShutdown.Both);
					SocketClient2.Close();
				}
				if (null != SocketServer && SocketServer.Connected == true)
				{
					SocketServer.Shutdown(SocketShutdown.Both);
					SocketServer.Close();
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

		public void ReceiveData1()
		{
			try
			{
				SocketClient1 = SocketServer.Accept();      // socket1 ，ожидает клиента 
				SocketClient1.Send(Encoding.Default.GetBytes("`joinSuccess,0,"));      //шлет клиенту 
				log_LB.Items.Add("p0:joinSuccess,0,"); // лог что подсоединился игрок

				try
				{
					do
					{
						if (SocketClient1.Receive(data1) > 0)   //checking received data != 0
						{
							string[] commands = Encoding.Default.GetString(data1).Trim().Split('`');
							Array.Clear(data1, 0, data1.Length);
							for (int i = 1; i < commands.Length; i++)
							{
								log_LB.Items.Add("p0:" + commands[i]);
								string[] line = commands[i].Split(',');
					
								if (line[0] == "color")
								{
									int temp = int.Parse(line[1]);
									if (p1.SnackColor == temp)
									{
										SocketClient1.Send(Encoding.Default.GetBytes("`color,false,"));
										log_LB.Items.Add("p0:color,false");
									}
									else
									{
										SocketClient1.Send(Encoding.Default.GetBytes("`color,true,"));
										log_LB.Items.Add("p0:color,true");
										p0.SnackColor = temp;
									}
								}
								else if (line[0] == "ready")
								{
									p0r = true;
									if (p0r && p1r)
									{
										SocketClient1.Send(Encoding.Default.GetBytes("`colorset," + p1.SnackColor + ","));
										SocketClient2.Send(Encoding.Default.GetBytes("`colorset," + p0.SnackColor + ","));
										start = true;
									}
								}
								else if (line[0] == "way")
								{
									if (line[1] == "w") ChangeWay(p0, Player.Way.Up);
									else if(line[1] == "a") ChangeWay(p0, Player.Way.Left);
									else if (line[1] == "s") ChangeWay(p0, Player.Way.Down);
									else if (line[1] == "d") ChangeWay(p0, Player.Way.Right);
								}
							
							}
						}
						else
						{
							SocketClient1.Close();
							SocketClient2.Close();
							SocketServer.Close();
							IsConnected = false;
							log_LB.Items.Add("server close");
						}
					} while (true);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void ReceiveData2()
		{
			SocketClient2 = SocketServer.Accept();
			SocketClient2.Send(Encoding.Default.GetBytes("`joinSuccess,1,"));
			log_LB.Items.Add("p1:joinSuccess,1,");
			try
			{
				do
				{
					if (SocketClient2.Receive(data2) > 0)   //checking received data != 0
					{
						string[] commands = Encoding.Default.GetString(data2).Trim().Split('`');
						Array.Clear(data2, 0, data2.Length);
						for (int i = 1; i < commands.Length; i++)
						{
							log_LB.Items.Add("p1:" + commands[i]);
							string[] line = commands[i].Split(',');
							
							if (line[0] == "color")
							{
								int temp = int.Parse(line[1]);
								if (p0.SnackColor == temp)
								{
									SocketClient2.Send(Encoding.Default.GetBytes("`color,false,"));
									log_LB.Items.Add("p1:color,false");
								}
								else
								{
									SocketClient2.Send(Encoding.Default.GetBytes("`color,true,"));
									log_LB.Items.Add("p1:color,true");
									p1.SnackColor = temp;
								}
							}
							else if (line[0] == "ready")
							{
								p1r = true;
								if (p0r && p1r)
								{
									SocketClient1.Send(Encoding.Default.GetBytes("`colorset," + p1.SnackColor + ","));
									log_LB.Items.Add("p0:colorset," + p1.SnackColor);
									SocketClient2.Send(Encoding.Default.GetBytes("`colorset," + p0.SnackColor + ","));
									log_LB.Items.Add("p1:colorset," + p0.SnackColor);
									start = true;
								}
							}
							else if (line[0] == "way")
							{
								if (line[1] == "w") ChangeWay(p1, Player.Way.Up);
								else if (line[1] == "a") ChangeWay(p1, Player.Way.Left);
								else if (line[1] == "s") ChangeWay(p1, Player.Way.Down);
								else if (line[1] == "d") ChangeWay(p1, Player.Way.Right);
							}
							
						}
					}
					else
					{
						SocketClient1.Close();
						SocketClient2.Close();
						SocketServer.Close();
						IsConnected = false;
						log_LB.Items.Add("close server");
					}
				} while (true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private List<Player.SnackBody> GetAllSnackBody()
		{
			List<Player.SnackBody> output = new List<Player.SnackBody>();
			for (int i = 0; i < p0.Body.Count(); i++)
			{
				p0.Body[i] = new Player.SnackBody(0, p0.Body[i].isHead, p0.Body[i].x, p0.Body[i].y);
				output.Add(p0.Body[i]);
			}
			for (int i = 0; i < p1.Body.Count(); i++)
			{
				p1.Body[i] = new Player.SnackBody(1, p1.Body[i].isHead, p1.Body[i].x, p1.Body[i].y);
				output.Add(p1.Body[i]);
			}
			return output;
		}

		private string GetScreenString()
		{
			List<Player.SnackBody> temp = GetAllSnackBody();
			string output = "`screen," + fruit.X + "," + fruit.Y + "," + temp.Count() + ",";
			foreach (Player.SnackBody sb in temp)
			{
				output += sb.id + "," + sb.isHead + "," + sb.x + "," + sb.y + ",";
			}
			return output;
		}

		private void GetFruit() 
		{
			List<Player.SnackBody> allBody = GetAllSnackBody();
			List<Point> avalible = new List<Point>();
			for (int i = 0; i <= 60; i++)
			{
				for (int j = 1; j <= 35; j++)
				{
					bool pass = true;
					foreach (Player.SnackBody body in allBody)
					{
						if (body.x == i && body.y == j)
						{
							pass = false;
							break;
						}
					}
					if (pass) avalible.Add(new Point(i, j));
				}
			}
			fruit = avalible[new Random().Next(0, avalible.Count())];
			log_LB.Items.Add("fr:" + fruit.X + "," + fruit.Y);
		}

		public void ChangeWay(Player player, Player.Way way)
		{
			if ((way == Player.Way.Up || way == Player.Way.Down) && player.NowWay != Player.Way.Down && player.NowWay != Player.Way.Up)
			{
				player.NextWay = way;
        
			}
			else if ((way == Player.Way.Left || way == Player.Way.Right) && player.NowWay != Player.Way.Left && player.NowWay != Player.Way.Right)
			{
				player.NextWay = way;
			}
      nextWays = true;
    }

		private void main_timer_Tick(object sender, EventArgs e)
		{
			if (start)
			{
				main_timer.Interval = speed;
				int result = SnackMove();
				SocketClient1.Send(Encoding.Default.GetBytes(GetScreenString()));
				SocketClient2.Send(Encoding.Default.GetBytes(GetScreenString()));
				if (result == 0)
				{
					//p0
					main_timer.Stop();
					SocketClient1.Send(Encoding.Default.GetBytes("`end,lose,"));
					SocketClient2.Send(Encoding.Default.GetBytes("`end,win,"));
				}
				else if (result == 1)
				{
					//p1
					main_timer.Stop();
					SocketClient1.Send(Encoding.Default.GetBytes("`end,win,"));
					SocketClient2.Send(Encoding.Default.GetBytes("`end,lose,"));
				}
				else if (result == 2)
				{
					
					main_timer.Stop();
					SocketClient1.Send(Encoding.Default.GetBytes("`end,fare,"));
					SocketClient2.Send(Encoding.Default.GetBytes("`end,fare,"));
				}
			}
		}

		private int SnackMove()
		{
			
			bool p0L = false, p1L = false;

			p0.NowWay = p0.NextWay;
			Player.SnackBody temp = new Player.SnackBody(0, false, p0.Body.Last().x, p0.Body.Last().y);
			if (p0.NowWay == Player.Way.Up)
			{
				if (p0.Body[0].y == 1) p0L = true; 
				else
				{
					for (int i = p0.Body.Count() - 1; i > 0; i--)
					{
						p0.Body[i] = new Player.SnackBody(0, false, p0.Body[i - 1].x, p0.Body[i - 1].y);
					}
					p0.Body[0] = new Player.SnackBody(0, true, p0.Body[0].x, p0.Body[0].y - 1);
				}
			}
			else if (p0.NowWay == Player.Way.Down)
			{
				if (p0.Body[0].y == 35) p0L = true; 
				else
				{
					for (int i = p0.Body.Count() - 1; i > 0; i--)
					{
						p0.Body[i] = new Player.SnackBody(0, false, p0.Body[i - 1].x, p0.Body[i - 1].y);
					}
					p0.Body[0] = new Player.SnackBody(0, true, p0.Body[0].x, p0.Body[0].y + 1);
				}
			}
			else if (p0.NowWay == Player.Way.Left)
			{
				if (p0.Body[0].x == 1) p0L = true; 
				else
				{
					for (int i = p0.Body.Count() - 1; i > 0; i--)
					{
						p0.Body[i] = new Player.SnackBody(0, false, p0.Body[i - 1].x, p0.Body[i - 1].y);
					}
					p0.Body[0] = new Player.SnackBody(0, true, p0.Body[0].x - 1, p0.Body[0].y);
				}
			}
			else if (p0.NowWay == Player.Way.Right)
			{
				if (p0.Body[0].x == 60) p0L = true;
				else
				{
					for (int i = p0.Body.Count() - 1; i > 0; i--)
					{
						p0.Body[i] = new Player.SnackBody(0, false, p0.Body[i - 1].x, p0.Body[i - 1].y);
					}
					p0.Body[0] = new Player.SnackBody(0, true, p0.Body[0].x + 1, p0.Body[0].y);
				}
			}

			if (p0.Ate) 
			{
				p0.Body.Add(temp);
				p0.Ate = false;
			}

			p1.NowWay = p1.NextWay;
			temp = new Player.SnackBody(0, false, p1.Body.Last().x, p1.Body.Last().y);
			if (p1.NowWay == Player.Way.Up)
			{
				if (p1.Body[0].y == 1) p1L = true; 
				else
				{
					for (int i = p1.Body.Count() - 1; i > 0; i--)
					{
						p1.Body[i] = new Player.SnackBody(0, false, p1.Body[i - 1].x, p1.Body[i - 1].y);
					}
					p1.Body[0] = new Player.SnackBody(0, true, p1.Body[0].x, p1.Body[0].y - 1);
				}
			}
			else if (p1.NowWay == Player.Way.Down)
			{
				if (p1.Body[0].y == 35) p1L = true; 
				else
				{
					for (int i = p1.Body.Count() - 1; i > 0; i--)
					{
						p1.Body[i] = new Player.SnackBody(0, false, p1.Body[i - 1].x, p1.Body[i - 1].y);
					}
					p1.Body[0] = new Player.SnackBody(0, true, p1.Body[0].x, p1.Body[0].y + 1);
				}
			}
			else if (p1.NowWay == Player.Way.Left)
			{
				if (p1.Body[0].x == 1) p1L = true; 
				else
				{
					for (int i = p1.Body.Count() - 1; i > 0; i--)
					{
						p1.Body[i] = new Player.SnackBody(0, false, p1.Body[i - 1].x, p1.Body[i - 1].y);
					}
					p1.Body[0] = new Player.SnackBody(0, true, p1.Body[0].x - 1, p1.Body[0].y);
				}
			}
			else if (p1.NowWay == Player.Way.Right)
			{
				if (p1.Body[0].x == 60) p1L = true;
				else
				{
					for (int i = p1.Body.Count() - 1; i > 0; i--)
					{
						p1.Body[i] = new Player.SnackBody(0, false, p1.Body[i - 1].x, p1.Body[i - 1].y);
					}
					p1.Body[0] = new Player.SnackBody(0, true, p1.Body[0].x + 1, p1.Body[0].y);
				}
			}

			if (p1.Ate) 
			{
				p1.Body.Add(temp);
				p1.Ate = false;
			}

		
			for (int i = 1; i < p0.Body.Count(); i++)
			{
				if (p0.Body[0].x == p0.Body[i].x && p0.Body[0].y == p0.Body[i].y)
				{
					p0L = true;
					break;
				}
			}
			
			for (int i = 0; i < p1.Body.Count(); i++)
			{
				if (p0.Body[0].x == p1.Body[i].x && p0.Body[0].y == p1.Body[i].y)
				{
					p0L = true;
					break;
				}
			}
			
			if (p0.Body[0].x == fruit.X && p0.Body[0].y == fruit.Y)
			{
				p0.Ate = true;
				GetFruit();
			}

			
			for (int i = 1; i < p1.Body.Count(); i++)
			{
				if (p1.Body[0].x == p1.Body[i].x && p1.Body[0].y == p1.Body[i].y)
				{
					p1L = true;
					break;
				}
			}
		
			for (int i = 0; i < p0.Body.Count(); i++)
			{
				if (p1.Body[0].x == p0.Body[i].x && p1.Body[0].y == p0.Body[i].y)
				{
					p1L = true;
					break;
				}
			}
			
			if (p1.Body[0].x == fruit.X && p1.Body[0].y == fruit.Y)
			{
				p1.Ate = true;
				GetFruit();
			}

			
			if (!p0L && !p1L) return -1;
			else if (p0L && !p1L) return 0;
			else if (!p0L && p1L) return 1;
			return 2;
		}
	}
}
