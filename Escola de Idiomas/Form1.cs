using System.Drawing.Drawing2D;
namespace Escola_de_Idiomas
{
	public partial class Form1 : Form
	{
		Professor professor;
		Diretor diretor;
		Aluno aluno;
		public Form1()
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
		}

		private void Form1_Load(object sender, EventArgs e)
		{

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

		private void button2_Click_1(object sender, EventArgs e)
		{
            professor = new Professor();
            this.Hide();
            professor.ShowDialog();
            this.Show();
        }// botão do professor

        private void button1_Click_1(object sender, EventArgs e)
		{
            diretor = new Diretor();
            this.Hide();
            diretor.ShowDialog();
            this.Show();
        }// botão do diretor

		private void button3_Click_1(object sender, EventArgs e)
		{
            aluno = new Aluno();
            this.Hide();
            aluno.ShowDialog();
            this.Show();
        }// botão do aluno
	}
}
