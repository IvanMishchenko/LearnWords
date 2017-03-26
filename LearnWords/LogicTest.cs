using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWords
{
    class LogicTest
    {
        private MyBase objMyBase = new MyBase();
        private Random rnd = new Random();

        private struct SCategoryAndTotalAmount
        {
            public string categoryCheckBox;
            public long totalAmount;
            
        }

        internal struct STest
        {
          
            public string cateory;
            public string eng;
            public string ru1;
            public bool mainWord;
           // public string ru2;
        
        }

        private List<SCategoryAndTotalAmount> SearchChosoCategory()
        {
            List<SCategoryAndTotalAmount> tabelList = new List<SCategoryAndTotalAmount>();
            SCategoryAndTotalAmount objSCategoryAndTotalAmount = new SCategoryAndTotalAmount();
            var table = objMyBase.ShowCategory();

            foreach (var record in table)
            {
                if (record.СheckBoxValue == "True")
                {
                    objSCategoryAndTotalAmount.categoryCheckBox = record.Categ;
                    objSCategoryAndTotalAmount.totalAmount = Convert.ToInt64(record.TotalAmount);
                 
                    tabelList.Add(objSCategoryAndTotalAmount);
                }

            }
            return tabelList;

        }


        public bool CheckAmount()
        {
            bool result = false;

            var list = SearchChosoCategory();

            foreach (var record in list)
            {
                
                    if (record.totalAmount != 0)
                    {
                        result = true;
                    }
                
            }

            return result;
        }


        private List<MyBase.WordsWithTable> ChooseWords()
        {
            List<MyBase.WordsWithTable> objListWords = new List<MyBase.WordsWithTable>(); 

           var listWords =  objMyBase.ShowWords();
            var chooseCategory = SearchChosoCategory();
            foreach (var record in listWords)
            {
                foreach (var rec in chooseCategory)
                {
                    if (record.Category==rec.categoryCheckBox)
                    {
                        objListWords.Add(record);
                    }
                }
             }

            return (objListWords.Count != 0) ? objListWords : null;
        }



        public List<STest> ChooseRandomWord()
        {
            List<STest> list= new List<STest>();
            var objSTest = new STest();

            var words = ChooseWords();
            var listWords = objMyBase.ShowWords();

           
            int mainWord = 0;

            if (words!=null)
            {
                 mainWord = rnd.Next(1, words.Count);
               

            objSTest.cateory = words[mainWord].Category;
            objSTest.eng = words[mainWord].Eng;
            objSTest.ru1 = words[mainWord].Ru1;
            objSTest.mainWord = true;
            list.Add(objSTest);

            }

            
                foreach (var VARIABLE in listWords)
                {
                    if (list[0].eng!=VARIABLE.Eng)
                    {
                        objSTest.cateory = VARIABLE.Category;
                        objSTest.eng = VARIABLE.Eng;
                        objSTest.ru1 = VARIABLE.Ru1;
                        objSTest.mainWord = false;
                        list.Add(objSTest);
                    }
                }
                
           
         
            for (int i = 0; i < list.Count; i++)
            {
                var tmp = list[0];
                list.RemoveAt(0);
                list.Insert(rnd.Next(list.Count), tmp);
            }

            return list;
        }



    }
}
