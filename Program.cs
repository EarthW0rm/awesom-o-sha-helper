using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sha256_helper
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string filePath = null;
                string hashFile = string.Empty;

                try {
                    FileInfo fi = new FileInfo(args[0]);
                    if (fi.Exists)
                        filePath = fi.FullName;
                }
                catch(System.ArgumentException) {
                    filePath = null;
                }

                if (!string.IsNullOrEmpty(filePath)) {
                    var form = new Form1(SHAHelper.GetSHA256(filePath), filePath);
                    Application.Run(form);
                }                
            }
            else {
                MessageBox.Show("Nada a fazer.", "EarthW0rm - SHA256 Helper",   MessageBoxButtons.OK);
            }

            
        }
    }
}
