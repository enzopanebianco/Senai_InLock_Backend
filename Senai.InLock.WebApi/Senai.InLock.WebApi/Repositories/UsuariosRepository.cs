using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private string StringConexao = @"Data Source=.\SqlExpress;Initial Catalog=InLock_Games_Tarde;User ID=sa;Password=132";

        public UsuarioDomain     Buscar(string email,string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string QuerySelect = @"select Usuarios.ID, Usuarios.Email as Email,Usuarios.Senha as Senha,Usuarios.Tipo_Usuario from Usuarios where Email = @Email and Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Senha", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();

                        while (sdr.Read())
                        {
                            usuarioBuscado.ID = Convert.ToInt32(sdr["ID"]);
                            usuarioBuscado.Email = sdr["Email"].ToString();
                            usuarioBuscado.Email = sdr["Senha"].ToString();
                            usuarioBuscado.Tipo_Usuario = sdr["Tipo_Usuario"].ToString();
                        }

                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
