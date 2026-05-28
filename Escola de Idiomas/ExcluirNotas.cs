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
	public partial class ExcluirNotas : Form
	{
		NotasProfessor notasProfessor;
		DAONotas daoNotas;
		public ExcluirNotas()
		{
			InitializeComponent();
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
		}// botao de voltar para a tela de gerenciamento das notas

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}// caixa de texto pra digitar o codigo da nota a ser excluida

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("Preencha o Campo");
			}
			else
			{
				int codigo = Convert.ToInt32(textBox1.Text);

				string msg = this.daoNotas.DeletarNotas(codigo);
				MessageBox.Show(msg);

				LimparCampos();
			}// botao de excluir a nota
		}

		public void LimparCampos()
		{
			textBox1.Text = "";
		}

		private void ExcluirNotas_Load(object sender, EventArgs e)
		{

		}
	}
}
