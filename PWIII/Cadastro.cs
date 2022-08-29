namespace PWIII
{
    public class Cadastro
    {

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

        public Cadastro(string cpf, string nome, DateTime dataNascimento, int idade)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = idade;
        }
        public Cadastro()
        {

        }

    }
}