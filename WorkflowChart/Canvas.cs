using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowChart.Shapes;
using System.Drawing;

namespace WorkflowChart
{
	public class Canvas:Control
	{
		private Graphics graphics;
		public Grid Grid { get; set; }
		
		public Canvas(Grid grid):base() {
			this.Grid = grid;
		}

		public void AppendShape(Position position, Dimension dimension, ShapeType shape) {
		
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			Brush background = Brushes.White;
			g.FillRectangle(background, this.Location.X, this.Location.Y, this.Width, this.Height);
			this.Grid.Draw(g);

			//foreach (Shape shape in shapes)
			//{
			//	shape.draw(graphics);
			//}
		}
	}
}
