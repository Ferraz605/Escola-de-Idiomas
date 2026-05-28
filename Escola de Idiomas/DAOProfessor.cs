using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_de_Idiomas
{
	class DAOProfessor
	{
		public MySqlConnection conexao;
		public string dados;
		public string comando;

		public DAOProfessor()
		{
			conexao = new MySqlConnection("server=localhost;DataBase=escolaIdiomas;Uid=root;Password=;Convert Zero DateTime=True");
			try
			{
				conexao.Open();//abrir a conexão
			}
			catch (Exception erro)
			{
				System.Windows.Forms.MessageBox.Show($"Algo deu errado!\n\n {erro}");
				conexao.Close();//fecha conexão com o banco de dados
			}//fim do try_catch
		}

		public void InserirProf(string nome, string telefone, string formacao, string idiomas, string email, string senha)
		{
			try
			{
				this.dados = $"('', '{nome}', '{telefone}', '{formacao}', '{idiomas}', '{email}', '{senha}')";
				this.comando = $"Insert into professor(codigo, nome, telefone, formacao, idiomas, email, senha) values{this.dados}";
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
		public string AtualizarProfessor(int codigo, string campo, string novoDado)
		{
			try
			{
				string query = $"update professor set {campo} = '{novoDado}' where codigo = '{codigo}'";
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

		public string DeletarProfessor(int codigo)
		{
			try
			{
				string query = $"delete from professor where codigo = '{codigo}'";
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

		public bool ValidarLoginProfessor(string email, string senha)
		{
			string sql = "SELECT * FROM professor " +
						 "WHERE email = '" + email + "' AND senha = '" + senha + "'";

			MySqlCommand cmd = new MySqlCommand(sql, conexao);
			MySqlDataReader leitura = cmd.ExecuteReader();

			bool encontrou = leitura.Read();
			leitura.Close();
			return encontrou;
		}

		public int ObterCodigoProfessorPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM professor ORDER BY codigo ASC LIMIT 1";
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
	}
}
