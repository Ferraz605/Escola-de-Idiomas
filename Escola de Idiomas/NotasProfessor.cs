using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_de_Idiomas
{
	public partial class NotasProfessor : Form
	{
		NotasSalas notasSalas;
		CadastrarNotas cadastrarNotas;
		ExcluirNotas excluirNotas;
		AtualizarNotas atualizarNotas;
		DAONotas daoNotas;
		public NotasProfessor()
		{
			InitializeComponent();
			daoNotas = new DAONotas();

			// botão 1
			button1.FlatStyle = FlatStyle.Flat;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = button1.BackColor; // mantém a cor original no hover
			button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button1.Text = "";
			ArredondarBotao(button1, 40);

			// botão 2
			button2.FlatStyle = FlatStyle.Flat;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatAppearance.MouseOverBackColor = button2.BackColor; // mantém a cor original no hover
			button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button2.Text = "";
			ArredondarBotao(button2, 40);

			// botão 3
			button3.FlatStyle = FlatStyle.Flat;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = button3.BackColor; // mantém a cor original no hover
			button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button3.Text = "";
			ArredondarBotao(button3, 40);

			// botão 4
			button4.FlatStyle = FlatStyle.Flat;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = button4.BackColor; // mantém a cor original no hover
			button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button4.Text = "";
			ArredondarBotao(button4, 40);
		}

		private void ArredondarBotao(System.Windows.Forms.Button botao, int raio)
		{
			GraphicsPath path = new GraphicsPath();

			path.AddArc(0, 0, raio, raio, 180, 90);
			path.AddArc(botao.Width - raio, 0, raio, raio, 270, 90);
			path.AddArc(botao.Width - raio, botao.Height - raio, raio, raio, 0, 90);
			path.AddArc(0, botao.Height - raio, raio, raio, 90, 90);

			path.CloseFigure();
			botao.Region = new Region(path);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao de voltar para o menu do professor

		private void button3_Click(object sender, EventArgs e)
		{
			atualizarNotas = new AtualizarNotas();
			this.Hide();
            atualizarNotas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao para ir a tela de atualizar notas

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}// data grid view para gerenciar as notas dos alunos


		public void ChamarMetodo(DataGridView datagrid)
		{
			ConfigurarDataGrid(datagrid);
			NomeColunas(datagrid);
			AdicionarDados(datagrid);
		}

		public void ConfigurarDataGrid(DataGridView dataGrid)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 5;
			dataGrid.AllowUserToAddRows = false;
			dataGrid.AllowUserToDeleteRows = false;
			dataGrid.AllowUserToResizeColumns = false;
			dataGrid.AllowUserToResizeRows = false;
			dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGrid.ColumnCount = 4;
		}

		public void AdicionarDados(DataGridView dataGrid)
		{
			//Primeira coisa será: PREENCHER O VETOR
			this.daoNotas.PreencherVetor();
			for (int i = 0; i < this.daoNotas.contar; i++)
			{
				dataGrid.Rows.Add(this.daoNotas.codigo[i], this.daoNotas.nota[i], this.daoNotas.dat[i], this.daoNotas.observacao[i]);
			}//fim do for
		}

		public void NomeColunas(DataGridView dataGrid)
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nota";
			dataGrid.Columns[2].Name = "Data";
			dataGrid.Columns[3].Name = "Observação";
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
				dataGridView1.Rows.Clear();
				AdicionarDados(dataGridView1);
		}// caixa de texto do codigo do aluno para gerenciar as notas dos alunos

		private void button5_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear(); // limpa o grid

			int codigoBusca = Convert.ToInt32(textBox1.Text);
			this.daoNotas.PreencherVetorPorCodigoAvaliacao(codigoBusca);

			for (int i = 0; i < this.daoNotas.contar; i++)
			{
				dataGridView1.Rows.Add(
					this.daoNotas.codigo[i],
					this.daoNotas.nota[i],
					this.daoNotas.dat[i],
					this.daoNotas.observacao[i]
				);

			} // BOTAO BUSCAR
		}// botao de buscar o codigo do aluno para gerenciar as notas dos alunos

		private void button2_Click(object sender, EventArgs e)
		{
			cadastrarNotas = new CadastrarNotas();
			this.Hide();
            cadastrarNotas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao para ir a tela de cadastrar notas

		private void button4_Click(object sender, EventArgs e)
		{
			excluirNotas = new ExcluirNotas();
			this.Hide();
            excluirNotas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao para ir a tela de excluir notas

		private void NotasProfessor_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 4;

			dataGridView1.Columns[0].Name = "Código";
			dataGridView1.Columns[1].Name = "Nota";
			dataGridView1.Columns[2].Name = "Data";
			dataGridView1.Columns[3].Name = "Observação";
		}
	}
}
