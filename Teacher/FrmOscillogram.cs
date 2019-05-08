using BLL.Core;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Commands;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Teacher
{

    public partial class FrmOscillogram : XtraForm
    {
         public FrmOscillogram()
        {
            this.InitializeComponent();
        }

        private void AddPoints(Series series, SeriesPoint[] pointsToUpdate)
        {
            if (series.View is SwiftPlotSeriesViewBase)
            {
                series.Points.AddRange(pointsToUpdate);
            }
        }

        private void BindData()
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.Nodes.Add(new object[] { 1, "发动机冷却液温度", 1 });
            this.treeList1.Nodes.Add(new object[] { 2, "发动机转速", 2 });
        }

        private double CalculateNextValue(double value)
        {
            return (value + ((this.random.NextDouble() * 10.0) - 5.0));
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
            }
            else
            {
                this.diagram.AxisX.GridLines.Color = Color.White;
                this.diagram.AxisX.GridLines.Visible = false;
                this.diagram.AxisX.GridLines.MinorVisible = false;
                this.diagram.AxisY.GridLines.MinorVisible = false;
            }
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.diagram.AxisX.GridLines.Color = (sender as ColorEdit).Color;
            this.diagram.AxisX.GridLines.MinorColor = (sender as ColorEdit).Color;
            this.diagram.AxisY.GridLines.MinorColor = this.colorEdit1.Color;
            this.diagram.AxisY.GridLines.Color = this.colorEdit1.Color;
        }


        private void FrmOscillogram_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.checkEdit1.Checked = false;
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                MessageBox.Show("监测正在进行");
            }
            else if (this.selecttypeid == 0)
            {
                MessageBox.Show("请选择要监控的对象");
            }
            else
            {
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
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((this.Series1 != null) && (this.Series2 != null))
            {
                DateTime now = DateTime.Now;
                int num = 500;
                int num2 = 2;
                SeriesPoint[] pointsToUpdate = new SeriesPoint[num2];
                SeriesPoint[] pointArray2 = new SeriesPoint[num2];
                for (int i = 0; i < num2; i++)
                {
                    pointsToUpdate[i] = new SeriesPoint(now, new double[] { this.value1 });
                    pointArray2[i] = new SeriesPoint(now, new double[] { this.value2 });
                    now = now.AddMilliseconds((double) num);
                    this.UpdateValues();
                }
                DateTime minValue = now.AddSeconds((double) -this.TimeInterval);
                int count = 0;
                foreach (SeriesPoint point in this.Series1.Points)
                {
                    if (point.DateTimeArgument < minValue)
                    {
                        count++;
                    }
                }
                if (count < this.Series1.Points.Count)
                {
                    count--;
                }
                this.AddPoints(this.Series1, pointsToUpdate);
                this.AddPoints(this.Series2, pointArray2);
                if (count > 0)
                {
                    this.Series1.Points.RemoveRange(0, count);
                    this.Series2.Points.RemoveRange(0, count);
                }
                if ((this.diagram != null) && ((this.diagram.AxisX.DateTimeScaleOptions.MeasureUnit == DateTimeMeasureUnit.Second) || (this.diagram.AxisX.DateTimeScaleOptions.ScaleMode == ScaleMode.Continuous)))
                {
                    this.diagram.AxisX.WholeRange.SetMinMaxValues(minValue, now);
                }
            }
        }

        private void treeList1_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if (!this.timer1.Enabled)
            {
                this.currenttypeid = (int) e.Node.GetValue("TypeId");
            }
            this.selecttypeid = (int) e.Node.GetValue("TypeId");
        }

        private void UpdateValues()
        {
            RTData newdata = null;
            lock (CacheInvoke.newdata)
            {
                newdata = CacheInvoke.newdata;
            }
            if (newdata == null)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                string fDJLQYWD = string.Empty;
                switch (this.currenttypeid)
                {
                    case 1:
                        this.value2 = 70.0;
                        if (newdata == null)
                        {
                            this.value1 = 0.0;
                            return;
                        }
                        fDJLQYWD = newdata.FDJLQYWD;
                        if (string.IsNullOrEmpty(fDJLQYWD))
                        {
                            break;
                        }
                        this.value1 = Convert.ToDouble(fDJLQYWD.Remove(fDJLQYWD.IndexOf('℃')));
                        return;

                    case 2:
                        this.value2 = 800.0;
                        if (newdata == null)
                        {
                            this.value1 = 0.0;
                            break;
                        }
                        fDJLQYWD = newdata.FDJZS;
                        if (string.IsNullOrEmpty(fDJLQYWD))
                        {
                            break;
                        }
                        this.value1 = Convert.ToDouble(fDJLQYWD.Remove(fDJLQYWD.IndexOf('r')));
                        return;

                    default:
                        return;
                }
            }
        }

        private SwiftPlotDiagram diagram
        {
            get
            {
                return (this.chartControl1.Diagram as SwiftPlotDiagram);
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

        private int TimeInterval
        {
            get
            {
                return (20 - Convert.ToInt32(this.spinEdit3.EditValue));
            }
        }
    }
}

