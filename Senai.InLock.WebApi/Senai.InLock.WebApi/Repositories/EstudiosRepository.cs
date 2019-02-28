using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    

    public class EstudiosRepository : IEstudiosRepoitory
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial Catalog=InLock_Games_Tarde;User ID=sa;Password=132";
        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> lsEstudios = new List<EstudiosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string QuerySelect = "select Estudios.ID as ID,Estudios.nome as NOME_ESTUDIO from Estudios";
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())

                    {

                        EstudiosDomain estudios = new EstudiosDomain()
                        {
                            ID = Convert.ToInt32(sdr["ID"]),
                            Nome = sdr["NOME_ESTUDIO"].ToString()
                        };
                    lsEstudios.Add(estudios);
                    }
                    
                }
                
            }
            return lsEstudios;
        }
    }
}
