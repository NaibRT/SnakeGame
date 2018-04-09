using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SnakeGame
{
    public partial class SnakeGame : Form
    {
        public int top = 30;
        public int left = 0;
        public int topbody = 10;
        public PictureBox snake;
        public PictureBox meal;
        public Random teq = new Random();
        public List<PictureBox> body = new List<PictureBox>();
        public int count = 0;
        public int price = 0;
        public Timer time;
        
        public SnakeGame()
        {
      
            InitializeComponent();
            snakemake();
            this.Width = 530;
            this.Height = 600;
            this.KeyUp += new KeyEventHandler(SnakeGame_KeyUp);
            timer1.Interval = 1000;
            void SnakeGame_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up)
                {
                        for (int i = 0; i < body.Count - 1; i++)
                        {
                            if (body[i].Top < 24)
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
                        if (body[body.Count - 1].Top < 24)
                        {
                            body[body.Count - 1].Top = 500;
                            body[body.Count - 1].Top -= 10;
                        }
                        else
                        {
                            body[body.Count - 1].Top -= 10;
                        }
                    gameover();
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

                            top = 24;
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
                        body[body.Count - 1].Top = 24;
                        body[body.Count - 1].Top += 10;
                    }
                    else
                    {
                        body[body.Count - 1].Top += 10;
                    }
                    gameover();
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
                            body[i].Left = 24;
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
                        body[body.Count - 1].Left = 24;
                        body[body.Count - 1].Left += 10;
                    }
                    else
                    {
                        body[body.Count - 1].Left += 10;
                    }
                    gameover();
                     mealeating();
                }
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (e.KeyCode == Keys.Left)
                {
                    for (int i = 0; i < body.Count-1; i++)
                    {
                        if (body[i].Left < 24)
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
                    if (body[body.Count - 1].Left < 24)
                    {
                        body[body.Count - 1].Left = 500;
                        body[body.Count - 1].Left -= 10;
                    }
                    else
                    {
                        body[body.Count - 1].Left -= 10;
                    }

                    gameover();
                    mealeating();

                }
            }
          
        }
          public  void mealeating()
        {
            if (body[body.Count - 1].Location.X == meal.Location.X && body[body.Count - 1].Location.Y == meal.Location.Y)
                {
                song();
                Controls.Remove(meal);
                
             
                count++;
                price += 5;
                label1.Text = count.ToString();
                label2.Text = price.ToString();
                makemeal();
                snakegrow();
            }
            
        }
        public void makemeal()
        {
            Random teq = new Random();
            //int x = 0;
            while (true)
            {
                int x = teq.Next(30, 500);
                int y = teq.Next(30, 500);
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
            
        }
        public void snakegrow()
        {
            snake = new PictureBox();
            snake.Enabled = false;
            snake.Height = 10;
            snake.Width = 10;
            //snake.FlatStyle = FlatStyle.Popup;
          
           snake.Top = body[body.Count-1].Top;
            snake.Left = body[body.Count - 1].Left;
            snake.BackColor = Color.Black;
            Controls.Add(snake);
            body.Add(snake);
        }
        public void gameover()
        {
            for (int i = 0; i < body.Count - 1; i++)
            {
                if (body[body.Count - 1].Top == body[i].Top && body[body.Count - 1].Left == body[i].Left)
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over");
                   // restart();
                    
                }
            }
        }
        public void snakemake()
        {
            for (int i = 0; i < 3; i++)
            {
                snake = new PictureBox();
                snake.Height = 10;
                snake.Width = 10;
                //snake.FlatStyle = FlatStyle.Popup;
                snake.Top = top;
                snake.Left = left;

                snake.BackColor = Color.Black;
                body.Add(snake);

                top += 10;
            }
            //left += 20;
        foreach (var item in body)
            {
                Controls.Add(item);
            }
            meal = new PictureBox();
            meal.Enabled = false;
            meal.Left = 0;
            meal.Top = 100;
            meal.Height = 10;
            meal.Width = 10;
            meal.BackColor = Color.Red;
            Controls.Add(meal);

        }
        public void restart()
        {
            Controls.Clear();
            Controls.Clear();
            body.Clear();
  

        }
        public void song()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Naib\Downloads\1.wav");
            player.Play();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int secound = Convert.ToInt32(label4.Text);
            int minut = Convert.ToInt32(label5.Text);
            secound++;
            label4.Text = secound.ToString();
            if (secound==60)
            {
                minut++;
                secound = 0;
                label4.Text = secound.ToString();
            }
            label5.Text = minut.ToString();
        }
    }
}
