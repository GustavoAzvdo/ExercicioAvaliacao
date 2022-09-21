namespace ExercicioAvaliacao
{
    partial class ControleContas
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
            this.dgwContasPagar = new System.Windows.Forms.DataGridView();
            this.dgwContasReceber = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnContasPagar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdContas = new System.Windows.Forms.TextBox();
            this.txtPesquisa2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwContasPagar
            // 
            this.dgwContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasPagar.Location = new System.Drawing.Point(44, 59);
            this.dgwContasPagar.Margin = new System.Windows.Forms.Padding(4);
            this.dgwContasPagar.Name = "dgwContasPagar";
            this.dgwContasPagar.RowHeadersWidth = 51;
            this.dgwContasPagar.Size = new System.Drawing.Size(667, 172);
            this.dgwContasPagar.TabIndex = 0;
            this.dgwContasPagar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasPagar_CellDoubleClick);
            // 
            // dgwContasReceber
            // 
            this.dgwContasReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasReceber.Location = new System.Drawing.Point(44, 269);
            this.dgwContasReceber.Margin = new System.Windows.Forms.Padding(4);
            this.dgwContasReceber.Name = "dgwContasReceber";
            this.dgwContasReceber.RowHeadersWidth = 51;
            this.dgwContasReceber.Size = new System.Drawing.Size(667, 172);
            this.dgwContasReceber.TabIndex = 1;
            this.dgwContasReceber.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasReceber_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contas à Pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contas à Receber";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(731, 59);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(159, 36);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.Location = new System.Drawing.Point(731, 269);
            this.btnReceber.Margin = new System.Windows.Forms.Padding(4);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(159, 36);
            this.btnReceber.TabIndex = 4;
            this.btnReceber.Text = "RECEBER";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnContasPagar
            // 
            this.btnContasPagar.Location = new System.Drawing.Point(861, 463);
            this.btnContasPagar.Margin = new System.Windows.Forms.Padding(4);
            this.btnContasPagar.Name = "btnContasPagar";
            this.btnContasPagar.Size = new System.Drawing.Size(159, 36);
            this.btnContasPagar.TabIndex = 4;
            this.btnContasPagar.Text = "Contas a Pagar";
            this.btnContasPagar.UseVisualStyleBackColor = true;
            this.btnContasPagar.Click += new System.EventHandler(this.btnContasPagar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(44, 465);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(159, 34);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(940, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // txtIdContas
            // 
            this.txtIdContas.Location = new System.Drawing.Point(981, 69);
            this.txtIdContas.Name = "txtIdContas";
            this.txtIdContas.Size = new System.Drawing.Size(53, 22);
            this.txtIdContas.TabIndex = 8;
            // 
            // txtPesquisa2
            // 
            this.txtPesquisa2.Location = new System.Drawing.Point(822, 317);
            this.txtPesquisa2.Name = "txtPesquisa2";
            this.txtPesquisa2.Size = new System.Drawing.Size(212, 22);
            this.txtPesquisa2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(738, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "PESQUISA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(738, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "PESQUISA:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(822, 99);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(212, 22);
            this.txtPesquisa.TabIndex = 9;
            // 
            // ControleContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 548);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.txtPesquisa2);
            this.Controls.Add(this.txtIdContas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.btnContasPagar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwContasReceber);
            this.Controls.Add(this.dgwContasPagar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControleContas";
            this.Text = "ControleContas";
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwContasPagar;
        private System.Windows.Forms.DataGridView dgwContasReceber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnContasPagar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdContas;
        private System.Windows.Forms.TextBox txtPesquisa2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPesquisa;
    }
}