
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class Contatos : Form
    {
        public Contatos()
        {
            InitializeComponent();
            Mostrar();

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            Data();

            try
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero datetime = true";
                        cnx.Open();
                        string sql;
                        if (rbMasculino.Checked)
                        {
                            sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbMasculino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP = "+txtCEP.Text+" limit 1))";

                        }
                        else
                        {
                            sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbFeminino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP =  "+txtCEP.Text+" limit 1))";

                        }
                        MessageBox.Show("Dados pessoais inseridos com sucesso!!!");
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                try
                {
                    addEndereco();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Mostrar();
            Limpar();

            

        }

        private void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            Telefones telefone = new Telefones();
            telefone.Show();
        }

        void Data()
        {
            ClasseData.Data = dtpData.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void addEndereco()
        {

            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero Datetime = true";
                    cnx.Open();
                    string sql = "insert into endereco (logradouro,cidade,bairro,UF,cep) values ('" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','"+txtCEP.Text+"')";
                    MessageBox.Show("Endereco adicionado com sucesso !!!");
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
                    string sql = "select idContato,nome,cpf,dataNascimento,email,sexo,cep,logradouro,numeroCasa,complemento,bairro,cidade,uf from endereco inner join contato on endereco.idEndereco = contato.fkEndereco";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContatos.DataSource = table;
                    dgwContatos.AutoGenerateColumns = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCEP.Text;


                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select logradouro,bairro,cidade,uf from endereco where cep = '" + cep + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if ( reader.Read() )
                    {

                        string logradouro = reader["logradouro"].ToString();
                        txtLogradouro.Text = logradouro;
                        string bairro = reader["bairro"].ToString();
                        txtBairro.Text = bairro;
                        string cidade = reader["cidade"].ToString();
                        txtCidade.Text = cidade;
                        string uf = reader["uf"].ToString();
                        cmbUF.Text = uf;

                        txtLogradouro.Enabled = false;
                        txtBairro.Enabled = false;
                        txtCidade.Enabled = false;
                        cmbUF.Enabled = false;
                    }
                    else
                    {
                        txtLogradouro.Clear();
                        txtBairro.Clear();
                        txtCidade.Clear();
                        cmbUF.Text = null;
                        txtLogradouro.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCidade.Enabled = true;
                        cmbUF.Enabled = true;
                    }
                }


            }
            catch
            {

            }
        }

        void Limpar()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCPF.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            cmbUF.Text = null;
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
            txtNumeroCasa.Clear();
            txtID.Clear();
            txtComplemento.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
