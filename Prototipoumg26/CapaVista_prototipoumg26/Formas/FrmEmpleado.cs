using System;
using System.Windows.Forms;
using CapaControlador_prototipoumg;
using CapaVista_prototipoumg26.Reportes;

namespace CapaVista_prototipoumg26.Formas
{
    public partial class FrmEmpleado : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();

        public FrmEmpleado()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
            comboI1.SeleccionCambiada += comboI1_SeleccionCambiada;
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            listaEmpleados();
            comboI1.llenarCombo("empleado", "id_empleado", "nombre");
        }

        private void comboI1_SeleccionCambiada(object sender, EventArgs e)
        {
            if (comboI1.ValorSeleccionado == null || comboI1.ValorSeleccionado is DBNull) return;
            if (!int.TryParse(comboI1.ValorSeleccionado.ToString(), out int id)) return;
            foreach (DataGridViewRow row in dgvEmpleados.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == id)
                {
                    panIngresoDatos.Enabled = true;
                    empleado.Estado = EstadoEntidad.Modified;
                    empleado.IdEmpleado = id;
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtPuesto.Text = row.Cells[2].Value.ToString();
                    txtTelefono.Text = row.Cells[3].Value.ToString();
                    break;
                }
            }
        }

        private void listaEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = empleado.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindbyId(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindbyId(txtSearch.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            empleado.Nombre = txtNombre.Text;
            empleado.Puesto = txtPuesto.Text;
            empleado.Telefono = txtTelefono.Text;
            bool valido = new Ayudas.ValidacionDatos(empleado).Validar();
            if (valido == true)
            {
                string resultado = empleado.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
                Reinicio();
            }
        }

        private void Reinicio()
        {
            panIngresoDatos.Enabled = false;
            txtNombre.Clear();
            txtPuesto.Clear();
            txtTelefono.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panIngresoDatos.Enabled = true;
            empleado.Estado = EstadoEntidad.Added;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                panIngresoDatos.Enabled = true;
                empleado.Estado = EstadoEntidad.Modified;
                empleado.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value);
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtPuesto.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                empleado.Estado = EstadoEntidad.Deleted;
                empleado.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value);
                string resultado = empleado.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void ReporteBtn_Click(object sender, EventArgs e)
        {
            FrmReporteEmpleado reporteEmpleado = new FrmReporteEmpleado();
            reporteEmpleado.ShowDialog();
        }
    }
}
