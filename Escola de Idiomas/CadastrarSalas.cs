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

namespace Escola_de_Idiomas
{
	public partial class CadastrarSalas : Form
	{
		DAOSalas daoSalas;
		Salas salas;
		DAODiretor daoDiretor;
		DAOProfessor daoProfessor;
		public CadastrarSalas()
		{
			InitializeComponent();
			daoSalas = new DAOSalas();
			daoDiretor = new DAODiretor();
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

		private void CadastrarSalas_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao de voltar para tela do login

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o nome da sala

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o curso da sala

		private void button1_Click(object sender, EventArgs e)
		{
			if ((textBox1.Text == "") || (textBox2.Text == ""))
			{
				MessageBox.Show("Preencha os Campos");
			}
			else
			{
				string nome = textBox1.Text;
				string curso = textBox2.Text;
				int diretorCodigo = daoDiretor.ObterCodigoDiretorPadrao();
				int professorCodigo = daoProfessor.ObterCodigoProfessorPadrao();

				// INSERIR DENTRO DO BANCO
				this.daoSalas.InserirSalas(nome, curso, diretorCodigo, professorCodigo);
				// limpar os campos
				LimparCampos();
			}
		}// botao de cadastrar a sala

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
		}
	}
}
