namespace MLRiVuCApp
{
    partial class Transacciones
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
            SglTransacciones.Instance.Dispose1();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transacciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNueva = new System.Windows.Forms.Button();
            this.Compras = new System.Windows.Forms.TabPage();
            this.grvCompras = new System.Windows.Forms.DataGridView();
            this.menVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBusquedaCompras = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusquedaCompras = new System.Windows.Forms.TextBox();
            this.btnBuscarCompras = new System.Windows.Forms.Button();
            this.tbTransacciones = new System.Windows.Forms.TabControl();
            this.Ventas = new System.Windows.Forms.TabPage();
            this.grvVentas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBusquedaVentas = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBusquedaVenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscarVentaCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.Compras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompras)).BeginInit();
            this.menVentas.SuspendLayout();
            this.tbTransacciones.SuspendLayout();
            this.Ventas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sale.png");
            this.imageList1.Images.SetKeyName(1, "buy.png");
            this.imageList1.Images.SetKeyName(2, "New.png");
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueva.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNueva.Image = ((System.Drawing.Image)(resources.GetObject("btnNueva.Image")));
            this.btnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNueva.Location = new System.Drawing.Point(600, 10);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(78, 27);
            this.btnNueva.TabIndex = 1;
            this.btnNueva.Text = "Nuevo";
            this.btnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // Compras
            // 
            this.Compras.Controls.Add(this.grvCompras);
            this.Compras.Controls.Add(this.label2);
            this.Compras.Controls.Add(this.cbBusquedaCompras);
            this.Compras.Controls.Add(this.label3);
            this.Compras.Controls.Add(this.txtBusquedaCompras);
            this.Compras.Controls.Add(this.btnBuscarCompras);
            this.Compras.ImageIndex = 1;
            this.Compras.Location = new System.Drawing.Point(4, 23);
            this.Compras.Name = "Compras";
            this.Compras.Padding = new System.Windows.Forms.Padding(3);
            this.Compras.Size = new System.Drawing.Size(658, 358);
            this.Compras.TabIndex = 1;
            this.Compras.Text = "Compras";
            this.Compras.UseVisualStyleBackColor = true;
            // 
            // grvCompras
            // 
            this.grvCompras.ContextMenuStrip = this.menVentas;
            this.grvCompras.Location = new System.Drawing.Point(15, 69);
            this.grvCompras.MultiSelect = false;
            this.grvCompras.Name = "grvCompras";
            this.grvCompras.ReadOnly = true;
            this.grvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvCompras.Size = new System.Drawing.Size(624, 280);
            this.grvCompras.TabIndex = 15;
            this.grvCompras.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvCompras_CellMouseDown);
            // 
            // menVentas
            // 
            this.menVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menVentas.Name = "menVentas";
            this.menVentas.Size = new System.Drawing.Size(122, 48);
            this.menVentas.Opening += new System.ComponentModel.CancelEventHandler(this.menVentas_Opening);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem.Image")));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.modificarToolStripMenuItem.Text = "Abrir";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Buscar por:";
            // 
            // cbBusquedaCompras
            // 
            this.cbBusquedaCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusquedaCompras.FormattingEnabled = true;
            this.cbBusquedaCompras.Location = new System.Drawing.Point(151, 25);
            this.cbBusquedaCompras.Name = "cbBusquedaCompras";
            this.cbBusquedaCompras.Size = new System.Drawing.Size(121, 21);
            this.cbBusquedaCompras.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 12;
            // 
            // txtBusquedaCompras
            // 
            this.txtBusquedaCompras.Location = new System.Drawing.Point(305, 26);
            this.txtBusquedaCompras.Name = "txtBusquedaCompras";
            this.txtBusquedaCompras.Size = new System.Drawing.Size(147, 20);
            this.txtBusquedaCompras.TabIndex = 11;
            // 
            // btnBuscarCompras
            // 
            this.btnBuscarCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCompras.ForeColor = System.Drawing.Color.Blue;
            this.btnBuscarCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCompras.Image")));
            this.btnBuscarCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarCompras.Location = new System.Drawing.Point(482, 21);
            this.btnBuscarCompras.Name = "btnBuscarCompras";
            this.btnBuscarCompras.Size = new System.Drawing.Size(91, 30);
            this.btnBuscarCompras.TabIndex = 10;
            this.btnBuscarCompras.Text = "Buscar";
            this.btnBuscarCompras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarCompras.UseVisualStyleBackColor = true;
            this.btnBuscarCompras.Click += new System.EventHandler(this.btnBuscarCompras_Click);
            // 
            // tbTransacciones
            // 
            this.tbTransacciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTransacciones.Controls.Add(this.Ventas);
            this.tbTransacciones.Controls.Add(this.Compras);
            this.tbTransacciones.ImageList = this.imageList1;
            this.tbTransacciones.Location = new System.Drawing.Point(12, 20);
            this.tbTransacciones.Name = "tbTransacciones";
            this.tbTransacciones.SelectedIndex = 0;
            this.tbTransacciones.Size = new System.Drawing.Size(666, 385);
            this.tbTransacciones.TabIndex = 0;
            this.tbTransacciones.Tag = "";
            // 
            // Ventas
            // 
            this.Ventas.AccessibleDescription = "";
            this.Ventas.AccessibleName = "";
            this.Ventas.Controls.Add(this.grvVentas);
            this.Ventas.Controls.Add(this.label1);
            this.Ventas.Controls.Add(this.cbBusquedaVentas);
            this.Ventas.Controls.Add(this.label11);
            this.Ventas.Controls.Add(this.txtBusquedaVenta);
            this.Ventas.Controls.Add(this.btnBuscar);
            this.Ventas.ImageIndex = 0;
            this.Ventas.Location = new System.Drawing.Point(4, 23);
            this.Ventas.Name = "Ventas";
            this.Ventas.Padding = new System.Windows.Forms.Padding(3);
            this.Ventas.Size = new System.Drawing.Size(658, 358);
            this.Ventas.TabIndex = 0;
            this.Ventas.Text = "Ventas";
            this.Ventas.UseVisualStyleBackColor = true;
            // 
            // grvVentas
            // 
            this.grvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grvVentas.ContextMenuStrip = this.menVentas;
            this.grvVentas.Location = new System.Drawing.Point(15, 69);
            this.grvVentas.MultiSelect = false;
            this.grvVentas.Name = "grvVentas";
            this.grvVentas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grvVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvVentas.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvVentas.Size = new System.Drawing.Size(624, 280);
            this.grvVentas.TabIndex = 9;
            this.grvVentas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvVentas_CellMouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buscar por:";
            // 
            // cbBusquedaVentas
            // 
            this.cbBusquedaVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusquedaVentas.FormattingEnabled = true;
            this.cbBusquedaVentas.Location = new System.Drawing.Point(151, 25);
            this.cbBusquedaVentas.Name = "cbBusquedaVentas";
            this.cbBusquedaVentas.Size = new System.Drawing.Size(121, 21);
            this.cbBusquedaVentas.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 6;
            // 
            // txtBusquedaVenta
            // 
            this.txtBusquedaVenta.Location = new System.Drawing.Point(305, 26);
            this.txtBusquedaVenta.Name = "txtBusquedaVenta";
            this.txtBusquedaVenta.Size = new System.Drawing.Size(147, 20);
            this.txtBusquedaVenta.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Blue;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(482, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBuscarVentaCompra
            // 
            this.btnBuscarVentaCompra.Location = new System.Drawing.Point(553, 49);
            this.btnBuscarVentaCompra.Name = "btnBuscarVentaCompra";
            this.btnBuscarVentaCompra.Size = new System.Drawing.Size(114, 23);
            this.btnBuscarVentaCompra.TabIndex = 2;
            this.btnBuscarVentaCompra.Text = "BuscarVentaCompra";
            this.btnBuscarVentaCompra.UseVisualStyleBackColor = true;
            this.btnBuscarVentaCompra.Click += new System.EventHandler(this.btnBuscarVentaCompra_Click);
            // 
            // Transacciones
            // 
            this.AcceptButton = this.btnBuscarVentaCompra;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 417);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.tbTransacciones);
            this.Controls.Add(this.btnBuscarVentaCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Transacciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Transacciones";
            this.Load += new System.EventHandler(this.Transacciones_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Transacciones_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.Compras.ResumeLayout(false);
            this.Compras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompras)).EndInit();
            this.menVentas.ResumeLayout(false);
            this.tbTransacciones.ResumeLayout(false);
            this.Ventas.ResumeLayout(false);
            this.Ventas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.TabControl tbTransacciones;
        private System.Windows.Forms.TabPage Ventas;
        private System.Windows.Forms.ComboBox cbBusquedaVentas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBusquedaVenta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage Compras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grvVentas;
        private System.Windows.Forms.DataGridView grvCompras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBusquedaCompras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusquedaCompras;
        private System.Windows.Forms.Button btnBuscarCompras;
        private System.Windows.Forms.ContextMenuStrip menVentas;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Button btnBuscarVentaCompra;
    }
}