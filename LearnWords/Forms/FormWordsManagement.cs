using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;
using LearnWords.Forms.dialogForms;
using LearnWords.Properties;

namespace LearnWords.Forms
{
    public partial class FormWordsManagement : Form
    {
        readonly FormSettings _objSettings = new FormSettings(Settings.Default.numericUpDown);

        readonly WordRepository _wordRepository = new WordRepository();

        readonly CategoryRepository _categoryRepository = new CategoryRepository();

        readonly BdInitialization _bdInitialization = new BdInitialization();

        readonly BindingSource _bsTable = new BindingSource();

        readonly DataTable _dtTable = new DataTable();


        public FormWordsManagement()
        {
            InitializeComponent();

            _bdInitialization.Create();

            DataDelegate.Changes += ReloadColumn;

      
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            var form = new FormNewWord(TypeEvent.Create);
            var count= dataGridView1.RowCount;
           
            long cell=1;
                 if (count != 0)
                 {
                    cell = Convert.ToInt64(dataGridView1.Rows[count - 1].Cells[0].Value) + 1;
                 }
          
            
            if (form.ShowDialog()!=DialogResult.OK)
            {
                return;
            }


            var list = _categoryRepository.GetCategory();

            var category = list.Find(c => c.Id==form.ObjWord.CategoryId);
            var categ = (form.ObjWord.CategoryId == 0) ? "none" : category.CategoryName;

            _dtTable.Rows.Add(form.ObjWord.Id + cell, form.ObjWord.Eng, form.ObjWord.Ru, categ);
          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Activate();
             Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _objSettings.Activate();
                _objSettings.Show();
        }

        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           var  objCategoriesManagement=new FormCategoriesManagement();

                objCategoriesManagement.Show();
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objFormTest = new FormTest();
            objFormTest.Activate();
            objFormTest.Show();
       


        }

        private void WordsManagement_Load(object sender, EventArgs e)
        {

            _bsTable.DataSource = _dtTable;
            dataGridView1.DataSource = _dtTable;

            

            _dtTable.Columns.Add(new DataColumn("ID", typeof(int)));
            _dtTable.Columns.Add(new DataColumn("Eng", typeof(string)));
            _dtTable.Columns.Add(new DataColumn("Ru", typeof(string)));
            _dtTable.Columns.Add(new DataColumn("Category", typeof(string)));

            int[] masWidth = { 50, 120, 165, 120 };

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = masWidth[i];
            }

            var listWords = _wordRepository.GetWords();
       
            var listCategories = _categoryRepository.GetCategory();

           

            foreach (var reader in listWords)
            {
                var category = listCategories.Find(c => c.Id == reader.CategoryId);
                var categ = (reader.CategoryId == 0) ? "none" : category.CategoryName;

                _dtTable.Rows.Add(reader.Id, reader.Eng, reader.Ru, categ);
              

            }

        }

       

        private void EditButton_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.RowCount==0)
            {
                return;                
            }
            
                 var item = dataGridView1.CurrentRow;

            if (item != null)
            {
                var id = Convert.ToInt64(item.Cells[0].Value);

                var words = _wordRepository.GetWords();
                var word = words.Find(w => w.Id == id);

                var newWord = new FormNewWord(TypeEvent.Edit, word);


                    if (newWord.ShowDialog() != DialogResult.OK)
                    {
                        return;
                     }

                    var list = _categoryRepository.GetCategory();

                var category = list.Find(c => c.Id == newWord.ObjWord.CategoryId);
                var categoryName = (newWord.ObjWord.CategoryId == 0) ? "none" : category.CategoryName; 

                    item.Cells[1].Value = newWord.ObjWord.Eng;
                    item.Cells[2].Value = newWord.ObjWord.Ru;
                    item.Cells[3].Value = categoryName;

                var ind = dataGridView1.SelectedCells[0].RowIndex;
              
                    if (newWord.Result)
                    {
                       dataGridView1.Rows.RemoveAt(ind);
                    }
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            _dtTable.DefaultView.RowFilter = ("[Category] ='" + SelectCategoryBox.Text + "'");
        }

       

        private void SelectCategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SelectCategoryBox_Click(object sender, EventArgs e)
        {
            SelectCategoryBox.Items.Clear();
            var listCategories = _categoryRepository.GetCategory();
            SelectCategoryBox.Items.Add("none");
            foreach (var reader in listCategories)
            {
                SelectCategoryBox.Items.Add(reader.CategoryName);

            }
        }

        private void Resetbutton_Click(object sender, EventArgs e)
        {
            _dtTable.DefaultView.RowFilter = string.Empty;
            SearchBox.ResetText();
       
           
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            _dtTable.DefaultView.RowFilter = ("[Eng] like'%" + SearchBox.Text + "%'" + "OR [Ru] like'%" + SearchBox.Text + "%'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormStatistics();
            form.Activate();
            form.Show();
            
        }

        private void ReloadColumn(Category objCategory, TypeEvent typeEvent)
        {

            var listWords = _wordRepository.GetWords();
            var list = _categoryRepository.GetCategory();

            if (typeEvent==TypeEvent.Edit)
            {
                for (var i = 0; i < listWords.Count; i++)
                {
                    if (objCategory.Id == listWords[i].CategoryId)
                    {
                        var result = list.Find(c => c.Id == listWords[i].CategoryId);

                        dataGridView1.Rows[i].Cells[3].Value = result.CategoryName;

                    }
                }
            }

            if (typeEvent==TypeEvent.Delete)
            {
                for (var i = 0; i < listWords.Count; i++)
                {
                    if (objCategory.Id == listWords[i].CategoryId)
                    {
                        dataGridView1.Rows[i].Cells[3].Value ="none";

                    }
                }
            }

          
        }

     
    }
}
