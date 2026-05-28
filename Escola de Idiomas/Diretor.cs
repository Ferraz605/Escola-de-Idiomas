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

	public partial class Diretor : Form
	{
		CadastroDiretor cadastrarDiretor;
		DAODiretor daoDiretor;
		MenuDiretor menuDiretor;
		Salas salas;
		public Diretor()
		{
			InitializeComponent();
			daoDiretor = new DAODiretor();

			// botão 1
			button3.FlatStyle = FlatStyle.Flat;
			button3.FlatAppearance.BorderSize = 0;
			button3.FlatAppearance.MouseOverBackColor = button3.BackColor; // mantém a cor original no hover
			button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button3.Text = "";
			ArredondarBotao(button3, 40);

			// botão 2
			button4.FlatStyle = FlatStyle.Flat;
			button4.FlatAppearance.BorderSize = 0;
			button4.FlatAppearance.MouseOverBackColor = button4.BackColor; // mantém a cor original no hover
			button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 215, 235); // clique suave
			button4.Text = "";
			ArredondarBotao(button4, 40);
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

		private void Diretor_Load(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "" || textBox2.Text == "")
			{
				MessageBox.Show("Preencha os campos");
				return;
			}

			string email = textBox1.Text;
			string senha = textBox2.Text;

			bool loginOk = daoDiretor.ValidarLoginDiretor(email, senha);

			if (loginOk)
			{
                MessageBox.Show("Bem-vindo!");
                menuDiretor = new MenuDiretor();
                this.Hide();
                menuDiretor.ShowDialog();
                this.Show();
            }
            else
			{
				MessageBox.Show("Email ou senha incorretos!");
			}
		}// botao de entrar do diretor

		private void button4_Click(object sender, EventArgs e)
		{
			cadastrarDiretor = new CadastroDiretor();
			this.Hide();
            cadastrarDiretor.ShowDialog();
			this.Show();
        }// botao de cada;strar do diretor

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o email do diretor

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para a senha do diretor
	}
}
