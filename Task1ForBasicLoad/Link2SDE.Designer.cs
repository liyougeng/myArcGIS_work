namespace Task1ForBasicLoad
{
    partial class Link2SDE
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textVersion = new System.Windows.Forms.TextBox();
            this.textDatabase = new System.Windows.Forms.TextBox();
            this.textService = new System.Windows.Forms.TextBox();
            this.textServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textPasswd = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textFileLocation = new System.Windows.Forms.TextBox();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_Write2Sde = new System.Windows.Forms.Button();
            this.openShpFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.labelState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(550, 280);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(550, 242);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textVersion);
            this.groupBox1.Controls.Add(this.textDatabase);
            this.groupBox1.Controls.Add(this.textService);
            this.groupBox1.Controls.Add(this.textServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接配置";
            // 
            // textVersion
            // 
            this.textVersion.Location = new System.Drawing.Point(109, 190);
            this.textVersion.Name = "textVersion";
            this.textVersion.Size = new System.Drawing.Size(159, 21);
            this.textVersion.TabIndex = 7;
            this.textVersion.Text = "sde.DEFAULT";
            // 
            // textDatabase
            // 
            this.textDatabase.Location = new System.Drawing.Point(109, 138);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(159, 21);
            this.textDatabase.TabIndex = 6;
            this.textDatabase.Text = "sa";
            // 
            // textService
            // 
            this.textService.Location = new System.Drawing.Point(109, 88);
            this.textService.Name = "textService";
            this.textService.Size = new System.Drawing.Size(159, 21);
            this.textService.TabIndex = 5;
            this.textService.Text = "esri_sde";
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(109, 36);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(159, 21);
            this.textServer.TabIndex = 4;
            this.textServer.Text = "CZFEDORA-PC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(30, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "版本：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(30, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelState);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.textPasswd);
            this.groupBox2.Controls.Add(this.textUserName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 239);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录信息";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(23, 191);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(172, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textPasswd
            // 
            this.textPasswd.Location = new System.Drawing.Point(19, 145);
            this.textPasswd.Name = "textPasswd";
            this.textPasswd.Size = new System.Drawing.Size(174, 21);
            this.textPasswd.TabIndex = 3;
            this.textPasswd.Tag = "";
            this.textPasswd.UseSystemPasswordChar = true;
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(19, 75);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(174, 21);
            this.textUserName.TabIndex = 2;
            this.textUserName.Text = "sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "用户名：";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textFileLocation);
            this.flowLayoutPanel1.Controls.Add(this.btn_OpenFile);
            this.flowLayoutPanel1.Controls.Add(this.btn_Write2Sde);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textFileLocation
            // 
            this.textFileLocation.Location = new System.Drawing.Point(3, 3);
            this.textFileLocation.Name = "textFileLocation";
            this.textFileLocation.Size = new System.Drawing.Size(346, 21);
            this.textFileLocation.TabIndex = 0;
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(355, 3);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(95, 23);
            this.btn_OpenFile.TabIndex = 1;
            this.btn_OpenFile.Text = "openShapeFile";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_Write2Sde
            // 
            this.btn_Write2Sde.Location = new System.Drawing.Point(456, 3);
            this.btn_Write2Sde.Name = "btn_Write2Sde";
            this.btn_Write2Sde.Size = new System.Drawing.Size(75, 23);
            this.btn_Write2Sde.TabIndex = 2;
            this.btn_Write2Sde.Text = "写入SDE";
            this.btn_Write2Sde.UseVisualStyleBackColor = true;
            this.btn_Write2Sde.Click += new System.EventHandler(this.btn_Write2Sde_Click);
            // 
            // openShpFileDlg
            // 
            this.openShpFileDlg.FileName = "openShapeFile";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(21, 224);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(71, 12);
            this.labelState.TabIndex = 5;
            this.labelState.Text = "状态:未连接";
            // 
            // Link2SDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 280);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Link2SDE";
            this.Text = "Link2SDE";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textVersion;
        private System.Windows.Forms.TextBox textDatabase;
        private System.Windows.Forms.TextBox textService;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textPasswd;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textFileLocation;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_Write2Sde;
        private System.Windows.Forms.OpenFileDialog openShpFileDlg;
        private System.Windows.Forms.Label labelState;
    }
}