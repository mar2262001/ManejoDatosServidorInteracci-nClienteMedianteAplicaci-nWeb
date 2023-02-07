using AutoMapper;
using ModelLayerLaboratory;
using WebLayerLaboratory.Models;

namespace WebLayerLaboratory.MapperProfile
{
	public class BookProfile : Profile
	{
		public BookProfile() { 
			CreateMap<BookModel, BookViewModel>()
				.ForMember(dest =>
					dest.Id,
					opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.CountryId,
                    opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest =>
					dest.Title,
					opt => opt.MapFrom(src => src.Title))
				.ForMember(dest =>
					dest.Editorial,
					opt => opt.MapFrom(src => src.Editorial)) 
				
				.ForMember(dest =>
					dest.Author,
					opt => opt.MapFrom(src => src.Author)) 
				.ForMember(dest =>
					dest.Year,
					opt => opt.MapFrom(src => src.Year))
                .ForMember(dest =>
                    dest.ObjCountryViewModel,
                    opt => opt.MapFrom(src => src.ObjCountryModel))
                .ReverseMap();
		}
	}
}
