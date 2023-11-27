using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ClinicService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        [HttpPost("create", Name = "ClientCreate")]
        public ActionResult<int> Create([FromBody] CreateClientRequest createRequest)
        {

            if (string.IsNullOrEmpty(createRequest.SurName))
            {
                return Ok(new
                {
                    ErrCode = -10,
                    ErrMessage = "Фамилия указана некорректно.",
                });
            }

            if (string.IsNullOrEmpty(createRequest.FirstName))
            {
                return Ok(new
                {
                    ErrCode = -11,
                    ErrMessage = "Имя указано некорректно.",
                });
            }

            if (string.IsNullOrEmpty(createRequest.Patronymic))
            {
                return Ok(new
                {
                    ErrCode = -12,
                    ErrMessage = "Отчество указага некорректно.",
                });
            }

            if (createRequest.Birthday > DateTime.Now.AddYears(-18))
            {
                return Ok(new
                {
                    ErrCode = -13,
                    ErrMessage = "Возраст должен быть указан корректно.",
                });
            }

            if (string.IsNullOrEmpty(createRequest.Document)  ||
                createRequest.Document.Length < 10)
            {
                return Ok(new
                {
                    ErrCode = -13,
                    ErrMessage = "Документ должен быть указан корректно.",
                });
            }


            Client client = new Client();
            client.Document = createRequest.Document;
            client.SurName = createRequest.SurName;
            client.FirstName = createRequest.FirstName;
            client.Patronymic = createRequest.Patronymic;
            client.Birthday = createRequest.Birthday;
            return Ok(_clientRepository.Create(client));
        }

        [HttpPut("edit", Name = "ClientUpdate")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest updateRequest)
        {
            if (string.IsNullOrEmpty(updateRequest.SurName))
            {
                return Ok(new
                {
                    ErrCode = -10,
                    ErrMessage = "Фамилия указана некорректно.",
                });
            }

            if (string.IsNullOrEmpty(updateRequest.FirstName))
            {
                return Ok(new
                {
                    ErrCode = -11,
                    ErrMessage = "Имя указано некорректно.",
                });
            }

            if (string.IsNullOrEmpty(updateRequest.Patronymic))
            {
                return Ok(new
                {
                    ErrCode = -12,
                    ErrMessage = "Отчество указага некорректно.",
                });
            }

            if (updateRequest.Birthday > DateTime.Now.AddYears(-18))
            {
                return Ok(new
                {
                    ErrCode = -13,
                    ErrMessage = "Возраст должен быть указан корректно.",
                });
            }

            if (string.IsNullOrEmpty(updateRequest.Document) ||
                updateRequest.Document.Length < 10)
            {
                return Ok(new
                {
                    ErrCode = -13,
                    ErrMessage = "Документ должен быть указан корректно.",
                });
            }

            if (updateRequest.ClientId < 0)
            {
                return Ok(new
                {
                    ErrCode = -14,
                    ErrMessage = "Id указан некорректно.",
                });
            }

            Client client = new Client();
            client.ClientId = updateRequest.ClientId;
            client.Document = updateRequest.Document;
            client.SurName = updateRequest.SurName;
            client.FirstName = updateRequest.FirstName;
            client.Patronymic = updateRequest.Patronymic;
            client.Birthday = updateRequest.Birthday;
            return Ok(_clientRepository.Update(client));
        }


        [HttpDelete("delete", Name = "ClientDelete")]
        public ActionResult<int> Delete([FromQuery] int clientId)
        {

            if (clientId < 0)
            {
                return Ok(new
                {
                    ErrCode = -14,
                    ErrMessage = "Id указан некорректно.",
                });
            }
            int res = _clientRepository.Delete(clientId);
            return Ok(res);
        }

        [HttpGet("get-all", Name = "ClientGetAll")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }


        [HttpGet("get/{clientId}", Name = "ClientGetById")]
        public ActionResult<Client> GetById([FromRoute] int clientId)
        {
            return Ok(_clientRepository.GetById(clientId));
        }

    }
}
