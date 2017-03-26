using System;
using System.ComponentModel;
using System.Windows.Forms;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;

namespace LearnWords.Forms.dialogForms
{
    public partial class FormNewCategory : Form
    {
        readonly CategoryRepository _categoryRepository = new CategoryRepository();

        private readonly TypeEvent _typeEvent;

        public FormNewCategory(TypeEvent typeEvent)
        {
            Result = false;
            InitializeComponent();
            _typeEvent = typeEvent;
        }

        public  FormNewCategory(TypeEvent typeEvent, Category categoryObj)
        {
            Result = false;
            InitializeComponent();
            _typeEvent = typeEvent;
            Category = categoryObj;

            CategoryTextBox.Text = Category.CategoryName;

        }

        public Category Category { get; private set; }

        public bool Result { get; private set; }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None; 
            }
            else
            {
                if (TypeEvent.Edit==_typeEvent)
                {
                    _categoryRepository.UpDateCategory(CategoryTextBox.Text, Category.Id);

                     Category.CategoryName = CategoryTextBox.Text;

                    if (DataDelegate.Changes != null)
                    {
                        DataDelegate.Changes(Category, TypeEvent.Edit);
                    }

                }
                else
                {

                    _categoryRepository.InsertCategory(CategoryTextBox.Text);

                    Category = new Category(0,CategoryTextBox.Text,false);

                    if (DataDelegate.Changes != null)
                    {
                        DataDelegate.Changes(Category, TypeEvent.Add);
                    }
                }
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            if (TypeEvent.Edit == _typeEvent)
            {
                Text = TypeEvent.Edit.ToString();
                DeleteButton.Visible = true;
                add.Text = @"Submit";
                
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Are you sure, you want delete category ?", @"Delete category", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                if (DataDelegate.Changes != null)
                {
                    DataDelegate.Changes(Category, TypeEvent.Delete);
                    _categoryRepository.DeleteCategory(Category.Id);
                }
             
               
                Close();
                Result = true;
            }
        }

        private void CategoryTextBox_Validating(object sender, CancelEventArgs e)
        {
           
                if (String.IsNullOrWhiteSpace(CategoryTextBox.Text))
                {    
                    errorProvider1.SetError(CategoryTextBox, "You must to еnter name of category");  
                    e.Cancel = true;                           
                }
         
        }

        private void CategoryTextBox_Validated(object sender, EventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                errorProvider1.SetError(CategoryTextBox, null);    
            }
        }
    }
}
