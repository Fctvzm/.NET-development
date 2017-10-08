using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndTerm
{
    class Ball : UserControl
    {
        private GraphicsPath path;

        public Ball (Color color)
        {
            this.color = color;
            draw();
        }

        public Color color
        {
            get; set;
        }
        
        private void draw ()
        {
            path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);
            Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.FillPath(new SolidBrush(color), path);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            draw();
            Invalidate();
        }
    }
}
