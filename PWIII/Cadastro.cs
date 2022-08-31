using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;//possibilita a criação de validações dos atributos, além do retorno de mensidadens de erro

namespace PWIII
{
    public class Cadastro
    {
        [MinLength(11, ErrorMessage = "Não existe CPF com menos de 11 números")]
        [MaxLength(11, ErrorMessage = "Não existe CPF com mais de 11 números")]
        public string Cpf { get; set; }

        [MinLength(0, ErrorMessage = "Não existe Nome vazio.")]
        [Required(ErrorMessage = "É necessário informar um nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data é obrigatória.")]
        [Remote("IsValidDateOfBirth", "Validation", HttpMethod = "POST", ErrorMessage = "Por favor, informe uma data de nascimento válida.")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

        public Cadastro(string cpf, string nome, DateTime dataNascimento)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Idade = CalcularIdade(dataNascimento);
        }
        public Cadastro()
        {

        }

        public int CalcularIdade(DateTime dataNascimento)
        {
            // Save hoje's date.
            var hoje = DateTime.Today;

            // Calculate the idade.
            var idadeCalculada = hoje.Year - dataNascimento.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dataNascimento.Date > hoje.AddYears(-idadeCalculada))
                idadeCalculada--;
            return idadeCalculada;
        }
    }
}