using AutoMapper;
using MailOnRails.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailOnRails.API
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }

        [Obsolete]
        protected override void Configure()
        {
            CreateMap<ApplicationUser, RegisterViewModel>();
        }
    }
}