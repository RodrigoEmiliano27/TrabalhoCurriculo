using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCurriculo.Classes
{
    public class TextosValidacoes
    {
        string nome_vazio;
        string nascimento_invalido;
        string telefone_vazio;
        string cpf_vazio;
        string cpf_invalido;
        string email_vazio;
        string email_invalido;
        string cargo_vazio;
        string rua_vazio;
        string numero_invalido;
        string cep_vazio;
        string bairro_vazio;
        string estado_vazio;
        public string Nome_vazio { get => nome_vazio; }
        public string Nascimento_invalido { get => nascimento_invalido; }
        public string Cargo_vazio { get => cargo_vazio; }
        public string Telefone_vazio { get => telefone_vazio; }
        public string Cpf_vazio { get => cpf_vazio; }
        public string Cpf_invalido { get => cpf_invalido; }
        public string Email_vazio { get => email_vazio; }
        public string Email_invalido { get => Email_invalido; }
        public string Rua_vazio { get => rua_vazio; }
        public string Numero_invalido { get => Numero_invalido; }
        public string Cep_vazio { get => cep_vazio; }
        public string Bairro_vazio { get => bairro_vazio; }
        public string Estado_vazio { get => estado_vazio; }
        public TextosValidacoes(string idioma)
        {
            switch (idioma)
            {
                case "I":
                    ValidacaoEmIngles();
                    break;
                case "P":
                    ValidacaoEmPortugues();
                    break;
                default:
                    ValidacaoEmPortugues();
                    break;

            }
        }
        
        private void ValidacaoEmPortugues()
        {
            nome_vazio="Preencha o nome!";
            nascimento_invalido="Data de nascimento inválida!";
            telefone_vazio="Preencha o Telefone!";
            cpf_vazio="Preencha o CPF";
            cpf_invalido="CPF inválido!";
            email_vazio="Preencha o Email";
            email_invalido="Email inválido!";
            cargo_vazio="Preencha o cargo pretendido!";
            rua_vazio="Preencha a Rua";
            numero_invalido="Número de endereço inválido";
            cep_vazio="Preencha o CEP";
            bairro_vazio="Preencha o bairro";
            estado_vazio="Preencha o estado!";
        }
        private void ValidacaoEmIngles()
        {
            nome_vazio = "Name is blank!";
            nascimento_invalido = "birth date invalid!";
            telefone_vazio = "Telephone number is blank!";
            cpf_vazio = "CPF is blank!";
            cpf_invalido = "Invalid CPF!";
            email_vazio = "Email is blank!";
            email_invalido = "Invalid Email! ";
            cargo_vazio = "Intended position is blank!";
            rua_vazio = "Street is blank!";
            numero_invalido = "Invalid addess number! ";
            cep_vazio = "CEP is blank!";
            bairro_vazio = "Neighborhood is blank!";
            estado_vazio = "State is blank!";
        }


    }
}
