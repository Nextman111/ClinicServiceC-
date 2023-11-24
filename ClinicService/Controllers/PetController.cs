using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }


        [HttpPost("create", Name = "PetCreate")]
        public ActionResult<int> Create([FromBody] CreatePetsRequest request)
        {
            Pet entity = new Pet();
            entity.ClientId = request.ClientId;
            entity.Name = request.Name;
            entity.Birthday = request.Birthday;
            return Ok(_petRepository.Create(entity));
        }

        [HttpPut("edit", Name = "PetUpdate")]
        public ActionResult<int> Update([FromBody] UpdatePetsRequest request)
        {
            Pet entity = new Pet();
            entity.PetId = request.PetId;
            entity.ClientId = request.ClientId;
            entity.Name = request.Name;
            entity.Birthday = request.Birthday;
            return Ok(_petRepository.Update(entity));
        }


        [HttpDelete("delete", Name = "PetDelete")]
        public ActionResult<int> Delete([FromQuery] int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all", Name = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }


        [HttpGet("get/{petId}", Name = "PetGetById")]
        public ActionResult<Pet> GetById([FromRoute] int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }

    }
}
