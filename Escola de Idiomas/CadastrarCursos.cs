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
	public partial class CadastrarCursos : Form
	{
		DAOCursos daoCursos;
		DAONotas daoNotas;
		Cursos cursos;
		public CadastrarCursos()
		{
			InitializeComponent();
			daoCursos = new DAOCursos();
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

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
			{
				MessageBox.Show("Preencha os Campos");
			}
			else
			{
				string nome = textBox2.Text;
				double valor = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
				int cargaHoraria = int.Parse(textBox3.Text);
				int avaliacaoCodigo = daoNotas.ObterCodigoAvaliacaoPadrao();

				this.daoCursos.InserirCursos(nome, cargaHoraria, valor, avaliacaoCodigo);
				LimparCampos();
			}
		}// botao pra cadastrar o curso

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao pra voltar pro menu

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// botao de colocar o valor do curso

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}// botao pra colocar a carga horaria

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// botao pra colocar o nome do curso

		private void CadastrarCursos_Load(object sender, EventArgs e)
		{

		}
	}
}
