using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DLL_MAPEO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdministradorTablas objAdministradorTablas1 = new AdministradorTablas();
            this.cmbTablasBD.DataSource = objAdministradorTablas1.ListarTabla();
            this.cmbTablasBD.DisplayMember="Nombre";
            this.cmbTablasBD.ValueMember = "Id";

            AdministradorTablas objAdministradorTablas2 = new AdministradorTablas();
            this.cmbTablasBD2.DataSource = objAdministradorTablas2.ListarTabla();
            this.cmbTablasBD2.DisplayMember = "Nombre";
            this.cmbTablasBD2.ValueMember = "Id"; 
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            StringBuilder p_Impresion = new StringBuilder();
            GeneradorCodigo objGeneradorCodigo= new GeneradorCodigo();
            Tabla objTabla = new Tabla(Convert.ToString(this.cmbTablasBD.SelectedValue));
            Tabla objTabla2 = new Tabla(Convert.ToString(this.cmbTablasBD2.SelectedValue));

            consts.TIPO_BASE_DATOS p_TIPO_BASE_DATOS =  consts.TIPO_BASE_DATOS.SQL_SERVER;

            switch (this.treeView1.SelectedNode.Text) 
            {
                case "BeanEntidad":
                    p_Impresion = objGeneradorCodigo.GenerarEntidades(objTabla);
                    break;
                case "InterfaceDao":
                    p_Impresion = objGeneradorCodigo.InterfaceDAO(objTabla);
                    break;
                case "SqlServer_Tabla_Dao":
                    p_Impresion = objGeneradorCodigo.SqlServer_Tabla_DAO(objTabla);
                    break;
                case "ClaseNegocio":
                    p_Impresion = objGeneradorCodigo.Clase_Negocio(objTabla, objTabla2);
                    break;
                case "MantenimientoGUI":
                    p_Impresion = objGeneradorCodigo.Clase_GUI_Mantenimiento(objTabla);
                    break;
                case "MantenimientoProcedure":
                    p_Impresion = objGeneradorCodigo.Clase_GUI_Mantenimiento_Procedure(objTabla, p_TIPO_BASE_DATOS);
                    break;
                case "CrearTable":
                    p_Impresion = objGeneradorCodigo.Clase_GUI_CrearTable(objTabla);
                    break;
                case "CrearGrid":
                    p_Impresion = objGeneradorCodigo.Clase_GUI_CrearGrid(objTabla);
                    break;
                default:
                    break;
            }

            //this.textBox1.Text = p_Impresion.ToString();
            this.richTextBox1.Text = p_Impresion.ToString();
        }



    }
}
