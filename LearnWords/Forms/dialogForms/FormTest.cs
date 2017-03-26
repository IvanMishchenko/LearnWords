using System;
using System.Linq;
using System.Windows.Forms;
using LearnWords.DataAccess;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;
using LearnWords.Properties;

namespace LearnWords.Forms.dialogForms
{
    public partial class FormTest : Form
    {
        readonly StatisticsRepository _statisticsRepository = new StatisticsRepository();

        readonly LogicTest _objLogicTest = new LogicTest();

        private readonly Random _rnd = new Random();

        private string AnswerWithRd { get; set; }

        private string Answer { get; set; }

        private long WordId { get; set; }

        private int Counter { get; set; }


        public FormTest()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _statisticsRepository.InsertSatatistics(WordId, TypeAnswers.Close);
            Opacity = .80;
            Close();
           
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
          
            var result = (AnswerWithRd == Answer) ? true : false;
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            if (result)
            {
                _statisticsRepository.InsertSatatistics(WordId, TypeAnswers.True);
                pictureBox1.Image = Resources.yes;
                Counter = 0;
                SubmitButton.Enabled = false;
                NKnowButton.Enabled = false;
                CloseButton.Enabled = false;
            }
            else
            {
                pictureBox1.Image = Resources.TryAgain;
                Counter = Counter + 1;
            }
            
            if (Counter == 3)
            {
                pictureBox1.Image = Resources.no;
                _statisticsRepository.InsertSatatistics(WordId, TypeAnswers.False);
                SubmitButton.Enabled = false;
                NKnowButton.Enabled = false;
                CloseButton.Enabled = false;
            }
        
        }

        private void DNKnowButton_Click(object sender, EventArgs e)
        {
            LoadWords();
            _statisticsRepository.InsertSatatistics(WordId, TypeAnswers.DontKnow);
            
        }

        private void CaseRb(int i, string value)
        {
            switch (i)
            {
                case 0:
                    RB1.Text = value;
                    break;
                case 1:
                    RB2.Text = value;
                    break;
                case 2:
                    RB.Text = value;
                    break;
                case 3:
                    RB4.Text = value;
                    break;
                case 4:
                    RB5.Text = value;
                    break;
            }
        }

        private void LoadWords()
        {
            var listTest = _objLogicTest.ChooseRandomWord();
           

            int truePosition = _rnd.Next(0, 5);//1,4
            if (listTest.Count >= 5)
            {
                foreach (var record in listTest)
                {
                    if (record.MainWord)
                    {
                        CategoryNameLabel.Text = record.Cateory;
                        WordLabel.Text = record.Eng;
                        Answer = record.Ru;
                        WordId = record.WordId;
                    }
                }

                CaseRb(truePosition, Answer);
                listTest.Remove(listTest.Find(w => w.MainWord ));


                // MessageBox.Show("true "+truePosition);

                for (int i = 0; i < truePosition; i++)
                {
                    CaseRb(i, listTest[i].Ru);
                }

                for (int i = truePosition + 1; i <= 4; i++)
                {
                    CaseRb(i, listTest[i - 1].Ru);
                }
            }
            else
            {
          
                if (MessageBox.Show(@"You must add minimum 5 words", @"Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    SubmitButton.Enabled = false;
                    NKnowButton.Enabled = false;
                    CloseButton.Enabled = false;
                    timer1.Enabled = true;
                }
           

            }
        } 

        private void FormTest_Load(object sender, EventArgs e)
        {
                LoadWords();
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            timer1.Enabled = false;
            if (Counter == 0||Counter==3)
            {
                Close();
            }

           
        }

        private void RbCheckedChanged(object sender, EventArgs e)
        {
         
           foreach (Control control in Controls)
            {
                var rb = control as RadioButton;
                if (rb != null && rb.Checked)
                {
                    AnswerWithRd = rb.Text;
                }
               
            }

        }

        private void FormTest_MouseDown(object sender, MouseEventArgs e)
        {
            Opacity = .50;
        }

        private void FormTest_MouseUp(object sender, MouseEventArgs e)
        {
            Opacity = 100;
        }

        
       
    }
}
