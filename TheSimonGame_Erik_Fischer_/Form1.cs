using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSimonGame_Erik_Fischer_
{
    public partial class Form1 : Form
    {
        //Author: Erik Fischer
        int level = 1;
        int HS = 0; //Highscore taht session
        int SRO = 0; //Number of blinks per round
        int AR = 0; //random value (per level)
        int SR = 0; //Score that game
        int background = 1;
        List<int> musx = new List<int>();
        List<int> musy = new List<int>();
        bool active = false;
        
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

            if (SR == 7) //score that game = 12 extend to 3*3
            {
                level++;
            }
            if (SR == 14) // score that game = 24 extend to 4*4
            {
                level++;
            }
            
            


                for (int i = 0; i < SRO + 1; i++)
                {

                    if (level == 1)
                    {
                        AR = rnd_simonsq.Next(1, 4);
                        switch (AR)
                        {
                            case 1:
                                g.FillRectangle(pg, 0, 0, 95, 95);
                                Task.Delay(1000);
                                background = 1;

                                break;
                            case 2:
                                g.FillRectangle(pg, 100, 0, 95, 95);
                                Task.Delay(1000);
                                background = 1;

                                break;
                            case 3:
                                g.FillRectangle(pg, 0, 100, 95, 95);
                                Task.Delay(1000);
                                background = 1;

                                break;
                            case 4:
                                g.FillRectangle(pg, 100, 100, 95, 95);
                                Task.Delay(1000);
                                background = 1;
                                break;


                        }

                    }

                    /*else if (level == 2)
                    {
                        switch (AR)
                        {
                            case 1:
                                g.FillRectangle(pg, 0, 0, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 2:
                                g.FillRectangle(p, 100, 0, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 3:
                                g.FillRectangle(p, 200, 0, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 4:
                                g.FillRectangle(p, 0, 100, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 5:
                                g.FillRectangle(p, 100, 100, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 6:
                                g.FillRectangle(p, 200, 100, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 7:
                                g.FillRectangle(p, 0, 200, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 8:
                                g.FillRectangle(p, 100, 200, 95, 95);
                                panel1.Invalidate();
                                break;
                            case 9:
                                g.FillRectangle(p, 200, 200, 95, 95);
                                panel1.Invalidate();
                                break;
                        }

                    }
                    else
                    {

                    }
                    */

                }

                //SRO++; lägg till efter klick kod är gjord
            
        }



        private void lvl2()
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Run.Enabled = true;
            active = true;
            panel1.Invalidate();
        }
    }   
        
}
