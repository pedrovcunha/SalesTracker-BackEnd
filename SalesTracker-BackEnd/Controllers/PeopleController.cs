using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Domain.Contracts.UnitOfWork;
using SalesTracker.Domain.Entities;

namespace SalesTracker.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public delegate object DateTimePersonDob(string key, object value);

        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private async Task<bool> PersonExists(int id)
        {
            People person = await _unitOfWork.People.FindAsync(id);
           return !person.Equals(null) ? true : false;
        }

        [HttpGet]
        [Produces(typeof(DbSet<People>))]
        [ResponseCache(Duration = 60)]
        public IActionResult GetPerson()
        {
            var results = new ObjectResult(_unitOfWork.People.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            Request.HttpContext.Response.Headers.Add("X-Total-Count", _unitOfWork.People.GetAll().Count().ToString());

            return results;
        }

        [HttpGet("{id}")]
        [Produces(typeof(People))]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Person = await _unitOfWork.People.FindAsync(id);
            var Person2 = _unitOfWork.People.GetByID(new People { Id = id });

            if (Person == null)
            {
                return NotFound();
            }

            return Ok(Person);

        }


        [HttpPost]
        [Produces(typeof(People))]
        public async Task<IActionResult> PostPerson([FromBody] People Person)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Id set as Identity by SQLServer - auto incremented - indexed
            // if Person id is not set at the json.
            //if (Person.Id == 0)
            //{
            //    int totalPersons = _unitOfWork.People.GetAll().Count();
            //    Person.Id = totalPersons + 1;
            //}


            await _unitOfWork.People.AddAsync(Person);
            _unitOfWork.Save();

            return CreatedAtAction("GetPerson", new { id = Person.Id }, Person);
        }

        [HttpPut("{id}")]
        [Produces(typeof(People))]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] People Person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Person.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.People.Update(Person);
                return Ok(Person);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        [HttpDelete("{id}")]
        [Produces(typeof(People))]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await PersonExists(id))
            {
                return NotFound();
            }
            _unitOfWork.People.Delete(id);

            return Ok();
        }

    }
}
