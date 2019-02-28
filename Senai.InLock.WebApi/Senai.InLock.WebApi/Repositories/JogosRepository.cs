using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial Catalog=InLock_Games_Tarde;User ID=sa;Password=132";

        public void Cadastrar(JogosDomain jogos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                string QueryInsert = @"Insert into Jogos(NOME, DESCRICAO, DATA_LANCAMENTO, VALOR, ID_ESTUDIO)
                                    VALUES(@nome, @descricao, @datalancamento, @valor, @idestudio)";
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", jogos.Nome);
                    cmd.Parameters.AddWithValue("@descricao", jogos.Descricao);
                    cmd.Parameters.AddWithValue("@datalancamento", jogos.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogos.Valor);
                    cmd.Parameters.AddWithValue("@idestudio", jogos.EstudioId);
                                                              
                    cmd.ExecuteNonQuery();
                };

            }
        }

        public List<JogosDomain> Listar()
        {
            
                List<JogosDomain> lsJogos = new List<JogosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string QuerySelect = "Select Jogos.ID as ID, Estudios.Nome as Estudio_Nome ,Jogos.Nome as Nome,Jogos.Descricao as Descricao,Jogos.Data_Lancamento as Data_Lancamento,Jogos.Valor as Valor from Estudios join Jogos on Jogos.ID_Estudio=Estudios.ID";
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {

                        JogosDomain jogos = new JogosDomain() {

                            ID = Convert.ToInt32(sdr["ID"]),
                            Nome = sdr["Nome"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["Data_Lancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),                 
                            Estudio = new EstudiosDomain
                            {
                                
                                Nome = sdr["Estudio_Nome"].ToString(),
                            }
                    };

                        lsJogos.Add(jogos);
                    }
                }
            }
                return lsJogos;
        }
    }
}
