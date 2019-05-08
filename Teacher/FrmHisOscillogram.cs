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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Teacher
{


    public partial class FrmHisOscillogram : XtraForm
    {

        public FrmHisOscillogram()
        {
            this.InitializeComponent();
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

        private void FrmHisOscillogram_Load(object sender, EventArgs e)
        {
            this.checkEdit1.Checked = false;
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
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
    }
}

