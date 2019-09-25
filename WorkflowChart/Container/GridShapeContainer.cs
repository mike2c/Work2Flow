using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkflowChart.Container
{
	public class GridShapeContainer : ShapeContainer
	{

		private int blockSize;
		public int BlockSize { 
			get
			{
				return blockSize;
			}
					
			set
			 {
				blockSize = value;
				OnBlockSizeChanged(new BlockSizeEventArgs(value));
			} 
		}

		private int height;
		public new int Height
		{
			get
			{
				return height;
			}
			set
			{
				this.height = value;
				CalculateDimension();
			}
		}

		private int width;
		public new int Width
		{
			get
			{
				return width;
			}
			set
			{
				this.width = value;
				CalculateDimension();
			}
		}

		public int GridLineWidth { get; set; }
		public Color GridLineColor { get; set; }
		public int ColumnCount { get; set; }
		public int RowCount { get; set; }

		public event EventHandler<BlockSizeEventArgs> BlockSizeChanged;

		public GridShapeContainer(Control parent) : base(parent)
		{
			this.BlockSize = 20;
			this.GridLineWidth = 2;
			this.BackgroundColor = Color.LightGray;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Brush background = new SolidBrush(BackgroundColor);
			g.FillRectangle(background, this.Location.X, this.Location.Y, this.Width, this.Height);

			// calculamos y dibujamos la cuadricula
			Brush brush = Brushes.White;
			int x = GridLineWidth, y = GridLineWidth;
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					g.FillRectangle(brush, x, y, BlockSize - (GridLineWidth), BlockSize - (GridLineWidth));
					x += BlockSize;
				}

				x = GridLineWidth;
				y += BlockSize;
			}

			// dibujamos las figuras
			foreach (Shape shape in Shapes)
			{
				shape.Draw(g);
			}
		}

		protected virtual void OnBlockSizeChanged(BlockSizeEventArgs e)
		{
			CalculateDimension();
			BlockSizeChanged?.Invoke(this, e);			
		}

		/*
			EventHandler<BlockSizeEventArgs> handler = BlockSizeChanged;
			if (handler != null){				
				handler(this, e);
			}
		*/

		private void CalculateDimension() {
			ColumnCount = Width / BlockSize;
			RowCount = Height / BlockSize;
		}

		protected new void OnMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isPressed = false;

				foreach (Shape shape in Shapes)
				{
					shape.X = (shape.X % BlockSize) * BlockSize;
					shape.Y = (shape.Y % BlockSize) * BlockSize;

				}

				Refresh();
			}
		}	
	}
}
