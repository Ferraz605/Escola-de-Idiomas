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
	public partial class AtualizarSalas : Form
	{
		DAOSalas daoSalas;
		Salas salas;
		public AtualizarSalas()
		{
			InitializeComponent();
			daoSalas = new DAOSalas();

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

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}// botao de voltar para a tela

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("Informe o código da sala!");
				return;
			}

			int codigo = Convert.ToInt32(textBox1.Text);

			if (textBox2.Text != "")
				this.daoSalas.AtualizarSala(codigo, "nome", textBox2.Text);

			if (textBox3.Text != "")
				this.daoSalas.AtualizarSala(codigo, "curso", textBox3.Text);

            MessageBox.Show("Atualizado com sucesso!");

            LimparCampos();
		}// botao de atualizar a sala

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o curso da sala

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o nome da sala

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto para o codigo da sala

		public void LimparCampos()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
		}

		private void AtualizarSalas_Load(object sender, EventArgs e)
		{

		}
	}
}
