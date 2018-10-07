using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Model.Request.Post;
using Store.API.Model.Response.Get;
using Store.Application.Interface;

namespace StoreSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApp _customerApp;

        [HttpGet]
        [Route("Index")]
        public ActionResult<IEnumerable<string>> Default()
        {
            return new string[] { "index" };
        }

        public CustomerController(ICustomerApp customerApp) {
            _customerApp = customerApp;
        }

        /// <summary>
        /// Get Customers
        /// </summary>        
        /// <returns></returns>
        /// <response code="200">Customers returned</response>
        /// <response code="400">An error occurred to get the customers</response>        
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get()
        { 
            List<GetCustomerResponseModelView> customerResponse = await _customerApp.Get();

            return Ok(customerResponse);
        }

        /// <summary>
        /// Insert a Customer
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        /// <response code="200">Customer inserted</response>
        /// <response code="400">An error occurred to insert the customers</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] PostCustomerRequestViewModel customerRequest)
        {
            if (!ModelState.IsValid)
            {
                return Ok(customerRequest);
            }

            var resultInsertion = await _customerApp.Insert(customerRequest);            

            return Ok(resultInsertion);
        }
    }
}