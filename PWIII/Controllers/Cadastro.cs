using Microsoft.AspNetCore.Mvc;

namespace PWIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Cadastro : ControllerBase
    {
        public List<PWIII.Cadastro> cadastros { get; set; }

        private readonly ILogger<Cadastro> _logger;


        public Cadastro(ILogger<Cadastro> logger)
        {
            _logger = logger;
            cadastros = new List<PWIII.Cadastro>();
        }

        [HttpGet]
        //https://localhost:7197/Cadastro GET
        public IEnumerable<PWIII.Cadastro> Consulta()
        {
            return cadastros.ToList();
        }
        [HttpPost]
        //https://localhost:7197/Cadastro POST
        public PWIII.Cadastro Insert(PWIII.Cadastro cadastro)
        {
            cadastros.Add(cadastro);
            return cadastro;
        }

        [HttpDelete]
        //https://localhost:7197/Cadastro DELETE
        public PWIII.Cadastro Delete(PWIII.Cadastro cadastro)
        {
            cadastros.Remove(cadastro);
            return cadastro;
        }

        [HttpPut]
        //https://localhost:7197/Cadastro PUT
        public PWIII.Cadastro Update(PWIII.Cadastro cadastro)
        {
            PWIII.Cadastro item = cadastros.FirstOrDefault(x => x.Cpf == cadastro.Cpf);
            if (item != null)
                item = cadastro;

            return cadastro;
        }

    }
}