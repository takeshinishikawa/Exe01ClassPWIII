namespace PWIII.Core.Inteface
{
    public interface ICadastroRepository
    {
        List<Cadastro> GetCadastros();
        Cadastro GetByCpf(string cpf);
        bool Insert(Cadastro novoCliente);
        bool Delete(string cpf);
        bool Update(long id, Cadastro cadastro);
    }
}
