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
	public partial class CursoAluno : Form
	{
		DAOCursos daoCurso;
		MenuAluno menuAluno;
		public CursoAluno()
		{
			InitializeComponent();
			daoCurso = new DAOCursos();

			// botão 1
			button1.FlatStyle = FlatStyle.Flat;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatAppearance.MouseOverBackColor = button1.BackColor; // mantém a cor original no hover
			button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button1.Text = "";
			ArredondarBotao(button1, 40);
		}

		private void ArredondarBotao(Button botao, int raio)
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

		public void AdicionarDados(DataGridView dataGrid)
		{
			this.daoCurso.PreencherVetor();
			for (int i = 0; i < this.daoCurso.contar; i++)
			{
				dataGrid.Rows.Add(this.daoCurso.codigo[i], this.daoCurso.nome[i], this.daoCurso.cargaHoraria[i], this.daoCurso.valor[i], this.daoCurso.avaliacaoCodigo[i]);
			}
		}

		public void NomeColunas(DataGridView dataGrid)
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nome";
			dataGrid.Columns[2].Name = "Carga Horária";
			dataGrid.Columns[3].Name = "Valor";
			dataGrid.Columns[4].Name = "Cod. Avaliação";
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

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao pra voltar pro menu do aluno

		private void CursoAluno_Load(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 5;

			dataGridView1.Columns[0].Name = "Código";
			dataGridView1.Columns[1].Name = "Nome";
			dataGridView1.Columns[2].Name = "Carga Horária";
			dataGridView1.Columns[3].Name = "Valor";
			dataGridView1.Columns[4].Name = "Cod. Avaliação";
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView1.Rows.Clear(); // limpa o grid
			this.daoCurso.PreencherVetor();

			for (int i = 0; i < this.daoCurso.contar; i++)
			{
				dataGridView1.Rows.Add(
					this.daoCurso.codigo[i],
					this.daoCurso.nome[i],
					this.daoCurso.cargaHoraria[i],
					this.daoCurso.valor[i],
					this.daoCurso.avaliacaoCodigo[i]
				);
			}
		}
	}
}
