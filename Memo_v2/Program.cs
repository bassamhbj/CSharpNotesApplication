using Memo_v2.Model;
using Memo_v2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memo_v2 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Modelo model = new Modelo();
            Controlador control = new Controlador(model);

            Application.Run(new Form1(control));
        }
    }
}
