using StokKodHesaplama.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO.Packaging;

public class DbClass
{
    private string connectionString;
    private SQLiteConnection connection;

    public DbClass()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        connectionString = $"Data Source=C:\\Users\\fatih\\deneme\\stock.db;Version=3";
        connection = new SQLiteConnection(connectionString);
    }

    // Veritabanını aç
    public void OpenConnection()
    {
        if (connection.State != ConnectionState.Open)
        {
          
            connection.Open();
            
        }
    }

    // Veritabanını kapat
    public void CloseConnection()
    {
        if (connection.State != ConnectionState.Closed)
        {
            connection.Close();
        }
    }

    // SQL sorgusu çalıştır (SELECT dışındaki sorgular)
    public void ExecuteNonQuery(string query)
    {
        try
        {
            OpenConnection();
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
    }

   
    public DataTable GetRecord(string tableName, string columnName, string value)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            string query = $"SELECT * FROM {tableName} WHERE {columnName} = @value";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@value", value);
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }
    public bool ValueExistsInColumn(string tableName, string columnName, string value)
    {
        bool exists = false;
        try
        {
            OpenConnection();
            string query = $"SELECT COUNT(1) FROM {tableName} WHERE {columnName} = @value";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@value", value);
                exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
        return exists;
    }
    public object GetValueFromDatabase(string tableName, string columnName, string stokKodu)
    {
        object result = null;
        string query = $"SELECT {columnName} FROM {tableName} WHERE StokKodu = @StokKodu";

        try
        {
            OpenConnection();
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StokKodu", stokKodu);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader[columnName];
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }

        return result;
    }

    // SQL sorgusu çalıştır ve sonuçları DataTable olarak dön (SELECT sorguları)
    public DataTable ExecuteQuery(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            using (var cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }

  

}
