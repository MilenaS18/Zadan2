using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zadan2
{
    public partial class Form1 : Form
    {
        
        int[,] myArr = new int[5, 5];
        public Form1()
    
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
       {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
           
            Random ran = new Random();
   
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[j, i] = ran.Next(0, 5);

                    dataGridView1.Rows[i].Cells[j].Value = myArr[j,i];
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            int[,] myArr2 = new int[5, 5];
            float sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        myArr2[i, j] = (myArr[i + 1, j] + myArr[i, j + 1]) / 2;
                        continue;
                    }
                    if (i == 0 && j == 4)
                    {
                        myArr2[i, j] = (myArr[i, j - 1] + myArr[i + 1, j]) / 2;
                        continue;
                    }
                    if (i == 4 && j == 0)
                    {
                        myArr2[i, j] = (myArr[i, j + 1] + myArr[i - 1, j]) / 2;
                        continue;
                    }
                    if (i == 4 && j == 4)
                    {
                        myArr2[i, j] = (myArr[i, j - 1] + myArr[i - 1, j]) / 2;
                        continue;
                    }
                    if (i == 0 && j != 0 && j != 4)
                    {
                        myArr2[i, j] = (myArr[i, j - 1] + myArr[i + 1, j] + myArr[i, j + 1]) / 3;
                        continue;
                    }
                    if (i == 4 && j != 0 && j != 4)
                    {
                        myArr2[i, j] = (myArr[i, j - 1] + myArr[i - 1, j] + myArr[i, j + 1]) / 3;
                        continue;
                    }
                    if (j == 4 && i != 0 && i != 4)
                    {
                        myArr2[i, j] = (myArr[i, j - 1] + myArr[i + 1, j] + myArr[i - 1, j]) / 3;
                        continue;
                    }
                    if (j == 0 && i != 0 && i != 4)
                    {
                        myArr2[i, j] = (myArr[i, j + 1] + myArr[i + 1, j] + myArr[i - 1, j]) / 3;
                        continue;
                    }
                    if (i > 0 && j > 0 && i < 4 && j < 4)
                    {
                        myArr2[i, j] = (myArr[i + 1, j] + myArr[i - 1, j] + myArr[i, j - 1] + myArr[i, j + 1]) / 4;
                        continue;
                    }
                }

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = myArr2[i, j];
                }
            }
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = myArr[j, i];
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i > j)
                        sum += myArr[i, j];
                }
            }

            this.label1.Text = System.Convert.ToString(sum);

            Graphics gr = chart1.CreateGraphics();
            gr.Clear(Color.White);
            Rectangle data_bounds = new Rectangle(0, 0, 11, 10);
            Point[] points = {
                new Point (0, chart1.Height),
                new Point(chart1.Width, chart1.Height),
                new Point(0,0)
            };
            Matrix transformation = new Matrix(data_bounds, points);
            gr.Transform = transformation;

            using (Pen p = new Pen(Color.Black, 0))
            {
                for (int i = 0; i < 5; i++)
                {
                    Rectangle rect = new Rectangle(i, 0, 1, myArr[i, 1]);
                    using (Brush br = new SolidBrush(Color.Pink))
                    {
                        gr.FillRectangle(br, rect);
                        gr.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }

        }
     
    }
}

