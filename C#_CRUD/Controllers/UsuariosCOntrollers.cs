using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using C__CRUD.Models.Contexto;
using C__CRUD.Models.Entidades;
using Microsoft.Data.SqlClient;
using C__CRUD.Services;

namespace C__CRUD.Controllers
{
    public class UsuariosController : Controller
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        private readonly Contexto _contexto;

        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Aqui criamos um lista onde ela ja tem pessoas cadastradas, mas não é possivel excluir e alterar
        List<UsuarioServices> usuarios = UsuarioServices.GetUsuarioServices();

        public IActionResult Index()
        {
            // Pessoas ja cadastradas no SQL Server
            //cmd.Connection = conexao.Conectar();
            //cmd.CommandText = "insert into Usuario (Nome, Email, Senha) values('Danilo', 'Ahrkan@Ahrkan', '1234')";
            //cmd.ExecuteNonQuery(); // Esse comando manda a informação para o SQL Serve
            //conexao.Desconctar();

            var lista = _contexto.Usuario.ToList();

            // Nesse "return" e possivel escolher dois retornos, 1° a variavel "lista" ela tras as pessoas cadastradas no DB.
            // 2° a variavel "usuarios" nela retornamos as Pessoas ja cadastradas, mas essas pessoas são imutaveis.
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario _usuario)
        {
            var usuario = _contexto.Usuario.Find(_usuario.Id);
            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var usuario = _contexto.Usuario.Find(Id);
            return View(usuario);
        }

        /// <summary>
        /// 
        /// </summary>
    }
}