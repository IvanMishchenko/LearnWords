using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWords
{
    public partial class CategoriesManagement : Form
    {
       
        MyBase objMyBase = new MyBase();

        public CategoriesManagement()
        {
            InitializeComponent();
        }
      
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Category form = new Category();
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
            dataGridView1.Rows.Add(form.Id + cell, form.CategoryName, 0);
        }

        private void CategoriesManagement_Load(object sender, EventArgs e)
        {
            var table = objMyBase.ShowCategory();
            foreach (var record in table)
            {
                dataGridView1.Rows.Add(record.Id, record.Categ, record.TotalAmount);
            }
           
        }
 

        private void EditButton_Click(object sender, EventArgs e)
        {
            Category form = new Category();
            form.Text = "Edit category";
            if (dataGridView1.RowCount == 0)
            {
                return;
            }

            var item = dataGridView1.CurrentRow;
            form.Id =Convert.ToInt64(item.Cells[0].Value);
            form.CategoryName = item.Cells[1].Value.ToString();
           // form.TotalAmount = Convert.ToInt32( item.Cells[1].Value);
            
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            item.Cells[0].Value = form.Id;
            item.Cells[1].Value = form.CategoryName;
           // item.Cells[2].Value = form.TotalAmount;

            int ind = dataGridView1.SelectedCells[0].RowIndex;

            if (form.Result == true)
            {
                dataGridView1.Rows.RemoveAt(ind);
            }
        }
    }
}
