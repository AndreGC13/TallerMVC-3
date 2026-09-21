using CapaModelo_protipoumg26.Contratos;
using CapaModelo_protipoumg26.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_protipoumg26.Repositorios
{
    public class RepositorioEmpleado : RepositorioMaestro, IRepositorioEmpleado
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEmpleado()
        {
            selectAll = "SELECT * FROM empleado";
            insert = "INSERT INTO empleado (nombre, puesto, telefono) VALUES (?, ?, ?)";
            update = "UPDATE empleado SET nombre=?, puesto=?, telefono=? WHERE id_empleado=?";
            delete = "DELETE FROM empleado WHERE id_empleado=?";
        }

        public int Agregar(Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.Nombre));
            _parametros.Add(new OdbcParameter("p_Puesto", entidad.Puesto));
            _parametros.Add(new OdbcParameter("p_Telefono", (object)entidad.Telefono ?? DBNull.Value));

            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.Nombre));
            _parametros.Add(new OdbcParameter("p_Puesto", entidad.Puesto));
            _parametros.Add(new OdbcParameter("p_Telefono", (object)entidad.Telefono ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_IdEmpleado", entidad.IdEmpleado));
            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Remover(Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_IdEmpleado", entidad.IdEmpleado));
            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<Empleado> GetAll()
        {
            var lstEmpleados = new List<Empleado>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                var empleado = new Empleado();
                empleado.IdEmpleado = Convert.ToInt32(row[0]);
                empleado.Nombre = row[1].ToString();
                empleado.Puesto = row[2].ToString();
                empleado.Telefono = row[3] == DBNull.Value ? string.Empty : row[3].ToString();
                lstEmpleados.Add(empleado);
            }
            tblTabla.Clear();
            tblTabla = null;
            return lstEmpleados;
        }
    }
}
