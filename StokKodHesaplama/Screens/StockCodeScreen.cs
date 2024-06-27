using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Utilities.Collections;
using StokKodHesaplama;
using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;


namespace StokKodHesaplama
{
    public partial class StockCodeScreen : UserControl
    {
        private DbClass db;
        int ID;
        public StockCodeScreen()
        {
            InitializeComponent();
      
            db = new DbClass();
              GetData();
        }
        private void AddStockCode(string stockCode,decimal desi,decimal fiyat,decimal komisyon,decimal birimkargo,decimal urunMaliyet)
        {
            string insertQuery = $"INSERT INTO StockCodes (StokKodu, Desi, Fiyat, KomisyonTutari, BirimKargoUcreti, UrunMaliyeti) VALUES ('{txtStockCode.Text}'," +
                $"{txtDesi.Text},{txtFiyat.Text},{txtKomisyon.Text},{txtBirimKargo.Text},{txtUrunMaliyet.Text})";
            db.ExecuteNonQuery(insertQuery);
        }
        private void GetData()
        {
        
            string selectQuery = "select ID,StokKodu,Desi,Fiyat,KomisyonTutari,BirimKargoUcreti,UrunMaliyeti from StockCodes";
            DataTable dt = db.ExecuteQuery(selectQuery);
            dataGridView1.DataSource = dt;
            
        }


        private void UpdateStockCode(int id, string StockCode, string Desi, string Fiyat, string KomisyonTutari, string BirimKargoUcreti, string UrunMaliyeti)
        {
            string updateQuery = $@"UPDATE StockCodes
SET StokKodu =  '{StockCode}',
    Desi =  {Desi},
    Fiyat =  {Fiyat},
    KomisyonTutari =  {KomisyonTutari},
    BirimKargoUcreti =  {BirimKargoUcreti},
    UrunMaliyeti = {UrunMaliyeti}
WHERE ID = {id}
            ";
            db.ExecuteNonQuery(updateQuery);


        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = db.GetRecord("StockCodes", "ID", ID.ToString());
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                UpdateStockCode(ID, txtStockCode.Text, txtDesi.Text, txtFiyat.Text, txtKomisyon.Text, txtBirimKargo.Text, txtUrunMaliyet.Text);
                MessageBox.Show("Başarıyla Güncellendi");
                GetData();
            }
            else
            {
                MessageBox.Show("Stok Kodu bulunamadı");
            }

           


            //using (DataContext context = new DataContext())
            //{
            //    StockCode stockCode = context.StockCode.FirstOrDefault(x => x.ID == ID);
            //    if (stockCode != null)
            //    {
            //       stockCode.StokKodu = txtStockCode.Text;
            //        stockCode.Desi = Convert.ToDecimal(txtDesi.Text);
            //        stockCode.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            //        stockCode.KomisyonTutari = Convert.ToDecimal(txtKomisyon.Text);
            //        stockCode.BirimKargoUcreti = Convert.ToDecimal(txtBirimKargo.Text);
            //        stockCode.UrunMaliyeti = Convert.ToDecimal(txtUrunMaliyet.Text);
            //        stockCode.Tarih = DateTime.Now;

            //        context.SaveChanges();
            //        MessageBox.Show("Başarıyla Güncellendi");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Stok Kodu bulunamadı");
            //    }
            //    GetData();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stockCode = txtStockCode.Text;
            var desi = string.IsNullOrEmpty(txtDesi.Text) ? "0" : txtDesi.Text;
            var fiyat = string.IsNullOrEmpty(txtFiyat.Text) ? "0" : txtFiyat.Text;
            var komisyon = string.IsNullOrEmpty(txtKomisyon.Text) ? "0" : txtKomisyon.Text;
            var birimKargo = string.IsNullOrEmpty(txtBirimKargo.Text) ? "0" : txtBirimKargo.Text;
            var urunmaliyet = string.IsNullOrEmpty(txtUrunMaliyet.Text) ? "0" : txtUrunMaliyet.Text;

            bool exists = db.ValueExistsInColumn("StockCodes", "StokKodu", stockCode);

            if (!exists)
            {
                AddStockCode(stockCode, Convert.ToDecimal(desi), Convert.ToDecimal(fiyat), Convert.ToDecimal(komisyon), Convert.ToDecimal(birimKargo), Convert.ToDecimal(urunmaliyet));
                MessageBox.Show("Başarıyla Kayıt Yapıldı");
                GetData();
            }
            else
            {
                MessageBox.Show("Stok Kodu zaten var");
            }
            GetData();
      

            //using (DataContext context = new DataContext())
            //{
            //   var stockCode = txtStockCode.Text;
            //    var desi = string.IsNullOrEmpty(txtDesi.Text)?"0": txtDesi.Text;
            //    var fiyat = string.IsNullOrEmpty(txtFiyat.Text)?"0": txtFiyat.Text;
            //    var komisyon = string.IsNullOrEmpty(txtKomisyon.Text)?"0": txtKomisyon.Text;
            //    var birimKargo = string.IsNullOrEmpty(txtBirimKargo.Text)?"0": txtBirimKargo.Text;
            //    var urunmaliyet = string.IsNullOrEmpty(txtUrunMaliyet.Text)?"0": txtUrunMaliyet.Text;

            //    AddStockCode(stockCode, Convert.ToDecimal(desi), Convert.ToDecimal(fiyat), Convert.ToDecimal(komisyon), Convert.ToDecimal(birimKargo), Convert.ToDecimal(urunmaliyet));


            //    var stockCodeEntity = context.StockCode.FirstOrDefault(x => x.StokKodu == stockCode);
            //    var stockCodeExist = stockCodeEntity != null;

            //    if (!string.IsNullOrEmpty(stockCode) && !stockCodeExist)
            //    {
            //        context.StockCode.Add(new StockCode
            //        {
            //            StokKodu = stockCode,
            //            Desi = Convert.ToDecimal(desi),
            //            Fiyat = Convert.ToDecimal(fiyat),
            //            KomisyonTutari = Convert.ToDecimal(komisyon),
            //            BirimKargoUcreti = Convert.ToDecimal(birimKargo),
            //            UrunMaliyeti = Convert.ToDecimal(urunmaliyet),
            //             Tarih = DateTime.Now
            //        });
            //        context.SaveChanges();
            //        MessageBox.Show("Başarıyla Kayıt Yapıldı");
            //    }
            //    else if(!stockCodeExist)
            //    {
            //        MessageBox.Show("Stok Kodu zaten var");
            //    }

            //    else
            //    {
            //        MessageBox.Show("Stok Kodu boş olamaz");
            //    }

            //    GetData();

            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçildiğinden emin olun
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // İlgili hücrenin değerini al
                string stockCode = selectedRow.Cells["StokKodu"].Value.ToString();
                string desi = selectedRow.Cells["Desi"].Value.ToString();
                string fiyat = selectedRow.Cells["Fiyat"].Value?.ToString();
                string komisyonTutari = selectedRow.Cells["KomisyonTutari"].Value?.ToString();
                string birimKargoUcreti = selectedRow.Cells["BirimKargoUcreti"].Value?.ToString();
                string urunMaliyeti = selectedRow.Cells["UrunMaliyeti"].Value?.ToString();

                try
                {

                    ID = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                    txtStockCode.Text = stockCode;
                    txtDesi.Text = desi;
                    txtFiyat.Text = fiyat;
                    txtKomisyon.Text = komisyonTutari;
                    txtBirimKargo.Text = birimKargoUcreti;
                    txtUrunMaliyet.Text = urunMaliyeti;
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen doğru satırı seçiniz");
                  
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int selectedRowIndex = dataGridView1.CurrentRow.Index;
                if (selectedRowIndex >= 0)
                {
                    string stokKodu = dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value.ToString(); // Stok kodu hücresini alın


                    bool exists = db.ValueExistsInColumn("StockCodes", "ID", ID.ToString());
                    if (exists)
                    {
                        db.ExecuteNonQuery($"DELETE FROM StockCodes WHERE ID = {ID} ");
                        MessageBox.Show("Seçili satır başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen silinecek satırı seçin.");
                    }

                    //using (DataContext context = new DataContext())
                    //{
                    //    StockCode stockCode = context.StockCode.FirstOrDefault(x => x.ID == ID);
                    //    if (stockCode != null)
                    //    {
                    //        context.StockCode.Remove(stockCode);
                    //        context.SaveChanges();
                    //    }
                    //}

                   
                    GetData();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek satırı seçin.");
            }
        }
    }
}



   
    