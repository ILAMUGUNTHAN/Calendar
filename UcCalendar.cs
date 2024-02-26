using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcCalendar
{
    public partial class UcCalendar : UserControl
    {
        public UcCalendar()
        {
            InitializeComponent();
        }

        private string selectedMonth;
        private int month;
        private int year;
        private int startCol = 0;
        //private int row = 1;

        private void OnLoad(object sender, EventArgs e)
        {
            OnClickShow(null, null);
        }

        private void OnClickYearTextBox(object sender, EventArgs e)
        {
            YearTextBox.Text = "";
        }

        private void OnClickShow(object sender, EventArgs e)
        {
            if(MonthComboBox.Text!="" && YearTextBox.Text!="")
            {
   

                selectedMonth = MonthComboBox.Text;
                year = Convert.ToInt32(YearTextBox.Text);

                string[] str = selectedMonth.Split('.');

                month = Convert.ToInt32(str[0]);
                
                
            }
            else
            {
                return;
            }



            DateTime dateStruct = new DateTime(year,month,1);

            DayOfWeek currentDay = dateStruct.DayOfWeek;

            SetStartCol(currentDay);

            Button dateBtn;
            DateTime tod = DateTime.Today;

            int dateNow = tod.Day;
            int startDate = 1;

            RemoveControls();
            for(int i=1;i<7;i++)
            {
                for(int j=startCol;j<7;j++)
                {
                    dateBtn = new Button();
                    dateBtn.FlatStyle = FlatStyle.Popup;
                    dateBtn.Dock = DockStyle.Fill;
                    dateBtn.Text = startDate + "";
                    startDate++;
                    tableLayoutPanel1.Controls.Add(dateBtn,j,i);
                    if (month == 2 && year == 2024 && startDate == dateNow+1)
                    {
                        dateBtn.FlatStyle = FlatStyle.System;
                    }
                    try
                    {
                        DateTime temp = new DateTime(year, month, startDate);
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    

                }
                startCol = 0;
                try
                {
                    DateTime temp = new DateTime(year, month, startDate);
                }
                catch (Exception)
                {
                    break;
                }

            }

            
        }


        private void RemoveControls()
        {
            for(int i=1;i<7;i++)
            {
                for(int j=0;j<7;j++)
                {
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(j,i));
                }
            }
        }

        private void SetStartCol(DayOfWeek cur)
        {
            switch(cur)
            {
                
                case DayOfWeek.Monday:
                    startCol = 0;
                    break;
                case DayOfWeek.Tuesday:
                    startCol = 1;
                    break;
                case DayOfWeek.Wednesday:
                    startCol = 2;
                    break;
                case DayOfWeek.Thursday:
                    startCol = 3;
                    break;
                case DayOfWeek.Friday:
                    startCol = 4;
                    break;
                case DayOfWeek.Saturday:
                    startCol = 5;
                    break;
                case DayOfWeek.Sunday:
                    startCol = 6;
                    break;

            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            OnClickShow(null, null);
        }
    }
}
