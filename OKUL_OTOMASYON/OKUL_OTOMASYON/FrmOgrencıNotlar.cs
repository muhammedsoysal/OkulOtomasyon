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
    public partial class FrmOgrencıNotlar : Form
    {
        public FrmOgrencıNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NLD05HG\SQLEXPRESS;Initial Catalog=Okul_Otomasyon2;Integrated Security=True");
        public string numara;
        private void FrmOgrencıNotlar_Load(object sender, EventArgs e)
        {
             baglanti.Open();
            SqlCommand komut = new SqlCommand("Select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from TBL_NOTLAR INNER JOIN TBL_DERSLER ON TBL_NOTLAR.DERSID=TBL_DERSLER.DERSID  where OGRID=@P1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
         
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlCommand komut2 = new SqlCommand("Select OGRAD,OGRSOYAD FROM TBL_OGRENCILER where OGRID=@p1",baglanti);
            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0].ToString() + " " + dr[1].ToString();
            }
            baglanti.Close();


        }
    }
}
