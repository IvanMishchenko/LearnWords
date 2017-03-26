using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LearnWords
{
    internal partial class NewWord : Form
    {
   
        MyBase objMyBase = new MyBase();
        List<string> wordsList = new List<string>();
        
        //private int timeTick = 0;

        public string Eng
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Ru1
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string Ru2
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string CategoryName
        {
            get { return CategoryBox.Text; }
            set { CategoryBox.Text = value; }
        }

        public long Id
        {
            get; set; 
        }

        public bool Result
        {
            get;
            set;
        }


        public NewWord()
        {
            InitializeComponent();

        } 

        private void NewWord_Load(object sender, EventArgs e)
        {
            if (this.Text == "Edit")
            {
                AddButton2.Text = "Submit";
                DeleteButton.Visible = true;
               
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
           //а как лучше сделать проверку на коректнсть ввода ?

          //const string expr = "[,0-9-!?&@#$%^&*()\";:_=+`~'{|}\\/]";
          // Match isMatch = Regex.Match(record, expr, RegexOptions.IgnoreCase);
               
           
            //timer1.Enabled=true;

            if (this.Text == "Edit")
            {
              objMyBase.UpDate("TWords", textBox1.Text, textBox2.Text, "none" /*textBox3.Text*/, CategoryBox.Text,
                        Id);
                
            }
            else
            {
                objMyBase.Insert(textBox1.Text, textBox2.Text, "none" /*textBox3.Text*/, CategoryBox.Text);
            }


            //this.Text = "Word was added";
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* timeTick =timeTick +1;
            this.Text = this.Text == "Word was added" ? " " : "Word was added";
           
            if (timeTick == 5)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                timer1.Enabled = false;
                this.Text = "New word";
            }*/
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CategoryBox_Click(object sender, EventArgs e)
        {
            CategoryBox.Items.Clear();
            var listCategories = objMyBase.ShowCategory();
            foreach (var reader in listCategories)
            {
                CategoryBox.Items.Add(reader.Categ);

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure, you want delete word ?", "Delete word", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
              Result = objMyBase.Delete("TWords", Id);
            DialogResult = DialogResult.OK;
            this.Close();
             
            }
    }

        
    }
}
