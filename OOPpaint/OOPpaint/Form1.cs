using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPpaint
{
    public partial class Form1 : Form
    {
        Color color;
        Shape.ShapeType shape;
        bool isDrag = false; bool isRes = false;
        Point clicked = Point.Empty;
        Point[] polygon;
        UserControl cur = null;

        public Form1()
        {
            InitializeComponent();
            color = System.Drawing.Color.Black;
            shape = Shape.ShapeType.Rectangle;
            paintPanel.BackColor = System.Drawing.Color.White;
        }

        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
        }

        public void _MouseMove(object sender, MouseEventArgs e)
        {
            Control cur = (Control)sender;
            if (isDrag)
            {
                cur.Left = e.X - clicked.X + cur.Left;
                cur.Top = e.Y - clicked.Y + cur.Top;
            }
            else if (isRes)
            {
                if (cur.Cursor == Cursors.SizeNESW) {
                    cur.Location = new Point(cur.Location.X, e.Y);
                    cur.Width = e.X;
                    cur.Height += cur.Location.Y - e.Y;
                }
                else if (cur.Cursor == Cursors.SizeNWSE)
                {
                    cur.Width = e.X;
                    cur.Height = e.Y;
                }
            }
            else
            {
                label1.Text = e.X + " " + e.Y;
                if (((e.X + 5) > cur.Width && (e.Y + 5) > cur.Height) || ((e.X - 5) <= 0 && (e.Y - 5) <= 0))
                {
                    cur.Cursor = Cursors.SizeNWSE;
                }
                else if (((e.X + 5) > cur.Width && (e.Y - 5) <= 0) || ((e.X - 5) <= 0 && (e.Y + 5) > cur.Height))
                {
                    cur.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    cur.Cursor = Cursors.Arrow;
                }
            }
        }

        void _MouseDown(object sender, MouseEventArgs e)
        {
            Control cur = (Control)sender;
                clicked = e.Location;
                if ((e.X + 5) > cur.Width || (e.Y + 5) > cur.Height || (e.X - 5) <= 0 || (e.Y - 5) <= 0)
                {
                    isRes = true;
                }
                else isDrag = true;
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            Control cur = (Control)sender;
            isDrag = false; isRes = false;
        }

        void addControl(Point location)
        {
            Shape newShape = new Shape(color);
            if (shape == Shape.ShapeType.Triangle) newShape.polygon = polygon;
            newShape.Type = shape;
            newShape.Size = new Size(1, 1);
            newShape.Location = location;
            newShape.MouseDown += new MouseEventHandler(_MouseDown);
            newShape.MouseMove += new MouseEventHandler(_MouseMove);
            newShape.MouseUp += new MouseEventHandler(_MouseUp);
            paintPanel.Controls.Add(newShape);
            cur = newShape;
        }


        private void rectangle_Click(object sender, EventArgs e)
        {
            shape = Shape.ShapeType.Rectangle;
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            shape = Shape.ShapeType.Ellipse;
        }

        private void triangle_Click(object sender, EventArgs e)
        {
            shape = Shape.ShapeType.Triangle;
        }

        private void paintPanel_MouseDown(object sender, MouseEventArgs e)
        {
            addControl(e.Location);
        }

        private void paintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (cur != null)
            {
                cur.Width = e.X - cur.Location.X;
                cur.Height = e.Y - cur.Location.Y;
            }
        }

        private void paintPanel_MouseUp(object sender, MouseEventArgs e)
        {
            cur = null;
        }
    }
}
