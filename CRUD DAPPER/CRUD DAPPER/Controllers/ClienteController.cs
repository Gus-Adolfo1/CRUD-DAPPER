using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Logic;


namespace CRUD_DAPPER.Controllers
{
    public class ClienteController : Controller
    {
      LogicClient  logicCliente = new LogicClient();

        // GET: ClienteController
        public ActionResult Index()
        {
            var roles = logicCliente.getAll();
            return View(roles);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var cliente = logicCliente.getId(id);

            if (cliente == null)
            {
                return NotFound();
            }


            return View(cliente);



        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();

            
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    logicCliente.Create(cliente);

                    TempData["mensaje"] = "El usuario se a creado correctamente";
                }

               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var cliente = logicCliente.getId(id);

            if (cliente == null)
            {
                return NotFound();
            }


            return View(cliente);
        
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pCliente = logicCliente.Update(cliente,cliente.Id);
                    TempData["mensaje"] = "El usuario se ha actualizado correctamente";
                    return RedirectToAction("Index");
                }

                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var cliente = logicCliente.getId(id);

            if (cliente == null)
            {
                return NotFound();
            }


            return View(cliente);
           
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(Cliente cliente)
        {
            try
            {


                var pCliente = logicCliente.Delete(cliente.Id);

                TempData["mensaje"] = "El libro se ha borrado correctamente";
           

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
       
            }
        }
    }
}
