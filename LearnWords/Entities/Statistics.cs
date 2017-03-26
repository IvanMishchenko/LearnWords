using System;


namespace LearnWords.Entities
{
  internal class Statistics
  {
      public long Id { get; set; }

      public DateTime Date { get; private set; }

      public Statistics(long id, DateTime date)
        {
            Id = id;
            Date = date;
        }

     
    }
}
