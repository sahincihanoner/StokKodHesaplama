using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace StokKodHesaplama
{
    public partial class Form1 : Form
    {
        DataTable dt = null;
        public Form1()
        {
            InitializeComponent();
            GetConnection();
        }
        private void GetConnection()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-7EVV1FF\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True;TrustServerCertificate=True");
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from [deneme].[dbo].[UrunStock]",connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();



                while (sqlDataReader.Read())
                {
                    // bu verileri tek tek alıyorum. Biz bunun satır olarak değerini alıp saklamamız gerekiyor.
                    // [UrunStock] tablosundan gelen değerleri Datatable olarak tutucaz
                    // daha sonrasında sen stok kodu girdiğinde ilgili alanlar bu row'daki değerlere göre dolacak
                    // Anlaşılmayan bir şey???


                    string name = sqlDataReader[3].ToString();
                    

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Hata Oluştu");
            }
            finally 
            { 
                connection.Close();
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView yapılandırması
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Stok Kodu";
            dataGridView1.Columns[1].Name = "Satış Adeti";
            dataGridView1.Columns[2].Name = "Satış Fiyatı";
            dataGridView1.Columns[3].Name = "Toplam Satış Fiyatı";
            dataGridView1.Columns[4].Name = "Komisyon Tutarı";
            dataGridView1.Columns[5].Name = "Birim Kargo Ücreti";
            dataGridView1.Columns[6].Name = "Toplam Kargo Ücreti";
            dataGridView1.Columns[7].Name = "Ürün Maliyeti";
            dataGridView1.Columns[8].Name = "Kazanç";

            // Örnek veri ekleme
            string[] row1 = new string[] { "SK001", "10", "20", "", "", "5", "", "12", "" };
            string[] row2 = new string[] { "SK002", "15", "25", "", "", "4", "", "10", "" };
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                string stokKodu = row.Cells[0].Value.ToString();
                int satisAdeti = int.Parse(row.Cells[1].Value.ToString());
                double satisFiyati = double.Parse(row.Cells[2].Value.ToString());

                double toplamSatisFiyati = satisFiyati * satisAdeti;
                row.Cells[3].Value = toplamSatisFiyati;

                double komisyonTutari = toplamSatisFiyati * 0.2; // Komisyon oranı %20
                row.Cells[4].Value = komisyonTutari;

                double birimKargoUcreti = double.Parse(row.Cells[5].Value.ToString());
                double toplamKargoUcreti = birimKargoUcreti * satisAdeti;
                row.Cells[6].Value = toplamKargoUcreti;

                double urunMaliyeti = double.Parse(row.Cells[7].Value.ToString());
                double toplamUrunMaliyeti = urunMaliyeti * satisAdeti;

                double kazanc = toplamSatisFiyati - komisyonTutari - toplamKargoUcreti - toplamUrunMaliyeti;
                row.Cells[8].Value = kazanc;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("KarZarar");
                ws.Cells["A1"].LoadFromCollection(GetData(), true);

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Excel Dosyasını Kaydet"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        package.SaveAs(stream);
                    }
                }
            }
        }

        private List<Stok> GetData()
        {
            var data = new List<Stok>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                var stok = new Stok
                {
                    StokKodu = row.Cells[0].Value.ToString(),
                    SatisAdeti = int.Parse(row.Cells[1].Value.ToString()),
                    SatisFiyati = double.Parse(row.Cells[2].Value.ToString()),
                    ToplamSatisFiyati = double.Parse(row.Cells[3].Value?.ToString() ?? "0"),
                    KomisyonTutari = double.Parse(row.Cells[4].Value?.ToString() ?? "0"),
                    BirimKargoUcreti = double.Parse(row.Cells[5].Value?.ToString() ?? "0"),
                    ToplamKargoUcreti = double.Parse(row.Cells[6].Value?.ToString() ?? "0"),
                    UrunMaliyeti = double.Parse(row.Cells[7].Value?.ToString() ?? "0"),
                    Kazanc = double.Parse(row.Cells[8].Value?.ToString() ?? "0")
                };
                data.Add(stok);
            }
            return data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Stok
    {
        public string StokKodu { get; set; }
        public int SatisAdeti { get; set; }
        public double SatisFiyati { get; set; }
        public double ToplamSatisFiyati { get; set; }
        public double KomisyonTutari { get; set; }
        public double BirimKargoUcreti { get; set; }
        public double ToplamKargoUcreti { get; set; }
        public double UrunMaliyeti { get; set; }
        public double Kazanc { get; set; }
    }
}
