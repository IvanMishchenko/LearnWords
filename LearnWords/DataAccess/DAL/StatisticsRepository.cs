using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using LearnWords.Entities;

namespace LearnWords.DataAccess.DataBaseManagement
{
    internal class StatisticsRepository : BdRepository
    {


        public List<Statistics> GetStatistisc()
        {
            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command = null;
                command = new SQLiteCommand("Select t.Id, t.Date From Statistics t;", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                List<Statistics> statis = (from DbDataRecord record in reader
                    select
                        new Statistics(record.GetInt64(0), record.GetDateTime(1))).ToList();

                return statis;
            }
        }

        public void InsertSatatistics(long wordId, TypeAnswers answer)
        {



            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();

                SQLiteCommand command =
                    new SQLiteCommand(
                        "INSERT INTO Statistics (WordID,RESULT,Date ) VALUES ( @wordId, @result, @date)",
                        connection);

                command.Parameters.AddWithValue("@wordId", wordId);
                command.Parameters.AddWithValue("@result", Convert.ToInt32(answer));
                command.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                command.ExecuteNonQuery();

            }


        }

        public long GetResult(DateTime date1, DateTime date2, TypeAnswers answer)
        {

            using (SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", Connection)))
            {
                connection.Open();
                SQLiteCommand command =
                    new SQLiteCommand(
                        "select COUNT(s.RESULT) from Statistics s where s.DATE  between @date1 and @date2 and s.RESULT = @answer",
                        connection);

                command.Parameters.AddWithValue("@date1", date1);
                command.Parameters.AddWithValue("@date2", date2);
                command.Parameters.AddWithValue("@answer", Convert.ToInt32(answer));
                var reader = command.ExecuteScalar();

                return (long) reader;
            }

        }

      
      

}
}
