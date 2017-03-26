


namespace LearnWords.Entities
{
    public class Category 
    {
        public long Id { get; private set; }

        public string CategoryName{get; set; }

        public bool SelectCategory { get; private set; }

        public Category(long id, string category, bool selectCategory)
        {
            CategoryName = category;
            Id = id;
            SelectCategory = selectCategory;
         
        }

        
    }

}
