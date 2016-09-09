using AutoMapper;
using MailOnRails.Model;
using System;

namespace MailOnRails.API
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }

        [Obsolete]
        protected override void Configure()
        {
            CreateMap<RegisterViewModel, ApplicationUser>();
            CreateMap<RegisterViewModel, ApplicationUser>().ForMember(user => user.UserName, vm => vm.MapFrom(rm => rm.Email));
        }
    }
}