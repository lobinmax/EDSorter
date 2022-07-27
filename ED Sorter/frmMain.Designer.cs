
namespace ED_Sorter
{
    sealed partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barMenuMain = new DevExpress.XtraBars.BarSubItem();
            this.barButtonISettings = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barEditItemServiceStatus = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barStaticItemServiceNotFound = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.toggleSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditLog = new DevExpress.XtraEditors.MemoEdit();
            this.timerLoadingLog = new System.Windows.Forms.Timer(this.components);
            this.timerServiceStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager2
            // 
            this.barManager2.AllowCustomization = false;
            this.barManager2.AllowHtmlText = true;
            this.barManager2.AllowMdiChildButtons = false;
            this.barManager2.AllowMoveBarOnToolbar = false;
            this.barManager2.AllowQuickCustomization = false;
            this.barManager2.AllowShowToolbarsPopup = false;
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barMenuMain,
            this.barButtonISettings,
            this.barButtonItem1,
            this.barEditItem1,
            this.barEditItemServiceStatus,
            this.barStaticItemServiceNotFound});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 7;
            this.barManager2.OptionsLayout.AllowAddNewItems = false;
            this.barManager2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemTextEdit1,
            this.repositoryItemMarqueeProgressBar1});
            this.barManager2.ShowFullMenusAfterDelay = false;
            this.barManager2.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.HideWhenMerging = DevExpress.Utils.DefaultBoolean.True;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMenuMain)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barMenuMain
            // 
            this.barMenuMain.Caption = "Главное меню";
            this.barMenuMain.Id = 0;
            this.barMenuMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonISettings)});
            this.barMenuMain.Name = "barMenuMain";
            // 
            // barButtonISettings
            // 
            this.barButtonISettings.Caption = "Параметры";
            this.barButtonISettings.Id = 1;
            this.barButtonISettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonISettings.ImageOptions.Image")));
            this.barButtonISettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonISettings.ImageOptions.LargeImage")));
            this.barButtonISettings.Name = "barButtonISettings";
            this.barButtonISettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonISettings_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemServiceStatus, "", false, true, true, 107),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemServiceNotFound)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barEditItemServiceStatus
            // 
            this.barEditItemServiceStatus.Caption = "barEditItem2";
            this.barEditItemServiceStatus.Edit = this.repositoryItemMarqueeProgressBar1;
            this.barEditItemServiceStatus.Id = 5;
            this.barEditItemServiceStatus.Name = "barEditItemServiceStatus";
            this.barEditItemServiceStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barEditItemServiceStatus.VisibleInSearchMenu = false;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // barStaticItemServiceNotFound
            // 
            this.barStaticItemServiceNotFound.Caption = "Не установлена служба \'ED Sorter Service\'";
            this.barStaticItemServiceNotFound.Id = 6;
            this.barStaticItemServiceNotFound.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItemServiceNotFound.ImageOptions.Image")));
            this.barStaticItemServiceNotFound.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItemServiceNotFound.ImageOptions.LargeImage")));
            this.barStaticItemServiceNotFound.Name = "barStaticItemServiceNotFound";
            this.barStaticItemServiceNotFound.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItemServiceNotFound.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(742, 49);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 309);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(742, 32);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 49);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 260);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(742, 49);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 260);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Свернуть в трей";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 4;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Location = new System.Drawing.Point(91, 64);
            this.toggleSwitch.MenuManager = this.barManager2;
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.Properties.AutoWidth = true;
            this.toggleSwitch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.toggleSwitch.Properties.FullFocusRect = true;
            this.toggleSwitch.Properties.OffText = "Off";
            this.toggleSwitch.Properties.OnText = "On";
            this.toggleSwitch.Size = new System.Drawing.Size(92, 26);
            this.toggleSwitch.TabIndex = 15;
            this.toggleSwitch.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.toggleSwitch_EditValueChanging);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Статус службы";
            // 
            // memoEditLog
            // 
            this.memoEditLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.memoEditLog.EditValue = "";
            this.memoEditLog.Location = new System.Drawing.Point(293, 49);
            this.memoEditLog.MenuManager = this.barManager2;
            this.memoEditLog.Name = "memoEditLog";
            this.memoEditLog.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.memoEditLog.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memoEditLog.Properties.Appearance.Options.UseBackColor = true;
            this.memoEditLog.Properties.Appearance.Options.UseFont = true;
            this.memoEditLog.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEditLog.Properties.ReadOnly = true;
            this.memoEditLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memoEditLog.Properties.WordWrap = false;
            this.memoEditLog.Size = new System.Drawing.Size(449, 260);
            this.memoEditLog.TabIndex = 26;
            // 
            // timerLoadingLog
            // 
            this.timerLoadingLog.Enabled = true;
            this.timerLoadingLog.Interval = 1000;
            this.timerLoadingLog.Tick += new System.EventHandler(this.timerLoadingLog_Tick);
            // 
            // timerServiceStatus
            // 
            this.timerServiceStatus.Enabled = true;
            this.timerServiceStatus.Interval = 1000;
            this.timerServiceStatus.Tick += new System.EventHandler(this.timerServiceStatus_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 341);
            this.Controls.Add(this.memoEditLog);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.toggleSwitch);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmMain.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "ED Sorter";
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarSubItem barMenuMain;
        private DevExpress.XtraBars.BarButtonItem barButtonISettings;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch;
        private DevExpress.XtraEditors.MemoEdit memoEditLog;
        private System.Windows.Forms.Timer timerLoadingLog;
        private DevExpress.XtraBars.BarEditItem barEditItemServiceStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private System.Windows.Forms.Timer timerServiceStatus;
        private DevExpress.XtraBars.BarStaticItem barStaticItemServiceNotFound;
    }
}