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
            var meal = new Label();
            meal.Left = 10;
            meal.Top = 10;
            meal.Height = 10;
            meal.Width = 10;
            meal.BackColor = Color.Red;
            Controls.Add(meal);

            this.Width = 500 + 17;
            this.Height = 500 + 40;
            button5.Height = 10;
            button5.Width = 10;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Top = top;
            button5.Left = left;
            //Controls.Add(button5);

        }

        



        private void button5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                top -= 10;
                if (button5.Top < 0)
                {
                    top = 500;
                    button5.Top = top;
                    top -= 10;
                    button5.Top = top;

                }
                else
                {
                    top -= 10;
                    button5.Top = top;
                }
            }
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.Down)
            {
                top += 10;
                if (button5.Top > 500)
                {
                    top = 0;
                    button5.Top = top;

                    top += 10;
                    button5.Top = top;
                }
                else
                {
                    top += 10;
                    button5.Top = top;
                }
            }

            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.Right)
            {
                left += 10;
                if (button5.Left > 500)
                {
                    left = 0;
                    button5.Left = left;
                    left += 10;
                    button5.Left = left;
                }
                else
                {
                    left += 10;
                    button5.Left = left;
                }
            }
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.Left)
            {
                left -= 10;
                if (button5.Left < 0)
                {
                    left = 500;
                    button5.Left = left;
                    left -= 10;
                    button5.Left = left;
                }
                else
                {
                    left -= 10;
                    button5.Left = left;

                }
            }
        }
    }
}
