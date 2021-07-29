using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBancoDigital.Models;
using System.Net;

namespace ApiBancoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasDigitaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasDigitaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaDigital>>> GetContasDigitais()
        {
            return await _context.ContasDigitais.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaDigital(int id, ContaDigital contaDigital)
        {
            if (id != contaDigital.Id)
            {
                return BadRequest();
            }

            _context.Entry(contaDigital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaDigitalExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ContaDigital>> PostContaDigital(ContaDigital contaDigital)
        {
            _context.ContasDigitais.Add(contaDigital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaDigital", new { id = contaDigital.Id }, contaDigital);
        }

        [HttpPut("/{id}/sacar")]
        public async Task<IActionResult> SacarContaDigital(int id, double sacar)
        {
            var contaDigital = await _context.ContasDigitais.FindAsync(id);
            if (contaDigital == null)
            {
                return NotFound();
            }

            contaDigital.Saldo = (contaDigital.Saldo - sacar);

            if (sacar > contaDigital.Saldo)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();


            return NoContent();
        }

        [HttpPut("/{id}/depositar")]
        public async Task<IActionResult> DepositarContaDigital(int id, double depositar)
        {
            var contaDigital = await _context.ContasDigitais.FindAsync(id);
            if (contaDigital == null)
            {
                return NotFound();
            }

            contaDigital.Saldo = (contaDigital.Saldo + depositar);

            _context.Entry(contaDigital).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool ContaDigitalExists(int id)
        {
            return _context.ContasDigitais.Any(e => e.Id == id);
        }
    }
}
