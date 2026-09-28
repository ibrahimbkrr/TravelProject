using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Business.Abstract;
using TravelProject.Dto.ContactDtos;
using TravelProject.Entity.Entities;

namespace TravelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(
            IContactService contactService,
            IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllContactAsync();

            var result = _mapper.Map<List<ResultContactDto>>(contacts);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ResultContactDto>(contact);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);

            await _contactService.AddContactAsync(contact);

            return Ok("İletişim mesajı başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var existingContact =
                await _contactService.GetContactByIdAsync(updateContactDto.ContactId);

            if (existingContact == null)
            {
                return NotFound();
            }

            _mapper.Map(updateContactDto, existingContact);

            await _contactService.UpdateContactAsync(existingContact);

            return Ok("İletişim mesajı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            await _contactService.DeleteContactAsync(id);

            return Ok("İletişim mesajı başarıyla silindi.");
        }
    }
}