﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExercicioAvaliacao
{
    public partial class ContasReceber : Form
    {
        public ContasReceber()
        {
            InitializeComponent();
            MostrarReceber();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }
        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {
            verificaVazio();
            Data();                                                         //Método de data onde ele vai pegar a data e transforma-la para o MySql poder ler.

            if (btnInserir.Text == "INSERIR" && continua == "yes")          //Se ambas as condições forem verdadeiras, ele continuará o código.
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "insert into contas (nome,descricao,valor,dataVencimento,situacao,pago_recebido,tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + ClasseData.DataNova + "','Receber','N/E','" + txtTipo.Text + "')";         //Inserir dados na tabela 'contas'.
                        MessageBox.Show("Inserido com sucesso!");
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
            MostrarReceber();           //
            Limpar();                   // Depois de inserido ele limpa os campos e mostra a tabela atualizada.

        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente deletar?", "Deletar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "delete from contas where idContasPagar = '" + txtIdContas.Text + "'";         //Deleta a columna da tabela 'contas'.
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");

                    }
                    Limpar();
                    MostrarReceber();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            verificaVazio();
            Data();


            if (MessageBox.Show("Deseja realmente alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set nome = '" + txtNome.Text + "',descricao = '" + txtDescricao.Text + "',valor = '" + txtValor.Text + "',tipo = '" + txtTipo.Text + "', dataVencimento = '" + ClasseData.DataNova + "' where idContasPagar = '" + txtIdContas.Text + "'";  //Alterar os dados
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            MostrarReceber();

           

        }
        void Limpar()                   //Limpa os textBox 
        {
            txtIdContas.Clear();
            txtDescricao.Clear();
            txtNome.Clear();
            txtTipo.Clear();
            txtValor.Clear();


            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
        void MostrarReceber()                   //Esse metodo vai mostrar na dgw os dados da tabela 'contas' com uma condição;
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where situacao = 'Receber'";      //Vai mostrar os dados onde a situação seja igual a 'Receber'.
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContasReceber.DataSource = table;
                    dgwContasReceber.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Data()
        {
            ClasseData.Data = dtpDataVencimento.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void verificaVazio()
        {
            if (txtNome.Text == "" || txtDescricao.Text == "" || txtValor.Text == "" || txtTipo.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }
        private void dgwContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)          //Levar os dados do banco para o textBox definido
        {
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContas.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasReceber.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasReceber.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasReceber.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasReceber.CurrentRow.Cells[4].Value.ToString());
                cbRecebido.Text = dgwContasReceber.CurrentRow.Cells[7].Value.ToString();
                txtTipo.Text = dgwContasReceber.CurrentRow.Cells[8].Value.ToString();

                string recebido = cbRecebido.Text;

                if (recebido == "Recebido")
                {
                    cbRecebido.Checked = true;                                                      //Condição que vai checkar se no banco estiver escrito 'Recebido', se não ele mudará a condição.

                }
                else if (recebido == "N/E")
                {
                    cbRecebido.Text = "Recebido";
                    cbRecebido.Checked = false;
                }
                btnInserir.Text = "ADD NEW";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;

            }
        }


    }
}
