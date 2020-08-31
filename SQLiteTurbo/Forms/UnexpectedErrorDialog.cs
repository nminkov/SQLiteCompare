using System;
using System.Windows.Forms;

namespace SQLiteTurbo
{
    public partial class UnexpectedErrorDialog : Form
    {
        public UnexpectedErrorDialog()
        {
            InitializeComponent();
        }

        #region Public Properties
        public Exception Error
        {
            get { return _error; }
            set { _error = value; }
        }
        #endregion

        #region Event Handlers

        private void UnexpectedErrorDialog_Load(object sender, EventArgs e)
        {
            if (_shown)
                this.Close();
            else
                _shown = true;
            txtErrorLog.Text = _error.ToString();
            txtLogFilePath.Text = Configuration.LogFilePath;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            WebSiteUtils.OpenBugFeaturePage();
        }
        #endregion

        #region Private Variables
        private Exception _error;
        private static bool _shown = false;
        #endregion
    }
}