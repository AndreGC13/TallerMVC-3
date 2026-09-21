using Capa_Controlador_ComboI;
using System;
using System.Data;
using System.Windows.Forms;

namespace Capa_Vista_ComboI
{
    public partial class ComboI : UserControl
    {
        public ComboI()
        {
            InitializeComponent();
        }
        ModeloComboI controlador = new ModeloComboI();

        public object ValorSeleccionado => cboPrueba.SelectedValue;

        public event EventHandler SeleccionCambiada
        {
            add { cboPrueba.SelectedIndexChanged += value; }
            remove { cboPrueba.SelectedIndexChanged -= value; }
        }

        public void llenarCombo(string _tabla, string _campo1, string _campo2)
        {
            var dtTabla = controlador.enviarDatos(_tabla, _campo1, _campo2);

            cboPrueba.DisplayMember = _campo2;
            cboPrueba.ValueMember = _campo1;
            cboPrueba.DataSource = dtTabla;
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dtTabla.Rows)
            {
                coleccion.Add(Convert.ToString(row[_campo1]) + "-" + Convert.ToString(row[_campo2]));
                coleccion.Add(Convert.ToString(row[_campo2]) + "-" + Convert.ToString(row[_campo1]));
            }
            cboPrueba.AutoCompleteCustomSource = coleccion;
            cboPrueba.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboPrueba.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
