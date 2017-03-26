using System;
using System.Collections.Generic;
using System.Linq;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;

namespace LearnWords.DataAccess
{
    class LogicTest
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        private readonly WordRepository _wordRepository = new WordRepository();

        private readonly Random _rnd = new Random();

     

        internal struct FieldsOfWord
        {
            public long WordId;
            public string Cateory;
            public string Eng;
            public string Ru;
            public bool MainWord;
        
        }

        private List<Word> GetWordsWithCategories()
        {
            var chooseWords = new List<Word>();

            var categories = _categoryRepository.GetCategory();
            var words = _wordRepository.GetWords();

            var selectedCategories = categories.Where(record => record.SelectCategory ).ToList();
            
            var wordsCount = (words != null && words.Count >= 5);

           
            //select words from the selected categories
            if (wordsCount)
            {
                foreach (var currentWord in words)
                {
                    foreach (var currentCategory in selectedCategories)
                    {
                        if (currentWord.CategoryId == currentCategory.Id)
                        {
                            chooseWords.Add(currentWord);
                        }
                    }
                }
            }
            return chooseWords;
        }








        public List<FieldsOfWord> ChooseRandomWord()
        {
            var mainWord = 0;
            var list = new List<FieldsOfWord>();
            var objSTest = new FieldsOfWord();

            var wordsWithCategories = GetWordsWithCategories();
            var listWords = _wordRepository.GetWords();
            var listCategory = _categoryRepository.GetCategory();

            var wordsCount = (listWords != null && listWords.Count >= 5);

            if (wordsCount)
            {


                if (wordsWithCategories.Count!=0)
                {
                    mainWord = _rnd.Next(0, wordsWithCategories.Count);

                    var category = listCategory.Find(c => c.Id == wordsWithCategories[mainWord].CategoryId);
                    var nameCategory = category.CategoryName;


                    objSTest.WordId = wordsWithCategories[mainWord].Id;
                    objSTest.Cateory = nameCategory;
                    objSTest.Eng = wordsWithCategories[mainWord].Eng;
                    objSTest.Ru = wordsWithCategories[mainWord].Ru;
                    objSTest.MainWord = true;

                    list.Add(objSTest);


                }
                else
                {

                    mainWord = _rnd.Next(0, listWords.Count);

                    var category = listCategory.Find(c => c.Id == listWords[mainWord].CategoryId);

                    objSTest.Cateory = (category != null) ? category.CategoryName : "none";


                    objSTest.WordId = listWords[mainWord].Id;
                    objSTest.Eng = listWords[mainWord].Eng;
                    objSTest.Ru = listWords[mainWord].Ru;
                    objSTest.MainWord = true;
                    list.Add(objSTest);


                }


                foreach (var variable in listWords)
                {
                    if (list[0].WordId != variable.Id)
                    {
                        var categ = listCategory.Find(c => c.Id == variable.CategoryId);

                        objSTest.Cateory = (categ != null) ? categ.CategoryName : "none";


                        objSTest.WordId = variable.Id;
                        objSTest.Eng = variable.Eng;
                        objSTest.Ru = variable.Ru;
                        objSTest.MainWord = false;
                        list.Add(objSTest);
                    }
                }


                for (var i = 0; i < list.Count; i++)
                {
                    var tmp = list[0];
                    list.RemoveAt(0);
                    list.Insert(_rnd.Next(list.Count), tmp);
                }

                

            }
            return list;
        }

    }
}
