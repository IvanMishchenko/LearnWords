namespace LearnWords.DataAccess.DataBaseManagement
{
    internal abstract class BdRepository
    {
        private const string DbConnection = @"WordsBD.sqlite";

        protected static string Connection
        {
            get { return DbConnection; }
        }
    }

}

