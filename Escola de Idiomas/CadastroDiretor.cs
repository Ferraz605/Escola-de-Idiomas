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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Escola_de_Idiomas
{
	public partial class CadastroDiretor : Form
	{
		Diretor cadastroDiretor;
		DAODiretor daoDiretor;
		public CadastroDiretor()
		{
			InitializeComponent();
			daoDiretor = new DAODiretor();

			// botão 1
			button7.FlatStyle = FlatStyle.Flat;
			button7.FlatAppearance.BorderSize = 0;
			button7.FlatAppearance.MouseOverBackColor = button7.BackColor; // mantém a cor original no hover
			button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button7.Text = "";
			ArredondarBotao(button7, 40);

			// botão 2
			button8.FlatStyle = FlatStyle.Flat;
			button8.FlatAppearance.BorderSize = 0;
			button8.FlatAppearance.MouseOverBackColor = button8.BackColor; // mantém a cor original no hover
			button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button8.Text = "";
			ArredondarBotao(button8, 40);
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


		private void button8_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao pra voltar para a tela de login


		private void button7_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
			{
				MessageBox.Show("Preencha os Campos");
			}
			else
			{
				string nome = textBox1.Text;
				string telefone = textBox2.Text;
				string cpf = textBox3.Text;
				DateTime dtNascimento = Convert.ToDateTime(textBox4.Text);
				string email = textBox5.Text;
				string senha = textBox6.Text;

				// INSERIR DENTRO DO BANCO
				this.daoDiretor.InserirDiretor(nome, telefone, cpf, dtNascimento, email, senha);
				// limpar os campos
				LimparCampos();
			}
		}// botao de cadastrar o diretor

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
		}


		private void CadastroDiretor_Load(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o nome do diretor

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o telefone do diretor

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para CPF do diretor

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para data de nascimento do diretor

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para email do diretor

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para senha do diretor
	}
}
