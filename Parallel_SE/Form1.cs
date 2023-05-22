using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_SE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long number = long.Parse(textBox1.Text);
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool is_prime = Prime(number);

            sw.Stop();

            if (is_prime)
            {
                MessageBox.Show("It is prime number. \n\nTime taken (ms) = " + sw.ElapsedMilliseconds.ToString());
            }
            else
            {
                MessageBox.Show("It is not prime number. \n\nTime taken (ms) = " + sw.ElapsedMilliseconds.ToString());
            }
        }

            private bool Prime(long number)
            {
            bool result=true;
                Parallel.For( 2, number/2 + 1, i =>
                {
                    if (number % i == 0)
                    {
                        result = false;
                    }
            });
            return result;
        }
    }
}
