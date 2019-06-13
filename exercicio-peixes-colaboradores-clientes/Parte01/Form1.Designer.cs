namespace Parte01
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPeixes = new System.Windows.Forms.Button();
            this.btnColaboradores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPeixes
            // 
            this.btnPeixes.Location = new System.Drawing.Point(28, 40);
            this.btnPeixes.Name = "btnPeixes";
            this.btnPeixes.Size = new System.Drawing.Size(75, 398);
            this.btnPeixes.TabIndex = 0;
            this.btnPeixes.Text = "Peixes";
            this.btnPeixes.UseVisualStyleBackColor = true;
            this.btnPeixes.Click += new System.EventHandler(this.btnPeixes_Click);
            // 
            // btnColaboradores
            // 
            this.btnColaboradores.Location = new System.Drawing.Point(131, 40);
            this.btnColaboradores.Name = "btnColaboradores";
            this.btnColaboradores.Size = new System.Drawing.Size(86, 398);
            this.btnColaboradores.TabIndex = 1;
            this.btnColaboradores.Text = "Colaboradores";
            this.btnColaboradores.UseVisualStyleBackColor = true;
            this.btnColaboradores.Click += new System.EventHandler(this.btnColaboradores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(240, 40);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(75, 398);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 450);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnColaboradores);
            this.Controls.Add(this.btnPeixes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeixes;
        private System.Windows.Forms.Button btnColaboradores;
        private System.Windows.Forms.Button btnClientes;
    }
}

