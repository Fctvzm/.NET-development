using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPpaint
{
    class Shape : UserControl
    {
        public enum ShapeType { Rectangle, Ellipse, Triangle };
        private ShapeType shape = ShapeType.Rectangle;
        private GraphicsPath path;
        private Color color;
        public Point[] polygon { get; set; }

        public Shape(Color color)
        {
            this.color = color;
        }

        public ShapeType Type
        {
            get { return shape; }
            set
            {
                shape = value;
                draw();
            }
        }

        public void draw()
        {
            path = new GraphicsPath();
            switch (shape)
            {
                case ShapeType.Rectangle:
                    path.AddRectangle(ClientRectangle);
                    break;
                case ShapeType.Ellipse:
                    path.AddEllipse(ClientRectangle);
                    break;
                case ShapeType.Triangle:
                    path.AddPolygon(polygon);
                    break;
            }
            Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (path != null)
            {
                //e.Graphics.FillPath(new SolidBrush(color), path);
                e.Graphics.DrawPath(new Pen(color, 4), path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            draw();
            Invalidate();
        }
    }
}
