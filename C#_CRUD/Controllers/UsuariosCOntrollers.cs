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
    [Route("Usuario")]
    public class UsuariosController : Controller
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        private Contexto _contexto;
        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Aqui criamos um lista onde ela ja tem pessoas cadastradas, mas não é possivel excluir e alterar
        List<UsuarioServices> usuarios = UsuarioServices.GetUsuarioServices();

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.usuario = _contexto.Usuario.ToList();
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string nomeAcionar, string emailAcionar, string senhaAcionar)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario{
                    NomeUsuario = nomeAcionar,
                    Email = emailAcionar,
                    Senha = senhaAcionar
                };
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("find/{id}")]
        public IActionResult Edit(int id)
        {
            var usuarioEdit = _contexto.Usuario.Find(id);
            return new JsonResult(usuarioEdit);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(int id, string nomeUsuario, string email, string senha)
        {
            var usuarioEdit = _contexto.Usuario.Find(id);
            usuarioEdit.NomeUsuario = nomeUsuario;
            usuarioEdit.Email = email;
            usuarioEdit.Senha = senha;
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int idDelete)
        {
            var usuarioDelete = _contexto.Usuario.Find(idDelete);
            _contexto.Usuario.Remove(usuarioDelete);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
    }
}