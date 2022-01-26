using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OKUL_OTOMASYON
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            TxtID.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NLD05HG\SQLEXPRESS;Initial Catalog=Okul_Otomasyon2;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable2TableAdapter ds = new DataSet1TableAdapters.DataTable2TableAdapter();
        void List()
        {
            dataGridView1.DataSource = ds.OgrenciList();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            List();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From TBL_KULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulub.DisplayMember = "KULUPAD";
            CmbKulub.ValueMember = "KULUPID";
            CmbKulub.DataSource = dt;
            baglanti.Close();
        }

        string cinsiyet = " ";
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            ds.OgrenciAdd(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulub.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci Ekleme İşlemi Gerçekleşti ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            Temizle();
        }

        private void CmbKulub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (cinsiyet == "Erkek")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            if (cinsiyet == "Kız")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.OgrenciDelete(byte.Parse(TxtID.Text));
            MessageBox.Show("Öğrenci Silme İşlemi Gerçekleşti ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            Temizle();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            List();
            Temizle();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.OgrenciUpdate(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulub.SelectedValue.ToString()), cinsiyet, byte.Parse(TxtID.Text));
            List();
            Temizle();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cinsiyet = "Kız";
            }

        }
            
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
