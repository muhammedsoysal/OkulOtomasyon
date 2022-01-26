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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frmKulup= new FrmKulup();
            frmKulup.Show();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler frmDersler = new FrmDersler();
            frmDersler.Show();

        }

        private void BtnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmOgrenci = new FrmOgrenci();
            frmOgrenci.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınavNotları frmSınavNotları = new FrmSınavNotları();
            frmSınavNotları.Show();
        }
    }
}
