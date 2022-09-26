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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void telefoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Telefones telefones = new Telefones();      //Ele vai para o campo telefone.
            telefones.MdiParent = this; 
            telefones.Show();
        }

        private void telefoneToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PesquisaTelefones pesquisaTelefone = new PesquisaTelefones();
            pesquisaTelefone.MdiParent = this;          //Ele vai para o campo de pesquisa por telefones.
            pesquisaTelefone.Show();
        }

        private void tarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.MdiParent = this;                    //Ele vai para o campo da agenda.
            agenda.Show();
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContasPagar contasPagar = new ContasPagar();
            contasPagar.MdiParent = this;               //Ele vai para o campo de contas a pagar.
            contasPagar.Show();
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContasReceber contasReceber = new ContasReceber();  
            contasReceber.MdiParent = this;             //Ele vai para o campo de contas a receber.
            contasReceber.Show();
        }

        private void contasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleContas controleContas = new ControleContas();
            controleContas.MdiParent = this;            //Ele vai para o campo de controle de contas.
            controleContas.Show();
        }


        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contatos contato = new Contatos();
            contato.MdiParent = this;                  //Ele vai para o campo de contato.
            contato.Show();
        }
    }
}
