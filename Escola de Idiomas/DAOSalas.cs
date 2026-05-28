using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_de_Idiomas
{
    class DAOSalas
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] curso;
        public int[] diretorCodigo;
        public int[] professorCodigo;
        public int i;
        public int contar;

        public DAOSalas()
        {
			codigo = new int[100];
			nome = new string[100];
			curso = new string[100];
			diretorCodigo = new int[100];
			professorCodigo = new int[100];
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

        public void InserirSalas(string nome, string curso, int diretorCodigo, int professorCodigo)
        {
            try
            {
                this.dados = $"('', '{nome}', '{curso}', '{diretorCodigo}', '{professorCodigo}')";
                this.comando = $"Insert into salas(codigo, nome, curso, diretorCodigo, professorCodigo) values{this.dados}";
                //Inserir comando
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show($"Inserido com Sucesso! \n\n{resultado}");
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show($"Algo deu errado\n\n {erro}");
            }
        }//fim do inserir

		public void PreencherVetorPorCodigo(int codigoBusca)
		{
			string query = $"SELECT * FROM salas WHERE codigo = {codigoBusca}";
			this.codigo = new int[100];
			this.nome = new string[100];
			this.curso = new string[100];
            this.diretorCodigo = new int[100];
			this.professorCodigo = new int[100];

			MySqlCommand coletar = new MySqlCommand(query, this.conexao);
			MySqlDataReader leitura = coletar.ExecuteReader();

			i = 0; this.contar = 0;
			while (leitura.Read())
			{
				this.codigo[i] = Convert.ToInt32(leitura["codigo"]);
				this.nome[i] = leitura["nome"] + "";
				this.curso[i] = leitura["curso"] + "";
				this.diretorCodigo[i] = Convert.ToInt32(leitura["diretorCodigo"] + "");
				this.professorCodigo[i] = Convert.ToInt32(leitura["professorCodigo"] + "");
				i++;
				this.contar++;
			}
			leitura.Close();
		}

		public void PreencherVetor()
        {
            string query = "select * from salas";//Buscando todos os dados da tabela salas
                                                 //Instanciar os vetores
            this.codigo = new int[100];
            this.nome = new string[100];
            this.curso = new string[100];
            this.diretorCodigo = new int[100];
            this.professorCodigo = new int[100];

            //Preencher os vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigo[i] = 0;
                this.nome[i] = "";
                this.curso[i] = "";
                this.diretorCodigo[i] = 0;
                this.professorCodigo[i] = 0;

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
                this.curso[i] = leitura["curso"] + "";
                this.diretorCodigo[i] = Convert.ToInt32(leitura["diretorCodigo"]);
                this.professorCodigo[i] = Convert.ToInt32(leitura["professorCodigo"]);
                i++;
                this.contar++;
            }//fim do while
            leitura.Close();//Encerrando o processo de busca
        }//fim do método

        public void AtualizarSala(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update salas set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();//comando da inserção no banco
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }
        }

        public string DeletarSalas(int codigo)
        {
            try
            {
                string query = $"delete from salas where codigo = '{codigo}'";
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

		public int ObterCodigoSalaPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM salas LIMIT 1";

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

		public void PreencherVetorPorProfessor(int professorCodigo)
		{
			this.contar = 0;

			string sql = "SELECT * FROM salas WHERE professorCodigo = " + professorCodigo;

			MySqlCommand cmd = new MySqlCommand(sql, conexao);
			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				this.codigo[contar] = reader.GetInt32("codigo");
				this.nome[contar] = reader.GetString("nome");
				this.curso[contar] = reader.GetString("curso");
				this.diretorCodigo[contar] = reader.GetInt32("diretorCodigo");
				this.professorCodigo[contar] = reader.GetInt32("professorCodigo");
				contar++;
			}

			reader.Close();
		}
	}
}