
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
            MostrarTelefone();          //Inicializa mostrando a tabela de telefones cadastrados.
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
            btnAtualizar.Visible = false;

        }
        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {

            Data();
            verificaVazio();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if(MessageBox.Show("Deseja realmente inserir?", "INSERIR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        try
                        {
                            addEndereco(); //Metodo que usa o insert para cadastrar o endereco no banco.
                            using (MySqlConnection cnx = new MySqlConnection())
                            {
                                cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero datetime = true";
                                cnx.Open();
                                string sql;
                                if (rbMasculino.Checked)
                                {
                                    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbMasculino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP = " + txtCEP.Text + " limit 1))"; //Ele pega o numero do idEndereco e joga no fkEndereco, onde o CEP for igual ao cadastrado no banco.(O LIMIT 1 serve para ele trazer somente um valor, evitando erros e bugs).
                                    //Se o sexo estiver marcado como masculino ele executara essa linha
                                }
                                else
                                {
                                    sql = "insert into contato (nome,cpf,dataNascimento,email,sexo,numeroCasa,complemento,fkEndereco) values ('" + txtNome.Text + "','" + txtCPF.Text + "','" + ClasseData.DataNova + "','" + txtEmail.Text + "','" + rbFeminino.Text + "','" + txtNumeroCasa.Text + "','" + txtComplemento.Text + "',( select idEndereco from endereco where  CEP =  " + txtCEP.Text + " limit 1))"; //Ele pega o numero do idEndereco e joga no fkEndereco, onde o CEP for igual ao cadastrado no banco.(O LIMIT 1 serve para ele trazer somente um valor, evitando erros e bugs).
                                    //Se não ele executara essa;
                                }
                                MessageBox.Show("Dados inseridos com sucesso!!!");
                                MySqlCommand cmd = new MySqlCommand(sql, cnx);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                
            }
            Mostrar();
            Limpar();

        }

        private void btnCadastrarTelefone_Click(object sender, EventArgs e)        //Ele mostrará o form de cadastrar telefone transferindo o valor do txtID pro form de cadastro.
        {
          

            Telefones telefone = new Telefones(txtID.Text);
            telefone.Show();
            btnAtualizar.Visible = true; 

          
        }

        void Data()
        {
            ClasseData.Data = dtpData.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }
        void addEndereco()                  //Metodo que insere o endereco no banco
        {

            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero Datetime = true";
                    cnx.Open();
                    string sql = "insert into endereco (logradouro,cidade,bairro,UF,cep) values ('" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','"+txtCEP.Text+"')";
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

       

        private void txtCEP_TextChanged(object sender, EventArgs e) //Metodo que será feito quando o texto entrar no textBox.
        {
            try
            {
                string cep = txtCEP.Text; //O txt entra numa variavel.


                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select logradouro,bairro,cidade,uf from endereco where cep = '" + cep + "'"; //Essa string mostrara os dados da tabela endereco onde o CEP condiz com os dados.
                    MySqlCommand cmd = new MySqlCommand(sql, cnx);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if ( reader.Read() )      //Esse comanddo pega a execução da string acima  e separa cada valor em uma variavel que vai entrar em seu textBox respectivamente.
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
                        txtNumeroCasa.Clear();
                    }
                    else    //Se o CEP nao existir ele limpará os textBoxs e liberando eles para a digitação.
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpar()       //Limpa os rbs e txts do form.
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

            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }

        void verificaVazio()
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtCPF.Text == "" || txtCEP.Text == "" || txtLogradouro.Text == "" || txtCidade.Text == "" || cmbUF.Text == "" || txtBairro.Text == "" || txtNumeroCasa.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
           
            Data();

            if (MessageBox.Show("Deseja realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "insert into endereco (logradouro,cidade,bairro,UF,cep) values ('" + txtLogradouro.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cmbUF.Text + "','" + txtCEP.Text + "')"; //Esse comando faz que ao alterar o endereco da pessoa, o antigo não seja excluido, permanecendo os dados no banco
                        txtLogradouro.Enabled = false;
                        txtBairro.Enabled = false;
                        txtCidade.Enabled = false;
                        cmbUF.Enabled = false;
                        string sql3;  //Essa string verifica qual Radio Button está checkado para assim mudar a string e verificar se é Masculino ou Feminino, adicionando o sexo na tabela.
                        if (rbMasculino.Checked)
                        {
                            sql3 = "update contato set nome = '" + txtNome.Text + "',email = '" + txtEmail.Text + "', CPF = '" + txtCPF.Text + "', dataNascimento = '" + ClasseData.DataNova + "', sexo = '" + rbMasculino.Text + "' ,numeroCasa = '" + txtNumeroCasa.Text + "', complemento = '" + txtComplemento.Text + "', fkEndereco = ( select idEndereco from endereco where  CEP = '" + txtCEP.Text + "' limit 1) where idContato = '" + txtID.Text + "'";
                        }
                        else
                        {
                            sql3 = "update contato set nome = '" + txtNome.Text + "',email = '" + txtEmail.Text + "', CPF = '" + txtCPF.Text + "', dataNascimento = '" + ClasseData.DataNova + "', sexo = '" + rbFeminino.Text + "',numeroCasa = '" + txtNumeroCasa.Text + "', complemento = '" + txtComplemento.Text + "', fkEndereco = ( select idEndereco from endereco where  CEP = '" + txtCEP.Text + "' limit 1) where idContato = '" + txtID.Text + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);              // 
                        cmd.ExecuteNonQuery();                                      //  Comando que executará as strings 
                        MySqlCommand cmd3 = new MySqlCommand(sql3, cnx);            //
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Mostrar();

        }

        private void dgwContatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Metodo que pega os dados da tabela e joga nos textBoxs
        {
            if (dgwContatos.CurrentRow.Index != -1)
            {
                txtID.Text = dgwContatos.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContatos.CurrentRow.Cells[1].Value.ToString();
                txtCPF.Text = dgwContatos.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwContatos.CurrentRow.Cells[3].Value.ToString());
                txtEmail.Text = dgwContatos.CurrentRow.Cells[4].Value.ToString();
                rbMasculino.Text = dgwContatos.CurrentRow.Cells[5].Value.ToString();
                string masculino = rbMasculino.Text;

                if (masculino == "Masculino")
                {
                    rbMasculino.Checked = true;
                    rbFeminino.Checked = false;

                }
                else
                {
                    rbMasculino.Text = "Masculino";
                    rbFeminino.Checked = true;
                    rbMasculino.Checked = false;
                }
                txtCEP.Text = dgwContatos.CurrentRow.Cells[6].Value.ToString();
                txtLogradouro.Text = dgwContatos.CurrentRow.Cells[7].Value.ToString();
                txtNumeroCasa.Text = dgwContatos.CurrentRow.Cells[8].Value.ToString();
                txtComplemento.Text = dgwContatos.CurrentRow.Cells[9].Value.ToString();
                txtBairro.Text = dgwContatos.CurrentRow.Cells[10].Value.ToString();
                txtCidade.Text = dgwContatos.CurrentRow.Cells[11].Value.ToString();  
                cmbUF.Text =  dgwContatos.CurrentRow.Cells[12].Value.ToString();

                btnInserir.Text = "ADD NEW";
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                
            }
            MostrarTelefone();  
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
                        string sql = "delete from contato where idContato = '" + txtID.Text + "'"; //Deleta os dados do idContato.
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {

                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contato where nome like '" + txtPesquisar.Text + "%'"; //Foi usado o like para a pesquisa por nomes.
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
        void MostrarTelefone()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select DDD,numero,operadora from telefone inner join contato where contato.idContato = telefone.fkContato and idContato = '"+txtID.Text+"'"; //Mostra a tabela de telefones cadastrados, fazendo que cada Id mostre o telefone cadastrado no mesmo
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwTelefones.DataSource = table;
                    dgwTelefones.AutoGenerateColumns = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MostrarTelefone();
            btnAtualizar.Visible = false;

        }

        private void dgwTelefones_MouseDown(object sender, MouseEventArgs e)
        {
            MostrarTelefone();
        }
    }
}
