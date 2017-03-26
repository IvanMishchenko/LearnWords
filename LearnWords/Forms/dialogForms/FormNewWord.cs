using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;

namespace LearnWords.Forms.dialogForms
{
    internal partial class FormNewWord : Form
    {
        readonly CategoryRepository _categoryRepository = new CategoryRepository();

        readonly WordRepository _wordRepository = new WordRepository();

        private readonly TypeEvent _typeEvent;

        public Word ObjWord { get; private set; }

        public bool Result { get; private set; }


        public FormNewWord(TypeEvent typeEvent)
        {
            Result = false;

            InitializeComponent();
            _typeEvent = typeEvent;
        } 

        public FormNewWord(TypeEvent typeEvent, Word word)
        {
            Result = false;
            InitializeComponent();
            ObjWord = word;
            _typeEvent = typeEvent;

            EngTextBox.Text = word.Eng;
            Ru1TextBox.Text = word.Ru;


            var list = _categoryRepository.GetCategory();
            var category = list.Find(c => c.Id == word.CategoryId);
            var categ = (ObjWord.CategoryId == 0) ? "none" : category.CategoryName;
             CategoryBox.Text = categ;
           
        }



        private void NewWord_Load(object sender, EventArgs e)
        {
            if (_typeEvent == TypeEvent.Edit)
            {
                Text = TypeEvent.Edit.ToString();
                AddButton2.Text = @"Submit";
                DeleteButton.Visible = true;
               
               
            }

        }

       

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            long idCategory = 0;
            var listCategories = _categoryRepository.GetCategory();

            foreach (var reader in listCategories)
            {
                if (CategoryBox.Text == reader.CategoryName)
                {
                    idCategory = reader.Id;
                }
               

            }

            foreach (Control control in Controls)
            {
                TextBox tB = control as TextBox;
                if (tB != null && String.IsNullOrWhiteSpace(tB.Text))
                {
                    errorProvider1.SetError(tB, "You must enter word in the field ");
                    DialogResult = DialogResult.None;
                    
                }
            }
         /* if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
            }*/

            if (DialogResult != DialogResult.None)
            {
                if (_typeEvent==TypeEvent.Edit)
                {
                    _wordRepository.UpDateWord(EngTextBox.Text, Ru1TextBox.Text, idCategory, ObjWord.Id);

                    ObjWord.Eng = EngTextBox.Text;
                    ObjWord.Ru = Ru1TextBox.Text;
              
                    ObjWord.CategoryId = idCategory;
                     
                }
                else
                {
                    if (CategoryBox.Text==null)
                    {
                        idCategory = 0;
                    }
                    _wordRepository.InsertWord(EngTextBox.Text, Ru1TextBox.Text, idCategory);
                    ObjWord = new Word(0, EngTextBox.Text, Ru1TextBox.Text,  idCategory);
                }
                
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CategoryBox_Click(object sender, EventArgs e)
        {
            CategoryBox.Items.Clear();
            CategoryBox.Items.Add("none");
            var listCategories = _categoryRepository.GetCategory();
            foreach (var reader in listCategories)
            {
                CategoryBox.Items.Add(reader.CategoryName);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(@"Are you sure, you want delete word ?", @"Delete word", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Result = true;
                _wordRepository.DeleteWord(ObjWord.Id);
                DialogResult = DialogResult.OK;
            Close();
           
            }
        }

      

        private void CategoryBox_Validated(object sender, EventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                errorProvider1.SetError(CategoryBox, null);
                
            }
        }

        private void CategoryBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CategoryBox.Text))
            {
                errorProvider1.SetError(CategoryBox, "You must to choose category with field");
                e.Cancel = true;
            }
        }

        private void Ru1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

       

       

       

        

     
 

      

        
    }
}
