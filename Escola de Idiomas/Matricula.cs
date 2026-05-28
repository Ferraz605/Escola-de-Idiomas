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
	public partial class Matricula : Form
	{
		MenuAluno menuAluno;
		DAOMatricula daoMatricula;
		public Matricula()
		{
			InitializeComponent();
			daoMatricula = new DAOMatricula();

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
		}// botao para voltar para o menu do aluno

		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
			{
				MessageBox.Show("Preencha os Campos");
			}
			else
			{
				string nome = textBox1.Text;
				string cpf = textBox2.Text;
				string email = textBox3.Text;
				string telefone = textBox4.Text;
				DateTime dtDeNascimento = DateTime.Parse(textBox5.Text);
				string cursoDesejado = textBox6.Text;
				int cursoCodigo = daoMatricula.ObterCodigoCursoPorNome(cursoDesejado);

				if (cursoCodigo == -1)
				{
					MessageBox.Show("Esse curso não está disponível, escolha outro.",
						"Curso Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Error);
					textBox6.Focus();
					return;
				}

				int alunoCodigo = daoMatricula.ObterCodigoAlunoPadrao();

				// INSERIR DENTRO DO BANCO
				this.daoMatricula.InserirMatricula(nome, cpf, email, telefone, dtDeNascimento, cursoDesejado, cursoCodigo, alunoCodigo);

				// LIMPAR OS CAMPOS
				LimparCampos();
			}
		}// botao para realizar a matricula do aluno

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o aluno digitar o nome do curso que deseja se matricular

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto pro aluno digitar o seu cpf para realizar a matricula

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto pro aluno digitar o seu e-mail para realizar a matricula

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto pro aluno digitar o seu telefone para realizar a matricula

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto pro aluno digitar a data de nascimento para realizar a matricula

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}//caixa de texto pro aluno digitar o curso desejado para realizar a matricula

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
		}

		private void Matricula_Load(object sender, EventArgs e)
		{

		}
	}
}
