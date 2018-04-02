using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public int top = 0;
        public int left =0;
        public Form1()
        {
            InitializeComponent();
            this.Width = 500 + 17;
            this.Height = 500 + 40;
            button5.Height = 10;
            button5.Width = 10;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Top = top;
            button5.Left = left;
            //Controls.Add(button5);

        }

        private void button2_Click(object sender, EventArgs e)
        {//top
            if (button5.Top<0)
            {
                button5.Top = 500;
                MessageBox.Show("ERROR");
            }
            else
            {
                top -= 10;
                button5.Top = top;
            }
            
               
           
           
           
        }
        private void button1_Click(object sender, EventArgs e)
        {//down
            if (button5.Top > 540)
            {
                button5.Top = 0;
            }
            else
            {
                top += 10;
                button5.Top = top;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {//right
            left += 10;
            button5.Left = left;
        }
        private void button3_Click(object sender, EventArgs e)
        {//left
            left -= 10;
            button5.Left = left;
        }
    }
}
