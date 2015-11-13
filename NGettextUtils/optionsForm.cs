using System;
using System.Drawing;
using System.Windows.Forms;
using NGettext.WinForm;

namespace NGettextUtils
{
    public partial class optionsForm : Form
    {
        public bool firstRun = false;
        public string cscPath = string.Empty;
        public string gnugettextPath = string.Empty;
        public string poeditPath = string.Empty;
        public string poTranslator = string.Empty;
        public string poTeam = string.Empty;

        public optionsForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon( Application.ExecutablePath );
            I18N i10n = new I18N( null, this );
            //I18N i10n = new I18N( Path.GetFileNameWithoutExtension( Application.ExecutablePath ), this );
        }

        private void optionsForm_Load( object sender, EventArgs e )
        {
            edCscPath.Text = cscPath;
            edGNUGettextPath.Text = gnugettextPath;
            edPoeditPath.Text = poeditPath;
            edPoTranslator.Text = poTranslator;
            edPoTeam.Text = poTeam;
        }

        private void btnOK_Click( object sender, EventArgs e )
        {
            cscPath = edCscPath.Text;
            gnugettextPath = edGNUGettextPath.Text;
            poeditPath = edPoeditPath.Text;
            poTranslator = edPoTranslator.Text;
            poTeam = edPoTeam.Text;

            if ( !string.IsNullOrEmpty( cscPath ) && 
                 !string.IsNullOrEmpty( gnugettextPath ) && 
                 !string.IsNullOrEmpty( poeditPath ) )
            {
                firstRun = false;
            }
            this.Close();
        }

    }
}
