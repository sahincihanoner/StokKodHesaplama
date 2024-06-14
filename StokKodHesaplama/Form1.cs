using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using StokKodHesaplama.Screens;

namespace StokKodHesaplama
{
    public partial class Form1 : Form
    {
        DataTable dt = null;
        NavigationControl navigationControl;
        public Form1()
        {
            InitializeComponent();
            //  GetConnection();
            InitializeNavigationControl();
        }
        private void GetConnection()
        {
          
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> userControlList = new List<UserControl>()
                { new Calculate(), new StockCodeScreen()};

            navigationControl = new NavigationControl(userControlList, panel3);
            navigationControl.Display(0);
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           // using (DataContext context = new DataContext())
           // {
           //     dataGridView1.DataSource = context.StockCode.ToList();
           //   //  dataGridView1.DataSource = context.Stocks.ToList();
           // }
           //// DataGridView yapılandırması
           // dataGridView1.ColumnCount = 9;
           // dataGridView1.Columns[0].Name = "Stok Kodu";
           // dataGridView1.Columns[1].Name = "Satış Adeti";
           // dataGridView1.Columns[2].Name = "Satış Fiyatı";
           // dataGridView1.Columns[3].Name = "Toplam Satış Fiyatı";
           // dataGridView1.Columns[4].Name = "Komisyon Tutarı";
           // dataGridView1.Columns[5].Name = "Birim Kargo Ücreti";
           // dataGridView1.Columns[6].Name = "Toplam Kargo Ücreti";
           // dataGridView1.Columns[7].Name = "Ürün Maliyeti";
           // dataGridView1.Columns[8].Name = "Kazanç";

            //// Örnek veri ekleme
            //string[] row1 = new string[] { "SK001", "10", "20", "", "", "5", "", "12", "" };
            //string[] row2 = new string[] { "SK002", "15", "25", "", "", "4", "", "10", "" };
            //dataGridView1.Rows.Add(row1);
            //dataGridView1.Rows.Add(row2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells[0].Value == null)
            //        continue;

            //    string stokKodu = row.Cells[0].Value.ToString();
            //    int satisAdeti = int.Parse(row.Cells[1].Value.ToString());
            //    double satisFiyati = double.Parse(row.Cells[2].Value.ToString());

            //    double toplamSatisFiyati = satisFiyati * satisAdeti;
            //    row.Cells[3].Value = toplamSatisFiyati;

            //    double komisyonTutari = toplamSatisFiyati * 0.2; // Komisyon oranı %20
            //    row.Cells[4].Value = komisyonTutari;

            //    double birimKargoUcreti = double.Parse(row.Cells[5].Value.ToString());
            //    double toplamKargoUcreti = birimKargoUcreti * satisAdeti;
            //    row.Cells[6].Value = toplamKargoUcreti;

            //    double urunMaliyeti = double.Parse(row.Cells[7].Value.ToString());
            //    double toplamUrunMaliyeti = urunMaliyeti * satisAdeti;

            //    double kazanc = toplamSatisFiyati - komisyonTutari - toplamKargoUcreti - toplamUrunMaliyeti;
            //    row.Cells[8].Value = kazanc;
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //using (var package = new ExcelPackage())
            //{
            //    var ws = package.Workbook.Worksheets.Add("KarZarar");
            //    ws.Cells["A1"].LoadFromCollection(GetData(), true);

            //    var saveFileDialog = new SaveFileDialog
            //    {
            //        Filter = "Excel Files|*.xlsx",
            //        Title = "Excel Dosyasını Kaydet"
            //    };

            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
            //        {
            //            package.SaveAs(stream);
            //        }
            //    }
            //}
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
        }

        private void btnStockCodes_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
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
