using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//importando a estrutura de tela
using MySql.Data.MySqlClient;//importando a estrutura de conexão com o banco de dados

namespace Escola_de_Idiomas
{
	class DAONotas
	{
		public MySqlConnection conexao;
		public string dados;
		public string comando;
		public int[] codigo;
		public decimal[] nota;
		public DateTime[] dat;
		public string[] observacao;
        public int i;
		public int contar;
		public string msg;

		public DAONotas()
		{
			this.codigo = new int[100];      
			this.nota = new decimal[100];
			this.dat = new DateTime[100];
			this.observacao = new string[100];
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

		public void InserirNotas(double nota, DateTime dat, string observacao)
		{
			try
			{
				string dataFormatada = dat.ToString("yyyy-MM-dd");
				string notaFormatada = nota.ToString(System.Globalization.CultureInfo.InvariantCulture);

				this.comando = $"insert into avaliacao (nota, dat, observacao) values ({notaFormatada}, '{dataFormatada}', '{observacao}')";

				MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
				string resultado = "" + sql.ExecuteNonQuery();
				MessageBox.Show($"Inserido com sucesso!");
			}
			catch (Exception erro)
			{
				MessageBox.Show($"Algo deu errado\n\n {erro}");
			}
		}

		//Preencher Vetor --> Coletar os dados do banco e preenhcer o vetor
		public void PreencherVetor()
		{
			string query = "select * from avaliacao";//Buscando todos os dados da tabela autor
													 //Instanciar os vetores
			this.codigo = new int[100];
			this.nota = new decimal[100];
			this.dat = new DateTime[100];
			this.observacao = new string[100];

			//Preencher os vetores com valores padrões
			for (i = 0; i < 100; i++)
			{
				this.codigo[i] = 0;
				this.nota[i] = 0;
				this.dat[i] = DateTime.MinValue;
				this.observacao[i] = "";
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
				this.nota[i] = Convert.ToDecimal(leitura["nota"] + "");
				this.dat[i] = Convert.ToDateTime(leitura["dat"] + "");
				this.observacao[i] = leitura["observacao"] + "";
				i++;
				this.contar++;//Informar quantos dados tem no banco
			}//fim do while

			leitura.Close();//Encerrando o processo de busca
		}//fim do método

		public void PreencherVetorPorCodigoAvaliacao(int codigoBusca)
		{
			string query = $"SELECT * FROM avaliacao WHERE codigo = {codigoBusca}";

			this.codigo = new int[100];
			this.nota = new decimal[100];
			this.dat = new DateTime[100];
			this.observacao = new string[100];

			MySqlCommand coletar = new MySqlCommand(query, this.conexao);
			MySqlDataReader leitura = coletar.ExecuteReader();

			i = 0;
			this.contar = 0;
			while (leitura.Read())
			{
				this.codigo[i] = Convert.ToInt32(leitura["codigo"]);
				this.nota[i] = Convert.ToDecimal(leitura["nota"] + "");
				this.dat[i] = Convert.ToDateTime(leitura["dat"] + "");
				this.observacao[i] = leitura["observacao"] + "";
				i++;
				this.contar++;
			}
			leitura.Close();
		}


		public string DeletarNotas(int codigo)
		{
			try
			{
				string query = $"DELETE FROM avaliacao WHERE codigo = {codigo}";

				MySqlCommand sql = new MySqlCommand(query, this.conexao);
				int resultado = sql.ExecuteNonQuery();

				if (resultado > 0)
				{
					return "Deletado com sucesso!";
				}
				else
				{
					return "Nenhum registro encontrado com esse código.";
				}
			}
			catch (Exception erro)
			{
				return $"Algo deu errado\n\n{erro.Message}";
			}
		}

		public void AtualizarNotas(int codigo, string campo, string novoDado)
		{
			try
			{
				string query = $"update avaliacao set {campo} = '{novoDado}' where codigo = '{codigo}'";
				MySqlCommand sql = new MySqlCommand(query, this.conexao);
				string resultado = "" + sql.ExecuteNonQuery(); // comando de inserção no banco
			}
			catch (Exception erro)
			{
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }

        }

		public int ObterCodigoAvaliacaoPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM avaliacao ORDER BY codigo ASC LIMIT 1";
			// pega o menor código (primeira avaliacao cadastrada)

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

        public void PreencherVetorPorAvaliacao(int avaliacaoCodigo)
        {
            this.contar = 0;

            string sql = "SELECT * FROM avaliacao WHERE codigo = " + avaliacaoCodigo;

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.codigo[contar] = reader.GetInt32("codigo");
				this.nota[contar] = reader.GetDecimal("nota");
				this.dat[contar] = reader.GetDateTime("dat");
				this.observacao[contar] = reader.GetString("observacao");

                contar++;
            }

            reader.Close();
        }
    }
}
