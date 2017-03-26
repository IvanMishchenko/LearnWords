using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using LearnWords.Entities;

namespace LearnWords.DataAccess.DataBaseManagement
{
    class WordRepository:BdRepository
    {

        public void InsertWord(string eng, string ru, long categoryId)
        {

            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Words (ENG,RU,CategoryID) VALUES ( @eng, @ru, @categoryID )";

                command.Parameters.AddWithValue("@eng", eng);
                command.Parameters.AddWithValue("@ru", ru);

                command.Parameters.AddWithValue("@categoryID", categoryId);

                command.ExecuteNonQuery();

            }
           

        }

       

        public List<Word> GetWords()
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command = null;
                command = new SQLiteCommand("SELECT * FROM Words", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<Word> words = null;
                words = (from DbDataRecord record in reader
                         select
                             new Word(record.GetInt64(0), record.GetString(1), record.GetString(2), record.GetInt64(3))).ToList();

                return words;
            }
        }
        public void DeleteWord(long id)
        {

            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand("DELETE FROM Words WHERE rowid =@id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

            }

        }



        public void UpDateWord(string eng, string ru, long categoryId, long idWord)
        {

            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand(
                            "UPDATE Words SET ENG = @eng, RU= @ru, CategoryID= @categoryID WHERE ID= @id", connection);


                command.Parameters.AddWithValue("@eng", eng);
                command.Parameters.AddWithValue("@ru", ru);

                command.Parameters.AddWithValue("@categoryID", categoryId);
                command.Parameters.AddWithValue("@id", idWord);
                command.ExecuteNonQuery();

            }

        }

        public void UpDateInWordCategory(long idCategory)
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {

                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand("UPDATE Words SET CategoryID = 0 WHERE CategoryID = @oldNameCategory", connection);
                command.Parameters.AddWithValue("@oldNameCategory", idCategory);
                command.ExecuteNonQuery();
            }
        }
        
       
    }
}
