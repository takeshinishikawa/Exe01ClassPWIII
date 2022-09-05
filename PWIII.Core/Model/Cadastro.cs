using System.ComponentModel.DataAnnotations;//possibilita a cria��o de valida��es dos atributos, al�m do retorno de mensidadens de erro

namespace PWIII.Core
{
    public class Cadastro
    {
        public long Id { get; set; }

        [MinLength(11, ErrorMessage = "N�o existe CPF com menos de 11 n�meros")]
        [MaxLength(11, ErrorMessage = "N�o existe CPF com mais de 11 n�meros")]
        public string Cpf { get; set; }

        [MinLength(0, ErrorMessage = "N�o existe Nome vazio.")]
        [Required(ErrorMessage = "� necess�rio informar um nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data � obrigat�ria.")]
        //[Remote("IsValidDateOfBirth", "Validation", HttpMethod = "POST", ErrorMessage = "Por favor, informe uma data de nascimento v�lida.")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

        public int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idadeCalculada = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idadeCalculada))
                idadeCalculada--;
            return idadeCalculada;
        }
    }
}