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
	public partial class MenuAluno : Form
	{
		Aluno aluno;
		SalaAluno salaAluno;
		NotaAluno notaAluno;
		CursoAluno cursoAluno;
		Matricula matricula;
		public MenuAluno()
		{
			InitializeComponent();

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

			// botão 5
			button5.FlatStyle = FlatStyle.Flat;
			button5.FlatAppearance.BorderSize = 0;
			button5.FlatAppearance.MouseOverBackColor = button5.BackColor; // mantém a cor original no hover
			button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button5.Text = "";
			ArredondarBotao(button5, 40);
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
		}// voltar para a primeira tela do aluno

		private void button2_Click(object sender, EventArgs e)
		{
			salaAluno = new SalaAluno();
			salaAluno.ShowDialog();
		}// botao pro aluno consultar a sala dele

		private void button3_Click(object sender, EventArgs e)
		{
			notaAluno = new NotaAluno();
			notaAluno.ShowDialog();
		}// botao para ir pra tela de consultar notas

		private void button5_Click(object sender, EventArgs e)
		{
			cursoAluno = new CursoAluno();
			cursoAluno.ShowDialog();
		}// botao pra ir pra tela de consultar os cursos disponiveis

		private void button4_Click(object sender, EventArgs e)
		{
			matricula = new Matricula();
			matricula.ShowDialog();
		}// botao para ir pra tela de realizar a matricula

		private void MenuAluno_Load(object sender, EventArgs e)
		{

		}
	}
}
