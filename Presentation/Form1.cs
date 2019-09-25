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
using WorkflowChart.Container;

namespace Presentation
{
	public partial class Form1 : Form
	{
		//private Grid grid;
		//private Canvas canvas;

		private ShapeContainer shapeContainer;
		private GridShapeContainer gridContanier;

		public Form1()
		{
			InitializeComponent();			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			//grid = new Grid(this.Width, this.Height);

			////canvas = new Canvas(grid);
			////canvas.Location = new Point(10, 10);
			////canvas.Dock = DockStyle.Fill;
			////this.Controls.Add(canvas);

			//shapeContainer = new ShapeContainer(this);
			//shapeContainer.Dock = DockStyle.Fill;
			//shapeContainer.Width = 400;
			//shapeContainer.Height = 400;
			//shapeContainer.Location = new Point(0, 0);

			gridContanier = new GridShapeContainer(this);

			gridContanier.Width = 800;
			gridContanier.Height = 600;
			gridContanier.BlockSize = 20;
			gridContanier.Dock = DockStyle.Fill;

			Shape shape = Shape.GetInstance(ShapeType.Process);
			shape.X = 10;
			shape.Y = 10;
			shape.Width = 160;
			shape.Height = 70;
			gridContanier.Shapes.Add(shape);
		}

	}
}
