using Microsoft.AspNetCore.Mvc;

namespace PWIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CadastroController : ControllerBase
    {
        private List<Cadastro> cadastros = new List<Cadastro>();

        private readonly ILogger<CadastroController> _logger;

        private static List<Cadastro> listaCadastro = new List<Cadastro>()
        {
            new Cadastro("12345678901","admin", Convert.ToDateTime("1989/06/13")),
            new Cadastro("23456789012","admin2", Convert.ToDateTime("1989/06/14"))
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

        [HttpGet("/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //https://localhost:7197/Cadastro GET
        public ActionResult<List<Cadastro>> Get()
        {
            return Ok(cadastros);
        }

        [HttpGet("/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro GET
        public ActionResult<Cadastro> GetByCpf(string cpf)
        {
            Cadastro cadastro = cadastros.Where(x => x.Cpf == cpf).FirstOrDefault();

            if (cadastro != null)
                return Ok(cadastro);
            else
                return NotFound(cadastro);
        }

        [HttpPost("/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //https://localhost:7197/Cadastro POST
        public ActionResult<Cadastro> Insert(string cpf, string name, DateTime dataNascimento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else if (dataNascimento.Year == 1 && dataNascimento.Month == 1 && dataNascimento.Day == 1)
                return BadRequest("É necessário informar uma data de nascimento.");
            Cadastro novoCadastro = new Cadastro(cpf, name, dataNascimento);
            if (novoCadastro != null)
            {
                cadastros.Add(novoCadastro);
                return CreatedAtAction(nameof(Insert), novoCadastro);
            }
            else
                return BadRequest();

        }

        [HttpDelete("{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro DELETE
        public ActionResult<Cadastro> Delete(string cpf)
        {
            Cadastro item = cadastros.Where(x => x.Cpf == cpf).FirstOrDefault();
            if (cadastros.Remove(item))
                return Ok(cadastros);
            return NotFound();
        }

        [HttpPut("/atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro PUT
        public ActionResult<Cadastro> Update(Cadastro cadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            Cadastro item = cadastros.FirstOrDefault(x => x.Cpf == cadastro.Cpf);
            if (item != null)
            {
                item = cadastro;
                return Ok(cadastro);
            }
            return NotFound();
        }
    }
}