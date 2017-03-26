

using System.Runtime.InteropServices;

namespace LearnWords.Entities
{
    public class Word
    {
        public long Id { get; private set; }

        public string Eng { get; set; }

        public string Ru { get; set; }

        public long CategoryId { get; set; }
        
        public Word(long wordId, string eng, string ru, long categoryId) 
        {
            Eng = eng;
            Ru = ru;
            CategoryId = categoryId;
            Id = wordId;

        }

    }
}
