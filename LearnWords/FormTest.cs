using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWords
{
    public partial class FormTest : Form
    {
        LogicTest objLogicTest = new LogicTest();
        private Random rnd = new Random();
        private string unswerWithRD = null;
        private string unswer = null;
        private int counter = 0;

        public FormTest()
        {
            
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
         Close();
           
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
          
            var result = (unswerWithRD == unswer) ? true : false;
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            if (result)
            {
                pictureBox1.Image = Properties.Resources.yes;
                counter = 0;
            }
            else
            {
                pictureBox1.Image = Properties.Resources._120218TryAgain;
                counter = counter + 1;
            }
            
            if (counter == 3)
            {
                pictureBox1.Image = Properties.Resources.no;
            }
        }

        private void NKnowButton_Click(object sender, EventArgs e)
        {
            LoadWords();
        }

        protected void CaseRB(int i, string value)
        {
            switch (i)
            {
                case 0:
                    radioButton1.Text = value;
                    break;
                case 1:
                    radioButton2.Text = value;
                    break;
                case 2:
                    radioButton3.Text = value;
                    break;
                case 3:
                    radioButton4.Text = value;
                    break;
                case 4:
                    radioButton5.Text = value;
                    break;
            }
        }

        private void LoadWords()
        {
            var listTest = objLogicTest.ChooseRandomWord();


            int truePosition = rnd.Next(1, 4);

            foreach (var record in listTest)
            {
                if (record.mainWord == true)
                {
                    CategoryNameLabel.Text = record.cateory;
                    WordLabel.Text = record.eng;
                    unswer = record.ru1;
                }
            }

            CaseRB(truePosition, unswer);
            listTest.Remove(listTest.Find(w => w.mainWord == true));


            // MessageBox.Show("true "+truePosition);

            for (int i = 0; i < truePosition; i++)
            {
                CaseRB(i, listTest[i].ru1);
            }

            for (int i = truePosition + 1; i <= 4; i++)
            {
                CaseRB(i, listTest[i - 1].ru1);
            }
        } 

        private void FormTest_Load(object sender, EventArgs e)
        {
            LoadWords();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            unswerWithRD = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            unswerWithRD = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            unswerWithRD = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            unswerWithRD = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            unswerWithRD = radioButton5.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            timer1.Enabled = false;
            if (counter == 0||counter==3)
            {
                Close(); 
            }
            

        }

       
    }
}
