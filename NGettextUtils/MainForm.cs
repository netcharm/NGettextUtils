﻿using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NGettext.WinForm;

namespace NGettextUtils
{
    public partial class MainForm : Form
    {
        private string AppPath = Path.GetDirectoryName( Application.ExecutablePath );
        private SolutionInfo sln = new SolutionInfo();
        private string[] cmdArgs = null;

        private bool firstRun = true;
        private string lastSolution = string.Empty;
        private string lastLocale = string.Empty;
        private string GettextPath = AppDomain.CurrentDomain.BaseDirectory + "gnugettext";
        private string GettextVersion = string.Empty;
        private string poEditor = string.Empty;

        private string cscPath = string.Empty;

        private string strSolutionNotLoaded = I18N._( "Solution must be loaded first!" );

        private void LoadSetting()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration( Application.ExecutablePath );
            AppSettingsSection appSection = config.AppSettings;

            if ( appSection.Settings["firstRun"] != null )
            {
                try
                {
                    var bv = Convert.ToBoolean(appSection.Settings["firstRun"].Value);
                    firstRun = bv;
                }
                catch { }
            }

            if ( appSection.Settings["lastSolution"] != null )
            {
                lastSolution = appSection.Settings["lastSolution"].Value;
                //edSolution.Text = lastSolution;
            }
            if ( appSection.Settings["lastLocale"] != null )
            {
                lastLocale = appSection.Settings["lastLocale"].Value;
                //cbLanguage.Text = lastLocale;
            }
            if ( appSection.Settings["GettextPath"] != null )
            {
                if(!string.IsNullOrEmpty( appSection.Settings["GettextPath"].Value ) )
                {
                    GettextPath = appSection.Settings["GettextPath"].Value;
                }
                if ( sln != null )
                {
                    sln.GettextPath = GettextPath;
                    if ( !string.IsNullOrEmpty( GettextPath ) )
                    {
                        if ( Path.IsPathRooted( GettextPath ) )
                        {
                            msgidCollector.GettextPath = string.Format( "{0}\\", GettextPath ).Replace( "\\\\", "\\" );
                        }
                        else
                        {
                            msgidCollector.GettextPath = string.Format( "{1}\\{0}\\", GettextPath, AppDomain.CurrentDomain.BaseDirectory ).Replace( "\\\\", "\\" );
                        }
                    }
                }
            }
            else
            {
                GettextPath = AppDomain.CurrentDomain.BaseDirectory + "gnugettext";
            }
            if ( appSection.Settings["GettextVersion"] != null )
            {
                GettextVersion = appSection.Settings["GettextVersion"].Value;
                msgidCollector.GettextVersion = GettextVersion;
            }
            else
            {
                GettextVersion = msgidCollector.GettextVersion;
            }
            if ( appSection.Settings["cscPath"] != null )
            {
                cscPath = appSection.Settings["cscPath"].Value;
                if ( cscPath != null )
                {
                    if ( !string.IsNullOrEmpty( cscPath ) )
                    {
                        if ( Path.IsPathRooted( cscPath ) )
                        {
                            msgidCollector.cscPath = string.Format( "{0}", cscPath ).Replace( "\\\\", "\\" );
                        }
                        else if ( string.IsNullOrEmpty( Path.GetDirectoryName( cscPath ) ) )
                        {
                            msgidCollector.cscPath = string.Format( "{0}", cscPath ).Replace( "\\\\", "\\" );
                        }
                        else
                        {
                            msgidCollector.cscPath = string.Format( "{1}\\{0}", cscPath, AppDomain.CurrentDomain.BaseDirectory ).Replace( "\\\\", "\\" );
                        }
                    }
                }
            }

            if ( appSection.Settings["poEditor"] != null )
            {
                poEditor = appSection.Settings["poEditor"].Value;
                if ( poEditor != null )
                {
                    if ( !string.IsNullOrEmpty( poEditor ) )
                    {
                        if ( Path.IsPathRooted( poEditor ) )
                        {
                            msgidCollector.PoEditor = string.Format( "{0}", poEditor ).Replace( "\\\\", "\\" );
                        }
                        else if ( string.IsNullOrEmpty( Path.GetDirectoryName( poEditor ) ) )
                        {
                            msgidCollector.PoEditor = string.Format( "{0}", poEditor ).Replace( "\\\\", "\\" );
                        }
                        else
                        {
                            msgidCollector.PoEditor = string.Format( "{1}\\{0}", poEditor, AppDomain.CurrentDomain.BaseDirectory ).Replace( "\\\\", "\\" );
                        }
                    }
                }
            }
        }

        private void SaveSetting()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration( Application.ExecutablePath );
            AppSettingsSection appSection = config.AppSettings;

            if ( appSection.Settings["firstRun"] != null )
            {
                appSection.Settings["firstRun"].Value = firstRun.ToString();
            }
            else
            {
                appSection.Settings.Add( "firstRun", firstRun.ToString() );
            }

            var bv = Convert.ToBoolean(appSection.Settings["firstRun"].Value);
            firstRun = bv;

            if ( !string.IsNullOrEmpty( edSolution.Text ) )
            {
                lastSolution = edSolution.Text;
                if ( appSection.Settings["lastSolution"] != null )
                {
                    appSection.Settings["lastSolution"].Value = lastSolution;
                }
                else
                {
                    appSection.Settings.Add( "lastSolution", lastSolution );
                }
            }

            if ( !string.IsNullOrEmpty( cbLanguage.Text ) )
            {
                lastLocale = cbLanguage.Text;
                if ( appSection.Settings["lastLocale"] != null )
                {
                    appSection.Settings["lastLocale"].Value = lastLocale;
                }
                else
                {
                    appSection.Settings.Add( "lastLocale", lastLocale );
                }
            }

            if ( appSection.Settings["GettextPath"] != null )
            {
                appSection.Settings["GettextPath"].Value = GettextPath;
            }
            else
            {
                appSection.Settings.Add( "GettextPath", GettextPath );
            }
            if ( appSection.Settings["GettextVersion"] != null )
            {
                appSection.Settings["GettextVersion"].Value = GettextVersion;
            }
            else
            {
                appSection.Settings.Add( "GettextVersion", GettextVersion );
            }

            cscPath = msgidCollector.cscPath;
            if ( appSection.Settings["cscPath"] != null )
            {
                appSection.Settings["cscPath"].Value = cscPath;

            }
            else
            {
                appSection.Settings.Add( "cscPath", cscPath );
            }

            if ( appSection.Settings["poEditor"] != null )
            {
                appSection.Settings["poEditor"].Value = poEditor;
            }
            else
            {
                appSection.Settings.Add( "poEditor", poEditor );
            }

            config.Save( ConfigurationSaveMode.Full );
        }

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );
            I18N i10n = new I18N( null, this );
            //I18N i10n = new I18N( Path.GetFileNameWithoutExtension( Application.ExecutablePath ), this );
            InitUI();
        }

        public MainForm( string[] args )
        {
            cmdArgs = args;

            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );
            //I18N i10n = new I18N( "GetTextUtils", this );
            I18N i10n = new I18N( "GetTextUtils", this, this.toolTip, new object[] { this.dlgOpen } );
            //I18N i10n = new I18N( Path.GetFileNameWithoutExtension( Application.ExecutablePath ), this, this.toolTip, new object[] { this.dlgOpen } );
        }

        private void file_DragDrop( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                // Assign the file names to a string array, in
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData( DataFormats.FileDrop );
                try
                {
                    if ( Directory.Exists( files[0] ) )
                    {
                        string[] slnfiles = Directory.GetFiles( files[0], "*.sln", SearchOption.TopDirectoryOnly );
                        if ( slnfiles.Length > 0 )
                        {
                            edSolution.Text = slnfiles[0];
                        }
                    }
                    else if ( File.Exists( files[0] ) )
                    {
                        edSolution.Text = files[0];
                    }

                    // Assign the first image to the picture variable.
                    //this.picture = Image.FromFile( files[0] );
                    // Set the picture location equal to the drop point.
                    //this.pictureLocation = this.PointToClient( new Point( e.X, e.Y ) );
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( ex.Message );
                    return;
                }
            }
        }

        private void file_DragEnter( object sender, DragEventArgs e )
        {
            // If the data is a file, display the link cursor.

            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void log( string logtext )
        {
            StatusLabelState.Text = logtext;
            edLog.AppendText( string.Format( "{0}\n", logtext ) );
        }

        private void InitUI()
        {
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler( this.file_DragDrop );
            this.DragEnter += new DragEventHandler( this.file_DragEnter );

            toolTip.ToolTipTitle = this.Text;

            cbLanguage.Items.Clear();
            cbLanguage.Items.AddRange( msgidCollector.SystemLocales() );

            edSolution.Text = lastSolution;
            if ( cmdArgs != null && cmdArgs.Length >= 1 )
            {
                edSolution.Text = cmdArgs[0];
            }

            cbLanguage.Text = lastLocale;
            if ( cmdArgs != null && cmdArgs.Length >= 2 )
            {
                cbLanguage.Text = cmdArgs[1];
            }

            msgidCollector.AppLog = edLog;

        }

        private void LockUI()
        {
            grpLocale.Enabled = false;
            edLog.Enabled = false;
            pnlAction.Enabled = false;
        }

        private void UnlockUI()
        {
            grpLocale.Enabled = true;
            edLog.Enabled = true;
            pnlAction.Enabled = true;
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            LoadSetting();
            InitUI();
        }

        private void MainForm_Shown( object sender, EventArgs e )
        {
            if ( firstRun )
            {
                btnOptions.PerformClick();
            }
        }

        private void MainForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            SaveSetting();
        }

        private void toolTip_Popup( object sender, PopupEventArgs e )
        {
            toolTip.ToolTipTitle = e.AssociatedControl.Text;
            //toolTip.SetToolTip( e.AssociatedControl, I18N._( toolTip.GetToolTip( e.AssociatedControl ) ).Replace( "\\n", "\n" ) );
        }

        private void btnLoadSolution_Click( object sender, EventArgs e )
        {
            LockUI();
            sln.Load( edSolution.Text );
            UnlockUI();
            StatusLabelState.Text = I18N._( "Loaded" );
        }

        private void btnCreatePO_Click( object sender, EventArgs e )
        {
            if ( sln.Loaded )
            {
                LockUI();
                sln.Process();
                UnlockUI();
            }
            else
            {
                log( I18N._( strSolutionNotLoaded ) );
            }
        }

        private void btnCreateLangPO_Click( object sender, EventArgs e )
        {
            if ( sln.Loaded )
            {
                LockUI();
                sln.MakeLangPO( cbLanguage.Text );
                UnlockUI();
            }
            else
            {
                log( I18N._( strSolutionNotLoaded ) );
            }
        }

        private void btnOpenPO_Click( object sender, EventArgs e )
        {
            if ( sln.Loaded )
            {
                LockUI();
                sln.EditPO( cbLanguage.Text );
                UnlockUI();
            }
            else
            {
                log( I18N._( strSolutionNotLoaded ) );
            }
        }

        private void btnCreateLangDll_Click( object sender, EventArgs e )
        {
            if ( sln.Loaded )
            {
                LockUI();
                sln.MakeLangMO( cbLanguage.Text );
                UnlockUI();
            }
            else
            {
                log( I18N._( strSolutionNotLoaded ) );
            }
        }

        private void btnPatchFile_Click( object sender, EventArgs e )
        {
            if ( sln.Loaded )
            {
                LockUI();
                sln.Patch();
                UnlockUI();
            }
            else
            {
                log( I18N._( strSolutionNotLoaded ) );
            }
        }

        private void btnLocaleCHS_Click( object sender, EventArgs e )
        {
            //cbLanguage.Text = "zh-CHS";
            cbLanguage.Text = "zh-CN";
        }

        private void btnLocaleCHT_Click( object sender, EventArgs e )
        {
            //cbLanguage.Text = "zh-CHT";
            cbLanguage.Text = "zh-TW";
        }

        private void btnBrowseSln_Click( object sender, EventArgs e )
        {
            if(!string.IsNullOrEmpty(edSolution.Text))
            {
                dlgOpen.InitialDirectory = Path.GetDirectoryName( Path.GetFullPath(edSolution.Text) );
            }
            //dlgOpen.Filter = I18N._( dlgOpen.Filter );
            //dlgOpen.Title = I18N._( dlgOpen.Title );
            if ( dlgOpen.ShowDialog() == DialogResult.OK )
            {
                edSolution.Text = dlgOpen.FileName;                   
            }
        }

        private void btnOptions_ButtonClick( object sender, EventArgs e )
        {
            var form = new optionsForm();
            form.firstRun = firstRun;
            form.cscPath = cscPath;
            form.gnugettextPath = GettextPath;
            form.poeditPath = poEditor;

            DialogResult dlgResult = form.ShowDialog();
            //form.StartPosition = FormStartPosition.CenterParent;
            //form.AutoSize = true;
            //form.Location = new Point( 
            //    this.Location.X + ( this.Height - form.Height ) / 2, 
            //    this.Location.Y + ( this.Width - form.Width ) / 2 );
            if(dlgResult == DialogResult.OK)
            {
                firstRun = form.firstRun;
                cscPath = form.cscPath;
                GettextPath = form.gnugettextPath;
                poEditor = form.poeditPath;
            }
            form.Dispose();
        }

    }
}

