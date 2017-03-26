using System;
using System.Linq;
using System.Windows.Forms;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;

namespace LearnWords.Forms
{
    public partial class FormStatistics : Form
    {
        readonly StatisticsRepository _statisticsRepository = new StatisticsRepository();
        
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var firstDate = _statisticsRepository.GetStatistisc().First();
             
                dateTimePicker1.MinDate = new DateTime(firstDate.Date.Year, firstDate.Date.Month, firstDate.Date.Day);

                dateTimePicker2.MinDate = new DateTime(firstDate.Date.Year, firstDate.Date.Month, firstDate.Date.Day);

                dateTimePicker1.Value = dateTimePicker1.MinDate;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Sorry no statistics, because you did not pass the test ", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
           
        }
        
        

        private void ShowStatisticsButton_Click(object sender, EventArgs e)
        {
               

            var date1 = dateTimePicker1.Value.Date;
            var date2 = dateTimePicker2.Value.Date;
               
               
                     var dontKnow = _statisticsRepository.GetResult(date1, date2, TypeAnswers.DontKnow);
                     var trueAnswer = _statisticsRepository.GetResult(date1, date2, TypeAnswers.True);
                     var falseAnswer = _statisticsRepository.GetResult(date1, date2, TypeAnswers.False);
                     var close = _statisticsRepository.GetResult(date1, date2, TypeAnswers.Close);


                     chart1.Series["I dont know"].Points.AddY(dontKnow);

                     chart1.Series["True"].Points.AddY(trueAnswer);

                     chart1.Series["False"].Points.AddY(falseAnswer);

                     chart1.Series["Close"].Points.AddY(close);


        }

        private void StatisticsForm_MouseDown(object sender, MouseEventArgs e)
        {
            Opacity = .50;
        }

        private void StatisticsForm_MouseUp(object sender, MouseEventArgs e)
        {
            Opacity = 100;
        }
    }
}
