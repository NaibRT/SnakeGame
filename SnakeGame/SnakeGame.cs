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
        public int topbody = 10;
        public PictureBox snake;
        //public Button snakebas;// = new Button();
        public PictureBox meal;
        public Random teq = new Random();
        public List<PictureBox> body = new List<PictureBox>();
        public int count = 0;
        public int price = 0;

        public SnakeGame()
        {
            InitializeComponent();
            Random teq = new Random();
            meal = new PictureBox();
            meal.Enabled = false;
            meal.Left = 0;
            meal.Top = 100;
            meal.Height = 10;
            meal.Width = 10;
            meal.BackColor = Color.Red;






            for (int i = 0; i < 3; i++)
            {
                snake = new PictureBox();
                snake.Height = 10;
                snake.Width = 10;
                //snake.FlatStyle = FlatStyle.Popup;
                snake.Top = top;
                snake.Left = left;
                
                snake.BackColor = Color.White;
                body.Add(snake);

                top += 10;
            }
                //left += 20;
            
          

            foreach (var item in body)
            {
                Controls.Add(item);
            }
            Controls.Add(meal);
            
            this.Width = 520;
            this.Height = 540;
            this.KeyUp += new KeyEventHandler(SnakeGame_KeyUp);


            void SnakeGame_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up)
                {
                    for (int i = 0; i <body.Count-1 ; i++)
                    {
                        if (body[i].Top < 0)
                        {
                            top = 500;
                            body[i].Top = top;
                            //top -= 20;
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;

                        }
                        else
                        {
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }
                        
                    }
                    if (body[body.Count - 1].Top < 0)
                    {
                        body[body.Count - 1].Top = 500;
                        body[body.Count - 1].Top -= 10;
                    }
                    else
                    {
                        body[body.Count - 1].Top -= 10;
                    }
                    
                    mealeating();

                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Down)
                {
                    
                    // top += 10;
                    for (int i = 0; i < body.Count-1; i++)
                    {
                        if (body[i].Top > 500)
                        {
                            //top = 0;
                            //snakebas.Top = top;
                            //top += 20;
                            //snakebas.Top = top;

                            top = 0;
                            body[i].Top =top;
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }
                        else
                        {
                            //top += 20;
                            //snakebas.Top = top;
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;

                        }
                       
                    }
                    if (body[body.Count - 1].Top >500)
                    {
                        body[body.Count - 1].Top = 0;
                        body[body.Count - 1].Top += 10;
                    }
                    else
                    {
                        body[body.Count - 1].Top += 10;
                    }
                    mealeating();
                }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Right)
                {
                    for (int i = 0; i < body.Count-1; i++)
                    {
                        if (body[i].Left > 500)
                        {
                            //left = 0;
                            body[i].Left =0;
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }
                        else
                        {
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }

                    }
                    if (body[body.Count - 1].Left > 500)
                    {
                        body[body.Count - 1].Left = 0;
                        body[body.Count - 1].Left += 10;
                    }
                    else
                    {
                        body[body.Count - 1].Left += 10;
                    }
                     mealeating();
                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Left)
                {
                    for (int i = 0; i < body.Count-1; i++)
                    {
                        if (body[i].Left < 0)
                        {
                            left = 500;
                            body[i].Left = left;
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }
                        else
                        {
                            body[i].Top = body[i + 1].Top;
                            body[i].Left = body[i + 1].Left;
                        }

                    }
                    if (body[body.Count - 1].Left < 0)
                    {
                        body[body.Count - 1].Left = 500;
                        body[body.Count - 1].Left -= 10;
                    }
                    else
                    {
                        body[body.Count - 1].Left -= 10;
                    }

                
                    mealeating();

                }
            }

        }
          public  void mealeating()
        {
            if (body[body.Count - 1].Location.X == meal.Location.X && body[body.Count - 1].Location.Y == meal.Location.Y)
                {

                Controls.Remove(meal);
                body[body.Count-1].BackColor = Color.Green;
                textBox1.Text = "";
                textBox2.Text = "";
                count++;
                price += 5;
                textBox1.Text = count.ToString();
                textBox2.Text = price.ToString();
                makemeal();
                snakegrow();
            }
            
        }
        public void makemeal()
        {
            //int x = 0;
            while (true)
            {
                int x = teq.Next(0, 500);
                int y = teq.Next(0, 500);
                if (x % 10 == 0 && y % 10 == 0)
                {
                    meal = new PictureBox();
                    meal.Top = x;
                    meal.Left = y;

                    break;
                }
            }

            meal.Enabled = false;
            //meal.Top = 160;
            //meal.Left = 0;

            meal.Enabled = false;
            meal.Height = 10;
            meal.Width = 10;
            meal.BackColor = Color.Red;
            //meal.FlatStyle = FlatStyle.Flat;
            Controls.Add(meal);
            
        }//makemeal de deyisiklikler olunmalidi.
        public void snakegrow()
        {
            snake = new PictureBox();
            snake.Enabled = false;
            snake.Height = 10;
            snake.Width = 10;
            //snake.FlatStyle = FlatStyle.Popup;
          
           snake.Top = body[0].Top + 10;
            snake.Left = body[0].Left;
            snake.BackColor = Color.White;
            Controls.Add(snake);
            body.Add(snake);
        }

        private void SnakeGame_Load(object sender, EventArgs e)
        {

        }
    }
}
