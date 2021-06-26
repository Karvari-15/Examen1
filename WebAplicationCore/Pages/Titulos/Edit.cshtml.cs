using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity.dbo;
namespace WebAplicationCore.Pages.Titulos
{
    public class EditModel : PageModel
    {
        private readonly ITitulosService titulosService;

        public EditModel(ITitulosService titulosService)
        {
            this.titulosService = titulosService;
        }
        [BindProperty]
        public TitulosEntity Entity { get; set; } = new TitulosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await titulosService.GetById(entity: new() { Id_Titulo = id });
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
                if (Entity.Id_Titulo.HasValue)
                {
                    //Actualizar
                    var result = await titulosService.Update(entity: Entity);

                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData[key: "Msg"] = "Se actualizo correctamente";
                }
                else
                {
                    //Agregar
                    var result = await titulosService.Create(entity: Entity);

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
