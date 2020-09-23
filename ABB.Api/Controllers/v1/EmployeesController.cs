using ABB.Application.Models.v1.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ABB.Api.Controllers.v1
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
            => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpHead, HttpGet(Name = "v1/getallemployees")]
        [ProducesResponseType(200, Type = typeof(GetAllEmployeesResponseModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute]GetAllEmployeesRequestModel model)
        {
            var response = await _mediator.Send(model).ConfigureAwait(false);
            return response == null ? NotFound() : (IActionResult)Ok(response);
        }

        [HttpGet("{id}", Name = "v1/getemployeebyid")]
        [ProducesResponseType(200, Type = typeof(GetEmployeeByIdRequestModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmployeeById([FromRoute] GetEmployeeByIdRequestModel model)
        {
            var response = await _mediator.Send(model).ConfigureAwait(false);
            return response == null ? NotFound() : (IActionResult)Ok(response);
        }

        [HttpPost(Name = "v1/createemployeebyid")]
        [ProducesResponseType(201, Type = typeof(int))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]CreateEmployeeRequestModel model)
        {
            var id = await _mediator.Send(model).ConfigureAwait(false);
            return CreatedAtRoute("v1/getemployeebyid", id);
        }

        [HttpDelete("{id}", Name = "v1/deleteemployeebyid")]
        [ProducesResponseType(200, Type = typeof(void))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute]DeleteEmployeeRequestModel model)
        {
            await _mediator.Send(model).ConfigureAwait(false);
            return NoContent();
        }
    }
}
