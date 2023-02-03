using AutoMapper;
using ModelLayerLaboratory;
using WebLayerLaboratory.Models;

namespace WebLayerLaboratory.MapperProfile
{
	public class CountryProfile : Profile
	{
		public CountryProfile()
		{
			CreateMap<CountryModel, CountryViewModel>()
				.ForMember(dest =>
					dest.Id,
					opt => opt.MapFrom(src => src.Id))
				.ForMember(dest =>
					dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ReverseMap();
		}
	}
}
