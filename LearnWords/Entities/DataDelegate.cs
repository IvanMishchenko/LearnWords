

namespace LearnWords.Entities
{
    public delegate void CategoryEvent(Category objCategory, TypeEvent typeEvent);

    internal static class DataDelegate 
    {
        public static CategoryEvent Changes { get; set; }
    }
}