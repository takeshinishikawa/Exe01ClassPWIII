using PWIII.Core.Inteface;

namespace PWIII.Core.Service
{
    public class CadastroService : ICadastroService
    {
        public ICadastroRepository _cadastroRepository;

        public CadastroService(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }
        public bool Delete(string cpf)
        {
            return _cadastroRepository.Delete(cpf);
        }
        public Cadastro GetByCpf(string cpf)
        {
            return _cadastroRepository.GetByCpf(cpf);
        }
        public Cadastro GetById(long id)
        {
            return _cadastroRepository.GetById(id);
        }
        public List<Cadastro> GetCadastros()
        {
            return _cadastroRepository.GetCadastros();
        }
        public bool Insert(Cadastro novoCliente)
        {
            return _cadastroRepository.Insert(novoCliente);
        }
        public bool Update(long id, Cadastro cadastro)
        {
            return _cadastroRepository.Update(id, cadastro);
        }
    }
}
