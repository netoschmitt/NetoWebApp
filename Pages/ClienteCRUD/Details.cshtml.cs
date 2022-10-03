using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetoWebApp.Data;
using SuperOnline.Models;

namespace NetoWebApp.Pages.ClienteCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly NetoWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(NetoWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            else 
            {
                Cliente = cliente;
            }
            return Page();
        }
    }
}
