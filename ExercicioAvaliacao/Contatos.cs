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
                addEndereco();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero datetime = true";
                    cnx.Open();
                    string sql;


                    string sqlBusca = "SELECT idEndereco FROM endereco WHERE CEP = '" + txtCEP.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sqlBusca, cnx);
                    cmd.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlBusca, cnx);
                    adapter.Fill(table);
                    string pega;
                    

                    dgw2.DataSource = table;
                    dgw2.AutoGenerateColumns = false;

               // }


                //MessageBox.Show(cmd.);

                    //if (rbMasculino.Checked)
                    //{
                    //    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbMasculino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "')";

                    //}
                    //else
                    //{
                    //    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbFeminino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',(SELECT idEndereco FROM endereco WHERE CEP = '" + txtCEP.Text + "'))";

                    //}
                    //MessageBox.Show("Dados inseridos com sucesso!!!");
                    //MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    //cmd.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Mostrar();

            

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
                    string sql = "insert into endereco (idEndereco,logradouro,cidade,bairro,UF,cep) values ('" + txtID.Text + "','" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','" + txtCEP.Text + "')";
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
                    string sql = "select * from contato";
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

       
    }
}
