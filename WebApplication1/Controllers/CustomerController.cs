using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase

    {
        private readonly IWebAppDBContext _context;
        public CustomerController(IWebAppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer cus)
        {
            cus.Id = Guid.NewGuid();
            await _context.Customers.AddAsync(cus);
            await _context.SaveChangesAsync();
            return Ok(cus);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]Guid id, [FromBody]Customer cus)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if(customer != null)
            {
                customer.Name = cus.Name;
                customer.MobileNo = cus.MobileNo;
                customer.EmailID = cus.EmailID;

                 _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return Ok(cus);
            }
            else
            {
                return NotFound("Customer not found");
            }
           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return Ok("Customer Deleted Sucessfully");
            }
            else
            {
                return NotFound("Customer not found");
            }

        }
    }
}