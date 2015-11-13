namespace NGettextUtils
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.status = new System.Windows.Forms.StatusStrip();
            this.StatusLabelState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnOpenPO = new System.Windows.Forms.Button();
            this.btnPatchFile = new System.Windows.Forms.Button();
            this.btnLoadSolution = new System.Windows.Forms.Button();
            this.btnCreateLangPO = new System.Windows.Forms.Button();
            this.btnCreateLangDll = new System.Windows.Forms.Button();
            this.btnCreatePOT = new System.Windows.Forms.Button();
            this.edLog = new System.Windows.Forms.TextBox();
            this.edSolution = new System.Windows.Forms.TextBox();
            this.grpLocale = new System.Windows.Forms.GroupBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.btnLocaleCHT = new System.Windows.Forms.RadioButton();
            this.btnLocaleCHS = new System.Windows.Forms.RadioButton();
            this.lblSolutionFile = new System.Windows.Forms.Label();
            this.lblActionLog = new System.Windows.Forms.Label();
            this.btnBrowseSln = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnOptions = new System.Windows.Forms.ToolStripSplitButton();
            this.status.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.grpLocale.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelState,
            this.toolStripProgress,
            this.btnOptions});
            this.status.Location = new System.Drawing.Point(0, 427);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(677, 22);
            this.status.SizingGrip = false;
            this.status.TabIndex = 2;
            this.status.Text = "Ready";
            // 
            // StatusLabelState
            // 
            this.StatusLabelState.AutoToolTip = true;
            this.StatusLabelState.Name = "StatusLabelState";
            this.StatusLabelState.Size = new System.Drawing.Size(466, 17);
            this.StatusLabelState.Spring = true;
            this.StatusLabelState.Text = "Ready";
            this.StatusLabelState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLabelState.ToolTipText = "State Info";
            // 
            // toolStripProgress
            // 
            this.toolStripProgress.Name = "toolStripProgress";
            this.toolStripProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.btnOpenPO);
            this.pnlAction.Controls.Add(this.btnPatchFile);
            this.pnlAction.Controls.Add(this.btnLoadSolution);
            this.pnlAction.Controls.Add(this.btnCreateLangPO);
            this.pnlAction.Controls.Add(this.btnCreateLangDll);
            this.pnlAction.Controls.Add(this.btnCreatePOT);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 381);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(677, 46);
            this.pnlAction.TabIndex = 3;
            // 
            // btnOpenPO
            // 
            this.btnOpenPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenPO.Location = new System.Drawing.Point(343, 12);
            this.btnOpenPO.Name = "btnOpenPO";
            this.btnOpenPO.Size = new System.Drawing.Size(100, 23);
            this.btnOpenPO.TabIndex = 6;
            this.btnOpenPO.Text = "Translating PO";
            this.toolTip.SetToolTip(this.btnOpenPO, "Open .PO Editor to translating it to locale");
            this.btnOpenPO.UseVisualStyleBackColor = true;
            this.btnOpenPO.Click += new System.EventHandler(this.btnOpenPO_Click);
            // 
            // btnPatchFile
            // 
            this.btnPatchFile.Location = new System.Drawing.Point(563, 12);
            this.btnPatchFile.Name = "btnPatchFile";
            this.btnPatchFile.Size = new System.Drawing.Size(100, 23);
            this.btnPatchFile.TabIndex = 5;
            this.btnPatchFile.Text = "Patch File";
            this.toolTip.SetToolTip(this.btnPatchFile, "Add Code/FileRef to project\\n(not recommended for senior)");
            this.btnPatchFile.UseVisualStyleBackColor = true;
            this.btnPatchFile.Click += new System.EventHandler(this.btnPatchFile_Click);
            // 
            // btnLoadSolution
            // 
            this.btnLoadSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadSolution.Location = new System.Drawing.Point(13, 12);
            this.btnLoadSolution.Name = "btnLoadSolution";
            this.btnLoadSolution.Size = new System.Drawing.Size(100, 23);
            this.btnLoadSolution.TabIndex = 4;
            this.btnLoadSolution.Text = "Load Solution";
            this.toolTip.SetToolTip(this.btnLoadSolution, "Load Solution file");
            this.btnLoadSolution.UseVisualStyleBackColor = true;
            this.btnLoadSolution.Click += new System.EventHandler(this.btnLoadSolution_Click);
            // 
            // btnCreateLangPO
            // 
            this.btnCreateLangPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLangPO.Location = new System.Drawing.Point(233, 12);
            this.btnCreateLangPO.Name = "btnCreateLangPO";
            this.btnCreateLangPO.Size = new System.Drawing.Size(100, 23);
            this.btnCreateLangPO.TabIndex = 3;
            this.btnCreateLangPO.Text = "Create PO";
            this.toolTip.SetToolTip(this.btnCreateLangPO, "Create locale .PO file for every project");
            this.btnCreateLangPO.UseVisualStyleBackColor = true;
            this.btnCreateLangPO.Click += new System.EventHandler(this.btnCreateLangPO_Click);
            // 
            // btnCreateLangDll
            // 
            this.btnCreateLangDll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLangDll.Location = new System.Drawing.Point(453, 12);
            this.btnCreateLangDll.Name = "btnCreateLangDll";
            this.btnCreateLangDll.Size = new System.Drawing.Size(100, 23);
            this.btnCreateLangDll.TabIndex = 2;
            this.btnCreateLangDll.Text = "Create MO";
            this.toolTip.SetToolTip(this.btnCreateLangDll, "Create locale ResourceDLL file");
            this.btnCreateLangDll.UseVisualStyleBackColor = true;
            this.btnCreateLangDll.Click += new System.EventHandler(this.btnCreateLangDll_Click);
            // 
            // btnCreatePOT
            // 
            this.btnCreatePOT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreatePOT.Location = new System.Drawing.Point(123, 12);
            this.btnCreatePOT.Name = "btnCreatePOT";
            this.btnCreatePOT.Size = new System.Drawing.Size(100, 23);
            this.btnCreatePOT.TabIndex = 1;
            this.btnCreatePOT.Text = "Create POT";
            this.toolTip.SetToolTip(this.btnCreatePOT, "Create .POT file for every project");
            this.btnCreatePOT.UseVisualStyleBackColor = true;
            this.btnCreatePOT.Click += new System.EventHandler(this.btnCreatePO_Click);
            // 
            // edLog
            // 
            this.edLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edLog.HideSelection = false;
            this.edLog.Location = new System.Drawing.Point(12, 147);
            this.edLog.MaxLength = 524288;
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.ReadOnly = true;
            this.edLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edLog.Size = new System.Drawing.Size(653, 221);
            this.edLog.TabIndex = 4;
            // 
            // edSolution
            // 
            this.edSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edSolution.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.edSolution.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.edSolution.HideSelection = false;
            this.edSolution.Location = new System.Drawing.Point(12, 34);
            this.edSolution.Name = "edSolution";
            this.edSolution.Size = new System.Drawing.Size(604, 21);
            this.edSolution.TabIndex = 5;
            this.edSolution.WordWrap = false;
            // 
            // grpLocale
            // 
            this.grpLocale.Controls.Add(this.cbLanguage);
            this.grpLocale.Controls.Add(this.btnLocaleCHT);
            this.grpLocale.Controls.Add(this.btnLocaleCHS);
            this.grpLocale.Location = new System.Drawing.Point(12, 63);
            this.grpLocale.Name = "grpLocale";
            this.grpLocale.Size = new System.Drawing.Size(653, 47);
            this.grpLocale.TabIndex = 7;
            this.grpLocale.TabStop = false;
            this.grpLocale.Text = "Target Locale";
            // 
            // cbLanguage
            // 
            this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(527, 16);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(114, 20);
            this.cbLanguage.TabIndex = 7;
            this.toolTip.SetToolTip(this.cbLanguage, "Dropdown to select locale from all system supported");
            // 
            // btnLocaleCHT
            // 
            this.btnLocaleCHT.Location = new System.Drawing.Point(101, 16);
            this.btnLocaleCHT.Name = "btnLocaleCHT";
            this.btnLocaleCHT.Size = new System.Drawing.Size(81, 24);
            this.btnLocaleCHT.TabIndex = 1;
            this.btnLocaleCHT.Text = "CHT";
            this.toolTip.SetToolTip(this.btnLocaleCHT, "Most usage locale");
            this.btnLocaleCHT.UseVisualStyleBackColor = true;
            this.btnLocaleCHT.Click += new System.EventHandler(this.btnLocaleCHT_Click);
            // 
            // btnLocaleCHS
            // 
            this.btnLocaleCHS.Checked = true;
            this.btnLocaleCHS.Location = new System.Drawing.Point(13, 16);
            this.btnLocaleCHS.Name = "btnLocaleCHS";
            this.btnLocaleCHS.Size = new System.Drawing.Size(81, 24);
            this.btnLocaleCHS.TabIndex = 0;
            this.btnLocaleCHS.TabStop = true;
            this.btnLocaleCHS.Text = "CHS";
            this.toolTip.SetToolTip(this.btnLocaleCHS, "Most usage locale");
            this.btnLocaleCHS.UseVisualStyleBackColor = true;
            this.btnLocaleCHS.Click += new System.EventHandler(this.btnLocaleCHS_Click);
            // 
            // lblSolutionFile
            // 
            this.lblSolutionFile.Location = new System.Drawing.Point(12, 9);
            this.lblSolutionFile.Name = "lblSolutionFile";
            this.lblSolutionFile.Size = new System.Drawing.Size(182, 23);
            this.lblSolutionFile.TabIndex = 8;
            this.lblSolutionFile.Text = "Solution File:";
            this.lblSolutionFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActionLog
            // 
            this.lblActionLog.Location = new System.Drawing.Point(12, 121);
            this.lblActionLog.Name = "lblActionLog";
            this.lblActionLog.Size = new System.Drawing.Size(182, 23);
            this.lblActionLog.TabIndex = 9;
            this.lblActionLog.Text = "Logger:";
            this.lblActionLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseSln
            // 
            this.btnBrowseSln.Location = new System.Drawing.Point(626, 34);
            this.btnBrowseSln.Name = "btnBrowseSln";
            this.btnBrowseSln.Size = new System.Drawing.Size(38, 21);
            this.btnBrowseSln.TabIndex = 10;
            this.btnBrowseSln.Text = "...";
            this.toolTip.SetToolTip(this.btnBrowseSln, "Browsing Directory to select Solution file.");
            this.btnBrowseSln.UseMnemonic = false;
            this.btnBrowseSln.UseVisualStyleBackColor = true;
            this.btnBrowseSln.Click += new System.EventHandler(this.btnBrowseSln_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "sln";
            this.dlgOpen.FileName = "*.sln";
            this.dlgOpen.Filter = "Solution File|*.sln|All Files|*.*";
            this.dlgOpen.SupportMultiDottedExtensions = true;
            this.dlgOpen.Title = "Open Solution File";
            // 
            // btnOptions
            // 
            this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(63, 20);
            this.btnOptions.Text = "Options";
            this.btnOptions.ButtonClick += new System.EventHandler(this.btnOptions_ButtonClick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 449);
            this.Controls.Add(this.btnBrowseSln);
            this.Controls.Add(this.lblActionLog);
            this.Controls.Add(this.lblSolutionFile);
            this.Controls.Add(this.grpLocale);
            this.Controls.Add(this.edSolution);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NGetText Utility";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.grpLocale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnCreateLangDll;
        private System.Windows.Forms.Button btnCreatePOT;
        private System.Windows.Forms.Button btnCreateLangPO;
        private System.Windows.Forms.Button btnLoadSolution;
        private System.Windows.Forms.TextBox edLog;
        private System.Windows.Forms.Button btnPatchFile;
        private System.Windows.Forms.TextBox edSolution;
        private System.Windows.Forms.GroupBox grpLocale;
        private System.Windows.Forms.RadioButton btnLocaleCHT;
        private System.Windows.Forms.RadioButton btnLocaleCHS;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button btnOpenPO;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelState;
        private System.Windows.Forms.Label lblSolutionFile;
        private System.Windows.Forms.Label lblActionLog;
        private System.Windows.Forms.Button btnBrowseSln;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgress;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripSplitButton btnOptions;
    }
}

