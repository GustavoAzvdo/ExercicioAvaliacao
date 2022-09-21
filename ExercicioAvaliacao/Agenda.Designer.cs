namespace ExercicioAvaliacao
{
    partial class Agenda
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdAgenda = new System.Windows.Forms.TextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.rtbDescricao = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgwAgenda = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgenda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição";
            // 
            // txtIdAgenda
            // 
            this.txtIdAgenda.Enabled = false;
            this.txtIdAgenda.Location = new System.Drawing.Point(156, 52);
            this.txtIdAgenda.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdAgenda.Name = "txtIdAgenda";
            this.txtIdAgenda.Size = new System.Drawing.Size(73, 22);
            this.txtIdAgenda.TabIndex = 3;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(648, 110);
            this.dtpData.Margin = new System.Windows.Forms.Padding(4);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(348, 22);
            this.dtpData.TabIndex = 4;
            this.dtpData.Value = new System.DateTime(2021, 9, 25, 0, 0, 0, 0);
            // 
            // rtbDescricao
            // 
            this.rtbDescricao.Location = new System.Drawing.Point(156, 167);
            this.rtbDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDescricao.Name = "rtbDescricao";
            this.rtbDescricao.Size = new System.Drawing.Size(840, 198);
            this.rtbDescricao.TabIndex = 5;
            this.rtbDescricao.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora";
            // 
            // cmbHora
            // 
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Items.AddRange(new object[] {
            "8:00",
            "9:00"});
            this.cmbHora.Location = new System.Drawing.Point(156, 107);
            this.cmbHora.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(148, 24);
            this.cmbHora.TabIndex = 7;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(616, 38);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(325, 22);
            this.txtPesquisar.TabIndex = 14;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // dgwAgenda
            // 
            this.dgwAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAgenda.Location = new System.Drawing.Point(25, 90);
            this.dgwAgenda.Margin = new System.Windows.Forms.Padding(4);
            this.dgwAgenda.Name = "dgwAgenda";
            this.dgwAgenda.RowHeadersWidth = 51;
            this.dgwAgenda.Size = new System.Drawing.Size(920, 166);
            this.dgwAgenda.TabIndex = 13;
            this.dgwAgenda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAgenda_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(615, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "PESQUISAR";
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(425, 27);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(161, 34);
            this.btnDeletar.TabIndex = 0;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(225, 27);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(161, 34);
            this.btnAlterar.TabIndex = 0;
            this.btnAlterar.Text = "ALTERAR";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(25, 27);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(161, 34);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "INSERIR";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPesquisar);
            this.panel1.Controls.Add(this.dgwAgenda);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnInserir);
            this.panel1.Location = new System.Drawing.Point(53, 400);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 276);
            this.panel1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(440, 50);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(557, 22);
            this.txtTitulo.TabIndex = 18;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 709);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbDescricao);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.txtIdAgenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Agenda";
            this.Text = "Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.dgwAgenda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdAgenda;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.RichTextBox rtbDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgwAgenda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitulo;
    }
}