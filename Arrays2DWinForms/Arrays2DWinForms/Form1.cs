using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrays2DWinForms
{
    public partial class Form1 : Form
    {
        double[,] matrix;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number1 = (int)(numericUpDown1.Value);
            int number2 = (int)(numericUpDown2.Value);

            matrix = new double[number1, number2];
            
            dataGridView1.RowCount = matrix.GetLength(0);
            dataGridView1.ColumnCount = matrix.GetLength(1);

            Random r = new Random();
            for (int i = 0; i < number1; i++)
                for (int j = 0; j < number2; j++)
                {
                    matrix[i, j] = (double)r.Next(-278, 784) / 10;
                    dataGridView1[j, i].Value = matrix[i, j];
                }

            
 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool check = true;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check) counter++;
            }

            textBox1.Text = counter.ToString();




            double temp;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                bool f = false;
                for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                {
                    double[] sum = { 0, 0 };
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        sum[0] += matrix[k, j] > 0 ? matrix[k, j] : 0;
                        sum[1] += matrix[k, j + 1] > 0 ? matrix[k, j + 1] : 0;
                    }

                    if (sum[1] > sum[0])
                    {
                        f = true;
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            temp = matrix[k, j + 1];
                            matrix[k, j + 1] = matrix[k, j];
                            matrix[k, j] = temp;

                            dataGridView1[j, k].Value = matrix[k, j];
                            dataGridView1[j + 1, k].Value = matrix[k, j + 1];
                        }
                    }
                }
                if (!f) break;
            }
        }
    }
}
