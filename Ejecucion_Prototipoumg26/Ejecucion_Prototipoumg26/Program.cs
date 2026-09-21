using System;
using System.Windows.Forms;

namespace Ejecucion_Prototipoumg26
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CapaVista_prototipoumg26.Formas.FrmEmpleado());
        }
    }
}
