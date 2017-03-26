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
    public partial class Settings : Form
    {
        class CurrentTime
        {
          
            private int Hour { get; set; }
            private int Minutes { get; set; }
           
            internal CurrentTime(int withNumeric)
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                now = now.AddMinutes(withNumeric);             
                Hour = now.Hour;
                Minutes = now.Minute;
            }

            internal bool Equals(int nowHour,int nowMinutes)
            {
                
               var result= (nowHour == Hour && nowMinutes >= Minutes) ? true : false;
               return result; 
            }

        }

        struct SRow
        {
            public string categoryName;
            public string choose;
        }

        private CurrentTime objCurrentTime;
  
        MyBase objMyBase = new MyBase();
        LogicTest objLogicTest = new LogicTest();
        SRow objSRow = new SRow();
        List<SRow> objListRow = new List<SRow>(); 


        public Settings(int value)
        {
            InitializeComponent();
            objCurrentTime = new CurrentTime(value);
            numericUpDown1.Value =value;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
         
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Apply settings ?", "Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                DialogResult.Yes)
            {
                var value = Convert.ToInt16(numericUpDown1.Value);
                objCurrentTime = new CurrentTime(value);
                //set the new value of numericUpDown1
               LearnWords.Properties.Settings.Default.numericUpDown = value;
                //apply the changes to the settings file
               LearnWords.Properties.Settings.Default.Save();
                
             
                var table = objMyBase.ShowCategory();

                foreach (var record in objListRow)
                {
                    var tableValue = table.Find(a => a.Categ == record.categoryName);
                    if (tableValue.Categ==record.categoryName)
                    {
                        objMyBase.UpDate("TCategory", tableValue.Categ, Convert.ToInt64(tableValue.TotalAmount), tableValue.Id, record.choose);
                    }
                   
                }



               
            }
          

        }
        FormTest form = new FormTest();
        private void timer1_Tick(object sender, EventArgs e)
        {
        
            var valueResult = objLogicTest.CheckAmount();
         

            if (valueResult==true)
            {
                var result = objCurrentTime.Equals(DateTime.Now.Hour, DateTime.Now.Minute);

                if (result)
                {
                   
                    if (!form.Created)
                    {
                        form = new FormTest(); 
                        form.Show();
                    }
                    var value = Convert.ToInt16(numericUpDown1.Value);
                    objCurrentTime = new CurrentTime(value);

                }

            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            var table = objMyBase.ShowCategory();
            foreach (var record in table)
            {
                dataGridView1.Rows.Add( record.Categ, record.СheckBoxValue);
            }

            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView1.CurrentRow;
            if (item != null)
            {
                objSRow.categoryName = item.Cells[0].Value.ToString();
                objSRow.choose = item.Cells[1].Value.ToString();
                objListRow.Add(objSRow);
               
            }
        }
    }
}
