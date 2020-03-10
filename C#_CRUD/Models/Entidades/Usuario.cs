using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace C__CRUD.Models.Entidades
{
    
    [Table("Usuario")]
    public class Usuario
    {
        [Display(Description ="Código")]     
        public int Id { get; set; }

        [Display(Name = "Nome do Usuário")]
        [Column("Nome")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string NomeUsuario { get; set; }

        [Display(Description = "Email do Usuário")]
        [Column("Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Display(Description = "Senha do Usuário")]
        [Column("Senha")]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
    }
}
