using Microsoft.AspNetCore.Mvc;
using WebApp_Manha.Models;

namespace WebApp_Manha.Controllers
{
    public class ClientesController : Controller
    {
        public static List<ClienteViewModel> lista = new List<ClienteViewModel>();
        public IActionResult Lista()
        {
            //ClienteViewModel novo = new ClienteViewModel();
            //novo.Nome = "Fernando Graciano";
            //novo.Id = 10;
            //novo.Telefone = "16991340447";
            //ClienteViewModel novo2 = new ClienteViewModel();
            //novo2.Nome = "Julio Garcia";
            //novo2.Id = 5;
            //novo2.Telefone = "169874563214";
            //lista.Add(novo);
            //lista.Add(novo2);

            return View(lista);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarDados(ClienteViewModel model)
        {
            if(model.Id > 0)
            {
                int indice = lista.FindIndex(a => a.Id == model.Id);
                lista[indice] = model;

            }
            else
            {
                Random random = new Random();
                model.Id = random.Next(1, 9999);
                lista.Add(model);
            }
           
            return RedirectToAction("Lista");
        }

        [HttpPost]
        public IActionResult Cadastro(string Nome, string Telefone)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                TempData["Erro"] = "O campo nome não pode estar em branco";
            }

            if (string.IsNullOrEmpty(Telefone))
            {
                TempData["Erro"] = "O campo Telefone não pode estar em branco";
            }
            return View();
        }


        public IActionResult Editar(int id)
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Lista");
            }
            
        }



        public IActionResult Excluir(int id)
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if(cliente != null)
            {
                lista.Remove(cliente);
            }

            return RedirectToAction("Lista");
        }



        public IActionResult Compras(int id)
        {
            return View();
        }
    }
}
