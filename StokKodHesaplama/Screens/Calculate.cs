
using Google.Protobuf.Compiler;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.Ocsp;
using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;

using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

//Created By Fatih Mehmet Coşkun 41

namespace StokKodHesaplama.Screens
{
    public partial class Calculate : UserControl
    {
        private DbClass db;
        public Calculate()
        {
            InitializeComponent();

            db = new DbClass();


//            GetData();


        }


        private void GetData()
        {
            //using (DataContext context = new DataContext())
            //{
            //    cbStockCode.DataSource = context.StockCode.ToList();
            //    cbStockCode.DisplayMember = "StokKodu";
            //    cbStockCode.ValueMember = "ID";
            //    cbStockCode.SelectedIndex = -1;


            //}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged()
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           // txtToplamKargo.Text = (ConvertToDecimal(txtAdet.Text) * ConvertToDecimal(txtBirimKargo.Text)).ToString();


        }

        private void label2_Click()
        {

        }
        public bool IsDecimal(string value)
        {
            decimal result;
            return decimal.TryParse(value, out result);
        }
        public decimal ConvertToDecimal(string value)
        {
            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                // Eğer dönüştürme başarısız olduysa, isteğe bağlı olarak bir hata mesajı döndürebilirsiniz.
                return 0;
            }
        }



        private void cbStockCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtBirimKargo.Text = "0";
            //txtDesi.Text = "0";
            //txtFiyat.Text = "0";
            //txtKomisyon.Text = "0";
            //txtAdet.Text = "0";
            //txtMaliyet.Text = "0";
            //if (!string.IsNullOrEmpty(cbStockCode.Text))
            //{
            //    using (var dbContext = new DataContext())
            //    {
            //        var selectedStockCode = cbStockCode.Text;
            //        var desi = dbContext.StockCode
            //                            .Where(sc => sc.StokKodu == selectedStockCode)
            //                            .Select(sc => sc.Desi)
            //                            .FirstOrDefault();

            //        var fiyat = dbContext.StockCode
            //                          .Where(sc => sc.StokKodu == selectedStockCode)
            //                          .Select(sc => sc.Fiyat)
            //                          .FirstOrDefault();
            //        var komisyon = dbContext.StockCode
            //                          .Where(sc => sc.StokKodu == selectedStockCode)
            //                          .Select(sc => sc.KomisyonTutari)
            //                          .FirstOrDefault();
            //        var maliyet = dbContext.StockCode
            //                         .Where(sc => sc.StokKodu == selectedStockCode)
            //                         .Select(sc => sc.UrunMaliyeti)
            //                         .FirstOrDefault();


            //        var birimKargoUcreti = dbContext.StockCode
            //                            .Where(sc => sc.StokKodu == selectedStockCode)
            //                            .Select(sc => sc.BirimKargoUcreti)
            //                            .FirstOrDefault();


            //        if (birimKargoUcreti != null)
            //        {
            //            txtBirimKargo.Text = birimKargoUcreti.ToString();
            //        }
            //        else
            //        {
            //            txtBirimKargo.Text = "0";
            //        }


            //        if (desi != null)
            //        {
            //            txtDesi.Text = desi.ToString();
            //        }
            //        else
            //        {
            //            // Stok koduna karşılık gelen desi bulunamadı
            //            txtDesi.Text = "0";
            //        }

            //        if (fiyat != null)
            //        {
            //            txtFiyat.Text = fiyat.ToString();
            //        }
            //        else
            //        {
            //            // Stok koduna karşılık gelen fiyat bulunamadı
            //            txtFiyat.Text = "0";
            //        }

            //        if (komisyon != null)
            //        {
            //            txtKomisyon.Text = komisyon.ToString();
            //        }
            //        else
            //        {
            //            // Stok koduna karşılık gelen komisyon tutarı bulunamadı
            //            txtKomisyon.Text = "0";
            //        }

            //        if (maliyet != null)
            //        {
            //            txtMaliyet.Text = maliyet.ToString();
            //        }
            //        else
            //        {
            //            // Stok koduna karşılık gelen ürün maliyeti bulunamadı
            //            txtMaliyet.Text = "0";
            //        }



            //    }
            //}
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

         //   txtToplamKargo.Text = (ConvertToDecimal(txtAdet.Text) * ConvertToDecimal(txtBirimKargo.Text)).ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] {
            new DataColumn("StokKodu",typeof(string)),
            new DataColumn("Adet",typeof(decimal))

            });

            string excelData = sahinBox.Text.Trim();
            string[] rows = excelData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            decimal kar = 0;

          
                foreach (string row in rows)
                {
                    string[] cells = row.Split('\t');
                    if (cells.Length >= 2)
                    {
                        decimal number;
                        if (Decimal.TryParse(cells[1], out number))
                        {
                            DataRow dr = dt.NewRow();
                            dr["StokKodu"] = cells[0].ToString();
                            dr["Adet"] = number;

                            var desi = db.GetValueFromDatabase("StockCodes","Desi", cells[0].ToString());
                            var fiyat = db.GetValueFromDatabase("StockCodes", "Fiyat", cells[0].ToString());
                            var komisyon = db.GetValueFromDatabase("StockCodes", "KomisyonTutari", cells[0].ToString());
                            var maliyet = db.GetValueFromDatabase("StockCodes", "UrunMaliyeti", cells[0].ToString());
                            var birimKargoUcreti = db.GetValueFromDatabase("StockCodes", "BirimKargoUcreti", cells[0].ToString());

                            if (desi == null || birimKargoUcreti == null || fiyat == null || komisyon == null || maliyet == null)
                            {
                                desi = 0;
                                birimKargoUcreti = 0;
                                fiyat = 0;
                                komisyon = 0;
                                maliyet = 0;

                            }
                            else
                            {
                                decimal adet1 = number;
                                decimal fiyat1 = ConvertToDecimal(fiyat.ToString());
                                decimal birimKargo1 = ConvertToDecimal(birimKargoUcreti.ToString());
                                decimal komisyon1 = ConvertToDecimal(komisyon.ToString());
                                decimal desi1 = ConvertToDecimal(desi.ToString());
                                decimal maliyet1 = ConvertToDecimal(maliyet.ToString());
                                decimal toplamKargo1 = ConvertToDecimal((number * ConvertToDecimal(birimKargo1.ToString())).ToString());
                                     kar = adet1 * (fiyat1 - (fiyat1 * komisyon1 / 100) - toplamKargo1 - maliyet1);


                             string insertQuery = $@"INSERT INTO Stocks (StokKodu, Adet, Desi, Fiyat, Komisyon,BirimKargoUcreti,ToplamKargoUcreti,Maliyet,Kar,Tarih)
VALUES ('{cells[0]}', '{(int?)number}', '{desi1}', '{fiyat1}', '{komisyon1}', '{birimKargo1}','{toplamKargo1}','{maliyet1}','{kar}',DateTime('now', '+3 hours'))";
                            db.ExecuteNonQuery(insertQuery);


                            //using (DataContext context = new DataContext())
                            //    {


                            //        context.Stocks.Add(new Stock
                            //        {
                            //            StokKodu = cells[0],
                            //            Adet = (int?)number,
                            //            Fiyat = fiyat1,
                            //            Desi = desi1,
                            //            BirimKargoUcreti = birimKargo1,
                            //            Komisyon = komisyon1,
                            //            Maliyet = maliyet1,
                            //            ToplamKargoUcreti = toplamKargo1,
                            //            Kar = kar,
                            //            Tarih = DateTime.Now
                            //        });
                            //        context.SaveChanges();
                            //        //  MessageBox.Show("Başarıyla Kayıt Yapıldı");
                            //    }
                                kar += kar;

                            }


                        }

                        else
                        {
                            number = 0;
                            MessageBox.Show("Adet Sayısı Sayısal Olmalıdır");
                            break;
                        }


                    }

                }
                MessageBox.Show("Başarıyla Kayıt Yapıldı");

                lblKar.Text = "Kar: " + kar.ToString();
                lblKar.Visible = true;
            


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
     

        public void ExportToExcel()
        {

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Başlık satırını ekle
            worksheet.Cells[1, 1] = "Stok Kodu";
            worksheet.Cells[1, 2] = "Adet";
            worksheet.Cells[1, 3] = "Desi";
            worksheet.Cells[1, 4] = "Fiyat";
            worksheet.Cells[1, 5] = "Komisyon";
            worksheet.Cells[1, 6] = "BirimKargoUcreti";
            worksheet.Cells[1, 7] = "ToplamKargoUcreti";
            worksheet.Cells[1, 8] = "Maliyet";
            worksheet.Cells[1, 9] = "Kar";
            worksheet.Cells[1, 10] = "Tarih";


            // Diğer sütun başlıklarını ekleyin...

            // Verileri satırlara yaz
            int row = 2;

            string selectQuery = "select * from Stocks order by Tarih desc";
            DataTable dt = db.ExecuteQuery(selectQuery);

            foreach (DataRow stock in dt.Rows)
            {
                worksheet.Cells[row, 1] = stock["StokKodu"];
                worksheet.Cells[row, 2] = stock["Adet"];
                worksheet.Cells[row, 3] = stock["Desi"];
                worksheet.Cells[row, 4] = stock["Fiyat"];
                worksheet.Cells[row, 5] = stock["Komisyon"];
                worksheet.Cells[row, 6] = stock["BirimKargoUcreti"];
                worksheet.Cells[row, 7] = stock["ToplamKargoUcreti"];
                worksheet.Cells[row, 8] = stock["Maliyet"];
                worksheet.Cells[row, 9] = stock["Kar"];
                worksheet.Cells[row, 10] = stock["Tarih"];

                // Diğer sütunları ekleyin...

                row++;
            }

            // Excel uygulamasını göster

            if (dt.Rows.Count > 0)
            {
                excelApp.Visible = true;
            }
            else
            {
                excelApp.Visible = false;
                MessageBox.Show("Aktarılacak veri bulunamadı.");
            }
       

        }

        private void sahinBox_TextChanged(object sender, EventArgs e)
        {
           


            
           
           

           


        }
    }
}
