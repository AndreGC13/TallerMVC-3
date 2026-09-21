using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CapaModelo_protipoumg26.Contratos;
using CapaModelo_protipoumg26.Entidades;
using CapaModelo_protipoumg26.Repositorios;

namespace CapaControlador_prototipoumg
{
    public class ModeloEmpleado
    {
        private int _idEmpleado;
        private string _nombre;
        private string _puesto;
        private string _telefono;
        private IRepositorioEmpleado RepositorioEmpleado;

        public EstadoEntidad Estado { private get; set; }
        private List<ModeloEmpleado> ListaEmpleados = new List<ModeloEmpleado>();

        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [RegularExpression("^[a-zA-Zá-úÁ-Ú ]+$", ErrorMessage = "El campo Nombre debe ser solo letras")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [Required(ErrorMessage = "El campo Puesto es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Puesto { get => _puesto; set => _puesto = value; }

        [RegularExpression(@"^[0-9+\-\s]*$", ErrorMessage = "El campo Telefono solo puede contener numeros")]
        [StringLength(maximumLength: 20)]
        public string Telefono { get => _telefono; set => _telefono = value; }

        public ModeloEmpleado()
        {
            RepositorioEmpleado = new RepositorioEmpleado();
        }

        public string GrabarCambios()
        {
            string mensaje = null;
            try
            {
                var modeloDatosEmpleado = new Empleado();
                modeloDatosEmpleado.IdEmpleado = _idEmpleado;
                modeloDatosEmpleado.Nombre = _nombre;
                modeloDatosEmpleado.Puesto = _puesto;
                modeloDatosEmpleado.Telefono = _telefono;
                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        RepositorioEmpleado.Agregar(modeloDatosEmpleado);
                        mensaje = "Grabacion exitosa";
                        break;
                    case EstadoEntidad.Modified:
                        RepositorioEmpleado.Editar(modeloDatosEmpleado);
                        mensaje = "Actualizacion exitosa";
                        break;
                    case EstadoEntidad.Deleted:
                        RepositorioEmpleado.Remover(modeloDatosEmpleado);
                        mensaje = "Eliminacion exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("foreign key constraint") || ex.Message.Contains("FOREIGN KEY"))
                {
                    mensaje = "No se puede eliminar este empleado porque tiene registros relacionados (por ejemplo, devoluciones) en el sistema.";
                }
                else
                {
                    mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public List<ModeloEmpleado> GetAll()
        {
            var modeloDatosEmpleados = RepositorioEmpleado.GetAll();
            ListaEmpleados = new List<ModeloEmpleado>();
            foreach (Empleado item in modeloDatosEmpleados)
            {
                ListaEmpleados.Add(new ModeloEmpleado
                {
                    _idEmpleado = item.IdEmpleado,
                    _nombre = item.Nombre,
                    _puesto = item.Puesto,
                    _telefono = item.Telefono
                });
            }
            return ListaEmpleados;
        }

        public IEnumerable<ModeloEmpleado> FindbyId(string filter)
        {
            return ListaEmpleados.FindAll(e => e._nombre.Contains(filter) || e._puesto.Contains(filter));
        }
    }
}
