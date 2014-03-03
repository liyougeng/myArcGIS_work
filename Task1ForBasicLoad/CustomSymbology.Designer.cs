namespace Task1ForBasicLoad
{
    partial class CustomSymbology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSymbology));
            this.axSymbologyControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemMakerSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLineSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFillSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemLengdaClass = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemColorComp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.SymbolPanel = new System.Windows.Forms.Panel();
            this.groupBoxProperty = new System.Windows.Forms.GroupBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.colorBtn = new System.Windows.Forms.Button();
            this.sizeSpin = new System.Windows.Forms.NumericUpDown();
            this.angleSpin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.outColorBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SymbolPanel.SuspendLayout();
            this.groupBoxProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSpin)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl
            // 
            this.axSymbologyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyControl.Location = new System.Drawing.Point(0, 0);
            this.axSymbologyControl.Name = "axSymbologyControl";
            this.axSymbologyControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl.OcxState")));
            this.axSymbologyControl.Size = new System.Drawing.Size(429, 481);
            this.axSymbologyControl.TabIndex = 0;
            this.axSymbologyControl.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.axSymbologyControl_OnDoubleClick);
            this.axSymbologyControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl_OnItemSelected);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.ToolStripMenuItemFilter,
            this.ToolStripMenuItemDisplay,
            this.ToolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(636, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.MenuItemLoad,
            this.MenuItemSave});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(74, 21);
            this.MenuItemFile.Text = "文件（&F）";
            // 
            // MenuItemLoad
            // 
            this.MenuItemLoad.Name = "MenuItemLoad";
            this.MenuItemLoad.Size = new System.Drawing.Size(152, 22);
            this.MenuItemLoad.Text = "加载文件(&L)";
            this.MenuItemLoad.Click += new System.EventHandler(this.MenuItemLoad_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.Size = new System.Drawing.Size(152, 22);
            this.MenuItemSave.Text = "保存文件(&S)";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // ToolStripMenuItemFilter
            // 
            this.ToolStripMenuItemFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.ToolStripMenuItemMakerSymbol,
            this.ToolStripMenuItemLineSymbol,
            this.ToolStripMenuItemFillSymbol,
            this.toolStripSeparator2,
            this.ToolStripMenuItemLengdaClass,
            this.ToolStripMenuItemColorComp,
            this.toolStripSeparator3});
            this.ToolStripMenuItemFilter.Name = "ToolStripMenuItemFilter";
            this.ToolStripMenuItemFilter.Size = new System.Drawing.Size(123, 21);
            this.ToolStripMenuItemFilter.Text = "手动筛选类型（&S）";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemMakerSymbol
            // 
            this.ToolStripMenuItemMakerSymbol.Name = "ToolStripMenuItemMakerSymbol";
            this.ToolStripMenuItemMakerSymbol.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemMakerSymbol.Text = "点标记";
            this.ToolStripMenuItemMakerSymbol.Click += new System.EventHandler(this.ToolStripMenuItemMakerSymbol_Click);
            // 
            // ToolStripMenuItemLineSymbol
            // 
            this.ToolStripMenuItemLineSymbol.Name = "ToolStripMenuItemLineSymbol";
            this.ToolStripMenuItemLineSymbol.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemLineSymbol.Text = "线标记";
            this.ToolStripMenuItemLineSymbol.Click += new System.EventHandler(this.ToolStripMenuItemLineSymbol_Click);
            // 
            // ToolStripMenuItemFillSymbol
            // 
            this.ToolStripMenuItemFillSymbol.Name = "ToolStripMenuItemFillSymbol";
            this.ToolStripMenuItemFillSymbol.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemFillSymbol.Text = "面积标记";
            this.ToolStripMenuItemFillSymbol.Click += new System.EventHandler(this.ToolStripMenuItemFillSymbol_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemLengdaClass
            // 
            this.ToolStripMenuItemLengdaClass.Name = "ToolStripMenuItemLengdaClass";
            this.ToolStripMenuItemLengdaClass.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemLengdaClass.Text = "元素标记";
            this.ToolStripMenuItemLengdaClass.Click += new System.EventHandler(this.ToolStripMenuItemLengdaClass_Click);
            // 
            // ToolStripMenuItemColorComp
            // 
            this.ToolStripMenuItemColorComp.Name = "ToolStripMenuItemColorComp";
            this.ToolStripMenuItemColorComp.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemColorComp.Text = "色彩";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemDisplay
            // 
            this.ToolStripMenuItemDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemIcon,
            this.ToolStripMenuItemReport,
            this.ToolStripMenuItemSmallIcon,
            this.ToolStripMenuItemList});
            this.ToolStripMenuItemDisplay.Name = "ToolStripMenuItemDisplay";
            this.ToolStripMenuItemDisplay.Size = new System.Drawing.Size(101, 21);
            this.ToolStripMenuItemDisplay.Text = "显示风格（&D）";
            // 
            // ToolStripMenuItemIcon
            // 
            this.ToolStripMenuItemIcon.Name = "ToolStripMenuItemIcon";
            this.ToolStripMenuItemIcon.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemIcon.Text = "图标";
            this.ToolStripMenuItemIcon.Click += new System.EventHandler(this.ToolStripMenuItemIcon_Click);
            // 
            // ToolStripMenuItemReport
            // 
            this.ToolStripMenuItemReport.Name = "ToolStripMenuItemReport";
            this.ToolStripMenuItemReport.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemReport.Text = "报表";
            this.ToolStripMenuItemReport.Click += new System.EventHandler(this.ToolStripMenuItemReport_Click);
            // 
            // ToolStripMenuItemSmallIcon
            // 
            this.ToolStripMenuItemSmallIcon.Name = "ToolStripMenuItemSmallIcon";
            this.ToolStripMenuItemSmallIcon.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemSmallIcon.Text = "小图标";
            this.ToolStripMenuItemSmallIcon.Click += new System.EventHandler(this.ToolStripMenuItemSmallIcon_Click);
            // 
            // ToolStripMenuItemList
            // 
            this.ToolStripMenuItemList.Name = "ToolStripMenuItemList";
            this.ToolStripMenuItemList.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemList.Text = "列表";
            this.ToolStripMenuItemList.Click += new System.EventHandler(this.ToolStripMenuItemList_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAbout});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(61, 21);
            this.ToolStripMenuItemHelp.Text = "帮助(&H)";
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(116, 22);
            this.MenuItemAbout.Text = "关于(&A)";
            // 
            // SymbolPanel
            // 
            this.SymbolPanel.Controls.Add(this.axSymbologyControl);
            this.SymbolPanel.Location = new System.Drawing.Point(0, 28);
            this.SymbolPanel.Name = "SymbolPanel";
            this.SymbolPanel.Size = new System.Drawing.Size(429, 481);
            this.SymbolPanel.TabIndex = 2;
            // 
            // groupBoxProperty
            // 
            this.groupBoxProperty.Controls.Add(this.label4);
            this.groupBoxProperty.Controls.Add(this.outColorBtn);
            this.groupBoxProperty.Controls.Add(this.label3);
            this.groupBoxProperty.Controls.Add(this.label2);
            this.groupBoxProperty.Controls.Add(this.label1);
            this.groupBoxProperty.Controls.Add(this.angleSpin);
            this.groupBoxProperty.Controls.Add(this.sizeSpin);
            this.groupBoxProperty.Controls.Add(this.colorBtn);
            this.groupBoxProperty.Controls.Add(this.LabelName);
            this.groupBoxProperty.Location = new System.Drawing.Point(436, 28);
            this.groupBoxProperty.Name = "groupBoxProperty";
            this.groupBoxProperty.Size = new System.Drawing.Size(200, 422);
            this.groupBoxProperty.TabIndex = 3;
            this.groupBoxProperty.TabStop = false;
            this.groupBoxProperty.Text = "属性";
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(29, 36);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(0, 12);
            this.LabelName.TabIndex = 0;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(457, 477);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 4;
            this.OKBtn.Text = "确定";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(549, 477);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // colorBtn
            // 
            this.colorBtn.Location = new System.Drawing.Point(81, 154);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(94, 23);
            this.colorBtn.TabIndex = 1;
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // sizeSpin
            // 
            this.sizeSpin.Location = new System.Drawing.Point(81, 197);
            this.sizeSpin.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.sizeSpin.Name = "sizeSpin";
            this.sizeSpin.Size = new System.Drawing.Size(94, 21);
            this.sizeSpin.TabIndex = 2;
            this.sizeSpin.ValueChanged += new System.EventHandler(this.sizeSpin_ValueChanged);
            // 
            // angleSpin
            // 
            this.angleSpin.Location = new System.Drawing.Point(81, 235);
            this.angleSpin.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleSpin.Name = "angleSpin";
            this.angleSpin.Size = new System.Drawing.Size(94, 21);
            this.angleSpin.TabIndex = 3;
            this.angleSpin.ValueChanged += new System.EventHandler(this.angleSpin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "色彩：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "尺寸:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "角度：";
            // 
            // outColorBtn
            // 
            this.outColorBtn.Location = new System.Drawing.Point(81, 275);
            this.outColorBtn.Name = "outColorBtn";
            this.outColorBtn.Size = new System.Drawing.Size(94, 23);
            this.outColorBtn.TabIndex = 7;
            this.outColorBtn.UseVisualStyleBackColor = true;
            this.outColorBtn.Click += new System.EventHandler(this.outColorBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "外围颜色：";
            // 
            // CustomSymbology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 527);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.groupBoxProperty);
            this.Controls.Add(this.SymbolPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomSymbology";
            this.Text = "CustomSymbology";
            this.Load += new System.EventHandler(this.CustomSymbology_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.SymbolPanel.ResumeLayout(false);
            this.groupBoxProperty.ResumeLayout(false);
            this.groupBoxProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleSpin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFilter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDisplay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMakerSymbol;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLineSymbol;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFillSymbol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLengdaClass;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemColorComp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIcon;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemList;
        private System.Windows.Forms.Panel SymbolPanel;
        private System.Windows.Forms.GroupBox groupBoxProperty;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown angleSpin;
        private System.Windows.Forms.NumericUpDown sizeSpin;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button outColorBtn;
    }
}