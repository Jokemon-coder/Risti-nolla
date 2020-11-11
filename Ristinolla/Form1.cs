using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class Form1 : Form
    {
        bool vuoro = true; //True = X vuoro, False = Y vuoro
        int vuoroLaskin = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tekijä: Joel", "Risti-nollapeli About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vuoro = true;
            vuoroLaskin = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";

                }
            }
            catch { }
        }

        private void nappi_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (vuoro)
                b.Text = "X";
            else
                b.Text = "O";

            vuoro = !vuoro;
            b.Enabled = false;
            vuoroLaskin++;
            tarkistaVoittaja();

        }

        private void tarkistaVoittaja()
        {

            bool voittajaLöydetty = false;

            //horisontaalinen rivi
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                voittajaLöydetty = true;

            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                voittajaLöydetty = true;

            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                voittajaLöydetty = true;

            //vertikaalinen rivi
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                voittajaLöydetty = true;

            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                voittajaLöydetty = true;

            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                voittajaLöydetty = true;

            //viisto rivi
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                voittajaLöydetty = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                voittajaLöydetty = true;


            if (voittajaLöydetty)
            {
                poisNapit();
                
                string voittaja = "";
                if (vuoro)
                    voittaja = "O";
                else
                    voittaja = "X";

                MessageBox.Show(voittaja + "on voittanut pelin!", "Voittaja!");
            }
            else
            {
                if (vuoroLaskin == 9)
                    MessageBox.Show("Kukaan ei voittanut.", "Tasapeli!");

            }



        }//tarkistaVoittaja päättyy
        
        private void poisNapit()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }
            catch { }
        }
    
    
    }   

}