using ApiClientes.Data;
using ApiClientes.Models;
using ApiClientes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ValidationService _validationService;

        public ClientesController(AppDbContext context, ValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllClientes()
        {
            var clientes = await _context.Clientes
                .Where(c => c.Ativo) 
                .Select(c => new {
                    c.Id,
                    c.Nome,
                    c.Email,
                    c.Telefone,
                    c.Cidade
                })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            var isCpfValido = await _validationService.IsCpfValido(cliente.Cpf);
            if (!isCpfValido)
            {
                return BadRequest(new { message = "O CPF informado é inválido ou não foi encontrado na base de dados do governo." });
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do cliente no corpo da requisição.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Ativo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}