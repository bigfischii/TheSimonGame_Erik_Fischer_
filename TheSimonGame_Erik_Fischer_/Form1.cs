using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TheSimonGame_Erik_Fischer_
{
    public partial class Form1 : Form
    {
        //Author: Erik Fischer
        int level = 1;
        int HS = 0; //Highscore that session
        int SRO = 1; //Number of blinks per round
        int AR = 0; //random value (per round)
        int SR = 0; //Score that game
        int background = 1;
        int musx;
        int musy;
        int x = 0;
        List<int> rutx = new List<int>();
        List<int> ruty = new List<int>();
        bool active = false;
        bool corectornot = false;
        Random rnd_simonsq = new Random();
        public Form1()
        {
            
            InitializeComponent();
            Run.Enabled = true;
            label2.Text = HS.ToString();
            panel1.Invalidate();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush p = new SolidBrush(Color.Black);
            SolidBrush pg = new SolidBrush(Color.Purple);
            if (background == 1)
            {
                //row 1 column 1;2
                g.FillRectangle(p, 0, 0, 95, 95);
                g.FillRectangle(p, 0, 100, 95, 95);
                //row 2 column 1;2
                g.FillRectangle(p, 100, 0, 95, 95);
                g.FillRectangle(p, 100, 100, 95, 95);

            }
            if (background == 2)
            {
                //row 1 column 1;3
                g.FillRectangle(p, 0, 0, 95, 95);
                g.FillRectangle(p, 0, 100, 95, 95);
                g.FillRectangle(p, 0, 200, 95, 95);
                //row 2 column 1;3
                g.FillRectangle(p, 100, 0, 95, 95);
                g.FillRectangle(p, 100, 100, 95, 95);
                g.FillRectangle(p, 100, 200, 95, 95);
                //row 3 column 1;3
                g.FillRectangle(p, 200, 0, 95, 95);
                g.FillRectangle(p, 200, 100, 95, 95);
                g.FillRectangle(p, 200, 200, 95, 95);
            }
            if (background == 3)
            {
                //row 1 column 1;4
                g.FillRectangle(p, 0, 0, 95, 95);
                g.FillRectangle(p, 0, 100, 95, 95);
                g.FillRectangle(p, 0, 200, 95, 95);
                g.FillRectangle(p, 0, 300, 95, 95);
                //row 2 column 1;4
                g.FillRectangle(p, 100, 0, 95, 95);
                g.FillRectangle(p, 100, 100, 95, 95);
                g.FillRectangle(p, 100, 200, 95, 95);
                g.FillRectangle(p, 100, 300, 95, 95);
                //row 3 column 1;4
                g.FillRectangle(p, 200, 0, 95, 95);
                g.FillRectangle(p, 200, 100, 95, 95);
                g.FillRectangle(p, 200, 200, 95, 95);
                g.FillRectangle(p, 200, 300, 95, 95);
                //row 4 column 1;4
                g.FillRectangle(p, 300, 0, 95, 95);
                g.FillRectangle(p, 300, 100, 95, 95);
                g.FillRectangle(p, 300, 200, 95, 95);
                g.FillRectangle(p, 300, 300, 95, 95);
            }

            if (SR == 5) //score that game = 12 extend to 3*3
            {
                level++;
            }
            if (SR == 10) // score that game = 24 extend to 4*4
            {
                level++;
            }


            if (active == true)
            {

                for (int i = 0; i < SRO; i++)
                {

                    if (level == 1)
                    {
                        AR = rnd_simonsq.Next(1, 4);

                        switch (AR)
                        {
                            case 1:
                                rutx.Add(95);
                                ruty.Add(95);
                                g.FillRectangle(pg, 0, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 2:
                                rutx.Add(195);
                                ruty.Add(95);
                                g.FillRectangle(pg, 100, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 3:
                                rutx.Add(95);
                                ruty.Add(195);
                                g.FillRectangle(pg, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 4:
                                rutx.Add(195);
                                ruty.Add(195);
                                g.FillRectangle(pg, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;


                        }

                    }

                    else if (level == 2)
                    {
                        switch (AR)
                        {
                            case 1:
                                g.FillRectangle(pg, 0, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 2:
                                g.FillRectangle(pg, 100, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 3:
                                g.FillRectangle(pg, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 4:
                                g.FillRectangle(pg, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 5:
                                g.FillRectangle(pg, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 6:
                                g.FillRectangle(pg, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 7:
                                g.FillRectangle(pg, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 8:
                                g.FillRectangle(pg, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 9:
                                g.FillRectangle(pg, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                        }

                    }
                    else
                    {

                    }
                    
                    

                }
                active = false;
                label2.Text = "klicka i rutorna";
            }
            if (corectornot == true)
            {
                if (active == false && x == SRO)
                {
                    label2.Text = "GG";
                    SRO++;
                    System.Threading.Thread.Sleep(1000);
                    label2.Text = "Next round";
                    x = 0;
                    panel1.Invalidate();
                    rutx.Clear();
                    ruty.Clear();
                    active = true;
                }
                else
                {

                }
                corectornot = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Run.Enabled = true;
            active = true;
            button1.Enabled = false;
            panel1.Invalidate();
        }

        private void ClickM(object sender, MouseEventArgs e)
        {
             
            if (active == false)
            {
                Console.Beep(500, 150);
                musx = e.X;
                musy = e.Y;
                if (musx < rutx[x] && musx > (rutx[x] - 95) && musy < ruty[x] && musy > ruty[x] - 95)
                {
                    corectornot = true;
                    x++;
                    panel1.Invalidate();
                }
                else
                {
                    failed();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void failed()
        {
            label2.Text = "Press RESTART to restart";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }   
        
}
