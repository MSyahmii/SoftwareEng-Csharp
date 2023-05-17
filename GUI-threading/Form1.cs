using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI_threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread T1 = new Thread(() =>
            //{
            //   label2.BeginInvoke(new Action(() => label2.Text = "Proocessing..."));

            //   Thread.Sleep(5000);

            //   label2.BeginInvoke(new Action(() => label2.Text = "Answer=53"));

            //}); 

            //T1.IsBackground = true;
            //T1.Start();

            button1.Enabled = false;
            label2.Text = "procesing,...";
            int number = int.Parse(textBox1.Text);
            var awaiter = GetPrimesCountAsync(number);
            awaiter.Getawaiter().OnCompleted(() =>
            {
                label2.Text = "There are " = awaiter.Result + " primes";
                button1.Enabled = true;
            });

        }

        Task <int> GetPrimesCountAsync(int max)
        {
            return Task.Run(() => ParallelEnumerable.Range(2, max).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        int GetPrimesCountAsync(int max)
        {
            return Task.Run(() => ParallelEnumerable.Range(2, max).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}
