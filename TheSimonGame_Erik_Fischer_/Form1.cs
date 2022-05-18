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
        int background = 1; //initiates number of squares visable for player
        int stop = 0; //stops the blinking when player fails
        int once = 0; //stops the expansion for background
        int responseblink = 0; //variable for respons when clicking on square
        int musx; //mouse x position
        int musy; // mouse y position
        int x = 0; //value for list, resets to 0 every round, used to go through whole list
        List<int> rutx = new List<int>(); //saves every blink cordinate for x value, cleared every round
        List<int> ruty = new List<int>(); //saves every blink cordinate for y value, cleared every round
        bool active = false; //if blinking or not
        bool corectornot = false; //if player was correct per click
        Random rnd_simonsq = new Random(); //random for squares


        //Valuable information:
        /*
        grid is set ut lige this 
        level = 1
        1, 2,
        3, 4,
        or level = 2
        1, 2, 3, 
        4, 5, 6,
        7, 8, 9,
        or level = 3
        1,  2,  3,  4, 
        5,  6,  7,  8, 
        9,  10, 11, 12,
        13, 14, 15, 16,

    ____________________________
        everything is collapsed below 
         */
        public Form1()//initiating commands
        {
            InitializeComponent();
            label2.Text = " ";
            label6.Text = " ";
            panel1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }//nothing

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }//nothing

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush p = new SolidBrush(Color.LightSeaGreen);
            SolidBrush pg = new SolidBrush(Color.Crimson);
            SolidBrush pr = new SolidBrush(Color.MediumAquamarine);
            switch (background)
            {
                case 1:for (int i = 0; i <= 1; i++)
                    {
                        g.FillRectangle(p, i * 100, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 100, 95, 95);
                        g.FillRectangle(p, 100, i * 100, 95, 95);
                    }break;
                case 2:for (int i = 0; i <= 2; i++)
                    {
                        g.FillRectangle(p, i * 100, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 100, 95, 95);
                        g.FillRectangle(p, 100, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 200, 95, 95);
                        g.FillRectangle(p, 200, i * 100, 95, 95);
                    }break;
                case 3:for (int i = 0; i <= 3; i++)
                    {
                        g.FillRectangle(p, i * 100, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 100, 95, 95);
                        g.FillRectangle(p, 100, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 200, 95, 95);
                        g.FillRectangle(p, 200, i * 100, 95, 95);
                        g.FillRectangle(p, 300, i * 100, 95, 95);
                        g.FillRectangle(p, i * 100, 300, 95, 95);
                    }break;
            }
            
            if (responseblink == 1)
            {
                g.FillRectangle(p, (musx / 100) * 100, (musy / 100) * 100, 95, 95);
                g.FillRectangle(pr, (musx / 100) * 100, (musy / 100) * 100, 95, 95);
                responseblink = 0;
            }//reaction to input on squares(high up because of prioritizing)
            
            if (active == true && stop == 0) 
            {
                for (int i = 0; i < SRO; i++)
                {
                    switch (level)
                    {
                        case 1:AR = rnd_simonsq.Next(1, 4);
                        switch (AR)
                        {
                            case 1:rutx.Add(95);ruty.Add(95);break;
                            case 2:rutx.Add(195);ruty.Add(95);break;
                            case 3:rutx.Add(95);ruty.Add(195);break;
                            case 4:rutx.Add(195);ruty.Add(195);break;
                        }
                            g.FillRectangle(pg, rutx[rutx.Count-1]-95, ruty[ruty.Count-1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(1000);
                            g.FillRectangle(p, rutx[rutx.Count-1] - 95, ruty[ruty.Count-1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(50);
                            break;

                        case 2:AR = rnd_simonsq.Next(1, 9);
                        switch (AR)
                        {
                            case 1:rutx.Add(95);ruty.Add(95);break;
                            case 2:rutx.Add(195);ruty.Add(95);break;
                            case 3:rutx.Add(295);ruty.Add(95);break;
                            case 4:rutx.Add(95);ruty.Add(195);break;
                            case 5:rutx.Add(195);ruty.Add(195);break;
                            case 6:rutx.Add(295);ruty.Add(195);break;
                            case 7:rutx.Add(95);ruty.Add(295);break;
                            case 8:rutx.Add(195);ruty.Add(295);break;
                            case 9:rutx.Add(295);ruty.Add(295);break;      
                        }
                            g.FillRectangle(pg, rutx[rutx.Count-1] - 95, ruty[ruty.Count-1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(850);
                            g.FillRectangle(p, rutx[rutx.Count-1] - 95, ruty[ruty.Count-1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(50);
                            break;

                        case 3:AR = rnd_simonsq.Next(1, 16);
                        switch (AR)
                        {
                            case 1:rutx.Add(95);ruty.Add(95);break;
                            case 2:rutx.Add(195);ruty.Add(95);break;
                            case 3:rutx.Add(295);ruty.Add(95);break;
                            case 4:rutx.Add(395);ruty.Add(95);break;
                            case 5:rutx.Add(95);ruty.Add(195);break;
                            case 6:rutx.Add(195);ruty.Add(195);break;
                            case 7:rutx.Add(295);ruty.Add(195);break;
                            case 8:rutx.Add(395);ruty.Add(195);break;
                            case 9:rutx.Add(95);ruty.Add(295);break;
                            case 10:rutx.Add(195);ruty.Add(295);break;
                            case 11:rutx.Add(295);ruty.Add(295);break;
                            case 12:rutx.Add(395);ruty.Add(295);break;
                            case 13:rutx.Add(95);ruty.Add(395);break;
                            case 14:rutx.Add(195);ruty.Add(395);break;
                            case 15:rutx.Add(295);ruty.Add(395);break;
                            case 16:rutx.Add(395);ruty.Add(395);break;       
                        }
                            g.FillRectangle(pg, rutx[rutx.Count - 1] - 95, ruty[ruty.Count - 1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(p, rutx[rutx.Count - 1] - 95, ruty[ruty.Count - 1] - 95, 95, 95);
                            System.Threading.Thread.Sleep(50);
                            break;
                    }
                }
                active = false;
                label6.Text = " ";
                label2.Text = "klicka i rutorna";
                label5.Text = SRO.ToString();
            }// Randomly lights up one square, defined by SRO
            if (corectornot == true)
            {
                if (active == false && x == SRO)//if round is over or not
                {
                    System.Threading.Thread.Sleep(500);
                    label2.Text = "Next round";
                    x = 0;
                    SRO++;
                    panel1.Invalidate();
                    rutx.Clear();
                    ruty.Clear();
                    active = true;
                }
                corectornot = false; //if round not over, continue
            }//checks if next round should be initiated
            if (SRO == 6 || SRO == 11)
            {
                once = 0;
            }//checks when to increase diffculty and level
            if (SRO == 5 && once == 0 || SRO == 10 && once == 0)
            {
                background++;
                level++;
                once = 1;
                panel1.Invalidate();
            }//makes so that only level increases once
        }
        private void button1_Click(object sender, EventArgs e) //startbutton
        {
            active = true;
            button1.Enabled = false;
            panel1.Invalidate();
        }

        private void ClickM(object sender, MouseEventArgs e)//mouseclick, checs mose coordinate, sends signal to correctornot (row,396)
        {
            
            if (active == false)
            {
                musx = e.X;
                musy = e.Y;
                switch (background)//to make sure player only can press on active play area
                {
                    case 1:if (musx < 195 && musy < 195)//level=1
                        {
                            //blink click respons kod
                            responseblink = 1;
                            panel1.Invalidate();
                            if (musx < rutx[x] && musx > (rutx[x] - 95) && musy < ruty[x] && musy > ruty[x] - 95)
                            {
                                corectornot = true;
                                x++;
                                panel1.Invalidate();
                            }
                            else { failed(); }
                        }
                        else { break; }
                        break;

                    case 2:if (musx < 295 && musy < 295)//level=2
                        {
                            //blink click respons code
                            responseblink = 1;
                            panel1.Invalidate();
                            if (musx < rutx[x] && musx > (rutx[x] - 95) && musy < ruty[x] && musy > ruty[x] - 95)
                            {
                                corectornot = true;
                                x++;
                                panel1.Invalidate();
                            }
                            else { failed(); }
                        }
                        else { break;}
                        break;

                    case 3:if (musx < 395 && musy < 395)//level=3
                        {
                            //blink click respons code
                            responseblink = 1;
                            panel1.Invalidate();
                            if (musx < rutx[x] && musx > (rutx[x] - 95) && musy < ruty[x] && musy > ruty[x] - 95)
                            {
                                corectornot = true;
                                x++;
                                panel1.Invalidate();
                            }
                            else { failed(); }
                        }
                        else { break; }
                        break;
                }


            }//if not blinking, checks mouse position and if the clicked square is right
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
            label6.Text = "Press RESTART to restart";
            label2.Text = "GAME OVER";
            active = true;

        }//activated when player fails to remember or misclicks

        private void label1_Click(object sender, EventArgs e)
        {

        }//nothing
    }   
        
}
