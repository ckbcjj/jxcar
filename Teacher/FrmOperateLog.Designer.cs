using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Teacher
{
    partial class FrmOperateLog
    {
        private DataAccess da = new DataAccess();

        private IContainer components;

        private PanelControl panelControl1;

        private LabelControl labelControl1;

        private PanelControl panelControl2;

        private SimpleButton simpleButton2;

        private TextEdit textEdit1;

        private LabelControl labelControl3;

        private LabelControl labelControl2;

        private GridControl gridControl1;

        private GridView gridView1;

        private GridColumn gridColumn1;

        private GridColumn gridColumn2;

        private GridColumn gridColumn3;

        private GridColumn gridColumn4;

        private DateEdit dateEdit2;

        private DateEdit dateEdit1;

        private SimpleButton simpleButton1;

        private SimpleButton simpleButton3;

        private SimpleButton simpleButton4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmOperateLog));
            this.panelControl1 = new PanelControl();
            this.simpleButton4 = new SimpleButton();
            this.simpleButton3 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.dateEdit2 = new DateEdit();
            this.dateEdit1 = new DateEdit();
            this.simpleButton2 = new SimpleButton();
            this.textEdit1 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panelControl2 = new PanelControl();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.dateEdit2.Properties.CalendarTimeProperties).BeginInit();
            ((ISupportInitialize)this.dateEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).BeginInit();
            ((ISupportInitialize)this.dateEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(899, 34);
            this.panelControl1.TabIndex = 0;
            this.simpleButton4.Image = (Image)resources.GetObject("simpleButton4.Image");
            this.simpleButton4.Location = new Point(634, 2);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(83, 32);
            this.simpleButton4.TabIndex = 12;
            this.simpleButton4.Text = "刷新";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.simpleButton3.Image = (Image)resources.GetObject("simpleButton3.Image");
            this.simpleButton3.Location = new Point(539, 2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(92, 32);
            this.simpleButton3.TabIndex = 11;
            this.simpleButton3.Text = "全部显示";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButton1.Image = (Image)resources.GetObject("simpleButton1.Image");
            this.simpleButton1.Location = new Point(719, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(93, 31);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "清空日志";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.dateEdit2.EditValue = new DateTime(2014, 12, 16, 0, 0, 0, 0);
            this.dateEdit2.Location = new Point(199, 7);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.dateEdit2.Properties.DisplayFormat.FormatString = "G";
            this.dateEdit2.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            this.dateEdit2.Properties.EditFormat.FormatString = "G";
            this.dateEdit2.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dateEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.dateEdit2.Size = new Size(134, 20);
            this.dateEdit2.TabIndex = 9;
            this.dateEdit1.EditValue = new DateTime(2014, 12, 23, 0, 0, 0, 0);
            this.dateEdit1.Location = new Point(38, 7);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "G";
            this.dateEdit1.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "G";
            this.dateEdit1.Properties.EditFormat.FormatType = FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "G";
            this.dateEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.dateEdit1.Size = new Size(137, 20);
            this.dateEdit1.TabIndex = 8;
            this.simpleButton2.Image = (Image)resources.GetObject("simpleButton2.Image");
            this.simpleButton2.Location = new Point(467, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(70, 32);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "查找";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.textEdit1.Location = new Point(384, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(80, 20);
            this.textEdit1.TabIndex = 5;
            this.labelControl3.Location = new Point(340, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "用户名：";
            this.labelControl2.Location = new Point(181, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(12, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "到";
            this.labelControl1.Location = new Point(4, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "时间：";
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 34);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(899, 505);
            this.panelControl2.TabIndex = 1;
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(895, 501);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView1
			});
            this.gridView1.Columns.AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4
			});
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "RecordId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 52;
            this.gridColumn2.Caption = "操作用户";
            this.gridColumn2.FieldName = "OperaterName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 77;
            this.gridColumn3.Caption = "操作内容";
            this.gridColumn3.FieldName = "Message";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 289;
            this.gridColumn4.Caption = "操作时间";
            this.gridColumn4.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.gridColumn4.DisplayFormat.FormatType = FormatType.DateTime;
            this.gridColumn4.FieldName = "Time";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 103;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(899, 539);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
            base.Name = "FrmOperateLog";
            this.Text = "重要操作日志";
            base.Load += new EventHandler(this.FrmOperateLog_Load);
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((ISupportInitialize)this.dateEdit2.Properties.CalendarTimeProperties).EndInit();
            ((ISupportInitialize)this.dateEdit2.Properties).EndInit();
            ((ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).EndInit();
            ((ISupportInitialize)this.dateEdit1.Properties).EndInit();
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
