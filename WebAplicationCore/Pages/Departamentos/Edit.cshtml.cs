using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity.dbo;
namespace WebAplicationCore.Pages.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly IDepartamentosService departamentosService;

        public EditModel(IDepartamentosService departamentosService)
        {
            this.departamentosService = departamentosService;
        }
        [BindProperty]
        public DepartamentosEntity Entity { get; set; } = new DepartamentosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await departamentosService.GetById(entity: new() { Id_Departamento = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.Id_Departamento.HasValue)
                {
                    //Actualizar
                    var result = await departamentosService.Update(entity: Entity);

                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData[key: "Msg"] = "Se actualizo correctamente";
                }
                else
                {
                    //Agregar
                    var result = await departamentosService.Create(entity: Entity);

                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData[key: "Msg"] = "Se agrego correctamente";
                }
                return RedirectToPage(pageName: "Grid");
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }

    }
}
