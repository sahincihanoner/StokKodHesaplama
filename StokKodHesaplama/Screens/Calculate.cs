﻿using OfficeOpenXml;
using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

//Created By Fatih Mehmet Coşkun 41

namespace StokKodHesaplama.Screens
{
    public partial class Calculate : UserControl
    {
        public Calculate()
        {
            InitializeComponent();

            GetData();


        }


        private void GetData()
        {
            using (DataContext context = new DataContext())
            {
                cbStockCode.DataSource = context.StockCode.ToList();
                cbStockCode.DisplayMember = "StokKodu";
                cbStockCode.ValueMember = "ID";
                cbStockCode.SelectedIndex = -1;


            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged()
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            txtToplamKargo.Text = (ConvertToDecimal(txtAdet.Text) * ConvertToDecimal(txtBirimKargo.Text)).ToString();


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
            txtBirimKargo.Text = "0";
            txtDesi.Text = "0";
            txtFiyat.Text = "0";
            txtKomisyon.Text = "0";
            txtAdet.Text = "0";
            txtMaliyet.Text = "0";
            if (!string.IsNullOrEmpty(cbStockCode.Text))
            {
                using (var dbContext = new DataContext())
                {
                    var selectedStockCode = cbStockCode.Text;
                    var desi = dbContext.StockCode
                                        .Where(sc => sc.StokKodu == selectedStockCode)
                                        .Select(sc => sc.Desi)
                                        .FirstOrDefault();

                    var fiyat = dbContext.StockCode
                                      .Where(sc => sc.StokKodu == selectedStockCode)
                                      .Select(sc => sc.Fiyat)
                                      .FirstOrDefault();
                    var komisyon = dbContext.StockCode
                                      .Where(sc => sc.StokKodu == selectedStockCode)
                                      .Select(sc => sc.KomisyonTutari)
                                      .FirstOrDefault();
                    var maliyet = dbContext.StockCode
                                     .Where(sc => sc.StokKodu == selectedStockCode)
                                     .Select(sc => sc.UrunMaliyeti)
                                     .FirstOrDefault();


                    var birimKargoUcreti = dbContext.StockCode
                                        .Where(sc => sc.StokKodu == selectedStockCode)
                                        .Select(sc => sc.BirimKargoUcreti)
                                        .FirstOrDefault();


                    if (birimKargoUcreti != null)
                    {
                        txtBirimKargo.Text = birimKargoUcreti.ToString();
                    }
                    else
                    {
                        txtBirimKargo.Text = "0";
                    }


                    if (desi != null)
                    {
                        txtDesi.Text = desi.ToString();
                    }
                    else
                    {
                        // Stok koduna karşılık gelen desi bulunamadı
                        txtDesi.Text = "0";
                    }

                    if (fiyat != null)
                    {
                        txtFiyat.Text = fiyat.ToString();
                    }
                    else
                    {
                        // Stok koduna karşılık gelen fiyat bulunamadı
                        txtFiyat.Text = "0";
                    }

                    if (komisyon != null)
                    {
                        txtKomisyon.Text = komisyon.ToString();
                    }
                    else
                    {
                        // Stok koduna karşılık gelen komisyon tutarı bulunamadı
                        txtKomisyon.Text = "0";
                    }

                    if (maliyet != null)
                    {
                        txtMaliyet.Text = maliyet.ToString();
                    }
                    else
                    {
                        // Stok koduna karşılık gelen ürün maliyeti bulunamadı
                        txtMaliyet.Text = "0";
                    }



                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

            txtToplamKargo.Text = (ConvertToDecimal(txtAdet.Text) * ConvertToDecimal(txtBirimKargo.Text)).ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbStockCode.Text) || string.IsNullOrEmpty(txtAdet.Text) || string.IsNullOrEmpty(txtDesi.Text) || string.IsNullOrEmpty(txtFiyat.Text) || string.IsNullOrEmpty(txtBirimKargo.Text) ||
                string.IsNullOrEmpty(txtKomisyon.Text) || string.IsNullOrEmpty(txtMaliyet.Text) || string.IsNullOrEmpty(txtToplamKargo.Text)
                )
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                return;
            }
            else
            {
                decimal adet = ConvertToDecimal(txtAdet.Text);
                decimal fiyat = ConvertToDecimal(txtFiyat.Text);
                decimal birimKargo = ConvertToDecimal(txtBirimKargo.Text);
                decimal komisyon = ConvertToDecimal(txtKomisyon.Text);
                decimal desi = ConvertToDecimal(txtDesi.Text);
                decimal maliyet = ConvertToDecimal(txtMaliyet.Text);
                decimal toplamKargo = ConvertToDecimal(txtToplamKargo.Text);
                decimal kar = adet * (fiyat - (fiyat * komisyon / 100) - toplamKargo - maliyet);
                lblKar.Text = "Kar: " + kar.ToString();
                lblKar.Visible = true;
                using (DataContext context = new DataContext())
                {


                    context.Stocks.Add(new Stock
                    {
                        StokKodu = cbStockCode.Text,
                        Adet = (int?)adet,
                        Fiyat = fiyat,
                        Desi = desi,
                        BirimKargoUcreti = birimKargo,
                        Komisyon = komisyon,
                        Maliyet = maliyet,
                        ToplamKargoUcreti = toplamKargo,
                        Kar = kar,
                        Tarih = DateTime.Now
                    });
                    context.SaveChanges();
                    //  MessageBox.Show("Başarıyla Kayıt Yapıldı");
                }



            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(GetStocksFromDatabase());
        }
        private List<Stock> GetStocksFromDatabase()
        {
            // Veritabanından verileri al ve geri dön
            // Örnek bir veritabanı sorgusu:
            using (var context = new DataContext())
            {
                return context.Stocks.OrderByDescending(s => s.ID).ToList();

            }
        }

        public void ExportToExcel(List<Stock> stocks)
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
            foreach (var stock in stocks)
            {
                worksheet.Cells[row, 1] = stock.StokKodu;
                worksheet.Cells[row, 2] = stock.Adet;
                worksheet.Cells[row, 3] = stock.Desi;
                worksheet.Cells[row, 4] = stock.Fiyat;
                worksheet.Cells[row, 5] = stock.Komisyon;
                worksheet.Cells[row, 6] = stock.BirimKargoUcreti;
                worksheet.Cells[row, 7] = stock.ToplamKargoUcreti;
                worksheet.Cells[row, 8] = stock.Maliyet;
                worksheet.Cells[row, 9] = stock.Kar;
                worksheet.Cells[row, 10] = stock.Tarih;
                // Diğer sütunları ekleyin...

                row++;
            }

            // Excel uygulamasını göster
            excelApp.Visible = true;

        }
    }
}