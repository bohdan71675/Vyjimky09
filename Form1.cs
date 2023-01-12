using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            try
            {
                using (FileStream fs = new FileStream("RealnaCisla.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    while (fs.Position < fs.Length)
                    {
                        double cislo = br.ReadDouble();
                        soucet += cislo;
                        pocet++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("soubor nebyl nalezen, zkontroluj umístění a název soboru");
            }
            catch (IOException)
            {
                MessageBox.Show("Data jsou poskozena");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Součet je příliš velké nebo malé číslo");
            }
        }
    }
}
