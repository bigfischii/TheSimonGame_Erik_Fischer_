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
        int background = 1; //initiates number of squares
        int stop = 0; //stops the blinking when player fails
        int once = 0; //stops the expansion when active'
        int responseblink = 0;
        int musx; //mouse x position
        int musy; // mouse y position
        int x = 0; //value for list, resets to 0 every round
        List<int> rutx = new List<int>(); //saves every blink cordinate for x value, cleared every round
        List<int> ruty = new List<int>(); //saves every blink cordinate for y value, cleared every round
        bool active = false; //if blinking or not
        bool corectornot = false; //if player was correct per click
        Random rnd_simonsq = new Random(); //random for squares
        public Form1()
        {
            InitializeComponent();
            label2.Text = " ";
            label6.Text = " ";
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
            SolidBrush p = new SolidBrush(Color.LightSeaGreen);
            SolidBrush pg = new SolidBrush(Color.Crimson);
            SolidBrush pr = new SolidBrush(Color.MediumAquamarine);
            if (background == 1) //4 squares for level 1
            {
                //row 1 column 1;2
                g.FillRectangle(p, 0, 0, 95, 95);
                g.FillRectangle(p, 0, 100, 95, 95);
                //row 2 column 1;2
                g.FillRectangle(p, 100, 0, 95, 95);
                g.FillRectangle(p, 100, 100, 95, 95);
            }
            if (background == 2) //9 sqares for level 2
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
            if (background == 3) // 16 squares for level 3
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
            if (responseblink == 1)//reaction to input on squares
            {
                g.FillRectangle(pr, (musx / 100) * 100, (musy / 100) * 100, 95, 95);
                responseblink = 0;
                System.Threading.Thread.Sleep(200);
                g.FillRectangle(p, (musx / 100) * 100, (musy / 100) * 100, 95, 95);
            }
            if (active == true && stop == 0) // Randomly lights up one square, defined by SRO
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
                        AR = rnd_simonsq.Next(1, 9);
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
                                rutx.Add(295);
                                ruty.Add(95);
                                g.FillRectangle(pg, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 4:
                                rutx.Add(95);
                                ruty.Add(195);
                                g.FillRectangle(pg, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 5:
                                rutx.Add(195);
                                ruty.Add(195);
                                g.FillRectangle(pg, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 6:
                                rutx.Add(295);
                                ruty.Add(195);
                                g.FillRectangle(pg, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 7:
                                rutx.Add(95);
                                ruty.Add(295);
                                g.FillRectangle(pg, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 8:
                                rutx.Add(195);
                                ruty.Add(295);
                                g.FillRectangle(pg, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 9:
                                rutx.Add(295);
                                ruty.Add(295);
                                g.FillRectangle(pg, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                        }
                    }
                    else
                    {
                        AR = rnd_simonsq.Next(1, 16);
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
                                rutx.Add(295);
                                ruty.Add(95);
                                g.FillRectangle(pg, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 4:
                                rutx.Add(395);
                                ruty.Add(95);
                                g.FillRectangle(pg, 300, 0, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 300, 0, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 5:
                                rutx.Add(95);
                                ruty.Add(195);
                                g.FillRectangle(pg, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 6:
                                rutx.Add(195);
                                ruty.Add(195);
                                g.FillRectangle(pg, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 7:
                                rutx.Add(295);
                                ruty.Add(195);
                                g.FillRectangle(pg, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 8:
                                rutx.Add(395);
                                ruty.Add(195);
                                g.FillRectangle(pg, 300, 100, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 300, 100, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 9:
                                rutx.Add(95);
                                ruty.Add(295);
                                g.FillRectangle(pg, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 10:
                                rutx.Add(195);
                                ruty.Add(295);
                                g.FillRectangle(pg, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 11:
                                rutx.Add(295);
                                ruty.Add(295);
                                g.FillRectangle(pg, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 12:
                                rutx.Add(395);
                                ruty.Add(295);
                                g.FillRectangle(pg, 300, 200, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 300, 200, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 13:
                                rutx.Add(95);
                                ruty.Add(395);
                                g.FillRectangle(pg, 0, 300, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 0, 300, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 14:
                                rutx.Add(195);
                                ruty.Add(395);
                                g.FillRectangle(pg, 100, 300, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 100, 300, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 15:
                                rutx.Add(295);
                                ruty.Add(395);
                                g.FillRectangle(pg, 200, 300, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 200, 300, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                            case 16:
                                rutx.Add(395);
                                ruty.Add(395);
                                g.FillRectangle(pg, 300, 300, 95, 95);
                                System.Threading.Thread.Sleep(1000);
                                g.FillRectangle(p, 300, 300, 95, 95);
                                System.Threading.Thread.Sleep(200);
                                break;
                        }
                    }
                }
                active = false;
                label6.Text = " ";
                label2.Text = "klicka i rutorna";
                label5.Text = SRO.ToString();
            }// random blink code in collapsed
            if (corectornot == true)
            {
                if (active == false && x == SRO)//if round is over or not
                {
                    System.Threading.Thread.Sleep(1000);
                    label2.Text = "Next round";
                    x = 0;
                    SRO++;
                    panel1.Invalidate();
                    rutx.Clear();
                    ruty.Clear();
                    active = true;
                }
                corectornot = false; //if round not over, continue
            }
            if (SRO == 5 && once == 0 || SRO == 10 && once == 1) //score that game = 5 or 10 extend to 3*3 or 4*4
            {
                level++;
                background++;
                once++;
            }
            
        }
        private void button1_Click(object sender, EventArgs e) //startbutton
        {
            active = true;
            button1.Enabled = false;
            panel1.Invalidate();
        }

        private void ClickM(object sender, MouseEventArgs e)//mouseclick
        {
            
            if (active == false)//if not blinking
            {
                musx = e.X;
                musy = e.Y;
                //blink click respons kod
                responseblink = 1;
                panel1.Invalidate();
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

        private void button2_Click(object sender, EventArgs e)// reset
        {
            if (SRO > HS)
            {
                HS = SRO;
                label3.Text = HS.ToString();
            }
            level = 1;
            HS = 0; 
            SRO = 1; 
            AR = 0; 
            background = 1;
            stop = 0;
            once = 0;
            rutx.Clear();
            ruty.Clear();
            x = 0;
            active = true;
            corectornot = false;
            panel1.Invalidate();
        }
        private void failed()//self explanitory
        {
            Console.Beep(800, 100);
            Console.Beep(300, 100);
            stop++;
            label2.Text = "Press RESTART to restart";
            active = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }   
        
}
