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
            Mostrar();
            btnAlterar.Visible = false;            
            btnDeletar.Visible = false;

        }
        

        string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {

            Data();
            verificaVazio();

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
                
                
            }
            Mostrar();
            Limpar();
        }
        void Mostrar()
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

        private void dgwAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString(); 
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();

                btnInserir.Text = "ADD NEW";    
                btnDeletar.Visible = true;      
                btnAlterar.Visible = true;
                txtPesquisar.Clear();        
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
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
                        string sql = "update agenda set hora = '" + cmbHora.Text + "',titulo = '" + txtTitulo.Text + "', descricao = '" + rtbDescricao.Text + "', data = '" + ClasseData.DataNova + "' where idAgenda = '" + txtIdAgenda.Text + "'";
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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente deletar?","Deletar",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";
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
        
        void verificaVazio()
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
        void Limpar()
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
        void Data()
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
                        string sql = "select * from agenda where titulo like '" + txtPesquisar.Text + "%'";
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
