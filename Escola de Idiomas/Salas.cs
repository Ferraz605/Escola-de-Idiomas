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
	public partial class Salas : Form
	{
		DAOSalas daoSalas;
		CadastrarSalas cadastrarSalas;
		MenuDiretor menuDiretor;
		AtualizarSalas atualizarSalas;
		ExcluirSalas excluirSalas;
		public Salas()
		{
			InitializeComponent();
			daoSalas = new DAOSalas();

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
			dataGrid.ColumnCount = 5;
		}

		public void NomeColunas(DataGridView dataGrid)
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nome";
			dataGrid.Columns[2].Name = "Curso";
			dataGrid.Columns[3].Name = "Cód. Diretor";
			dataGrid.Columns[4].Name = "Cód. Professor";
		}

		private void Salas_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 5;

			dataGridView1.Columns[0].Name = "Código";
			dataGridView1.Columns[1].Name = "Nome";
			dataGridView1.Columns[2].Name = "Curso";
			dataGridView1.Columns[3].Name = "Cód. Diretor";
			dataGridView1.Columns[4].Name = "Cód. Professor";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			cadastrarSalas = new CadastrarSalas();
			this.Hide();
			cadastrarSalas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao de cadastrar sala

		private void button4_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao de sair

		private void button2_Click(object sender, EventArgs e)
		{
			atualizarSalas = new AtualizarSalas();
			this.Hide();
			atualizarSalas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao de atualizar sala

		private void button3_Click(object sender, EventArgs e)
		{
			excluirSalas = new ExcluirSalas();
			this.Hide();
            excluirSalas.ShowDialog();
			this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao de excluir sala

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}// data grid para exibir as salas cadastradas

		public void AdicionarDados(DataGridView dataGrid)
		{
			this.daoSalas.PreencherVetor();
			for (int i = 0; i < this.daoSalas.contar; i++)
			{
				dataGrid.Rows.Add(this.daoSalas.codigo[i], this.daoSalas.nome[i], this.daoSalas.curso[i],this.daoSalas.diretorCodigo[i],  this.daoSalas.professorCodigo[i]);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
				dataGridView1.Rows.Clear();
				AdicionarDados(dataGridView1);
	
		}// caixa de texto de buscar pelo codigo da sala

		private void button5_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear(); // limpa o grid

			if (int.TryParse(textBox1.Text, out int codigoBusca))
			{
				this.daoSalas.PreencherVetorPorProfessor(codigoBusca);

				for (int i = 0; i < this.daoSalas.contar; i++)
				{
					dataGridView1.Rows.Add(
						this.daoSalas.codigo[i],
						this.daoSalas.nome[i],
						this.daoSalas.curso[i],
						this.daoSalas.diretorCodigo[i],
						this.daoSalas.professorCodigo[i]
					);
				}
			}
			else
			{
				MessageBox.Show("Digite um código válido!");
			}
		}// botao de buscar todas as salas
	}
}
