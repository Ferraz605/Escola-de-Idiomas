using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_de_Idiomas
{
    class DAODiretor
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int i;
        public int contar;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public long[] cpf;
        public DateTime[] dtNascimento;
        public string [] email;
        public string[] senha;

        public DAODiretor()
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

        public void InserirDiretor(string nome, string telefone, string cpf, DateTime dtNascimento, string email, string senha)
        {
            try
            {
                string dataFormatada = dtNascimento.ToString("yyyy-MM-dd");
                this.dados = $"('', '{nome}', '{telefone}', '{cpf}', '{dataFormatada}', '{email}', '{senha}')";
                this.comando = $"Insert into diretor(codigo, nome, telefone, cpf, dtNascimento, email, senha) values{this.dados}";
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

        public void PreencherVetor()
        {
            string query = "select * from diretor";//Buscando todos os dados da tabela diretor
                                                 //Instanciar os vetores
            this.codigo = new int[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.cpf = new long[100];
            this.dtNascimento = new DateTime[100];
            this.email = new string[100];
            this.senha = new string[100];

            //Preencher os vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigo[i] = 0;
                this.nome[i] = "";
                this.telefone[i] = "";
                this.cpf[i] = 0;
                this.dtNascimento[i] = DateTime.Now;
                this.email[i] = ""; 
                this.senha[i] = "";

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
                this.telefone[i] = leitura["telefone"] + "";
                this.cpf[i] = Convert.ToInt64(leitura["cpf"]);
                this.dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);
                this.email[i] = leitura["email"] + "";
                this.senha[i] = leitura["senha"] + "";
                i++;
                this.contar++;
            }//fim do while
            leitura.Close();//Encerrando o processo de busca
        }//fim do método

        public string AtualizarDiretor(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update diretor set {campo} = '{novoDado}' where codigo = '{codigo}'";
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

        public string DeletarDiretor(int codigo)
        {
            try
            {
                string query = $"delete from diretor where codigo = '{codigo}'";
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

		public bool ValidarLoginDiretor(string email, string senha)
		{
			string sql = "SELECT * FROM diretor " +
						 "WHERE email = '" + email + "' AND senha = '" + senha + "'";

			MySqlCommand cmd = new MySqlCommand(sql, conexao);
			MySqlDataReader leitura = cmd.ExecuteReader();

			bool encontrou = leitura.Read();
			leitura.Close();
			return encontrou;
		}

		public int ObterCodigoDiretorPadrao()
		{
			int codigoSala = 0;
			string sql = "SELECT codigo FROM diretor ORDER BY codigo ASC LIMIT 1";
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
