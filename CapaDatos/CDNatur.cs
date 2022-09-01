using CapaEntidad;
using MySql.Data.MySqlClient;
using System.Data;
namespace CapaDatos
{
    public class CDNatur
    {
        string cadenaConexion = "Server=Localhost;User=root;Password=admin;Port=3306;database=naturvida";
        public void pruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión" + ex.Message);
                return;
            }
            mySqlConnection.Close();
            MessageBox.Show("Conexión exitosa");
        }
        public void Registrar(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"INSERT INTO `productos` (`proCodigo`, `proNombre`, `proDescripcion`, `proValor`, `proCantidad`) VALUES ('{cENatur.Codigo}', '{cENatur.Nombre}', '{cENatur.Descripcion}', '{cENatur.valor}', '{cENatur.cantidad}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }
        public DataTable Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            DataTable ds = new DataTable();
            mySqlConnection.Open();
            string query = "SELECT * FROM `productos` limit 1000;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
        }
        public DataTable ListarProductos()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            DataTable ds = new DataTable();
            mySqlConnection.Open();
            string query = "SELECT `proCodigo`, `proNombre` FROM `productos` limit 1000;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
        }
        public void Deletear(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"DELETE FROM `productos` WHERE (`proCodigo` = '{cENatur.Codigo}'); ";
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado");
        }
        public MySqlDataReader BuscarPorCodigo(int cENatur)
        {
            string cadenaConexion = "Server=Localhost;User=root;Password=admin;Port=3306;database=naturvida";
            MySqlDataReader reader = null;
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"Select * from productos where (proCodigo = {cENatur});";
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            reader = cmd.ExecuteReader();
            return reader;
            mySqlConnection.Close();
            MessageBox.Show("Registro Encontrado");
        }
        public void Actualizar(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"UPDATE `productos` SET `proNombre` = '{cENatur.Nombre}', `proDescripcion` = '{cENatur.Descripcion}', `proValor` = '{cENatur.valor}', `proCantidad` = '{cENatur.cantidad}' WHERE (`proCodigo` = '{cENatur.Codigo}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Actualizacion exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }
        public DataTable ListarClientes()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            DataTable ds = new DataTable();
            mySqlConnection.Open();
            string query = "SELECT `cliDocumento`, `cliNombre` FROM `clientes` limit 1000;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
        }
        public void Facturar(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"INSERT INTO `facturas` (`facNumero`, `facFecha`, `facCliente`, `facValorTotal`, `facVendedor`) " +
                    $" VALUES ('{cENatur.facNumero}', '{cENatur.facFecha}', '{cENatur.facCliente}', '{cENatur.facValorTotal}', '{cENatur.facVen}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }
        public void AgregarProductoFactura(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"INSERT INTO `facturadetalle` (`facNumero`, `facProducto`, `facCantidad`) VALUES ('{cENatur.facNumero}', '{cENatur.Codigo}', '{cENatur.cantidad}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }

        }
        public DataTable ListarFactura(int cENatur)
        {
            string cadenaConexion = "Server=Localhost;User=root;Password=admin;Port=3306;database=naturvida";
            DataTable ds = new DataTable();
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"Select * from facturadetalle where (facNumero = {cENatur});";
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, mySqlConnection);
            cmd.Fill(ds);
            return ds;
            mySqlConnection.Close();
            MessageBox.Show("Registro Encontrado");
        }
        public DataTable BuscarPorCodigoFactura()
        {
            DataTable ds = new DataTable();
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"Select `facNumero` from facturas;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
            mySqlConnection.Close();
        }
        public void GenerarFactura(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = $"INSERT INTO `facturas` (`facNumero`, `fecha` ,`facCliente` ) VALUES('{cENatur.facNumero}', '{cENatur.facFecha}','{cENatur.facCliente}');";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro exitoso");
        }
        public void ActualizarFactura(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = $"UPDATE `facturas` SET `facValorTotal` = '{cENatur.facValorTotal}' WHERE (`facNumero` = '{cENatur.facNumero}');";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Actualizacion exitosa");
        }
        public void GenerarPrimerProducto(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = $"INSERT INTO `facturadetalle` (`facNumero`, `facProducto`, `facCantidad`) VALUES ('{cENatur.facNumero}', '{cENatur.Codigo}', '{cENatur.cantidad}');";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro exitoso");
        }
        public MySqlDataReader TerminarFactura(int cENatur)
        {
            string cadenaConexion = "Server=Localhost;User=root;Password=admin;Port=3306;database=naturvida";
            MySqlDataReader reader = null;
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"select sum(p.proValor*fd.facCantidad) as ValorTotal from (facturas f inner join facturadetalle fd on f.facNumero = fd.facNumero) inner join productos p on fd.facProducto = p.proCodigo where f.facNumero = {cENatur} group by f.facNumero";
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            reader = cmd.ExecuteReader();
            return reader;
            mySqlConnection.Close();
            MessageBox.Show("Registro Encontrado");
        }
        public void GuardarFactura(CENatur cENatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string Query = $"UPDATE `facturas` SET `facValorTotal` = '{cENatur.facValorTotal}' WHERE (`facNumero` = '{cENatur.facNumero}');";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Actualizacion exitosa");
        }
        public void GuardarDatoscli(CENatur cEnatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"INSERT INTO `clientes` (`clidocumento`, `cliNombre`, `cliDireccion`, `cliTelefono`, `cliCorreo`) VALUES ('{cEnatur.clidocumento}', '{cEnatur.cliNombre}', '{cEnatur.cliDireccion}','{cEnatur.cliTelefono}', '{cEnatur.cliCorreo}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }


        }
        public DataTable ConsultarDatosCli()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            DataTable ds = new DataTable();
            mySqlConnection.Open();
            string query = "SELECT * FROM `Clientes` limit 1000;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
        }
        public DataTable ListarDatosCLiente()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            DataTable ds = new DataTable();
            mySqlConnection.Open();
            string query = "SELECT `cliNombre`, `cliDocumento` FROM `Clientes`;";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, mySqlConnection);
            adaptador.Fill(ds);
            return ds;
        }
        public void DeletearCliente(CENatur cEnatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"DELETE FROM `Clientes` WHERE (`cliDocumento` = '{cEnatur.clidocumento}'); ";
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado");
        }
        public MySqlDataReader BuscarDatosCliente(int cEnatur)
        {
            string cadenaConexion = "Server=Localhost;User=root;Password=admin;Port=3306;database=naturvida";
            MySqlDataReader reader = null;
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = $"Select * from clientes where (cliDocumento = {cEnatur});";
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            reader = cmd.ExecuteReader();
            return reader;
            mySqlConnection.Close();
            MessageBox.Show("Registro Encontrado");
        }
        public void ActualizarClientes(CENatur cEnatur)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            try
            {
                mySqlConnection.Open();
                string Query = $"UPDATE `Clientes` SET `cliNombre` = '{cEnatur.cliNombre}', `cliDocumento` = '{cEnatur.clidocumento}', `cliTelefono` = '{cEnatur.cliTelefono}', `cliCorreo` = '{cEnatur.cliCorreo}','cliDireccion' = '{cEnatur.cliDireccion}' WHERE (`cliDocumento` = '{cEnatur.clidocumento}');";
                MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Actualizacion exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
                throw;
            }

            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }
    }
}
//UPDATE `facturas` SET `facValorTotal` = '100' WHERE (`facNumero` = '1');
