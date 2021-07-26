using Entidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
