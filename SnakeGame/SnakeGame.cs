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
    public partial class SnakeGame : Form
    {
        public int top = 0;
        public int left = 0;
        public Button snake;
        public Button meal;
        public Random teq = new Random();

        public SnakeGame()
        {
            InitializeComponent();
            Random teq = new Random();
            
            meal = new Button();
            meal.Enabled = false;
            meal.Left = 100;//teq.Next(24,524);
            meal.Top = 100;//teq.Next(26, 524);
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;


            snake = new Button();
            snake.Height = 20;
            snake.Width = 20;
            snake.FlatStyle = FlatStyle.Flat;
            snake.Top = top;
            snake.Left = left;
            snake.BackColor = Color.White;
            Controls.Add(meal);
            Controls.Add(snake);
            this.Width = 500+17;
            this.Height = 500+40;
            //this.BringToFront();
            //this.Focus();
            //this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(SnakeGame_KeyUp);


            void SnakeGame_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up)
                {
                    //top -= 10;
                    if (snake.Top < 0)
                    {
                        top = 500;
                        snake.Top = top;
                        top -= 20;
                        snake.Top = top;

                    }
                    else
                    {
                        top -= 20;
                        snake.Top = top;
                    }
                    mealeating();
                    




                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Down)
                {
                   // top += 10;
                    if (snake.Top > 500)
                    {
                        top = 0;
                        snake.Top = top;

                        top += 20;
                        snake.Top = top;
                    }
                    else
                    {
                        top += 20;
                        snake.Top = top;
                    }
                    //if (snake.Left == meal.Left && snake.Top == meal.Top)
                    //{
                    //    meal.Hide();
                    //    snake.BackColor = Color.Green;

                    //}
                    mealeating();
                    

                }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Right)
                {

                   // left += 10;
                    if (snake.Left >500)
                    {
                        left = 0;
                        snake.Left = left;

                        left += 20;
                        snake.Left = left;
                    }
                    else
                    {
                        left += 20;
                        snake.Left = left;
                    }
                    mealeating();
                    

                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Left)
                {

                    //left -= 10;
                    if (snake.Left < 0)
                    {
                        left = 500;
                        snake.Left = left;
                        left -= 20;
                        snake.Left = left;
                    }
                    else
                    {
                        left -= 20;
                        snake.Left = left;

                    }
                    mealeating();
                    

                }
            }

        }
          public  void mealeating()
        {
            if (snake.Left == meal.Left && snake.Top == meal.Top)
            {
                meal.Hide();
                snake.BackColor = Color.Green;
                makemeal();

            }
        }
        public void makemeal()
        {
            int ran1 = 0;
            int ran2 = 0;
            meal = new Button();
            meal.Enabled = false;
            ran1=(teq.Next(0, 500)/2);
            ran2 = (teq.Next(0, 500) / 2);
            meal.Top = ran1;
            meal.Left = ran2;
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;
            Controls.Add(meal);
        }


    }
}
