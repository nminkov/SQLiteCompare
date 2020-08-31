using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using log4net.Config;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SQLiteTurbo
{
    static class Program
    {
        static Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
        /// <summary>
        /// https://github.com/adamabdelhamed/PowerArgs
        /// Copyright (c) 2013 Adam Abdelhamed
        /// SPDX-License-Identifier: MIT
        /// Converts a single string that represents a command line to be executed into a string[], 
        /// accounting for quoted arguments that may or may not contain spaces.
        /// </summary>
        /// <param name="commandLine">The raw arguments as a single string</param>
        /// <returns>a converted string array with the arguments properly broken up</returns>
        public static List<string> SplitCommandLine(string commandLine)
        {
            List<string> ret = new List<string>();
            string currentArg = string.Empty;
            bool insideDoubleQuotes = false;

            for (int i = 0; i < commandLine.Length; i++)
            {
                var c = commandLine[i];

                if (insideDoubleQuotes && c == '"')
                {
                    ret.Add(currentArg);
                    currentArg = string.Empty;
                    insideDoubleQuotes = !insideDoubleQuotes;
                }
                else if (!insideDoubleQuotes && c == ' ')
                {
                    if (currentArg.Length > 0)
                    {
                        ret.Add(currentArg);
                        currentArg = string.Empty;
                    }
                }
                else if (c == '"')
                {
                    insideDoubleQuotes = !insideDoubleQuotes;
                }
                else if (c == '\\' && i < commandLine.Length - 1 && commandLine[i + 1] == '"')
                {
                    currentArg += '"';
                    i++;
                }
                else
                {
                    currentArg += c;
                }
            }

            if (currentArg.Length > 0)
            {
                ret.Add(currentArg);
            }

            return ret;
        }

        static int About(String caption)
        {
            var dlg = new AboutDialog();
            dlg.Text = caption;
            dlg.ShowDialog();
            return 0;
        }

        static int Embed(String commandLine)
        {
            // Exceptions in here will gracefully auto-translate to COM errors
            // Configure log4net
            BasicConfigurator.Configure();
            var mainForm = new MainForm();
            var arguments = SplitCommandLine(commandLine);
            DialogResult result = mainForm.ParseArguments(arguments);
            if (result != DialogResult.Cancel)
                mainForm.Show();
            return (int)result;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                _mutex = Mutex.OpenExisting("SQLiteCompare");
                MessageBox.Show("Another instance of SQLiteCompare is already active.\r\n" +
                    "Please close it first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                _mutex = new Mutex(false, "SQLiteCompare");
            }

            // Configure log4net
            BasicConfigurator.Configure();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Issue a log message that contains the version of the application.
            _log.Info("===========================================================================");
            _log.Info(" SQLite Compare [" + Utils.GetSoftwareVersion() + " build " + Utils.GetSoftwareBuild() + "]");
            _log.Info("===========================================================================");

            // Remove any stale table change files
            TableChanges.RemoveStaleChangeFiles();

            try
            {
                _mainForm = new MainForm();
                var arguments = new ArrayList(Environment.GetCommandLineArgs());
                arguments.RemoveAt(0);
                _mainForm.ParseArguments(arguments);
                Application.Run(_mainForm);
                _mainForm = null;
            }
            catch (Exception ex)
            {
                _mainForm = null;
                _log.Error("Got exception from main loop", ex);
                ShowUnexpectedErrorDialog(ex);
            }
            finally
            {
                // Remove all active change files
                TableChanges.RemoveActiveChangeFiles();
            } // finally
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            _log.Error("thread exception", e.Exception);

            // Show error dialog
            ShowUnexpectedErrorDialog(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _log.Error("Unhandled exception ("+(e.IsTerminating?"terminating":"non-terminating")+")", 
                (Exception)e.ExceptionObject);

            ShowUnexpectedErrorDialog((Exception)e.ExceptionObject);
        }

        private static void ShowUnexpectedErrorDialog(Exception error)
        {
            // Prevent multiple unexpected-error-dialogs
            lock (typeof(Program))
            {
                if (_mainForm != null)
                {
                    if (_mainForm.InvokeRequired)
                    {
                        _mainForm.Invoke(new MethodInvoker(delegate
                        {
                            UnexpectedErrorDialog dlg = new UnexpectedErrorDialog();
                            dlg.Error = error;
                            dlg.ShowDialog(_mainForm);
                        }));
                    }
                    else
                    {
                        UnexpectedErrorDialog dlg = new UnexpectedErrorDialog();
                        dlg.Error = error;
                        dlg.ShowDialog(_mainForm);
                    } // else
                }
                else
                {
                    UnexpectedErrorDialog dlg = new UnexpectedErrorDialog();
                    dlg.Error = error;
                    Application.Run(dlg);
                } // else

                Environment.Exit(1);
            } // lock
        }

        private static Mutex _mutex = null;
        private static MainForm _mainForm = null;
        private static ILog _log = LogManager.GetLogger("Program");
    }
}