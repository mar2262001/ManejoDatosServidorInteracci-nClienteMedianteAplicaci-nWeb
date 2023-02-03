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
					dest.Title,
					opt => opt.MapFrom(src => src.Title))
				.ForMember(dest =>
					dest.Editorial,
					opt => opt.MapFrom(src => src.Editorial)) 
				.ForMember(dest =>
					dest.Country,
					opt => opt.MapFrom(src => src.Country)) 
				.ForMember(dest =>
					dest.Author,
					opt => opt.MapFrom(src => src.Author)) 
				.ForMember(dest =>
					dest.Year,
					opt => opt.MapFrom(src => src.Year))
				.ReverseMap();
		}
	}
}
