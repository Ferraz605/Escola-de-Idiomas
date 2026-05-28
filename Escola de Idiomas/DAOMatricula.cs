using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_de_Idiomas
{
    class DAOMatricula
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public long[] cpf;
        public string[] email;
        public string[] telefone;
        public DateTime[] dtDeNascimento;
        public string[] emailAluno;
        public string[] senhaAluno;
        public string[] cursoDesejado;
        public int[] cursoCodigo;
        public int[] alunoCodigo;
        public int i;
        public int contar;
        public string msg;

        public DAOMatricula()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=escolaIdiomas;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//abrir a conexão
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!\n\n {erro}");
                conexao.Close();//fecha conexão com o banco de dados

            }//fim do try_catch
        }

        public void InserirMatricula(string nome, string cpf, string email, string telefone, DateTime dtDeNascimento, string cursoDesejado, int cursoCodigo, int alunoCodigo)
        {
            try
            {
                string dataFormatada = dtDeNascimento.ToString("yyyy-MM-dd");
                this.dados = $"('', '{nome}', '{cpf}', '{email}', '{telefone}', '{dataFormatada}', '{cursoDesejado}', {cursoCodigo}, {alunoCodigo})";
                this.comando = $"Insert into matricula(codigo, nome, cpf, email, telefone, dtDeNascimento, cursoDesejado, cursoCodigo, alunoCodigo) values{this.dados}";
                //Inserir comando
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show($"Inserido com Sucesso! \n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }
        }//fim do inserir

        public void PreencherVetor()
        {
            string query = "select * from matricula";//Buscando todos os dados da tabela autor
                                                 //Instanciar os vetores
            this.codigo = new int[100];
            this.nome = new string[100];
            this.cpf = new long[100];
            this.email = new string[100];
            this.telefone = new string[100];
            this.dtDeNascimento = new DateTime[100];
            this.cursoDesejado = new string[100];
            this.cursoCodigo = new int[100];
            this.alunoCodigo = new int[100];



            //Preencher os vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigo[i] = 0;
                this.nome[i] = "";
                this.cpf[i] = 0;
                this.email[i] = "";
                this.telefone[i] = "";
                this.dtDeNascimento[i] = DateTime.MinValue;
                this.cursoDesejado[i] = "";
                this.cursoCodigo[i] = 0;
                this.alunoCodigo[i] = 0;


            }//fim do for

            //Executar o comando do SQL
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            //Leitura do dado no banco
            MySqlDataReader leitura = coletar.ExecuteReader();//Percorre o banco e traz os dados

            //Zerar o contador
            i = 0;
            this.contar = 0;
            while (leitura.Read())
            {
                this.codigo[i] = Convert.ToInt32(leitura["codigo"]);
                this.nome[i] = leitura["nome"] + "";
                this.cpf[i] = Convert.ToInt64(leitura["cpf"] + "");
                this.email[i] = leitura["email"] + "";
                this.telefone[i] = leitura["telefone"] + "";
                this.dtDeNascimento[i] = Convert.ToDateTime(leitura["dtDeNascimento"] + "");
                this.cursoDesejado[i] = leitura["cursoDesejado"] + "";
                this.cursoCodigo[i] = Convert.ToInt32(leitura["cursoCodigo"] + "");
                this.alunoCodigo[i] = Convert.ToInt32(leitura["alunoCodigo"] + "");

                i++;
                this.contar++;
            }//fim do while
            leitura.Close();//Encerrando o processo de busca
        }//fim do método

        public string AtualizarMatricula(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update matricula set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();//comando da inserção no banco
                return $"Atualizado com sucesso!\n\n{resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n{erro}";
            }
        }

        public string DeletarMatricula(int codigo)
        {
            try
            {
                string query = $"delete from matricula where codigo = '{codigo}'";
                //executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();//comando da inserção no banco
                return $"Deletado com sucesso!\n\n{resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n{erro}";
            }
        }

		public int ObterCodigoAlunoPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM aluno ORDER BY codigo ASC LIMIT 1";
			// pega o menor código (primeira sala cadastrada)

			using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
			{
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						codigoSala = reader.GetInt32("codigo");
					}
				}
			}
			return codigoSala;
		}

		public int ObterCodigoCursoPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM curso ORDER BY codigo ASC LIMIT 1";
			// pega o menor código (primeira sala cadastrada)

			using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
			{
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						codigoSala = reader.GetInt32("codigo");
					}
				}
			}
			return codigoSala;
		}

		public int ObterCodigoCursoPorNome(string nomeDoCorso)
		{
			int codigoCurso = -1;
			string sql = "SELECT codigo FROM curso WHERE nome = '" + nomeDoCorso + "' ORDER BY codigo ASC LIMIT 1";

			using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
			{
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						codigoCurso = reader.GetInt32("codigo");
					}
				}
			}
			return codigoCurso;
		}
	}
}
