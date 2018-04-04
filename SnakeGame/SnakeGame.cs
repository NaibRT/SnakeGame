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
        public int z = 0;

        public SnakeGame()
        {
            InitializeComponent();
            Random teq = new Random();
            meal = new Button();
            meal.Enabled = false;
            meal.Left = 100;
            meal.Top = 100;
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;

            for (int i = 0; i < 3; i++)
            {
                snakebas = new Button();
                snakebas.Height = 20;
                snakebas.Width = 20;
                snakebas.FlatStyle = FlatStyle.Flat;
                snakebas.Top = top;
                snakebas.Left = left;
                snakebas.BackColor = Color.White;
                body.Add(snakebas);
             
                top += 20;
                //left += 20;
            }
            //body[0].Enabled = false;
            //body[1].Enabled = false;
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
                    for (int i = 0; i < 3; i++)
                    {
                        if (body[i].Top < 0)
                        {
                            top = 500;
                            body[i].Top = top;
                            top -= 20;
                            body[i].Top = top;

                        }
                        else
                        {
                            top -= 20;
                            body[i].Top = top;
                        }
                        mealeating();
                    }

                    }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Down)
                {
                    
                    // top += 10;
                    for (int i = 0; i < 3; i++)
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
                            
                                top += 20;
                                body[i].Top = top;
                           
                            
                        }
                        mealeating();
                    }
                 }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Right)
                {
                    for (int i = 0; i < 0; i++)
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
                            left += 20;
                            body[i].Left += left;
                            if (body[i + 1].Top != body[i].Top)
                            {
                                body[i + 1].Top += 20;
                            }
                            else
                            {
                                body[i - 1].Left += 20;
                            }

                        }
                        mealeating();
                    }
                    }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Left)
                {
                    for (int i = 0; i < 3; i++)
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
                            left -= 20;
                            body[i].Left = left;

                        }
                        mealeating();
                    }
                    
                }
            }

        }
          public  void mealeating()
        {
            
            if (snakebas.Location.X == meal.Location.X && snakebas.Location.Y == meal.Location.Y)
            {
                meal.Visible=false;
                snakebas.BackColor = Color.Green;
                makemeal();
                snakegrow();
            }
        }
        public void makemeal()
        {
            while (true)
            {
                int x = teq.Next(0, 500);
                int y = teq.Next(0, 500);
                if (x % 20 == 0 && y % 20 == 0)
                {
                    meal = new Button();
                    meal.Top = x;
                    meal.Left = y;

                    break;
                }
            }
           

            meal.Enabled = false;
            meal.Height = 20;
            meal.Width = 20;
            meal.BackColor = Color.Red;
            meal.FlatStyle = FlatStyle.Flat;
            Controls.Add(meal);
            
        }
        public void snakegrow()
        {
                //snake = new Button();
                //snake.Height = 20;
                //snake.Width = 20;
                //snake.FlatStyle = FlatStyle.Flat;
                //snake.Top = snakebas.Top - 20;
                //snake.Left = snakebas.Left;
                //snake.BackColor = Color.White;
                //body.Add(snake);
                //Controls.Add(snake);
        }
    }
}
