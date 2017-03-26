using System;
using System.Linq;
using System.Windows.Forms;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;
using LearnWords.Forms.dialogForms;

namespace LearnWords.Forms
{
    public partial class FormCategoriesManagement : Form
    {
        readonly CategoryRepository _categoryRepository = new CategoryRepository();
        
        readonly WordRepository _wordRepository = new WordRepository();

        public FormCategoriesManagement()
        {
            
            InitializeComponent();
        }
      
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FormNewCategory form = new FormNewCategory(TypeEvent.Create);

            if (form.ShowDialog()!=DialogResult.OK)
            {
                return;
            }

                 var count = dataGridView1.RowCount;
                 long cell = 1;

            if (count != 0)
            {
                 cell = Convert.ToInt64(dataGridView1.Rows[count - 1].Cells[0].Value) + 1;
               
            }

           
            dataGridView1.Rows.Add(form.Category.Id+cell, form.Category.CategoryName,0);

                 
                
        }

        private void CategoriesManagement_Load(object sender, EventArgs e)
        {
            var tableCategory = _categoryRepository.GetCategory();

            var tableWord = _wordRepository.GetWords();

            foreach (var record in tableCategory)
            {
                var result = tableWord.Where(t => t.CategoryId == record.Id);

                dataGridView1.Rows.Add(record.Id, record.CategoryName, result.Count());
            }
        }
 

        private void EditButton_Click(object sender, EventArgs e)
        {
          
          
            if (dataGridView1.RowCount == 0)
            {
                return;
            }

                var item = dataGridView1.CurrentRow;
                var categoryList = _categoryRepository.GetCategory();
           
            if (item != null)
            {
                var id =Convert.ToInt64(item.Cells[0].Value);
                var category = categoryList.Find(w => w.Id == id);
           

                var form = new FormNewCategory(TypeEvent.Edit, category);
            
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }
           
                item.Cells[0].Value = form.Category.Id;
                item.Cells[1].Value = form.Category.CategoryName;

                int ind = dataGridView1.SelectedCells[0].RowIndex;

                if (form.Result)
                {
                    dataGridView1.Rows.RemoveAt(ind);
                }
            }
        }
    }
}
