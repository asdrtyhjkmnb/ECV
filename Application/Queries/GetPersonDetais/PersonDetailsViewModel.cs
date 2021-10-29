using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Queries.GetPersonDetais
{
    public class PersonDetailsViewModel : IMapWith<Person>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonDetailsViewModel>()
                .ForMember(view => view.FirstName, opt => opt.MapFrom(person => person.FirstName))
                .ForMember(view => view.LastName, opt => opt.MapFrom(person => person.LastName))
                .ForMember(view => view.MiddleName, opt => opt.MapFrom(person => person.MiddleName))
                .ForMember(view => view.Created, opt => opt.MapFrom(person => person.Created.ToShortDateString()));
        }
    }
}
