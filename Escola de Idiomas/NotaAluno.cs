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
	public partial class NotaAluno : Form
	{
		DAOAluno daoAluno;
		MenuAluno menuAluno;
		DAONotas daoNotas;
		public NotaAluno()
		{
			InitializeComponent();
			daoAluno = new DAOAluno();
			daoNotas = new DAONotas();


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

		public void ChamarMetodo(DataGridView datagrid)
		{
			ConfigurarDataGrid(datagrid);
			NomeColunas(datagrid);
			AdicionarDados(datagrid);
		}

		public void AdicionarDados(DataGridView dataGrid)
		{
			this.daoNotas.PreencherVetor();
			for (int i = 0; i < this.daoNotas.contar; i++)
			{
				dataGrid.Rows.Add(this.daoNotas.codigo[i], this.daoNotas.nota[i], this.daoNotas.dat[i], this.daoNotas.observacao[i]);
			}
		}

		public void NomeColunas(DataGridView dataGrid)
		{
			dataGrid.Columns[0].Name = "Código";
			dataGrid.Columns[1].Name = "Nota";
			dataGrid.Columns[2].Name = "Data";
			dataGrid.Columns[3].Name = "Observação";
		}

		public void ConfigurarDataGrid(DataGridView dataGrid)
		{
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnCount = 3;
			dataGrid.AllowUserToAddRows = false;
			dataGrid.AllowUserToDeleteRows = false;
			dataGrid.AllowUserToResizeColumns = false;
			dataGrid.AllowUserToResizeRows = false;
			dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGrid.ColumnCount = 4;
		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
				dataGridView1.Rows.Clear();
				AdicionarDados(dataGridView1);
		}// caixa de texto do codigo do aluno

		private void button1_Click(object sender, EventArgs e)
		{
            dataGridView1.Rows.Clear(); // limpa o grid

            if (int.TryParse(textBox1.Text, out int codigoBusca))
            {
                this.daoNotas.PreencherVetorPorAvaliacao(codigoBusca);

                for (int i = 0; i < this.daoNotas.contar; i++)
                {
                    dataGridView1.Rows.Add(
                        this.daoNotas.codigo[i],
						this.daoNotas.nota[i],
						this.daoNotas.dat[i],
						this.daoNotas.observacao[i]
                    );
                }
            }
            else
            {
                MessageBox.Show("Digite um código válido!");
            }
        }// botao de buscar codigo

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao pra voltar para a tela anterior

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}// datagrid

		private void NotaAluno_Load(object sender, EventArgs e)
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
