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
	public partial class CadastrarProfessor : Form
	{
		DAOProfessor daoProfessor;
		Professor professor;
		public CadastrarProfessor()
		{
			InitializeComponent();
			daoProfessor = new DAOProfessor();

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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto do nome do professor

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto do telefone do professor

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto da formação do professor

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto do idioma do professor

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto do email do professor

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto da senha do professor

		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
			{
				MessageBox.Show("Preencha os Campos");
			}
			else
			{
				string nome = textBox1.Text;
				string telefone = textBox2.Text;
				string formacao = textBox3.Text;
				string idiomas = textBox4.Text;
				string email = textBox5.Text;
				string senha = textBox6.Text;

				// INSERIR DENTRO DO BANCO
				this.daoProfessor.InserirProf(nome, telefone, formacao, idiomas, email, senha);
				// limpar os campos
				LimparCampos();
			}
		}// botão de cadastrar o professor

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botão de voltar para a tela de login do professor

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
		}

		private void CadastrarProfessor_Load(object sender, EventArgs e)
		{

		}
	}
}
