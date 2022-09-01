using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using MySql.Data.MySqlClient;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CNNatur cnNatur = new CNNatur();
        public Form1()
        {
            InitializeComponent();
        }

        private void txtEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var funciones = new CNNatur();
            if (txtEliminar.Text == "0") return;
            if (MessageBox.Show("¿Desea eliminar el registro?", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CENatur cliente = new CENatur();
                cliente.clidocumento = int.Parse(txtEliminar.Text);
                cnNatur.Deletearclientes(cliente);

                txtEliminar.DataSource = funciones.ListarDatosCLiente();
                txtEliminar.DisplayMember = "cliDocumento";
            }
            txtEliminar.DataSource = funciones.ListarDatosCLiente();
            txtEliminar.DisplayMember = "cliDocumento";
        }
    
        private void LimpiarForm()
        {
            txtDocumentoCli.Text = string.Empty;
            txtNombreCli.Text = string.Empty;
            txtTelefonoCli.Text = string.Empty;
            txtCorreoCli.Text = string.Empty;
            txtDireccionCli.Text = string.Empty;
        }

        private void btnGuardarCli_Click(object sender, EventArgs e)
        {
            bool resultado;
            CENatur cliennte = new CENatur();
            resultado = cnNatur.ValidarDatos(cliennte);
            cliennte.clidocumento = int.Parse(txtDocumentoCli.Text);
            cliennte.cliNombre = txtNombreCli.Text;
            cliennte.cliDireccion = txtNombreCli.Text;
            cliennte.cliTelefono = (txtTelefonoCli.Text);
            cliennte.cliCorreo = txtCorreoCli.Text;
            if (cliennte.clidocumento> 0)
            {
                cnNatur.GuardarDatos(cliennte);
                LimpiarForm();
            }
            else
            {
                MessageBox.Show("El campo codigo es invalido");
            }

        }

        private void btnConsultarCli_Click(object sender, EventArgs e)
        {
            var funciones = new CNNatur();
            txtActualizar.DataSource = funciones.ListarDatosCLiente();
            txtActualizar.DisplayMember = "cliDocumento";
            GridConsultar.Rows.Clear();

            var Tabla = cnNatur.ConsultarDatosCliente();
            var NumeroFilas = Tabla.Rows.Count;
            if (NumeroFilas > 0)
            {
                for (int i = 0; i < NumeroFilas; i++)
                {
                    String Nombre = Tabla.Rows[i][1].ToString();
                    String Documento = Tabla.Rows[i][1].ToString();
                    String Direccion = Tabla.Rows[i][2].ToString();
                    String Telefono = Tabla.Rows[i][3].ToString();
                    String Correo = Tabla.Rows[i][4].ToString();

                    GridConsultar.Rows.Add(Nombre,Documento,Direccion ,Telefono,Correo);
                }

            }
        }
        

        private void btnBuscarCli_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = cnNatur.BuscarDatosCliente(int.Parse(txtActualizar.Text));
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtDocumentoCliAc.Text = reader.GetString(0);
                    txtNombreCliAc.Text = reader.GetString(1);
                    txtDirecCliAC.Text = reader.GetString(2);
                    txttelefonocliac.Text = reader.GetString(3);
                    txtCorreoAc.Text = reader.GetString(4);
                    var funciones = new CNNatur();
                    txtActualizar.DataSource = funciones.ListarDatosCLiente();
                    txtActualizar.DisplayMember = "CliDocumento";
                }
            }
            else
            {
                MessageBox.Show("No se encontro el registro");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var funciones = new CNNatur();
            txtActualizar.DataSource = funciones.ListarDatosCLiente();
            txtActualizar.DisplayMember = "cliDocumento";

            txtEliminar.DataSource = funciones.ListarDatosCLiente();
            txtEliminar.DisplayMember = "cliDocumento";
        }

        private void btnGuardarCambiosCli_Click(object sender, EventArgs e)
        {
            CENatur cliente = new CENatur();
            cliente.clidocumento = int.Parse(txtDocumentoCliAc.Text);
            cliente.cliNombre = txtNombreCliAc.Text;
            cliente.cliDireccion = txtDirecCliAC.Text;
            cliente.cliCorreo = txtCorreoAc.Text;
            cliente.cliTelefono = txttelefonocliac.Text;
            cnNatur.ActualizarDatos(cliente);

            txtDocumentoCliAc.Text = string.Empty;
            txtNombreCliAc.Text = string.Empty;
            txtDirecCliAC.Text = string.Empty;
            txtCorreoAc.Text = string.Empty;
            txttelefonocliac.Text = string.Empty;
        }
    }
    }

