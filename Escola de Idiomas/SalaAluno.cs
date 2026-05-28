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
	public partial class SalaAluno : Form
	{
		MenuAluno menuAluno;
		DAOAluno daoAluno;
		public SalaAluno()
		{
			InitializeComponent();
			daoAluno = new DAOAluno();

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

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao pra voltar pro menu do aluno

		public void ChamarMetodo(DataGridView datagrid)
		{
			ConfigurarDataGrid(datagrid);
			NomeColunas(datagrid);
			AdicionarDados(datagrid);
		}

		public void AdicionarDados(DataGridView dataGrid)
		{
			this.daoAluno.PreencherVetor();
			for (int i = 0; i < this.daoAluno.contar; i++)
			{
				dataGrid.Rows.Add(this.daoAluno.codigo[i], this.daoAluno.nome[i], this.daoAluno.cpf[i], this.daoAluno.telefone[i],
					this.daoAluno.dtDeNascimento[i], this.daoAluno.emailAluno[i], this.daoAluno.senhaAluno[i], this.daoAluno.salasCodigo[i], this.daoAluno.avaliacaoCodigo[i]);
			}
		}

		public void NomeColunas(DataGridView dataGrid)
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nome";
			dataGrid.Columns[2].Name = "CPF";
			dataGrid.Columns[3].Name = "Telefone";
			dataGrid.Columns[4].Name = "Data de Nascimento";
			dataGrid.Columns[5].Name = "Email";
			dataGrid.Columns[6].Name = "Senha";
			dataGrid.Columns[7].Name = "Cód. Sala";
			dataGrid.Columns[8].Name = "Cód. Avaliação";
		}

		public void ConfigurarDataGrid(DataGridView dataGrid)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 9;
			dataGrid.AllowUserToAddRows = false;
			dataGrid.AllowUserToDeleteRows = false;
			dataGrid.AllowUserToResizeColumns = false;
			dataGrid.AllowUserToResizeRows = false;
			dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGrid.ColumnCount = 9;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}// dataGrid

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear(); // limpa o grid

			if (int.TryParse(textBox1.Text, out int codigoBusca))
			{
				this.daoAluno.PreencherVetorPorAluno(codigoBusca);

				for (int i = 0; i < this.daoAluno.contar; i++)
				{
					dataGridView1.Rows.Add(
						this.daoAluno.codigo[i],
						this.daoAluno.nome[i],
						this.daoAluno.cpf[i],
						this.daoAluno.telefone[i],
						this.daoAluno.dtDeNascimento[i],
						this.daoAluno.emailAluno[i],
						this.daoAluno.senhaAluno[i],
						this.daoAluno.salasCodigo[i],
						this.daoAluno.avaliacaoCodigo[i]
					);
				}
			}
			else
			{
				MessageBox.Show("Digite um código válido!");
			}
		}// botao de buscar codigo da sala na tabela do aluno

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
				dataGridView1.Rows.Clear();
				AdicionarDados(dataGridView1);
		}// caixa de texto do codigo da sala

		private void SalaAluno_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 9;

			dataGridView1.Columns[0].Name = "Código";
			dataGridView1.Columns[1].Name = "Nome";
			dataGridView1.Columns[2].Name = "CPF";
			dataGridView1.Columns[3].Name = "Telefone";
			dataGridView1.Columns[4].Name = "Data de Nascimento";
			dataGridView1.Columns[5].Name = "Email";
			dataGridView1.Columns[6].Name = "Senha";
			dataGridView1.Columns[7].Name = "Cód. Sala";
			dataGridView1.Columns[8].Name = "Cód. Avaliação";
		}
	}
}
