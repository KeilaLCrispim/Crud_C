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

        [Display(Description = "Nome do Usuário")]
        [Column("Nome")]
        public string NomeUsuario { get; set; }

        [Display(Description = "Email do Usuário")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Description = "Senha do Usuário")]
        [Column("Senha")]
        public string Senha { get; set; }
    }
}
