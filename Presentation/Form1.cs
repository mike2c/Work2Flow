using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowChart;

namespace Presentation
{
	public partial class Form1 : Form
	{
		private Grid grid;
		private Canvas canvas;

		public Form1()
		{
			InitializeComponent();			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			grid = new Grid(this.Width, this.Height);

			canvas = new Canvas(grid);
			canvas.Location = new Point(10, 10);
			canvas.Dock = DockStyle.Fill;
			this.Controls.Add(canvas);

			Shape shape = Shape.GetInstance(ShapeType.Process);
			shape.X = 10;
			shape.Y = 10;
			shape.Width = 160;
			shape.Height = 70;
			this.grid.Shapes.Add(shape);
		}

	}
}
