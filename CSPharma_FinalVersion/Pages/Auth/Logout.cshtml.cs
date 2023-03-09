using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSPharma_FinalVersion.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                //Limpiamos la session y redireccionamos al index
                HttpContext.Session.Clear();
                Redirect("../index");
            }catch (Exception ex)
            {
                Redirect("../Error");
            }
        }
    }
}
