using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pabo.Calendar;

[Serializable]
public struct perioada
{
    public DateTime ora;
    public float interval; // stocat in secunde
}
[Serializable]
public struct date
{
    public int dateIndex;
    public DateTime data;
    public perioada[] Perioada;
    public float nrPer;
    public float SLTIME;
    public float SRTIME;
    public float SMTIME;
    public float SRED;
    public float alertCount;
    public float sumRed() { return SLTIME + SRTIME + SMTIME; }
    public float getCorrectTime() { return sumPer() - SRED; }
    public float getSittingCoef() { return 1 - (SRED / sumPer()); }
    public float getSLTIMECoef() { return 1 - (SLTIME / sumPer()); }
    public float getSRTIMECoef() { return 1 -  (SRTIME / sumPer()); }
    public float getSMTIMECoef() { return 1 - (SMTIME / sumPer()); }
    public float getAlertCoef() { return (alertCount * 3600 / sumPer()); }
    public float sumPer()
    {
        float sum = 0;
        for (int i = 0; i < nrPer; i++) sum += Perioada[i].interval;
        return sum;
    }
}

namespace SmartChair___THE_FINAL_FINAL
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
       //    anualGraphObstructPanel.Visible = false;
        }

        int selectedDate = 0;

        public void updateCalendar()
        {
            Array.Sort(GlobalVar.dates, 0, GlobalVar.dateIndex + 1, dateComparer);
            Array.Sort(GlobalVar.dates, 0, GlobalVar.dateIndex + 1, dateComparer);
            Console.WriteLine("lungimea indexului: " + GlobalVar.dateIndex);
            for (int q = 0; q <= GlobalVar.dateIndex; q++)
            {
                Console.WriteLine(GlobalVar.dates[q].Perioada);
            }

            for (int q = 0; q <= GlobalVar.dateIndex; q++)
            {
                Array.Sort<perioada>(GlobalVar.dates[q].Perioada, 0, (int)GlobalVar.dates[q].nrPer, hourComparer);
            }

            DateItem[] d = new DateItem[GlobalVar.dateIndex + 1];
            d.Initialize();
            BLComm._commStream.WriteByte(0x61); //echoByte
            for (int i = 0; i <= GlobalVar.dateIndex; i++)
            {
                d[i] = new DateItem();
                d[i].Date = GlobalVar.dates[i].data;
                d[i].BackColor1 = System.Drawing.Color.FromArgb(229, 77, 2);

            }
            monthCalendar1.AddDateInfo(d);
            selectedDate = GlobalVar.dateIndex;
            if (selectedDate != -1)
            {
                updateStatisticForm();
                waitingForDataPanel.Visible = false;
            }
            else
            {
                waitingForDataPanel.Visible = true;
                waitingForDataLabel.Text = "No data to show";
            }

            if (GlobalVar.dateIndex > 5)
            {
                anualGraphObstructPanel.Visible = false;
                updateAnualGraph();
            }
            else
                anualGraphObstructPanel.Visible = true;

        }
        public class DateBasedComparer : IComparer<date>
        {
            public int Compare(date x, date y)
            {
                if (x.data.Year > y.data.Year) return 1;
                else if (x.data.Year < y.data.Year) return -1;
                else
                {
                    if (x.data.Month > y.data.Month) return 1;
                    else if (x.data.Month < y.data.Month) return -1;
                    else
                    {
                        if (x.data.Day > y.data.Day) return 1;
                        else return -1;
                    }
                }
            }
        }
        IComparer<date> dateComparer = new DateBasedComparer();

        public class HourBasedComparer : IComparer<perioada>
        {
            public int Compare(perioada x, perioada y)
            {
                DateTime a = x.ora;
                DateTime b = y.ora;
                if (b.CompareTo(a) > 0) return -1;
                else if (b.CompareTo(a) < 0) return 1;
                else return 0;
            }
        }
        IComparer<perioada> hourComparer = new HourBasedComparer();

        private void updateAnualGraph()
        {
            //+++++++++++ GRAFICUL GENERAL +++++++++++++++
            anualStatsChart.Series[0].Points.Clear();
            anualStatsChart.Series[1].Points.Clear();
            anualStatsChart.Series[2].Points.Clear();
            anualStatsChart.Series[3].Points.Clear();
            DateTime curentDate = GlobalVar.dates[0].data;
            anualStatsChart.Series[0].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[0].getSittingCoef());
            anualStatsChart.Series[1].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[0].getSLTIMECoef());
            anualStatsChart.Series[2].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[0].getSMTIMECoef());
            anualStatsChart.Series[3].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[0].getSRTIMECoef());
            int i = 1;
            while (i <= GlobalVar.dateIndex)
            {
                try { curentDate = curentDate.AddDays(1); }
                catch
                {
                    DateTime nextMonth = new DateTime();
                    nextMonth.AddYears(curentDate.Year - 1);
                    nextMonth.AddMonths(curentDate.Month);
                    curentDate = nextMonth;
                }
                if (GlobalVar.dates[i].data == curentDate)
                {
                    anualStatsChart.Series[0].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[i].getSittingCoef());
                    anualStatsChart.Series[1].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[i].getSLTIMECoef());
                    anualStatsChart.Series[2].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[i].getSMTIMECoef());
                    anualStatsChart.Series[3].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[i].getSRTIMECoef());
                    i++;
                }
                else
                {
                    anualStatsChart.Series[0].Points.AddXY(curentDate.ToOADate(), anualStatsChart.Series[0].Points.Last<System.Windows.Forms.DataVisualization.Charting.DataPoint>().YValues[0]);
                    anualStatsChart.Series[1].Points.AddXY(curentDate.ToOADate(), anualStatsChart.Series[1].Points.Last<System.Windows.Forms.DataVisualization.Charting.DataPoint>().YValues[0]);
                    anualStatsChart.Series[2].Points.AddXY(curentDate.ToOADate(), anualStatsChart.Series[2].Points.Last<System.Windows.Forms.DataVisualization.Charting.DataPoint>().YValues[0]);
                    anualStatsChart.Series[3].Points.AddXY(curentDate.ToOADate(), anualStatsChart.Series[3].Points.Last<System.Windows.Forms.DataVisualization.Charting.DataPoint>().YValues[0]);
                }
            }


            // +++++++++++++++ GRAFICUL CU NUAMRUL DE ALERTE

            alertTimeChart.Series[0].Points.Clear();
            curentDate = GlobalVar.dates[0].data;
            alertTimeChart.Series[0].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[0].getAlertCoef());

            i = 1;
            while (i <= GlobalVar.dateIndex)
            {
                try { curentDate = curentDate.AddDays(1); }
                catch
                {
                    DateTime nextMonth = new DateTime();
                    nextMonth.AddYears(curentDate.Year - 1);
                    nextMonth.AddMonths(curentDate.Month);
                    curentDate = nextMonth;
                }
                if (GlobalVar.dates[i].data == curentDate)
                {
                    alertTimeChart.Series[0].Points.AddXY(curentDate.ToOADate(), GlobalVar.dates[i].getAlertCoef());
                    i++;
                }
                else
                {
                    alertTimeChart.Series[0].Points.AddXY(curentDate.ToOADate(), alertTimeChart.Series[0].Points.Last<System.Windows.Forms.DataVisualization.Charting.DataPoint>().YValues[0]);
                }
            }

        }

        public void updateStatisticForm()
        {
            chart1.Series.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            // ==== ADAUGAM TOATE PERIOADELE IN GRAFIC, LIPIND INTERVALELE MAI MICI DE 5 MIN =======
            int intervalIndex = 0;
            int nrSeries = 0;
            while (intervalIndex < GlobalVar.dates[selectedDate].nrPer)
            {
                int concat = 0;
                chart1.Series.Add("Series" + nrSeries);
                chart1.Series[nrSeries].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart1.Series[nrSeries].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.Series[nrSeries].Color = System.Drawing.Color.FromArgb(229, 77, 2);

                chart1.Series[nrSeries].Points.AddXY(GlobalVar.dates[selectedDate].Perioada[intervalIndex].ora.ToOADate(), 20);
                while (true)
                {
                    if (intervalIndex + concat + 1 < GlobalVar.dates[selectedDate].nrPer)
                    {
                        DateTime endFirst = GlobalVar.dates[selectedDate].Perioada[intervalIndex + concat].ora.AddSeconds(GlobalVar.dates[selectedDate].Perioada[intervalIndex + concat].interval);
                        DateTime startSecond = GlobalVar.dates[selectedDate].Perioada[intervalIndex + concat + 1].ora;
                        if (startSecond.Hour == endFirst.Hour && startSecond.Minute - endFirst.Minute < 5) concat++;
                        else break;
                    }
                    else break;
                }
                DateTime endPeriod = GlobalVar.dates[selectedDate].Perioada[intervalIndex + concat].ora.AddSeconds(GlobalVar.dates[selectedDate].Perioada[intervalIndex + concat].interval);               
                chart1.Series[nrSeries].Points.AddXY(endPeriod.ToOADate(), 20);
                intervalIndex += concat + 1;
                nrSeries++;
            }
            // ========= ADAUGAM VALORILE IN PIE CHART =========

            chart2.Series[0].Points.AddXY(0, GlobalVar.dates[selectedDate].SLTIME);
            chart2.Series[0].Points[0].Label = GlobalVar.dates[selectedDate].SLTIME + " sec / " + (GlobalVar.dates[selectedDate].SLTIME * 100 / GlobalVar.dates[selectedDate].sumRed()).ToString("0.0") + "%"; 
            chart2.Series[0].Points[0].LegendText = "Omoplatul stâng";
            chart2.Series[0].Points[0].Color = System.Drawing.Color.GreenYellow;
            chart2.Series[0].Points.AddXY(0, GlobalVar.dates[selectedDate].SMTIME);
            chart2.Series[0].Points[1].Label = GlobalVar.dates[selectedDate].SMTIME + " sec / " + (GlobalVar.dates[selectedDate].SMTIME * 100 / GlobalVar.dates[selectedDate].sumRed()).ToString("0.0") + "%";
            chart2.Series[0].Points[1].LegendText = "Zona lombara";
            chart2.Series[0].Points[1].Color = System.Drawing.Color.FromArgb(65, 140, 240);
            chart2.Series[0].Points.AddXY(0, GlobalVar.dates[selectedDate].SRTIME);
            chart2.Series[0].Points[2].Label = GlobalVar.dates[selectedDate].SRTIME + " sec / " + (GlobalVar.dates[selectedDate].SRTIME * 100 / GlobalVar.dates[selectedDate].sumRed()).ToString("0.0") + "%"; 
            chart2.Series[0].Points[2].LegendText = "Omoplatul drept";
            chart2.Series[0].Points[2].Color = System.Drawing.Color.FromArgb(252, 180, 65);

            float sumaTot = GlobalVar.dates[selectedDate].getCorrectTime();
            float sumaRed = GlobalVar.dates[selectedDate].SRED; ;

            chart3.Series[0].Points.AddXY(0, sumaTot);
            int[] splitSumaTot = splitToComponentTimes(sumaTot); // { ore, min, sec }
            chart3.Series[0].Points[0].Label = splitSumaTot[0] + "h " + splitSumaTot[1] + "min " + splitSumaTot[2] + " sec";
            chart3.Series[0].Points[0].LegendText = "Corect";
            chart3.Series[0].Points.AddXY(0, sumaRed);
            int[] splitSumaRed = splitToComponentTimes(sumaRed);
            chart3.Series[0].Points[1].Label = splitSumaRed[0] + "h " + splitSumaRed[1] + "min " + splitSumaRed[2] + " sec";
            chart3.Series[0].Points[1].LegendText = "Gresit";
            chart3.Series[0].Points[1].Color = System.Drawing.Color.Red;

            // ====== NUMARUL DE ALERTE ========
            statisticFormAlertCount.Text = GlobalVar.dates[selectedDate].alertCount.ToString();
            waitingForDataPanel.Visible = false;

        }

        private void monthCalendar1_DayClick(object sender, DayClickEventArgs e)
        {
            DateTime date = DateTime.Parse(e.Date);
            int i;
            for (i = 0; i <= GlobalVar.dateIndex; i++)
            {
                if (GlobalVar.dates[i].data == date) // Daca data este prezenta in database
                {
                    selectedDate = i;
                    updateStatisticForm();
                    i = GlobalVar.dateIndex + 5; // iesim for loop
                }
            }
            if (i != GlobalVar.dateIndex + 6) // Daca data nu a fost gasita, facem request la arduino
            {
                byte[] toSend = Encoding.ASCII.GetBytes("*a" + date.Year.ToString().Substring(date.Year.ToString().Length - 2) + "b" + date.Month.ToString() + "c" + date.Day.ToString() + "d");
                BLComm._commStream.Write(toSend, 0, toSend.Length);
            }
            monthCalendar1.Visible = false;
        }


        public static int[] splitToComponentTimes(float biggy) // imparte milisecunde in ora, min, sec
        {
            long longVal = (long)biggy;
            int hours = (int)longVal / 3600;
            int remainder = (int)longVal - hours * 3600;
            int mins = remainder / 60;
            remainder = remainder - mins * 60;
            int secs = remainder;

            int[] ints = { hours, mins, secs };
            return ints;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false, System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    foreach (var Serie in chart1.Series)
                    {
                        if (xVal > Serie.Points[0].XValue && xVal < Serie.Points[1].XValue && yVal < Serie.Points[0].YValues[0])
                        {
                            DateTime startPer = DateTime.FromOADate(Serie.Points[0].XValue);
                            DateTime endPer = DateTime.FromOADate(Serie.Points[1].XValue);
                            intervalLabel.Text = startPer.Hour + ":" + startPer.Minute + "--" + endPer.Hour + ":" + endPer.Minute;

                            break;
                        }
                        else
                        {
                            intervalLabel.Text = "";
                        }
                    }
                    break;
                }
            }
        }

        private void StatisticsFormCloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void changeDateButton_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void requestAllDataButton_Click(object sender, EventArgs e)
        {
            BLComm._commStream.WriteByte(0x63); // request data byte
            waitingForDataLabel.Text = "Se așteaptă datele...";
            waitingForDataPanel.Visible = true;
            pictureBox1.ImageLocation = Application.StartupPath.Replace(@"\", @"\\") + "\\images\\loadingIcon.gif";
        }
    }
}
