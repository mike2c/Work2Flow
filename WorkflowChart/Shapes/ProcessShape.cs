using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowChart.Shapes
{
	class ProcessShape : Shape
	{

		public override void Draw(Graphics g)
		{

			Brush brush = new SolidBrush(Color.FromArgb(120, 0, 0, 0));
			g.FillRectangle(brush, X + 5, Y + 5, Width, Height);

			brush = new SolidBrush(Color.FromArgb(190, 255, 255, 255));
			g.FillRectangle(brush, X, Y, Width, Height);

			Pen pen = new Pen(Color.LightGray);
			g.DrawRectangle(pen, X, Y, Width, Height);

			brush = new SolidBrush(Color.FromArgb(255, 98, 156, 233));
			g.FillRectangle(brush, X + 6, Y + 6, Width - 10, Height - 10);
			g.DrawImage(Image.FromFile("Shapes/process.png"), X+ 8,Y+ 8, 18, 18);

		}
	}
}
