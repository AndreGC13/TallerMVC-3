using System.Data.Odbc;

namespace CapaModelo_protipoumg26.Repositorios
{
    public abstract class Repositorio
    {
        public readonly string connectionString;
        public Repositorio()
        {
            connectionString = "Dsn=UMG_Didactica";
        }
        protected OdbcConnection ObtenerConexion()
        {
            return new OdbcConnection(connectionString);
        }
    }
}
