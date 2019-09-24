using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowChart.Shapes;

namespace WorkflowChart
{
	public class Canvas:Control
	{
        private bool isPressed = false;
		public Grid Grid { get; set; }

        private Point startPoint;
        private Point finalPoint;

        public Canvas(Grid grid):base() {

            this.DoubleBuffered = true;
            startPoint = new Point();
            startPoint = new Point();

            this.Grid = grid;
            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.MouseUp += new MouseEventHandler(OnMouseUp);
            this.MouseMove += new MouseEventHandler(OnMouseMove);

            this.Controls.Add(new Button());
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
		}

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {               
                isPressed = true;
                startPoint = e.Location;
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = false;
                            
            }
           
            //Console.WriteLine(startPoint.X);
            //Console.WriteLine(startPoint.Y);
            //Console.WriteLine(finalPoint.X);
            //Console.WriteLine(finalPoint.Y);
            //Refresh();
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {            
            if (isPressed)
            {
                foreach (Shape shape in Grid.Shapes)
                {
                    if (shape.Intersect(e.Location.X, e.Location.Y))
                        shape.IsSelected = !shape.IsSelected;
                }

                finalPoint = e.Location;              

                int xDisplace = finalPoint.X - startPoint.X;
                int yDisplace = finalPoint.Y - startPoint.Y;

                List<Shape> selectedShapes = (from shape in this.Grid.Shapes
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
