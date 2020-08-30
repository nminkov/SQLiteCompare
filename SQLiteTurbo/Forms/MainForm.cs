using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Runtime.InteropServices;
using SQLiteParser;
using log4net;

namespace SQLiteTurbo
{
    /// <summary>
    /// This class is the main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000;

        public DialogResult ParseArguments(IList arguments)
        {
            var result = DialogResult.None;
            var ctype = ComparisonType.CompareSchemaAndData;
            var compareBlobFields = false;
            int i;
            if ((i = arguments.IndexOf("/ParentWindow")) != -1)
            {
                arguments.RemoveAt(i);
                if (i < arguments.Count)
                {
                    IntPtr hwndParent = (IntPtr)Convert.ToInt64((string)arguments[i], 16);
                    arguments.RemoveAt(i);
                    FormBorderStyle = FormBorderStyle.None;
                    CreateControl();
                    SetWindowLong(Handle, GWL_STYLE, GetWindowLong(Handle, GWL_STYLE) | WS_CHILD);
                    SetParent(Handle, hwndParent);
                }
            }
            if ((i = arguments.IndexOf("/ShowCompareDialog")) != -1)
            {
                arguments.RemoveAt(i);
                result = DialogResult.OK;
            }
            if ((i = arguments.IndexOf("/CompareSchemaOnly")) != -1)
            {
                arguments.RemoveAt(i);
                ctype = ComparisonType.CompareSchemaOnly;
            }
            if ((i = arguments.IndexOf("/CompareBlobFields")) != -1)
            {
                arguments.RemoveAt(i);
                compareBlobFields = true;
            }
            if (arguments.Count == 2)
            {
                _compareParams = new CompareParams((string)arguments[0], (string)arguments[1], ctype, compareBlobFields);
            }
            if (result != DialogResult.None)
            {
                CompareDialog dlg = new CompareDialog();
                dlg.CompareParams = _compareParams;
                result = dlg.ShowDialog();
                _compareParams = dlg.CompareParams;
            }
            return result;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            HandleCompareDialog();
        }

        private void mniCompare_Click(object sender, EventArgs e)
        {
            HandleCompareDialog();
        }

        private void mniRefresh_Click(object sender, EventArgs e)
        {
            RefreshComparison(true);
        }

        private void mniCloseComparison_Click(object sender, EventArgs e)
        {
            CleanupSchemaView();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanupSchemaView();
        }

        private void btnNextDiff_Click(object sender, EventArgs e)
        {
            _schemaView.MoveToNextDiff();
        }

        private void toolStripButton_EnabledChanged(object sender, EventArgs e)
        {
            AutomationEventArgs args = new AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent);
            var provider = AutomationInteropProvider.HostProviderFromHandle(toolStrip1.Handle);
            AutomationInteropProvider.RaiseAutomationEvent(InvokePatternIdentifiers.InvokedEvent, provider, args);
        }

        private void btnPreviousDiff_Click(object sender, EventArgs e)
        {
            _schemaView.MoveToPreviousDiff();
        }

        private void _schemaView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void mniCopyFromLeftDB_Click(object sender, EventArgs e)
        {
            _schemaView.CopyFromLeftDB();
        }

        private void mniCopyFromRightDB_Click(object sender, EventArgs e)
        {
            _schemaView.CopyFromRightDB();
        }

        private void btnEditSelectedDifference_Click(object sender, EventArgs e)
        {
            _schemaView.OpenCompareDialog();
        }

        private void mniEditSelection_Click(object sender, EventArgs e)
        {
            _schemaView.OpenCompareDialog();
        }

        private void mniGotoNextDifference_Click(object sender, EventArgs e)
        {
            _schemaView.MoveToNextDiff();
        }

        private void mniGotoPreviousDifference_Click(object sender, EventArgs e)
        {
            _schemaView.MoveToPreviousDiff();
        }

        private void btnCopyFromLeftDB_Click(object sender, EventArgs e)
        {
            _schemaView.CopyFromLeftDB();
        }

        private void btnCopyFromRightDB_Click(object sender, EventArgs e)
        {
            _schemaView.CopyFromRightDB();
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            AboutDialog dlg = new AboutDialog();
            dlg.ShowDialog(this);
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mniReport_Click(object sender, EventArgs e)
        {
            WebSiteUtils.OpenBugFeaturePage();
        }

        private void mniGenerateChangeScriptLeftToRight_Click(object sender, EventArgs e)
        {
            string sql = ChangeScriptBuilder.Generate(_leftdb, _rightdb, _leftSchema, _rightSchema, _results, ChangeDirection.LeftToRight);

            ChangeScriptDialog dlg = new ChangeScriptDialog();
            dlg.Prepare(sql);
            dlg.ShowDialog(this);
        }

        private void mniGenerateChangeScriptRightToLeft_Click(object sender, EventArgs e)
        {
            string sql = ChangeScriptBuilder.Generate(_leftdb, _rightdb, _leftSchema, _rightSchema, _results, ChangeDirection.RightToLeft);

            ChangeScriptDialog dlg = new ChangeScriptDialog();
            dlg.Prepare(sql);
            dlg.ShowDialog(this);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateTitle();

            if (FormBorderStyle == FormBorderStyle.None)
            {
                menuStrip1.Visible = false;
                toolStrip1.Visible = false;
                WindowState = FormWindowState.Maximized;
            }
            else if (_compareParams != null)
            {
                RefreshComparison(true);
            }
        }

        private void mniCheckForUpdates_Click(object sender, EventArgs e)
        {
            WebSiteUtils.OpenReleasesPage();
        }

        private void btnExportDataDifferences_Click(object sender, EventArgs e)
        {
            _schemaView.ExportDataDifferences();
        }

        #endregion

        #region Private Methods

        private void UpdateTitle()
        {
            this.Text = "SQLite Compare";
        }

        /// <summary>
        /// Allows to refresh the comparison results
        /// </summary>
        /// <param name="cancellable">TRUE means that the user will be allowed to cancel
        /// the comparison process. FALSE prevents this from happening (by making the CANCEL
        /// button disabled).</param>
        private void RefreshComparison(bool cancellable)
        {
            CompareWorker worker = new CompareWorker(_compareParams);
            ProgressDialog pdlg = new ProgressDialog();
            if (cancellable)
                pdlg.Start(this, worker);
            else
                pdlg.StartNonCancellable(this, worker);

            Dictionary<SchemaObject, List<SchemaComparisonItem>> results =
                (Dictionary<SchemaObject, List<SchemaComparisonItem>>)pdlg.Result;
            if (results != null)
            {
                // Create the schema comparison view and populate it with the results
                if (_schemaView == null)
                {
                    _schemaView = new SchemaComparisonView();
                    _schemaView.BackColor = SystemColors.Control;
                    pnlContents.Controls.Add(_schemaView);
                    _schemaView.Dock = DockStyle.Fill;
                    _schemaView.SelectionChanged += new EventHandler(_schemaView_SelectionChanged);
                }

                _schemaView.ShowComparisonResults(results, _compareParams.LeftDbPath, _compareParams.RightDbPath,
                    worker.LeftSchema, worker.RightSchema, _compareParams.ComparisonType == ComparisonType.CompareSchemaAndData);

                _leftSchema = worker.LeftSchema;
                _rightSchema = worker.RightSchema;
                SchemaComparisonItem.CleanupTempFiles(_results);
                _results = results;
                _leftdb = _compareParams.LeftDbPath;
                _rightdb = _compareParams.RightDbPath;
            }

            UpdateState();
        }

        private void CleanupSchemaView()
        {
            if (_schemaView == null)
                return;

            // Delete all temporary comparison files.
            foreach (SchemaComparisonItem item in _schemaView.Results[SchemaObject.Table])
            {
                if (item.TableChanges != null)
                    item.TableChanges.Dispose();
            } // foreach

            // Hide the schema view control
            pnlContents.Controls.Remove(_schemaView);
            _schemaView.SelectionChanged -= new EventHandler(_schemaView_SelectionChanged);
            _schemaView.Dispose();
            _schemaView = null;            

            _leftSchema = _rightSchema = null;
            _results = null;

            UpdateState();
        }

        private void UpdateState()
        {
            btnNextDiff.Enabled = _schemaView != null && _schemaView.HasNextDiff();
            btnPreviousDiff.Enabled = _schemaView != null && _schemaView.HasPreviousDiff();
            btnCopyFromLeftDB.Enabled = _schemaView != null && _schemaView.CanCopyFromLeftDB();
            btnCopyFromRightDB.Enabled = _schemaView != null && _schemaView.CanCopyFromRightDB();
            btnEditSelectedDifference.Enabled = _schemaView != null && _schemaView.CanEditSelectedDifference();
            mniCopyFromLeftDB.Enabled = _schemaView != null && _schemaView.CanCopyFromLeftDB();
            mniCopyFromRightDB.Enabled = _schemaView != null && _schemaView.CanCopyFromRightDB();
            mniEditSelection.Enabled = _schemaView != null && _schemaView.CanEditSelectedDifference();
            mniGotoNextDifference.Enabled = _schemaView != null && _schemaView.HasNextDiff();
            mniGotoPreviousDifference.Enabled = _schemaView != null && _schemaView.HasPreviousDiff();        

            mniGenerateChangeScriptLeftToRight.Enabled = _schemaView != null;
            mniGenerateChangeScriptRightToLeft.Enabled = _schemaView != null;
            mniCloseComparison.Enabled = _schemaView != null;
            btnExportDataDifferences.Enabled = _schemaView != null && _schemaView.HasDataDiffs();
        }

        private void HandleCompareDialog()
        {
            CompareDialog dlg = new CompareDialog();
            dlg.CompareParams = _compareParams;
            DialogResult res = dlg.ShowDialog(this);
            if (res == DialogResult.Cancel)
                return;

            // Collect the comparison parameters from the user and do the comparison.
            _compareParams = dlg.CompareParams;
            RefreshComparison(true);
        }

        #endregion

        #region Private Variables       
        private SchemaComparisonView _schemaView = null;
        private CompareParams _compareParams = null;
        private string _leftdb;
        private string _rightdb;
        private ILog _log = LogManager.GetLogger(typeof(MainForm));
        private Dictionary<SchemaObject, List<SchemaComparisonItem>> _results;
        private Dictionary<SchemaObject, Dictionary<string, SQLiteDdlStatement>> _leftSchema;
        private Dictionary<SchemaObject, Dictionary<string, SQLiteDdlStatement>> _rightSchema;
        #endregion
    }
}