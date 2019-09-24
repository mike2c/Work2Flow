using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowChart;
using WorkflowChart.Shapes;

namespace WorkflowChart
{
	public abstract class Shape: IShape
	{
		
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
        public bool IsSelected { get; set; }

		public Shape(int xPos, int yPos, int width, int height)
		{
			X = xPos;
			Y = yPos;
			Width = width;
			Height = height;
		}

		public Shape() {}

        public bool Intersect(int x, int y)
        {
            if (((x >= this.X) && x <= (this.X + this.Width))
                && ((y >= this.Y) && y <= (this.Y + this.Height)))
                return true;

            return false;
        }

        public void Translate(int xDisplacement, int yDisplacement)
        {
            this.X += xDisplacement;
            this.Y += yDisplacement;
        }

        public static Shape GetInstance(ShapeType shapeType) {

			Shape shape = null;


			switch (shapeType)
			{

				case ShapeType.Begin:


					break;

				case ShapeType.Process:

					shape = new ProcessShape();

					break;

				case ShapeType.End:

					break;

				case ShapeType.Conditional:

					break;
			}

			return shape;
		}

		public abstract void Draw(Graphics g);
	}
}
