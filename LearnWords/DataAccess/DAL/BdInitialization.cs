using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using LearnWords.Entities;

namespace LearnWords.DataAccess.DataBaseManagement
{
    class BdInitialization : BdRepository
    {
        readonly CategoryRepository _category = new CategoryRepository();
        readonly WordRepository _word = new WordRepository();

        public void Create()
        {

            if (!File.Exists(Connection))
            {
                SQLiteConnection.CreateFile(Connection);
                
                CreateCategory();
                CreateWords();
                CreateStatistics();
                StandardWords();
            }

        }

        private void CreateStatistics()
        {
            using (var connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                SQLiteCommand command = null;
                connection.Open();
                command =
                   new SQLiteCommand("CREATE TABLE Statistics (ID INTEGER PRIMARY KEY, WordID INTEGER, RESULT INTEGER, Date DATETIME, FOREIGN KEY (WordID) REFERENCES Word(ID));",
                           connection);
                command.ExecuteNonQuery();

            }

        }


        private void CreateWords()
        {
            using (var connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                SQLiteCommand command = null;
                connection.Open();
                command =
                   new SQLiteCommand("CREATE TABLE Words (ID INTEGER PRIMARY KEY, ENG TEXT, RU TEXT, CategoryID INTEGER, FOREIGN KEY (CategoryID) REFERENCES Category(ID));",
                           connection);
                command.ExecuteNonQuery();

            }

        }

        private void CreateCategory()
        {
            using (var connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                SQLiteCommand command = null;
                connection.Open();
                command =
                    new SQLiteCommand(
                        "CREATE TABLE Category (ID INTEGER PRIMARY KEY, Category TEXT, SelectCategory BOOL);",
                        connection);
                command.ExecuteNonQuery();

            }
        }

        private void StandardWords()
        {
            var objList = new List<Word>
            {
                new Word(1,"draw",  "рисовать", 1),
                new Word(2,"fight",  "драться", 1),
                new Word(3,"fall",  "падать", 1),
                new Word(4,"hit",  "ударить", 1),
                new Word(5,"hurt",  "ранить", 1),
                new Word(6,"hear",  "слушать", 1)
            };
            _category.InsertCategory("Irregular words");

            foreach (var record in objList)
            {
                _word.InsertWord(record.Eng, record.Ru, record.CategoryId);
            }
            _category.UpDateCheckBox("Irregular words",1,true);
        }
    }
}
