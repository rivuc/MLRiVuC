namespace MLRiVuCApp
{
    partial class OpcionesUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            SglOpcionesUsuarios.Instance.Dispose1();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionesUsuarios));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.grvUsuarios = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarios)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Blue;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(472, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 39);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(296, 21);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(147, 20);
            this.txtBusqueda.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por:";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Location = new System.Drawing.Point(142, 20);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(121, 21);
            this.cbBusqueda.TabIndex = 3;
            // 
            // grvUsuarios
            // 
            this.grvUsuarios.AllowUserToAddRows = false;
            this.grvUsuarios.AllowUserToDeleteRows = false;
            this.grvUsuarios.AllowUserToOrderColumns = true;
            this.grvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grvUsuarios.ContextMenuStrip = this.contextMenuStrip1;
            this.grvUsuarios.Location = new System.Drawing.Point(21, 59);
            this.grvUsuarios.MultiSelect = false;
            this.grvUsuarios.Name = "grvUsuarios";
            this.grvUsuarios.ReadOnly = true;
            this.grvUsuarios.Size = new System.Drawing.Size(596, 229);
            this.grvUsuarios.TabIndex = 4;
            this.grvUsuarios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvUsuarios_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAbrir,
            this.mnModificar,
            this.mnEliminar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnAbrir
            // 
            this.mnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("mnAbrir.Image")));
            this.mnAbrir.Name = "mnAbrir";
            this.mnAbrir.Size = new System.Drawing.Size(128, 22);
            this.mnAbrir.Text = "Abrir";
            this.mnAbrir.Click += new System.EventHandler(this.mnAbrir_Click);
            // 
            // mnModificar
            // 
            this.mnModificar.Image = ((System.Drawing.Image)(resources.GetObject("mnModificar.Image")));
            this.mnModificar.Name = "mnModificar";
            this.mnModificar.Size = new System.Drawing.Size(128, 22);
            this.mnModificar.Text = "Modificar";
            this.mnModificar.Click += new System.EventHandler(this.mnModificar_Click);
            // 
            // mnEliminar
            // 
            this.mnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("mnEliminar.Image")));
            this.mnEliminar.Name = "mnEliminar";
            this.mnEliminar.Size = new System.Drawing.Size(128, 22);
            this.mnEliminar.Text = "Eliminar";
            this.mnEliminar.Click += new System.EventHandler(this.mnEliminar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // OpcionesUsuarios
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 302);
            this.Controls.Add(this.grvUsuarios);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OpcionesUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Usuarios";
            this.Load += new System.EventHandler(this.OpcionesUsuarios_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpcionesUsuarios_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarios)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.DataGridView grvUsuarios;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnAbrir;
        private System.Windows.Forms.ToolStripMenuItem mnModificar;
        private System.Windows.Forms.ToolStripMenuItem mnEliminar;
    }
}