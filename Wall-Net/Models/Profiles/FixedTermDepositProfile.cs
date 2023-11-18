using AutoMapper;
using Wall_Net.Models.DTO;

namespace Wall_Net.Models.Profiles
{
    public class FixedTermDepositProfile : Profile
    {
        public FixedTermDepositProfile() 
        {
            CreateMap<FixedTermDeposit, FixedTermsDepositDTO>();
        }   
    }
}
