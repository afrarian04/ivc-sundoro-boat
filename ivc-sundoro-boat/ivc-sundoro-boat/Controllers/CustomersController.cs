#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ivc_sundoro_boat.Models;
using ivc_sundoro_boat.ViewModels;

namespace ivc_sundoro_boat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly d576bg3m9fd4sfContext _context;

        public CustomersController(d576bg3m9fd4sfContext context)
        {
            _context = context;
        }

        // Post: api/Customers/GetDataCustomers
        [HttpPost]
        [Route("GetDataCustomers")]
        public async Task<ActionResult<IEnumerable<DataCustomer>>> GetDataCustomers([FromBody] RequestVM req)
        {
            try
            {
                var getList = await _context
                .DataCustomers
                .Skip((req.PageIndex - 1) * req.PageLimit)
                .Take(req.PageLimit)
                .ToListAsync();

                List<CustomerLoadVM> list = new List<CustomerLoadVM>();

                foreach (var item in getList)
                {
                    CustomerLoadVM data = new CustomerLoadVM();
                    data.Uuid = item.Uuid;
                    data.CreatedAt = item.CreatedAt;
                    data.BoatPrice = item.BoatPrice;
                    data.CustName = item.CustName;
                    data.DateIvc = item.DateIvc.ToString();
                    data.RentDate = item.RentDate.ToString();
                    data.IsPph = item.IsPph;
                    data.Note = item.Note;
                    data.Necessity = item.Necessity;
                    data.NumberIvc = item.NumberIvc;
                    data.PphValue = item.PphValue;
                    data.RentTime = item.RentTime;

                    list.Add(data);
                }

                return Ok(new { Code = 1, Message = "Success", Data = list });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Code = -1, Message = ex.Message });
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerLoadVM>> GetDataCustomer(Guid id)
        {
            var dataCustomer = await _context.DataCustomers.FindAsync(id);

            if (dataCustomer == null)
            {
                return NotFound();
            }

            CustomerLoadVM data = new CustomerLoadVM();
            data.Uuid = dataCustomer.Uuid;
            data.CreatedAt = dataCustomer.CreatedAt;
            data.BoatPrice = dataCustomer.BoatPrice;
            data.CustName = dataCustomer.CustName;
            data.DateIvc = dataCustomer.DateIvc.ToString();
            data.RentDate = dataCustomer.RentDate.ToString();
            data.IsPph = dataCustomer.IsPph;
            data.Note = dataCustomer.Note;
            data.Necessity = dataCustomer.Necessity;
            data.NumberIvc = dataCustomer.NumberIvc;
            data.PphValue = dataCustomer.PphValue;
            data.RentTime = dataCustomer.RentTime;

            return data;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataCustomer(Guid id, DataCustomer dataCustomer)
        {
            if (id != dataCustomer.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(dataCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataCustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataCustomer>> PostDataCustomer(CustomerVM req)
        {
            try
            {
                DataCustomer data = new DataCustomer();
                data.DateIvc = DateOnly.FromDateTime(req.DateIvc);
                data.CustName = req.CustName;
                data.RentDate = DateOnly.FromDateTime(req.RentDate);
                data.CreatedAt = DateTime.Now;
                data.NumberIvc = req.NumberIvc;
                data.BoatPrice = req.BoatPrice;
                data.Necessity = req.Necessity;
                data.Note = req.Note;
                data.RentTime = req.RentTime;

                data.IsPph = req.IsPph;
                if (req.IsPph && req.PphValue.HasValue)
                {
                    data.PphValue = req.PphValue;
                }


                _context.DataCustomers.Add(data);
                _context.SaveChangesAsync().Wait();

                return Ok( new { Code = 1, Message = "Data Customer Saved" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Code = -1, Message = ex.Message });
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataCustomer(Guid id)
        {
            var dataCustomer = await _context.DataCustomers.FindAsync(id);
            if (dataCustomer == null)
            {
                return NotFound();
            }

            _context.DataCustomers.Remove(dataCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataCustomerExists(Guid id)
        {
            return _context.DataCustomers.Any(e => e.Uuid == id);
        }
    }
}
