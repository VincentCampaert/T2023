using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Game;
using WebDev.Web.Common.ViewModels;

namespace WebDev.Web.Common.Profiles
{
    public class ReversiProfile : Profile
    {
        public ReversiProfile() 
        {
            CreateMap<HostGameViewModel, HostGameModel>();
            CreateMap<HostGameModel, HostGameViewModel>();
        }
    }
}
