using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKUL_OTOMASYON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrencıNotlar frmOgrencıNotlar = new FrmOgrencıNotlar();
            frmOgrencıNotlar.numara = textBox1.Text;
            frmOgrencıNotlar.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }
    }
}
