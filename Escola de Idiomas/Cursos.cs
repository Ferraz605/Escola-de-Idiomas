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
    public partial class Cursos : Form
    {
        CadastrarCursos cadastrarCursos;
        MenuDiretor menuDiretor;
        AtualizarCursos atualizarCursos;
        ExcluirCurso excluirCurso;
        DAOCursos daoCursos;
        public Cursos()
        {
            InitializeComponent();
            daoCursos = new DAOCursos();

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

        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid);
            NomeColunas(datagrid);
            AdicionarDados(datagrid);
        }

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 5;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.ColumnCount = 5;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "Carga Horária";
            dataGrid.Columns[3].Name = "Valor";
            dataGrid.Columns[4].Name = "Cód. Avaliação";
        }

        public void AdicionarDados(DataGridView dataGrid)
        {
            this.daoCursos.PreencherVetor();
            for (int i = 0; i < this.daoCursos.contar; i++)
            {
                dataGrid.Rows.Add(this.daoCursos.codigo[i], this.daoCursos.nome[i], this.daoCursos.cargaHoraria[i],
                    this.daoCursos.valor[i], this.daoCursos.avaliacaoCodigo[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//botao de voltar pro menu do diretor

        private void button2_Click(object sender, EventArgs e)
        {
            excluirCurso = new ExcluirCurso();
            this.Hide();
            excluirCurso.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao de excluir os cursos

        private void button4_Click(object sender, EventArgs e)
        {
            atualizarCursos = new AtualizarCursos();
            this.Hide();
            atualizarCursos.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao de atualizar os cursos

        private void button5_Click(object sender, EventArgs e)
        {
            cadastrarCursos = new CadastrarCursos();
            this.Hide();
            cadastrarCursos.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// botao pra ir pra tela de cadastrar cursos

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }// data grid para exibir os cursos cadastrados

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        }// caixa de texto do codigo do curso para buscar

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // limpa o grid

            if (int.TryParse(textBox1.Text, out int codigoBusca))
            {
                this.daoCursos.PreencherVetorPorCurso(codigoBusca);

                for (int i = 0; i < this.daoCursos.contar; i++)
                {
                    dataGridView1.Rows.Add(
                        this.daoCursos.codigo[i],
                        this.daoCursos.nome[i],
                        this.daoCursos.cargaHoraria[i],
                        this.daoCursos.valor[i],
                        this.daoCursos.avaliacaoCodigo[i]
                    );
                }
            }
            else
            {
                MessageBox.Show("Digite um código válido!");
            }
        }// botao de buscar o curso pelo codigo

        private void Cursos_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Carga Horária";
            dataGridView1.Columns[3].Name = "Valor";
            dataGridView1.Columns[4].Name = "Cód. Avaliação";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
