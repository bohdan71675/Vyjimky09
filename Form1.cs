using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vyjimky09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pocet = 0;
            double soucet = 0;
            int n = int.Parse(textBox1.Text);
            try
            {
                using (FileStream fs = new FileStream("RealnaCisla.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    for(int i = 0; i < n; i++)
                    {
                        double cislo = br.ReadDouble();
                        soucet += cislo;
                        pocet++;
                    }
                }
                if (pocet > 0)
                {
                    double AP = soucet / pocet;
                    MessageBox.Show("Prumer je " + AP);
                }
                else 
                {
                    MessageBox.Show("Nelze delit nulou");
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("soubor nebyl nalezen, zkontroluj umístění a název soboru");
            }
           // catch ()
           // {
          //      MessageBox.Show("Neni pristup k souboru");
           // }
            catch (OverflowException)
            {
                MessageBox.Show("Součet je příliš velké nebo malé číslo");
            }
        }
    }
}
