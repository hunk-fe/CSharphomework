using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int recursionDepth = 10;
        double length = 100;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {

            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            Pen mypen = new Pen(btn_Color_Changed.ForeColor);

            graphics.DrawLine(
                mypen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void draw_click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, panel_Draw.Width, panel_Draw.Height);

            using (Graphics g = panel_Draw.CreateGraphics())
            {
                g.FillRectangle(Brushes.White, rect);
            }

            if (graphics == null)
                graphics = panel_Draw.CreateGraphics();

            drawCayleyTree(recursionDepth, 280, 340, length, -Math.PI / 2);
        }

        private void NUD_Recursion_Changed(object sender, EventArgs e)
        {
            recursionDepth = Int32.Parse(NUD_Recursion.Value.ToString());
        }

        private void TB_Length_Changed(object sender, EventArgs e)
        {
            length_Value.Text = TB_Length.Value.ToString();
            length = Int32.Parse(length_Value.Text);
        }

        private void TB_Per1_Changed(object sender, EventArgs e)
        {
            double per1Tx = Double.Parse(TB_Per1.Value.ToString()) ;
            per1_Value.Text = (per1Tx / 100).ToString();
            per1 = Double.Parse(per1_Value.Text);
        }

        private void TB_Per2_ValueChanged(object sender, EventArgs e)
        {
            double per2Tx = Double.Parse(TB_Per2.Value.ToString());
            per2_Value.Text = (per2Tx / 100).ToString();
            per2 = Double.Parse(per2_Value.Text);
        }

        private void TB_Th1_ValueChanged(object sender, EventArgs e)
        {
            double th1Tx = Double.Parse(TB_Th1.Value.ToString());
            th1_Value.Text = th1Tx.ToString() + "°";
            th1 = th1Tx * Math.PI / 180;
        }

        private void TB_Th2_ValueChanged(object sender, EventArgs e)
        {
            double th2Tx = Double.Parse(TB_Th2.Value.ToString());
            th2_Value.Text = th2Tx.ToString() + "°";
            th2 = th2Tx * Math.PI / 180;
        }

        ColorDialog colorDialog = new ColorDialog();

        private void btn_Color_Changed_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog.ShowDialog();

            //colorDialog.FullOpen = true;
            btn_Color_Changed.ForeColor = colorDialog.Color;
        }
    }
}
