using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//importando a estrutura de tela
using MySql.Data.MySqlClient;//importando a estrutura de conexão com o banco de dados

namespace Escola_de_Idiomas
{
	class DAOAluno
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
		public int[] salasCodigo;
		public int[] cursoCodigo;
		public int[] alunoCodigo;
		public int[] avaliacaoCodigo;
		public int i;
		public int contar;
		public string msg;
		public DAOAluno()
		{

			codigo = new int[100];
			nome = new string[100];
			cpf = new long[100];
			telefone = new string[100];
			dtDeNascimento = new DateTime[100];
			emailAluno = new string[100];
			senhaAluno = new string[100];
			salasCodigo = new int[100];
			avaliacaoCodigo = new int[100];
			alunoCodigo = new int[100];
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

		public void InserirAluno(string nome, string cpf, string telefone, DateTime dataNascimento, string emailAluno, string senhaAluno, int salasCodigo, int avaliacaoCodigo)
		{
			try
			{
				string dataFormatada = dataNascimento.ToString("yyyy-MM-dd");
				this.dados = $"('', '{nome}', '{cpf}', '{telefone}', '{dataFormatada}', '{emailAluno}', '{senhaAluno}', '{salasCodigo}', '{avaliacaoCodigo}')";
				this.comando = $"Insert into aluno(codigo, nome, cpf, telefone, dtDeNascimento, email, senha, salasCodigo, avaliacaoCodigo) values{this.dados}";
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
			string query = "select * from aluno";//Buscando todos os dados da tabela autor
												 //Instanciar os vetores
			this.codigo = new int[100];
			this.nome = new string[100];
			this.cpf = new long[100];
			this.telefone = new string[100];
			this.dtDeNascimento = new DateTime[100];
			this.emailAluno = new string[100];
			this.senhaAluno = new string[100];
			this.salasCodigo = new int[100];
			this.avaliacaoCodigo = new int[100];


			//Preencher os vetores com valores padrões
			for (i = 0; i < 100; i++)
			{
				this.codigo[i] = 0;
				this.nome[i] = "";
				this.cpf[i] = 0;
				this.telefone[i] = "";
				this.dtDeNascimento[i] = DateTime.MinValue;
				this.emailAluno[i] = "";
				this.senhaAluno[i] = "";
				this.salasCodigo[i] = 0;
				this.avaliacaoCodigo[i] = 0;


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
				this.telefone[i] = leitura["telefone"] + "";
				this.dtDeNascimento[i] = Convert.ToDateTime(leitura["dtDeNascimento"] + "");
				this.emailAluno[i] = leitura["email"] + "";
				this.senhaAluno[i] = leitura["senha"] + "";
				this.salasCodigo[i] = Convert.ToInt32(leitura["salasCodigo"] + "");
				this.avaliacaoCodigo[i] = Convert.ToInt32(leitura["avaliacaoCodigo"] + "");
				i++;
				this.contar++;
			}//fim do while
			leitura.Close();//Encerrando o processo de busca
		}//fim do método

		public string AtualizarAluno(int codigo, string campo, string novoDado)
		{
			try
			{
				string query = $"update aluno set {campo} = '{novoDado}' where codigo = '{codigo}'";
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

		public string DeletarAluno(int codigo)
		{
			try
			{
				string query = $"delete from aluno where codigo = '{codigo}'";
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

		public bool ValidarLoginAluno(string email, string senha)
		{
			string sql = "SELECT * FROM aluno " +
						 "WHERE email = '" + email + "' AND senha = '" + senha + "'";

			MySqlCommand cmd = new MySqlCommand(sql, conexao);
			MySqlDataReader leitura = cmd.ExecuteReader();

			bool encontrou = leitura.Read();
			leitura.Close();
			return encontrou;
		}

		public void PreencherVetorPorAluno(int alunoCodigo)
		{
			this.contar = 0;

			string sql = "SELECT * FROM aluno WHERE codigo = " + alunoCodigo;

			MySqlCommand cmd = new MySqlCommand(sql, conexao);
			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				this.codigo[contar] = reader.GetInt32("codigo");
				this.nome[contar] = reader.GetString("nome");
				this.cpf[contar] = reader.GetInt64("cpf");
				this.telefone[contar] = reader.GetString("telefone");
				this.dtDeNascimento[contar] = reader.GetDateTime("dtDeNascimento");
				this.emailAluno[contar] = reader.GetString("email");
				this.senhaAluno[contar] = reader.GetString("senha");
				this.salasCodigo[contar] = reader.GetInt32("salasCodigo");
				this.avaliacaoCodigo[contar] = reader.GetInt32("avaliacaoCodigo");
				this.alunoCodigo[contar] = reader.GetInt32("codigo");

				contar++;
			}

			reader.Close();
		}
	}
}
