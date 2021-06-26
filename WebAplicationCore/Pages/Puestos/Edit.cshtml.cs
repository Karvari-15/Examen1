using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity.dbo;
namespace WebAplicationCore.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly IPuestosService puestosService;

        public EditModel(IPuestosService puestosService)
        {
            this.puestosService = puestosService;
        }
        [BindProperty]
        public PuestosEntity Entity { get; set; } = new PuestosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await puestosService.GetById(entity: new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)
                {
                    //Actualizar
                    var result = await puestosService.Update(entity: Entity);

                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData[key: "Msg"] = "Se actualizo correctamente";
                }
                else
                {
                    //Agregar
                    var result = await puestosService.Create(entity: Entity);

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
