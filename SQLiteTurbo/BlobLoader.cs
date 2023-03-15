using System;
using System.IO;

namespace SQLiteTurbo
{
    /// <summary>
    /// This class is responsible for loading a BLOB field into the local file system
    /// and doing this in a chunky way that won't cause too much memory to be used.
    /// </summary>
    public class BlobLoader : AbstractWorker, IDisposable
    {
        #region Constructors & Destructors
        public BlobLoader(string dbpath, string tableName, string columnName, long rowId, FileStream blobFile)
            : base("BlobLoader")
        {
            _blobReader = new BlobReaderWriter(dbpath, true);
            _tableName = tableName;
            _columnName = columnName;
            _rowId = rowId;
            _blobFile = blobFile;
        }

        ~BlobLoader()
        {
            Dispose(false);
        }
        #endregion

        #region Protected Overrided Methods
        protected override void DoWork()
        {
            // Call the BLOB reader object to do the job
            _blobReader.ReadBlobToFile(_tableName, _columnName, _rowId, _blobFile, ProgressHandler);
        }

        protected override bool IsDualProgress
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);     
        }

        #endregion

        #region Protected Virtual Methods
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                if (_blobReader != null)
                {
                    _blobReader.Dispose();
                    _blobReader = null;
                }
            }
        }
        #endregion

        #region Private Methods
        private void ProgressHandler(byte[] buffer, int length, int bytesRead, int totalBytes, ref bool cancel)
        {
            cancel = this.WasCancelled;

            int progress = (int)(100.0 * bytesRead / totalBytes);
            if (progress > _progress)
            {
                NotifyPrimaryProgress(false, progress, Utils.FormatMemSize(bytesRead, MemFormat.KB) + "/" + 
                    Utils.FormatMemSize(totalBytes, MemFormat.KB) + " loaded so far", null);
                _progress = progress;
            }
        }
        #endregion

        #region Private Variables
        private long _rowId;
        private FileStream _blobFile;
        private string _tableName;
        private string _columnName;
        private int _progress = 0;
        private BlobReaderWriter _blobReader = null;
        #endregion
    }
}
