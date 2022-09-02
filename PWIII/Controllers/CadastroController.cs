using Microsoft.AspNetCore.Mvc;
using PWIII.Repository;

namespace PWIII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CadastroController : ControllerBase
    {
        public CadastroRepository _repositoryCadastro;

        public CadastroController(IConfiguration configuration)
        {
            _repositoryCadastro = new CadastroRepository(configuration);
        }

        [HttpGet("/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //https://localhost:7197/Cadastro GET
        public ActionResult<List<Cadastro>> GetCadastros()
        {
            return Ok(_repositoryCadastro.GetCadastros());
        }

        [HttpGet("/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro GET
        public ActionResult<Cadastro> GetByCpf(string cpf)
        {
            Cadastro cadastro = _repositoryCadastro.GetByCpf(cpf);

            if (cadastro != null)
                return Ok(cadastro);
            else
                return NotFound(cadastro);
        }

        [HttpPost("/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //https://localhost:7197/Cadastro POST
        public ActionResult<Cadastro> Insert(Cadastro novoCadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else if (novoCadastro.DataNascimento.Year == 1 && novoCadastro.DataNascimento.Month == 1 && novoCadastro.DataNascimento.Day == 1)
                return BadRequest("É necessário informar uma data de nascimento.");
            novoCadastro.Idade = novoCadastro.CalcularIdade(novoCadastro.DataNascimento);
            if (_repositoryCadastro.Insert(novoCadastro))
                return CreatedAtAction(nameof(Insert), novoCadastro);
            else
                return BadRequest();
        }

        [HttpDelete("{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro DELETE
        public ActionResult<Cadastro> Delete(string cpf)
        {
            Cadastro cadastro = _repositoryCadastro.GetByCpf(cpf);
            if (_repositoryCadastro.Delete(cpf))
                return Ok(cadastro);
            return NotFound();
        }

        [HttpPut("/atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //https://localhost:7197/Cadastro PUT
        public ActionResult<Cadastro> Update(long id, Cadastro cadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            cadastro.Idade = cadastro.CalcularIdade(cadastro.DataNascimento);
            if (_repositoryCadastro.Update(id, cadastro))
                return Ok(cadastro);
            return NotFound();
        }
    }
}