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

namespace ukolBin2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ShowIcon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("sport.txt", Encoding.GetEncoding("Windows-1250"));
            FileStream fs = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("Windows-1250"));
            BinaryReader br = new BinaryReader(fs, Encoding.GetEncoding("Windows-1250"));

            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(';');

                int osc = Convert.ToInt32(s[0]);
                int vyska = Convert.ToInt32(s[4]);
                int vaha = Convert.ToInt32(s[5]);
                char pohlavi = Convert.ToChar(s[3]);

                bw.Write(osc);
                bw.Write(s[1]);
                bw.Write(s[2]);
                bw.Write(pohlavi);
                bw.Write(vyska);
                bw.Write(vaha);
                //bw.Write("\n");
            }

                                   
            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox1.Text += br.ReadInt32().ToString() + " " + br.ReadString() + " " + br.ReadString() + " " + br.ReadChar().ToString() + " " + br.ReadInt32().ToString() + " " + br.ReadInt32().ToString() + "\r\n";
            }

            sr.Close();
            fs.Close();
            bw.Close();            
            br.Close();

        }

       
    }
}
