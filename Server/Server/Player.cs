using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Server
{
	

	public class Player
	{
		
		public Color[] ava_color = { Color.Black, Color.White, Color.Yellow, Color.Blue };

		public enum Way { Up, Down, Left, Right }

		public struct SnackBody
		{
			public int id;
			public bool isHead;
			public double x, y;

			public SnackBody(int id, bool isHead, double x, double y)
			{
				this.id = id;
				this.isHead = isHead;
				this.x = x;
				this.y = y;
			}
		}

		public int Id { get; set; }
		public int SnackColor { get; set; }
		public Way NowWay { get; set; }
		public Way NextWay { get; set; }
		public List<SnackBody> Body { get; set; }
		public bool Ate { get; set; }

		public Player(int Id, int SnackColor)
		{
			Ate = false;
			this.Id = Id;
			this.SnackColor = SnackColor;
			NowWay = Way.Up;
			NextWay = Way.Up;
			Body = new List<SnackBody>();

			if (Id == 0)
			{
				
				Body.Add(new SnackBody(Id, true, 1, 31));
				for (int i = 1; i <= 4; i++)
				{
					Body.Add(new SnackBody(Id, false, 1, 31 + i));
				}
			}
			else
			{
				Body.Add(new SnackBody(Id, true, 60, 31));
				for (int i = 1; i <= 4; i++)
				{
					Body.Add(new SnackBody(Id, false, 60, 31 + i));
				}
			}
		}
	}
}
