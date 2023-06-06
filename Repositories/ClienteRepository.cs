using Entities;
using MySql.Data.MySqlClient;
using System.Data;


namespace Repositories
{
    public class ClienteRepository
    {
        public List<Cliente> getClientes()
        {
            string query = "SELECT * FROM CLIENTE;";
            var dao = new DAO();
            DataTable dt = dao.Read(query);
            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente;
            foreach (DataRow dr in dt.Rows)
            {
                cliente = new Cliente{
                    Id = int.Parse(dr[0].ToString()!),
                    Nombre = dr[1].ToString()!,
                    Apellido = dr[2].ToString()!,
                    FechaNacimiento = Convert.ToDateTime(dr[3])!,
                    Direccion = dr[4].ToString() == null ? null : (dr[4].ToString()!),
                    Telefono = dr[5].ToString() == null ? null: long.Parse(dr[5].ToString()!),
                    Email = dr[6].ToString() == null ? null : dr[6].ToString()!,
                    Dni = long.Parse(dr[7].ToString()!),
                    Cuit = dr[8].ToString() == null ? null : long.Parse(dr[8].ToString()!),
                };
                clientes.Add(cliente);
            }
            return clientes;
        }
        public Cliente getCliente(long dni)
        {
            string query = "SELECT * FROM CLIENTE WHERE DNI=@P1;";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@P1", dni);
            var dao = new DAO();
            DataTable dt = dao.Read(query, parameters);
            Cliente cliente = new Cliente
            {
                Id = int.Parse(dt.Rows[0][0].ToString()!),
                Nombre = dt.Rows[0][1].ToString()!,
                Apellido = dt.Rows[0][2].ToString()!,
                FechaNacimiento = Convert.ToDateTime(dt.Rows[0][3])!,
                Direccion = dt.Rows[0][4].ToString() == null ? null : (dt.Rows[0][4].ToString()!),
                Telefono = dt.Rows[0][5].ToString() == null ? null : long.Parse(dt.Rows[0][5].ToString()!),
                Email = dt.Rows[0][6].ToString() == null ? null : dt.Rows[0][6].ToString()!,
                Dni = long.Parse(dt.Rows[0][7].ToString()!),
                Cuit = dt.Rows[0][8].ToString() == null ? null : long.Parse(dt.Rows[0][8].ToString()!),
            };
            return cliente;
        }
        public Cliente getCliente(int id)
        {
            string query = "SELECT * FROM CLIENTE WHERE ID=@P1;";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@P1", id);
            var dao = new DAO();
            DataTable dt = dao.Read(query, parameters);
            Cliente cliente = new Cliente
            {
                Id = int.Parse(dt.Rows[0][0].ToString()!),
                Nombre = dt.Rows[0][1].ToString()!,
                Apellido = dt.Rows[0][2].ToString()!,
                FechaNacimiento = Convert.ToDateTime(dt.Rows[0][3])!,
                Direccion = dt.Rows[0][4].ToString() == null ? null : (dt.Rows[0][4].ToString()!),
                Telefono = dt.Rows[0][5].ToString() == null ? null : long.Parse(dt.Rows[0][5].ToString()!),
                Email = dt.Rows[0][6].ToString() == null ? null : dt.Rows[0][6].ToString()!,
                Dni = long.Parse(dt.Rows[0][7].ToString()!),
                Cuit = dt.Rows[0][8].ToString() == null ? null : long.Parse(dt.Rows[0][8].ToString()!),
            };
            return cliente;
        }

        public int addCliente(Cliente cliente)
        {
            string query = "INSERT INTO CLIENTE (NOMBRE, APELLIDO, FECHA_NACIMIENTO, DIRECCION," +
                "TELEFONO, EMAIL, DNI, CUIT) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8);";
            MySqlParameter[] parameters = new MySqlParameter[8];
            parameters[0] = new MySqlParameter("@P1", cliente.Nombre);
            parameters[1] = new MySqlParameter("@P2", cliente.Apellido);
            parameters[2] = new MySqlParameter("@P3", cliente.FechaNacimiento);
            parameters[3] = new MySqlParameter("@P4", cliente.Direccion);
            parameters[4] = new MySqlParameter("@P5", cliente.Telefono);
            parameters[5] = new MySqlParameter("@P6", cliente.Email);
            parameters[6] = new MySqlParameter("@P7", cliente.Dni);
            parameters[7] = new MySqlParameter("@P8", cliente.Cuit);

            var dao = new DAO();
            return dao.Write(query, parameters);
        }
        private int getId()
        {
            string query1 = "SELECT COUNT(*) FROM CLIENTE;";        
            string query2 = "SELECT MAX(ID) + 1 FROM CLIENTE;";
            DAO dao = new DAO();
            DataTable dtCount = dao.Read(query1);

            if (dtCount.Rows[0][0] != null || int.Parse(dtCount.Rows[0][0].ToString()!) >= 1)
            {
                DataTable dtMax = dao.Read(query2);
                return int.Parse(dtMax.Rows[0][0].ToString()!);
            }
            return 1;
        }
    }
}
