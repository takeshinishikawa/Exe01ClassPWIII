using Dapper;
using Microsoft.Data.SqlClient;

namespace PWIII.Repository
{
    public class CadastroRepository
    {
        private readonly IConfiguration _configuration;
        public CadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cadastro> GetCadastros()
        {
            var query = "SELECT * FROM clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Cadastro>(query).ToList();
        }

        public Cadastro GetByCpf(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf LIKE @cpf";

            var parameters = new DynamicParameters(new
            {
                cpf
            });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Cadastro>(query, parameters);
        }

        public bool Insert(Cadastro novoCliente)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", novoCliente.Cpf);
            parameters.Add("nome", novoCliente.Nome);
            parameters.Add("dataNascimento", novoCliente.DataNascimento);
            parameters.Add("idade", novoCliente.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool Delete(string cpf)
        {
            var query = "DELETE FROM clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool Update(long id, Cadastro cadastro)
        {
            var query = "UPDATE clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";

            cadastro.Id = id;
            var parameters = new DynamicParameters(cadastro);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

    }
}
