using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SQLiteTurbo
{
    public class WebSiteUtils
    {
        public static void OpenBugFeaturePage()
        {
            OpenPage("https://github.com/datadiode/SQLiteCompare/issues");
        }

        public static void OpenProductPage()
        {
            OpenPage("https://github.com/datadiode/SQLiteCompare");
        }

        public static void OpenReleasesPage()
        {
            OpenPage("https://github.com/datadiode/SQLiteCompare/releases");
        }

        public static void OpenPage(string url)
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(url);
            p.StartInfo = psi;
            psi.UseShellExecute = true;
            p.Start();
        }
    }
}
