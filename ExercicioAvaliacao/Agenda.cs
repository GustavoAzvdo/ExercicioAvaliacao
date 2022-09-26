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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
            Mostrar();                                          //
            btnAlterar.Visible = false;                         // Comandos que vão ser inicializados junto com o código.
            btnDeletar.Visible = false;                         //

        }
        

        string continua = "yes";                                // variavel ja começa com o valor 'yes'.    
        private void btnInserir_Click(object sender, EventArgs e)
        {

            Data();                                             // Metodo que le a data e transforma ela do jeito que o MySql aceita.
            verificaVazio();                                    // Verifica se os campos estão preenchidos.

            if(btnInserir.Text == "INSERIR" && continua == "yes")
            {
                if(MessageBox.Show("Deseja realmente inserir?","INSERIR",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {

                        using (MySqlConnection cnx = new MySqlConnection())
                        {
                            cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306";
                            cnx.Open();
                            string sql = "insert into agenda (titulo,hora,data,descricao) values ('" + txtTitulo.Text + "','" + cmbHora.Text + "','" + ClasseData.DataNova + "','" + rtbDescricao.Text + "')";
                            MessageBox.Show("Inserido com sucesso!");                                                                            //Variavel global da data nova.
                            MySqlCommand cmd = new MySqlCommand(sql, cnx);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                
                
            }
            Mostrar();
            Limpar();                //Depois de inserir os dados, os campos se limpam.
        }
        void Mostrar()              //Mostrar os dados da tabela agenda do banco 
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)                                  //Método de double click no valor da tabela ir nos campos.
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString(); 
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());                        //Conversão de variavel para o DateTime.
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();

                btnInserir.Text = "ADD NEW";    
                btnDeletar.Visible = true;      
                btnAlterar.Visible = true;
                txtPesquisar.Clear();        
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)       //Alterar dados do banco da tabela agenda.
        {
            Data();

            if(MessageBox.Show("Deseja realmente Alterar?","ALTERAR",MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update agenda set hora = '" + cmbHora.Text + "',titulo = '" + txtTitulo.Text + "', descricao = '" + rtbDescricao.Text + "', data = '" + ClasseData.DataNova + "' where idAgenda = '" + txtIdAgenda.Text + "'";         //Alterar dados da tabela 'agenda' onde o idAgenda seja igual ao textBox.
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
            Mostrar();
            
        }

        private void btnDeletar_Click(object sender, EventArgs e)                       //Deletar dados da tabela agenda do banco. 
        {
            if(MessageBox.Show("Deseja realmente deletar?","Deletar",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";          //Comando do MySql que vai deletar a coluna do banco onde o ID seja igual ao textBox.
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
        
        void verificaVazio()                        //Se algum dos campos estiverem vazios, ele irá falar pra você preencher os campos.
        {
            if (cmbHora.Text == "" || txtTitulo.Text == "" || rtbDescricao.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }
        void Limpar()                               //Metodo que limpa os campos depois de inserir/deletar algum dado.
        {
            
            txtIdAgenda.Clear();
            txtTitulo.Clear();
            rtbDescricao.Clear();
            txtPesquisar.Clear();
            cmbHora.Text = "";

            btnInserir.Text = "INSERIR";        
            btnDeletar.Visible = false;         
            btnAlterar.Visible = false;


        }
        void Data()                                 //Método que pega a data e modifica para o MySql ler.
        {
            ClasseData.Data = dtpData.Value;
            string dataCurta = ClasseData.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            ClasseData.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";
        }


        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            
            string pesquisa = txtPesquisar.Text;
            var i = pesquisa;
          
            if (i == pesquisa)
            {
                try
                {
                
                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "select * from agenda where titulo like '" + txtPesquisar.Text + "%'";         //Ele vai pesquisar por 'titulo' e vai pegar todos os campos que começam pela letra que está no textBox.
                        DataTable table = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                        adapter.Fill(table);
                        dgwAgenda.DataSource = table;
                        dgwAgenda.AutoGenerateColumns = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }

        }

    }
}
