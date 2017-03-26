using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWords
{
    public partial class WordsManagement : Form
    {
        readonly Settings objSettings = new Settings(LearnWords.Properties.Settings.Default.numericUpDown);
        MyBase objMyBase = new MyBase();
        FormTest objFormTest = new FormTest();
        CategoriesManagement objCategoriesManagement = new CategoriesManagement();


        public WordsManagement()
        {
            InitializeComponent();
            objMyBase.Create();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            var form = new NewWord();
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
            dataGridView1.Rows.Add(form.Id+cell, form.Eng, form.Ru1, form.CategoryName);
            
        
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
            
            Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objSettings.Show();
        }

        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objCategoriesManagement=new CategoriesManagement();
            objCategoriesManagement.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFormTest=new FormTest();
           objFormTest.Show(); 
        
        }

        private void WordsManagement_Load(object sender, EventArgs e)
        {
          
              var listWords = objMyBase.ShowWords();
                foreach (var reader in listWords)
                {
                    dataGridView1.Rows.Add( reader.Id, reader.Eng, reader.Ru1, reader.Category);
                   
                }
          
               
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.RowCount==0)
            {
                return;                
            }

            NewWord newWord = new NewWord();
            newWord.Text = "Edit";
            
            var item = dataGridView1.CurrentRow;
           
            newWord.Id = Convert.ToInt64(item.Cells[0].Value);
            newWord.Eng = item.Cells[1].Value.ToString();
             
            newWord.Ru1 = item.Cells[2].Value.ToString();
            //newWord.Ru2 = item.Cells[2].Value.ToString(); //поле Ru2
            newWord.CategoryName = item.Cells[3].Value.ToString();
        

            if (newWord.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            item.Cells[1].Value = newWord.Eng;
            item.Cells[2].Value = newWord.Ru1;
            item.Cells[3].Value = newWord.CategoryName;

            int ind = dataGridView1.SelectedCells[0].RowIndex;
            
            if (newWord.Result == true)
            {
                dataGridView1.Rows.RemoveAt(ind);
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
          


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SelectCategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SelectCategoryBox_Click(object sender, EventArgs e)
        {
            SelectCategoryBox.Items.Clear();
            var listCategories = objMyBase.ShowCategory();
            foreach (var reader in listCategories)
            {
                SelectCategoryBox.Items.Add(reader.Categ);

            }
        }
        
    }
}
