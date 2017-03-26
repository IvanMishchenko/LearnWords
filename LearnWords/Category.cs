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
    public partial class Category : Form
    {
       MyBase objMyBase=new MyBase();
        
        public  Category()
        {
            InitializeComponent();
           
        }

        public string CategoryName 
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int TotalAmount
        {
            get; set;
        }

        public long Id
        {
            get; set;
        }
        public bool Result
        {
            get;  set;
        }
        private CategoriesManagement objCategoriesManagement = new CategoriesManagement();
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //нужна проверка ввода

           
            if (this.Text == "Edit category")
            {
                objMyBase.UpDate("TCategory", CategoryName, TotalAmount, Id);
            }
            else
            {
                if (MessageBox.Show("Add category ?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                    DialogResult.Yes)
                {
                    objMyBase.Insert(textBox1.Text, 0);

                }
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            if (this.Text == "Edit category")
            {
                DeleteButton.Visible = true;
                add.Text = "Submit";
                
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want delete category, and all words this category ?", "Delete category", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                Result= objMyBase.Delete("TCategory", Id);
                this.Close();
            }
        }
    }
}
