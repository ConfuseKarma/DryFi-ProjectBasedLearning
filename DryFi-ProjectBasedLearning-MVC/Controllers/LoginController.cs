﻿using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult FazLogin(string usuario, string senha)
        {
            //Este é apenas um exemplo, aqui você deve consultar na sua tabela de usuários
            //se existe esse usuário e senha
            if (usuario == "admin" && senha == "1234")
            {
                HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }


}
