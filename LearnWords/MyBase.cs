using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWords
{
   internal class MyBase
    {
        private const string databaseName = @"WordsBD.sqlite";

       internal class WordsWithTable
        { 
           private string eng;
           private string ru1;
           private string ru2;
           private string category;
           private long id;

           public string Eng 
           { 
                get { return eng; } 
                private set { eng = value; }
           }

           public string Ru1
           {
               get { return ru1; }
               private set { ru1 = value; }
           }

           public string Ru2
           {
               get { return ru2; } 
               set { ru2 = value; }
           }

           public string Category
           {
               get { return category; }
               set { category = value; }
           }

           public long Id
           {
               get { return id; }
               set { id = value; }
           }

            public WordsWithTable(long id, string eng, string ru1, string ru2, string category)
            {
               this.Eng = eng;
               this.Ru1 = ru1;
               this.Ru2 = ru2;
               this.Category = category;
                this.Id = id;
            }
        }

       internal class Category
       {
           private long id;
           private string categ;
           private string totalAmount;
           private string checkBox;
           
           public string Categ
           {
               get { return categ; }
               set { categ = value; }
           }
           public string TotalAmount
           {
               get { return totalAmount; }
               set { totalAmount = value; }
           }

           public long Id
           {
               get { return id; }
               set { id = value; }
           }

           public string СheckBoxValue
           {
               get { return checkBox; }
               set { checkBox = value; }
           }
          public Category(long id, string category, string totalAmount, string checkbox)
           {
               Categ = category;
               TotalAmount = totalAmount.ToString();
               Id = id;
               СheckBoxValue = checkbox;
           
          }


       }
        public void Create()
        {
         
            if (!File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
                CreateTable("TWords");
                CreateTable("TCategory");
                MessageBox.Show("Base was created !", "Settings");
            }
          
        }

       public void Insert(string eng, string ru1,string ru2, string category)
       {
           
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand("INSERT INTO 'TWords' ('ENG','RU1','RU2','Category') VALUES ('" + eng + "','"+ru1+"','"+ru2+"','"+category+"');", connection);
           command.ExecuteNonQuery();
           connection.Close();


           var table = ShowCategory();
           foreach (var record in table)
           {
               if (record.Categ==category)
               {
                   var totalAmount = Convert.ToInt32(record.TotalAmount) + 1;
                  UpDate("TCategory",category,totalAmount,record.Id);               
               }
              
           }

       }
       public void Insert(string category, int totalAmount)
       {

           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand("INSERT INTO 'TCategory' ('Category','TotalAmount','СheckBox') VALUES ('" + category + "','" + totalAmount + "','false');", connection);
           command.ExecuteNonQuery();
           connection.Close();
       }

       private void CreateTable(string tabelName)
       {
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           SQLiteCommand command = null;
           connection.Open();
 
           if (tabelName == "TWords")
           {
            command =
               new SQLiteCommand("CREATE TABLE '" + tabelName + "' (ID INTEGER PRIMARY KEY, ENG TEXT, RU1 TEXT, RU2 TEXT, Category TEXT);",
                       connection);
           }
           if (tabelName=="TCategory")
           {
                command =
                new SQLiteCommand("CREATE TABLE '" + tabelName + "' (ID INTEGER PRIMARY KEY, Category TEXT, TotalAmount TEXT, СheckBox TEXT);",
                        connection); 
           }
           command.ExecuteNonQuery();
           connection.Close();
           
       }

       public bool Delete(string nameTable, long id)
       {
           //нежно доделать удаление слов которые относятся к этой категории 
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand(String.Format("DELETE FROM '" + nameTable + "'WHERE rowid ={0};", id), connection);
           SQLiteDataReader reader = command.ExecuteReader();

           var table = ShowCategory();
           foreach (var record in table)
           {
               if (record.Id == id)
               {
                   var totalAmount = Convert.ToInt32(record.TotalAmount) - 1;
                   UpDate("TCategory", record.Categ, totalAmount, record.Id);
               }

           }
           
           return true;
           
       }

       /*public List<string> TotalAmount(string nameTable)
       {
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;", connection);
           SQLiteDataReader reader = command.ExecuteReader();

           List<string> Tables = (from DbDataRecord record in reader select record["name"].ToString()).ToList();
           connection.Close();
           return Tables;
       }*/


       public List<WordsWithTable> ShowWords()
       {
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = null;
           command = new SQLiteCommand("SELECT * FROM 'TWords';", connection);
           SQLiteDataReader reader = command.ExecuteReader();
           List<WordsWithTable> Words = null;
           Words = (from DbDataRecord record in reader
               select
                   new WordsWithTable(record.GetInt64(0), record.GetString(1), record.GetString(2),
                       record.GetString(3), record.GetString(4))).ToList();

      

       connection.Close();
           return  Words;
       }

       public List<Category> ShowCategory()
       {
           
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command  = new SQLiteCommand("SELECT * FROM 'TCategory';", connection);
           SQLiteDataReader reader = command.ExecuteReader();
           List<Category> Category = (from DbDataRecord record in reader
                        select
                            new Category(record.GetInt64(0), record.GetString(1), record.GetString(2), record.GetString(3))).ToList();
        
           connection.Close();
           return Category;
       }

       public void UpDate(string nameTable, string eng, string ru1, string ru2, string category, long id)
       {
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand(String.Format("UPDATE '" + nameTable + "' SET 'ENG' ='"+eng+"', 'RU1'='{1}', 'RU2'='{2}', 'Category'='{3}' WHERE ID='{4}'", eng, ru1, ru2, category, id), connection);
           SQLiteDataReader reader = command.ExecuteReader();
           connection.Close();
           

           
       }

       public void UpDate(string nameTable, string category, long totalAmount, long id, string chackBoxValue)
       {
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand(String.Format("UPDATE '" + nameTable + "' SET 'Category' ='" + category + "','TotalAmount'='" + totalAmount + "','СheckBox'='" + chackBoxValue + "' WHERE ID='{0}'", id), connection);
           SQLiteDataReader reader = command.ExecuteReader();
           connection.Close();

       }

       public void UpDate(string nameTable, string category, long totalAmount, long id)
       {
           SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
           connection.Open();
           SQLiteCommand command = new SQLiteCommand(String.Format("UPDATE '" + nameTable + "' SET 'Category' ='" + category + "','TotalAmount'='" + totalAmount + "' WHERE ID='{0}'", id), connection);
           SQLiteDataReader reader = command.ExecuteReader();
           connection.Close();



       }

    }
}
