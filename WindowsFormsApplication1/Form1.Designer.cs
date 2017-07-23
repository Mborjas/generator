namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("MantenimientoProcedure");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Procedure", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ClaseNegocio");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Negocio", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("InterfaceDao");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("SqlServer_Tabla_Dao");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("BeanEntidad");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("DAO", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("MantenimientoGUI");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("CrearTable");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("CrearGrid");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("GUI", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            this.cmbTablasBD = new System.Windows.Forms.ComboBox();
            this.cmbTablasBD2 = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbTipoBDDATOS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTablasBD
            // 
            this.cmbTablasBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablasBD.FormattingEnabled = true;
            this.cmbTablasBD.Location = new System.Drawing.Point(568, 18);
            this.cmbTablasBD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTablasBD.Name = "cmbTablasBD";
            this.cmbTablasBD.Size = new System.Drawing.Size(318, 28);
            this.cmbTablasBD.TabIndex = 0;
            // 
            // cmbTablasBD2
            // 
            this.cmbTablasBD2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablasBD2.FormattingEnabled = true;
            this.cmbTablasBD2.Location = new System.Drawing.Point(568, 77);
            this.cmbTablasBD2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTablasBD2.Name = "cmbTablasBD2";
            this.cmbTablasBD2.Size = new System.Drawing.Size(318, 28);
            this.cmbTablasBD2.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label2.Location = new System.Drawing.Point(488, 23);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 35);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Tabla";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(18, 129);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "MantenimientoProcedure";
            treeNode1.Text = "MantenimientoProcedure";
            treeNode2.Name = "Procedure";
            treeNode2.Text = "Procedure";
            treeNode3.Name = "ClaseNegocio";
            treeNode3.Text = "ClaseNegocio";
            treeNode4.Name = "Nodo1";
            treeNode4.Text = "Negocio";
            treeNode5.Name = "InterfaceDao";
            treeNode5.Text = "InterfaceDao";
            treeNode6.Name = "SqlServer_Tabla_Dao";
            treeNode6.Text = "SqlServer_Tabla_Dao";
            treeNode7.Name = "BeanEntidad";
            treeNode7.Text = "BeanEntidad";
            treeNode8.Name = "Nodo2";
            treeNode8.Text = "DAO";
            treeNode9.Name = "MantenimientoGUI";
            treeNode9.Text = "MantenimientoGUI";
            treeNode10.Name = "CrearTable";
            treeNode10.Text = "CrearTable";
            treeNode11.Name = "CrearGrid";
            treeNode11.Text = "CrearGrid";
            treeNode12.Name = "GUI";
            treeNode12.Text = "GUI";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode8,
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(270, 522);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(298, 129);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(679, 522);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // cmbTipoBDDATOS
            // 
            this.cmbTipoBDDATOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoBDDATOS.FormattingEnabled = true;
            this.cmbTipoBDDATOS.Items.AddRange(new object[] {
            "(Seleccione)",
            "SQL SERVER"});
            this.cmbTipoBDDATOS.Location = new System.Drawing.Point(174, 46);
            this.cmbTipoBDDATOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoBDDATOS.Name = "cmbTipoBDDATOS";
            this.cmbTipoBDDATOS.Size = new System.Drawing.Size(180, 28);
            this.cmbTipoBDDATOS.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Base de datos";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(479, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 35);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tabla 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 654);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoBDDATOS);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbTablasBD2);
            this.Controls.Add(this.cmbTablasBD);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTablasBD;
        private System.Windows.Forms.ComboBox cmbTablasBD2;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cmbTipoBDDATOS;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
    }
}

