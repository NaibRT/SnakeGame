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
        public int topbody = 20;
        public Button snake;
        public Button snakebas;// = new Button();
        public Button meal;
        public Random teq = new Random();
        public List<Button> body = new List<Button>();
      

        public SnakeGame()
        {
            InitializeComponent();
            Random teq = new Random();
            meal = new Button();
            meal.Enabled = false;
            meal.Left = 0;
            meal.Top = 100;
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;
            
            

            
            
                snakebas = new Button();
                snakebas.Height = 20;
                snakebas.Width = 20;
                snakebas.FlatStyle = FlatStyle.Popup;
                snakebas.Top = top;
                snakebas.Left = left;
                snakebas.BackColor = Color.White;
                body.Add(snakebas);
             
                top += 20;
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
                    for (int i = 0; i <body.Count ; i++)
                    {
                        if (body[i].Top < 0)
                        {
                            top = 500;
                            body[i].Top = top;
                            //top -= 20;
                            body[i].Top -= 20;

                        }
                        else
                        {
                            if (body[i]==body[0])
                            {
                                //top -= 20;
                                body[i].Top -= 20;
                            }
                            else if (body[i].Left > body[i-1].Left)
                            {
                                body[i].Left -= 20;
                            }
                            else if (body[i].Left < body[0].Left)
                            {
                                body[i].Left += 20;
                            }
                            else
                            {
                                body[i].Top -= 20;
                            }
                        }
                        
                    }
                    mealeating();

                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Down)
                {
                    
                    // top += 10;
                    for (int i = 0; i < body.Count; i++)
                    {
                        if (body[i].Top > 500)
                        {
                            //top = 0;
                            //snakebas.Top = top;
                            //top += 20;
                            //snakebas.Top = top;

                            top = 0;
                            body[i].Top =top;
                            top += 20;
                            body[i].Top = top;
                         }
                        else
                        {
                            //top += 20;
                            //snakebas.Top = top;
                            if (body[i] == body[0])
                            {
                                //top += 20;
                                body[i].Top += 20;
                            }
                            else if (body[i].Top < body[i-1].Top && body[i].Left < body[i - 1].Left)
                            {
                                body[i].Left += 20;
                            }
                            else if (body[i].Top==body[i-1].Top && body[i].Left < body[i - 1].Left)
                            {
                                body[i].Left += 20;
                            }
                            else if (body[i].Top > body[i - 1].Top && body[i].Left < body[i - 1].Left)
                            {
                                body[i].Top -= 20;
                            }
                            else if (body[i].Top < body[i - 1].Top && body[i].Left == body[i - 1].Left)
                            {
                                body[i].Top += 20;
                            }
                            else if (body[i].Top > body[i - 1].Top && body[i].Left == body[i - 1].Left)
                            {
                                body[i].Top -= 20;
                            }
                            else if (body[i].Top<body[i-1].Top && body[i].Left> body[i-1].Left)
                            {
                                body[i].Left -= 20;
                            }
                           




                        }
                       
                    }
                    mealeating();
                }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Right)
                {
                    for (int i = 0; i < body.Count; i++)
                    {
                        if (body[i].Left > 500)
                        {
                            left = 0;
                            body[i].Left = left;
                            left += 20;
                            body[i].Left = left;
                        }
                        else
                        {
                            if (body[i]==body[0])
                            {
                                //left += 20;
                                body[i].Left += 20;
                            }
                            else if (body[i].Top > body[0].Top)
                            {
                                body[i].Top -= 20;
                            }
                            else if (body[i].Top < body[0].Top)
                            {
                                body[i].Top += 20;
                            }
                            else 
                            {
                                body[i].Left += 20;
                            }
                            
                         }
                        
                    }
                    mealeating();
                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Left)
                {
                    for (int i = 0; i < body.Count; i++)
                    {
                        if (body[i].Left < 0)
                        {
                            left = 500;
                            body[i].Left = left;
                            left -= 20;
                            body[i].Left = left;
                        }
                        else
                        {
                            if (body[i]==body[0])
                            {
                                //left -= 20;
                                body[i].Left -=20;
                            }
                            else if (body[i].Top < body[0].Top)
                            {
                                body[i].Top += 20;
                            }
                            else if (body[i].Top >body[0].Top)
                            {
                                body[i].Top -= 20;
                            }
                            else
                            {
                                body[i].Left -= 20;
                            }
                           

                        }
                       
                    }
                    mealeating();

                }
            }

        }
          public  void mealeating()
        {
            if (body[0].Location.X == meal.Location.X && body[0].Location.Y == meal.Location.Y)
                {
                Controls.Remove(meal);
                body[0].BackColor = Color.Green;
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
                //int y = teq.Next(0, 500);
                if (x % 20 == 0)// && y % 20 == 0)
                {
                    meal = new Button();
                    meal.Top = x;
                    //meal.Left = y;

                    break;
                }
            }

            meal.Enabled = false;
            //meal.Top = 160;
            meal.Left = 0;

            meal.Enabled = false;
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;
            Controls.Add(meal);
            
        }//makemeal de deyisiklikler olunmalidi.
        public void snakegrow()
        {
            snake = new Button();
            snake.Enabled = false;
            snake.Height = 20;
            snake.Width = 20;
            snake.FlatStyle = FlatStyle.Popup;
          
            snake.Top = body[body.Count-1].Top + 20;
            snake.Left = body[body.Count - 1].Left;
            snake.BackColor = Color.White;
            Controls.Add(snake);
            body.Add(snake);
        }

        private void SnakeGame_Load(object sender, EventArgs e)
        {

        }
    }
}
