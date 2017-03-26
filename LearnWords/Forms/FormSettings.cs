using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LearnWords.DataAccess;
using LearnWords.DataAccess.DataBaseManagement;
using LearnWords.Entities;
using LearnWords.Forms.dialogForms;
using LearnWords.Properties;

namespace LearnWords.Forms
{
    public partial class FormSettings : Form
    {
        

        struct SRow
        {
            public long CategoryName;
            public bool Choose;
        }

     
        readonly CategoryRepository _categoryRepository = new CategoryRepository();
        
        private SRow _objSRow;

        readonly List<SRow> _objListRow = new List<SRow>(); 
        
        readonly LogicTest _objLogicTest = new LogicTest();

        FormTest _form = new FormTest();

        private DateTime _timeForTest;

        private DateTime _nowTime;


        public FormSettings(int value)
        {
            InitializeComponent();

            DataDelegate.Changes += UpDataTable;

            _nowTime = DateTime.Now;

            _timeForTest = _nowTime.AddMinutes(value);

            numericUpDown1.Value =value;

           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
         
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(@"Apply settings ?", @"Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                DialogResult.Yes)
            {
                var value = Convert.ToInt16(numericUpDown1.Value);
                _nowTime = DateTime.Now;
                _timeForTest = _nowTime.AddMinutes(value);
                //set the new value of numericUpDown1
               Settings.Default.numericUpDown = value;
                //apply the changes to the settings file
               Settings.Default.Save();


               var table = _categoryRepository.GetCategory();

                foreach (var record in _objListRow)
                {
                    
                    var tableValue = table.Find(a => a.Id == record.CategoryName);
               
                    if (tableValue.Id==record.CategoryName)
                    {
                        _categoryRepository.UpDateCheckBox(tableValue.CategoryName,tableValue.Id, record.Choose);
                    }
                  
                }
                
                Hide();
            }
          

        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            var listTest = _objLogicTest.ChooseRandomWord();
           
            _nowTime = DateTime.Now;
           

            if (listTest.Count >= 5)
            {
                if (_timeForTest <= _nowTime)
                {
                    
                    if (!_form.Created)
                    {
                        _form = new FormTest();
                        _form.Show();
                    }
              
                    _nowTime = DateTime.Now;
                    _timeForTest = _nowTime.AddMinutes((Int16)numericUpDown1.Value);
                    
                }

            }
            if (!GetLastUserInput.GetIdleTickCount())
            {
              _form.Close();  
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            var table = _categoryRepository.GetCategory();

            foreach (var record in table)
            {
                dataGridView1.Rows.Add(record.Id, record.CategoryName, record.SelectCategory);
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
                _objSRow.CategoryName =Convert.ToInt64(item.Cells[0].Value);
                _objSRow.Choose = Convert.ToBoolean(item.Cells[2].Value);
                _objListRow.Add(_objSRow);
               
            }
        }

        private void UpDataTable(Category objCategory, TypeEvent typeEvent)
        {
            if (typeEvent == TypeEvent.Edit)
            {
                var list = _categoryRepository.GetCategory();
                if (dataGridView1.Rows.Count!=0)
                {
                    for (var i = 0; i < list.Count; i++)
                    {
                        if (objCategory.Id == list[i].Id)
                        {

                            dataGridView1.Rows[i].Cells[1].Value = list[i].CategoryName;

                        }

                    }
                }
            }

            if (typeEvent == TypeEvent.Add)
            {
               
                var count = dataGridView1.RowCount;
                long cell = 1;
                if (dataGridView1.Rows.Count != 0)
                {
                    if (count != 0)
                    {
                        cell = Convert.ToInt64(dataGridView1.Rows[count - 1].Cells[0].Value) + 1;

                    }
                    dataGridView1.Rows.Add(cell, objCategory.CategoryName, objCategory.SelectCategory);
                }


            }

            if (typeEvent == TypeEvent.Delete)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    for (var i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long value = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                        if (value == objCategory.Id)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                        }
                    }
                }
            }
           
        }

        
    }
}
