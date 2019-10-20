using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrays1DWinForms
{
    public partial class Form1 : Form
    {
        double[] arr;

        public Form1()
        {
            InitializeComponent();                                  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = (int)(numericUpDown1.Value);
            arr = new double[value];

            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = value;


            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr.SetValue((double)r.Next(-11034, 11035) / 100, i);
                dataGridView1[i, 0].Value = arr[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Array.Sort(arr, 0, Array.IndexOf(arr, arr.Min()));
            for (int i = 0; i < arr.Length; i++)
                dataGridView1[i, 0].Value = arr[i];


            double suma = arr.Max() + arr.Min();
            textBox1.Text = suma.ToString();
        }
    }
}
