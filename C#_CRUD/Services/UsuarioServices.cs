using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using C__CRUD.Models.Contexto;
using C__CRUD.Controllers;
using C__CRUD.Models.Entidades;

namespace C__CRUD.Services{
    // Aqui Cadastramos as pessoas imutaveis.
    class UsuarioServices : Usuario{

        public static List<UsuarioServices> GetUsuarioServices()
            {
                var listaUsuarioServices = new List<UsuarioServices>()
                {
                    new UsuarioServices { Id = 1, NomeUsuario = "Danilo", Email = "Ahrkan@Ahrkan.com", Senha = "9999"},
                    new UsuarioServices { Id = 2, NomeUsuario = "Keila", Email = "Keila@Keila.com", Senha = "0000"},
                    new UsuarioServices { Id = 3, NomeUsuario = "Marco", Email = "Marco@Marco.com", Senha = "1111"},
                    new UsuarioServices { Id = 4, NomeUsuario = "Cafe", Email = "Cafe@Cafe.com", Senha = "2222"},
                    new UsuarioServices { Id = 5, NomeUsuario = "Leite", Email = "Leite@Leite.com", Senha = "3333"},
                };
                return listaUsuarioServices;
            }
        }
    }