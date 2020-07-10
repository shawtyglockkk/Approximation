using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _777
{
    public partial class Form1 : Form
    {
        private List<double> X, Y;
        private double Sum_x_y, Sum_x2, Sum_x, Sum_y, Sum_sr;
        private double q, w;

        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            X.Clear(); Y.Clear();
            dataGridView1.Columns.Clear(); 
            dataGridView1.ColumnCount = 2;
            label1.Text = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            X = new List<double>();
            Y = new List<double>();

            dataGridView1.ColumnCount = 2;
            label1.Text = null;
            textBox1.Text = "0";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                X.Add((double)Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
                Y.Add((double)Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));

            }
            for (int i = 0; i < X.Count; i++)
            {
                Sum_x += X[i];
                Sum_y += Y[i];
                Sum_x_y += X[i] * Y[i];
                Sum_x2 += X[i] * X[i];
            }
            q = (double)(X.Count * Sum_x_y - Sum_x * Sum_y) / (double)(X.Count * Sum_x2 - Sum_x * Sum_x);
            w = (double)(Sum_y - q * Sum_x) / (double)X.Count;
            for (int i = 0; i < X.Count; i++)
            {
                Sum_sr += ((Y[i] - (q * X[i] + w)) * (Y[i] - (q * X[i] + w)));
            }
            textBox1.Text = Convert.ToString(Sum_sr);
            label1.Text = "y =" + q + "x +" + w;

        }
    }
}
