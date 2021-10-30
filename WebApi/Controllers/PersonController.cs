using Application.Commands.CreatePerson;
using Application.Commands.DeletePerson;
using Application.Commands.UpdatePerson;
using Application.Queries.GetPersonDetais;
using Application.Queries.GetPersonList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Persons;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IMapper mapper;

        public PersonController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonViewModelList>> GetAll()
        {
            var query = new GetPersonListQuery();

            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<PersonDetailsViewModel>> Get(Guid guid)
        {
            var query = new GetPersonDetailsQuery
            {
                Guid = guid
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonDTO person)
        {
            var command = mapper.Map<CreatePersonCommand>(person);
            var personId = await Mediator.Send(command);
            return Ok(personId);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdatePersonDTO person)
        {
            var command = mapper.Map<UpdatePersonCommand>(person);
            var personId = await Mediator.Send(command);
            return Ok(personId);
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<PersonDetailsViewModel>> Delete(Guid guid)
        {
            var command = new DeletePersonCommand()
            {
                Id = guid
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
