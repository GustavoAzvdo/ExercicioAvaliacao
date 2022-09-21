using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class ContasPagar : Form
    {
        public ContasPagar()
        {
            InitializeComponent();
            Mostrar();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }

        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {
            verificaVazio();
            Data();

            if(btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if (MessageBox.Show("Deseja realmente inserir?", "INSERIR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection cnx = new MySqlConnection())
                        {
                            cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                            cnx.Open();
                            string sql;

                            if (cbPagar.Checked)
                            {
                                sql = "insert into contas (nome,descricao,valor,dataVencimento,situacao,pago_recebido,tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + ClasseData.DataNova + "','" + cbPagar.Text + "','N/E','" + txtTipo.Text + "')";
                            }
                            else
                            {
                                sql = "insert into contas (nome,descricao,valor,dataVencimento,situacao,pago_recebido,tipo) values ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + ClasseData.DataNova + "','" + cbReceber.Text + "','N/E','" + txtTipo.Text + "')";
                            }

                            MessageBox.Show("Inserido com sucesso!");
                            MySqlCommand cmd = new MySqlCommand(sql, cnx);
                            cmd.ExecuteNonQuery();


                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Mostrar();
                    Limpar();
                }

                    
            }
          
        }
        

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Data();

            if (MessageBox.Show("Deseja realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set nome = '" + txtNome.Text + "',descricao = '" + txtDescricao.Text + "',valor = '" + txtValor.Text + "',tipo = '" + txtTipo.Text + "', dataVencimento = '" + ClasseData.DataNova + "' where idContasPagar = '" + txtIdContas.Text + "'";
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
                        string sql = "delete from contas where idContasPagar = '" + txtIdContas.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado com sucesso!");

                    }
                    Limpar();
                    Mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        void Mostrar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContas.DataSource = table;
                    dgwContas.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContas.CurrentRow.Index != -1)
            {
                txtIdContas.Text = dgwContas.CurrentRow.Cells[0].Value.ToString();
                txtDescricao.Text = dgwContas.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = dgwContas.CurrentRow.Cells[2].Value.ToString();  
                txtValor.Text = dgwContas.CurrentRow.Cells[3].Value.ToString(); 
                txtTipo.Text = dgwContas.CurrentRow.Cells[4].Value.ToString();  
                //cbPagar.Text = dgwContas.CurrentRow.Cells[5].Value.ToString();  
                //cbReceber.Text = dgwContas.CurrentRow.Cells[6].Value.ToString();
                //dtpData.Value = Convert.ToDateTime(dgwContas.CurrentRow.Cells[7].Value.ToString());

                btnInserir.Text = "ADD NEW";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                
            }
        }
        void Data()
        {
            ClasseData.Data = dtpData.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void Limpar()
        {
            txtIdContas.Clear();
            txtDescricao.Clear();
            txtNome.Clear();
            txtTipo.Clear();
            txtValor.Clear();
            cbPagar.Checked = false;
            cbReceber.Checked = false;

            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
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
    }
}
