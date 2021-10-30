using Application.Commands.CreatePerson;
using Application.Common.Mappings;
using AutoMapper;

namespace WebApi.Models.Persons
{
    public class CreatePersonDTO : IMapWith<CreatePersonCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonDTO, CreatePersonCommand>()
                .ForMember(personCommand => personCommand.FirstName, opt => opt.MapFrom(pDTO => pDTO.FirstName))
                .ForMember(personCommand => personCommand.LastName, opt => opt.MapFrom(pDTO => pDTO.LastName))
                .ForMember(personCommand => personCommand.MiddleName, opt => opt.MapFrom(pDTO => pDTO.MiddleName));
        }
    }
}
