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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBL_DERSLERTableAdapter ds = new DataSet1TableAdapters.TBL_DERSLERTableAdapter();
        
        void list()
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ds.DersAdd(TxtDersAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.DersDelete(byte.Parse (TxtDersId.Text));
            MessageBox.Show("Ders Silme İşlemi gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.DersUpdate(TxtDersAd.Text, byte.Parse(TxtDersId.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }
    }
}
