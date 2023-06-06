using Entities;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repositories
{
    public class UsuarioAccesoRepository
    {
        public UsuarioAcceso? ValidateUser(UsuarioAcceso usuarioAcceso)
        {
            string query = "SELECT ID, USUARIO, PASSWORD FROM USUARIO_ACCESO WHERE USUARIO=@P1 AND PASSWORD=@P2;";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@P1", usuarioAcceso.Usuario);
            parameters[1] = new MySqlParameter("@P2", usuarioAcceso.Password);
            DAO dao = new DAO();
            DataTable dt = dao.Read(query, parameters);
            if (dt.Rows[0][0]  != null)
            {
                usuarioAcceso = new UsuarioAcceso
                {
                    Id = int.Parse(dt.Rows[0][0].ToString()!),
                    Usuario = dt.Rows[0][1].ToString()!,
                    Password = dt.Rows[0][2].ToString()!
                };
                return usuarioAcceso;
            }
            return null;
        }

        public UsuarioAcceso? GetById(int id)
        {
            string query = "SELECT ID, USUARIO, PASSWORD FROM USUARIO_ACCESO WHERE ID=@P1;";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@P1", id);
            DAO dao = new DAO();
            DataTable dt = dao.Read(query, parameters);
            UsuarioAcceso usuarioAcceso;
            if (dt.Rows[0][0] != null)
            {
                usuarioAcceso = new UsuarioAcceso
                {
                    Id = int.Parse(dt.Rows[0][0].ToString()!),
                    Usuario = dt.Rows[0][1].ToString()!,
                    Password = dt.Rows[0][2].ToString()!
                };
                return usuarioAcceso;
            }
            return null;
        }
    }
}
