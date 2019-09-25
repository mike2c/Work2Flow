using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkflowChart.Container
{
	public class ShapeContainer : Control
	{
		protected Control parent;
		protected bool isPressed = false;
		protected Point startPoint;
		protected Point finalPoint;

		public Color BackgroundColor { get; set; }
		public List<Shape> Shapes { get; set; }

		public ShapeContainer(Control parent)
		{
			this.DoubleBuffered = true;
			this.parent = parent;
			parent.Controls.Add(this);
			BackgroundColor = Color.White;

			Shapes = new List<Shape>();

			// Agregamos los eventos al control
			this.MouseDown += new MouseEventHandler(OnMouseDown);
			this.MouseUp += new MouseEventHandler(OnMouseUp);
			this.MouseMove += new MouseEventHandler(OnMouseMove);
		}

		public void AddShape(Shape shape) {

			if(shape != null)
				Shapes.Add(shape);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Brush background = new SolidBrush(BackgroundColor);
			g.FillRectangle(background, this.Location.X, this.Location.Y, this.Width, this.Height);

			foreach (Shape shape in Shapes)
			{
				shape.Draw(g);
			}

		}

		protected void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isPressed = true;
				startPoint = e.Location;
			}
		}

		protected void OnMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isPressed = false;
			}
		}

		protected void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (isPressed)
			{
				foreach (Shape shape in Shapes)
				{
					if (shape.Intersect(e.Location.X, e.Location.Y))
						shape.IsSelected = !shape.IsSelected;
				}

				finalPoint = e.Location;

				int xDisplace = finalPoint.X - startPoint.X;
				int yDisplace = finalPoint.Y - startPoint.Y;

				List<Shape> selectedShapes = (from shape in this.Shapes
											  where shape.IsSelected == true
											  select shape).ToList<Shape>();

				if (xDisplace != 0 || yDisplace != 0)
				{
					foreach (Shape shape in selectedShapes)
					{
						shape.Translate(xDisplace, yDisplace);
						shape.IsSelected = !shape.IsSelected;
					}
				}

				startPoint = finalPoint;
				Refresh();
			}
		}
	}
}
