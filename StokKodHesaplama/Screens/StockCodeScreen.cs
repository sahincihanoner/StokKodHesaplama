using StokKodHesaplama;
using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StokKodHesaplama
{
    public partial class StockCodeScreen : UserControl
    {
        int ID;
        public StockCodeScreen()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            using (DataContext context = new DataContext())
            {
                dataGridView1.DataSource = context.StockCode.ToList();
            
            }
           
        }



        private void button2_Click(object sender, EventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                StockCode stockCode = context.StockCode.FirstOrDefault(x => x.ID == ID);
                if (stockCode != null)
                {
                   stockCode.StokKodu = txtStockCode.Text;
                    stockCode.Desi = Convert.ToDecimal(txtDesi.Text);
                    stockCode.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                    stockCode.KomisyonTutari = Convert.ToDecimal(txtKomisyon.Text);
                    stockCode.BirimKargoUcreti = Convert.ToDecimal(txtBirimKargo.Text);
                    stockCode.UrunMaliyeti = Convert.ToDecimal(txtUrunMaliyet.Text);
                    stockCode.Tarih = DateTime.Now;

                    context.SaveChanges();
                    MessageBox.Show("Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Stok Kodu bulunamadı");
                }
                GetData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataContext context = new DataContext())
            {
               var stockCode = txtStockCode.Text;
                var desi = string.IsNullOrEmpty(txtDesi.Text)?"0": txtDesi.Text;
                var fiyat = string.IsNullOrEmpty(txtFiyat.Text)?"0": txtFiyat.Text;
                var komisyon = string.IsNullOrEmpty(txtKomisyon.Text)?"0": txtKomisyon.Text;
                var birimKargo = string.IsNullOrEmpty(txtBirimKargo.Text)?"0": txtBirimKargo.Text;
                var urunmaliyet = string.IsNullOrEmpty(txtUrunMaliyet.Text)?"0": txtUrunMaliyet.Text;


                //stok koduna göre veri tabanında arama yapıp yoksa ekleme yapılacak varsa stok kodu zaten var mesajı verilecek

                var stockCodeEntity = context.StockCode.FirstOrDefault(x => x.StokKodu == stockCode);
                var stockCodeExist = stockCodeEntity != null;

                if (!string.IsNullOrEmpty(stockCode) && !stockCodeExist)
                {
                    context.StockCode.Add(new StockCode
                    {
                        StokKodu = stockCode,
                        Desi = Convert.ToDecimal(desi),
                        Fiyat = Convert.ToDecimal(fiyat),
                        KomisyonTutari = Convert.ToDecimal(komisyon),
                        BirimKargoUcreti = Convert.ToDecimal(birimKargo),
                        UrunMaliyeti = Convert.ToDecimal(urunmaliyet),
                         Tarih = DateTime.Now
                    });
                    context.SaveChanges();
                    MessageBox.Show("Başarıyla Kayıt Yapıldı");
                }
                else if(!stockCodeExist)
                {
                    MessageBox.Show("Stok Kodu zaten var");
                }
              
                else
                {
                    MessageBox.Show("Stok Kodu boş olamaz");
                }

                GetData();

            }
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

                ID = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                txtStockCode.Text = stockCode;
                txtDesi.Text = desi;
                txtFiyat.Text = fiyat;
                txtKomisyon.Text = komisyonTutari;
                txtBirimKargo.Text = birimKargoUcreti;
                txtUrunMaliyet.Text = urunMaliyeti;
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

                    // DataGridView'den satırı kaldır
          

                    // Veritabanından sil
                    using (DataContext context = new DataContext())
                    {
                        StockCode stockCode = context.StockCode.FirstOrDefault(x => x.ID == ID); // Stok kodunu kullanarak ilgili kaydı bulun
                        if (stockCode != null)
                        {
                            context.StockCode.Remove(stockCode); // Kaydı veritabanından kaldırın
                            context.SaveChanges();
                        }
                    }

                    MessageBox.Show("Seçili satır başarıyla silindi.");
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



   
    