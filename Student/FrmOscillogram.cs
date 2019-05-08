using BLL.Core;
using BLL.Service;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmOscillogram : XtraForm
    {
        private int selecttypeid = 1;

        private int currenttypeid;

        private Random random = new Random();

        private double value1;

        private double value2;


        private SwiftPlotDiagram diagram
        {
            get
            {
                return this.chartControl1.Diagram as SwiftPlotDiagram;
            }
        }

        private int TimeInterval
        {
            get
            {
                return 20 - Convert.ToInt32(this.spinEdit3.EditValue);
            }
        }

        private Series Series1
        {
            get
            {
                if (this.chartControl1.Series.Count <= 0)
                {
                    return null;
                }
                return this.chartControl1.Series[0];
            }
        }

        private Series Series2
        {
            get
            {
                if (this.chartControl1.Series.Count <= 1)
                {
                    return null;
                }
                return this.chartControl1.Series[1];
            }
        }

        public FrmOscillogram()
        {
            this.InitializeComponent();
        }

        private void FrmOscillogram_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.checkEdit1.Checked = false;
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
        }

        private void BindData()
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.Nodes.Add(new object[]
			{
				1,
				"发动机冷却液温度",
				1
			});
            this.treeList1.Nodes.Add(new object[]
			{
				2,
				"发动机转速",
				2
			});
        }

        private double CalculateNextValue(double value)
        {
            return value + (this.random.NextDouble() * 10.0 - 5.0);
        }

        private void UpdateValues()
        {
            RTData rTData = null;
            lock (ClientListenManager.NewData)
            {
                rTData = ClientListenManager.NewData;
            }
            if (rTData != null)
            {
                string text = string.Empty;
                switch (this.currenttypeid)
                {
                    case 1:
                        this.value2 = 70.0;
                        if (rTData == null)
                        {
                            this.value1 = 0.0;
                            return;
                        }
                        text = rTData.FDJLQYWD;
                        if (!string.IsNullOrEmpty(text))
                        {
                            this.value1 = Convert.ToDouble(text.Remove(text.IndexOf('℃')));
                            return;
                        }
                        break;
                    case 2:
                        this.value2 = 600.0;
                        if (rTData != null)
                        {
                            text = rTData.FDJZS;
                            if (!string.IsNullOrEmpty(text))
                            {
                                this.value1 = Convert.ToDouble(text.Remove(text.IndexOf('r')));
                                return;
                            }
                        }
                        else
                        {
                            this.value1 = 0.0;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private void AddPoints(Series series, SeriesPoint[] pointsToUpdate)
        {
            if (series.View is SwiftPlotSeriesViewBase)
            {
                series.Points.AddRange(pointsToUpdate);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                MessageBox.Show("监测正在进行");
                return;
            }
            if (this.selecttypeid == 0)
            {
                MessageBox.Show("请选择要监控的对象");
                return;
            }
            this.currenttypeid = this.selecttypeid;
            switch (this.currenttypeid)
            {
                case 1:
                    this.Series1.Name = "实时温度";
                    this.Series2.Name = "标准温度";
                    break;
                case 2:
                    this.Series1.Name = "实时转速";
                    this.Series2.Name = "标准转速";
                    break;
            }
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Series1 == null || this.Series2 == null)
            {
                return;
            }
            DateTime dateTime = DateTime.Now;
            int num = 500;
            int num2 = 2;
            SeriesPoint[] array = new SeriesPoint[num2];
            SeriesPoint[] array2 = new SeriesPoint[num2];
            for (int i = 0; i < num2; i++)
            {
                array[i] = new SeriesPoint(dateTime, new double[]
				{
					this.value1
				});
                array2[i] = new SeriesPoint(dateTime, new double[]
				{
					this.value2
				});
                dateTime = dateTime.AddMilliseconds((double)num);
                this.UpdateValues();
            }
            DateTime dateTime2 = dateTime.AddSeconds((double)(-(double)this.TimeInterval));
            int num3 = 0;
            foreach (SeriesPoint seriesPoint in this.Series1.Points)
            {
                if (seriesPoint.DateTimeArgument < dateTime2)
                {
                    num3++;
                }
            }
            if (num3 < this.Series1.Points.Count)
            {
                num3--;
            }
            this.AddPoints(this.Series1, array);
            this.AddPoints(this.Series2, array2);
            if (num3 > 0)
            {
                this.Series1.Points.RemoveRange(0, num3);
                this.Series2.Points.RemoveRange(0, num3);
            }
            if (this.diagram != null && (this.diagram.AxisX.DateTimeScaleOptions.MeasureUnit == DateTimeMeasureUnit.Millisecond || this.diagram.AxisX.DateTimeScaleOptions.ScaleMode == ScaleMode.Continuous))
            {
                this.diagram.AxisX.WholeRange.SetMinMaxValues(dateTime2, dateTime);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
            {
                this.diagram.AxisX.GridLines.Color = this.colorEdit1.Color;
                this.diagram.AxisX.GridLines.MinorColor = this.colorEdit1.Color;
                this.diagram.AxisX.GridLines.Visible = true;
                this.diagram.AxisX.GridLines.MinorVisible = true;
                this.diagram.AxisY.GridLines.MinorColor = this.colorEdit1.Color;
                this.diagram.AxisY.GridLines.Color = this.colorEdit1.Color;
                this.diagram.AxisY.GridLines.MinorVisible = true;
                return;
            }
            this.diagram.AxisX.GridLines.Color = Color.White;
            this.diagram.AxisX.GridLines.Visible = false;
            this.diagram.AxisX.GridLines.MinorVisible = false;
            this.diagram.AxisY.GridLines.MinorVisible = false;
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.diagram.AxisX.GridLines.Color = (sender as ColorEdit).Color;
            this.diagram.AxisX.GridLines.MinorColor = (sender as ColorEdit).Color;
            this.diagram.AxisY.GridLines.MinorColor = this.colorEdit1.Color;
            this.diagram.AxisY.GridLines.Color = this.colorEdit1.Color;
        }

        private void treeList1_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if (!this.timer1.Enabled)
            {
                this.currenttypeid = (int)e.Node.GetValue("TypeId");
            }
            this.selecttypeid = (int)e.Node.GetValue("TypeId");
        }
    }
}
