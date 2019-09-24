using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowChart
{
	public class Grid : IShape
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public float Scale { get; set; }
		public List<Shape> Shapes { get; set; }
		public int BlockSize { get; set; }
		public int Tickness { get; set; }



		public Grid() {
			Shapes = new List<Shape>();
			BlockSize = 20;
			Tickness = 2;
		}
		
		public Grid(int width, int height):this() {
			
			this.Width = width;
			this.Height = height;
		}

		public void Draw(Graphics g)
		{
			Brush brush = Brushes.LightGray;
			g.FillRectangle(brush, 0, 0, Width, Height);

			int colnumber = Width / BlockSize;
			int rownumber = Height / BlockSize;

			brush = Brushes.White;
			int x = Tickness, y = Tickness;
			for (int i = 0; i < rownumber; i++)
			{
				for (int j = 0; j < colnumber; j++)
				{
					g.FillRectangle(brush, x , y , BlockSize - (Tickness ), BlockSize - (Tickness ));
					x += BlockSize;
					
				}
				x = Tickness;
				y += BlockSize;
			}

			// pintar formas
			foreach (Shape shape in Shapes)
			{
				shape.Draw(g);
			}
		}
	}
}
