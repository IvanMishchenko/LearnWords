using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using LearnWords.Entities;

namespace LearnWords.DataAccess.DataBaseManagement
{
    class CategoryRepository : BdRepository
    {
        readonly WordRepository _word = new WordRepository();

        public void InsertCategory(string category )
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand(
                       "INSERT INTO Category (Category,SelectCategory) VALUES ( @category, @FALSE );", connection);
                
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@FALSE", false);
                command.ExecuteNonQuery();

            }
        }

        public void DeleteCategory(long id)
        {
            _word.UpDateInWordCategory(id);
            using (var connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand("DELETE FROM Category WHERE rowid = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

            }


        }
        
        public List<Category> GetCategory()
        {

            using (var connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM Category", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<Category> category = (from DbDataRecord record in reader
                                           select
                                               new Category(record.GetInt64(0), record.GetString(1), record.GetBoolean(2))).ToList();


                return category;
            }
        }
        public void UpDateCategory(string category, long id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand(
                        "UPDATE Category SET Category =@category WHERE ID=@id",
                        connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@category", category);
                command.ExecuteNonQuery();
            }

        }
        public void UpDateCheckBox(string category, long idCategory, bool selectCategory)
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand(
                            "UPDATE Category SET Category = @category,SelectCategory=@SelectCategory  WHERE ID=@id", connection);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@SelectCategory", selectCategory);
                command.Parameters.AddWithValue("@id", idCategory);
                command.ExecuteNonQuery();

            }
        }
    }
}
