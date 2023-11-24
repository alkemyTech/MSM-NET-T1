using AutoMapper;
using Wall_Net.Models.DTO;

namespace Wall_Net.Models.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile() 
        {
            CreateMap<Transaction,TransactionDTO>();
        }
    }
}
