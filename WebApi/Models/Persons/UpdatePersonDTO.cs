using Application.Commands.UpdatePerson;
using Application.Common.Mappings;
using AutoMapper;

namespace WebApi.Models.Persons
{
    public class UpdatePersonDTO : IMapWith<UpdatePersonCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDTO, UpdatePersonCommand>()
                .ForMember(personCommand => personCommand.FirstName, opt => opt.MapFrom(pDTO => pDTO.FirstName))
                .ForMember(personCommand => personCommand.LastName, opt => opt.MapFrom(pDTO => pDTO.LastName))
                .ForMember(personCommand => personCommand.MiddleName, opt => opt.MapFrom(pDTO => pDTO.MiddleName));
        }
    }
}
