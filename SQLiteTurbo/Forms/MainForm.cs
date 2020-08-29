using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLiteParser;
using Common;
using log4net;

namespace SQLiteTurbo
{
    /// <summary>
    /// This class is the main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var arguments = new ArrayList(Environment.GetCommandLineArgs());
            var ctype = ComparisonType.CompareSchemaAndData;
            var compareBlobFields = false;
            int i;
            if ((i = arguments.IndexOf("/CompareSchemaOnly", 1)) != -1)
            {
                arguments.RemoveAt(i);
                ctype = ComparisonType.CompareSchemaOnly;
            }
            if ((i = arguments.IndexOf("/CompareBlobFields", 1)) != -1)
            {
                arguments.RemoveAt(i);
                compareBlobFields = true;
            }
            if (arguments.Count == 3)
            {
                _compareParams = new CompareParams((string)arguments[1], (string)arguments[2], ctype, compareBlobFields);
            }
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

            // The first time the software is ran - it should prompt the user if he wants to enable
            // checking for software updates upon system startup
            if (_compareParams != null)
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