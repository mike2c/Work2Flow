using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowChart.Container
{
	public class BlockSizeEventArgs : EventArgs
	{
		public BlockSizeEventArgs(int blockSize)
		{
			this.BlockSize = blockSize;
		}

		public int BlockSize { get; set; }
	}	
}
