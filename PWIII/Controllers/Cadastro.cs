using Microsoft.AspNetCore.Mvc;

namespace PWIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private List<Cadastro> cadastros { get; set; }

        private readonly ILogger<CadastroController> _logger;

        private static List<Cadastro> listaCadastro = new List<Cadastro>()
        {
            new Cadastro("admin","12345678901", Convert.ToDateTime("1989/06/13"), 33),
            new Cadastro("admin2","23456789012", Convert.ToDateTime("1989/06/14"), 33)
        };
        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
            cadastros = listaCadastro.Select(x => new Cadastro
            {
                Cpf = x.Cpf,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Idade = x.Idade,
            }).ToList();
        }

        [HttpGet]
        //https://localhost:7197/Cadastro GET
        public IActionResult Consulta()
        {
            return Ok(cadastros);
        }
        [HttpPost]
        //https://localhost:7197/Cadastro POST
        public Cadastro Insert(Cadastro cadastro)
        {
            cadastros.Add(cadastro);
            return cadastro;
        }

        [HttpDelete]
        //https://localhost:7197/Cadastro DELETE
        public Cadastro Delete(Cadastro cadastro)
        {
            cadastros.Remove(cadastro);
            return cadastro;
        }

        [HttpPut]
        //https://localhost:7197/Cadastro PUT
        public Cadastro Update(Cadastro cadastro)
        {
            Cadastro item = cadastros.FirstOrDefault(x => x.Cpf == cadastro.Cpf);
            if (item != null)
                item = cadastro;

            return cadastro;
        }

    }
}