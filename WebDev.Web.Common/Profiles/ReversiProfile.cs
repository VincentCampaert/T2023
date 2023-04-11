using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Models;
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

            CreateMap<GameViewModel, GameModel>();
            CreateMap<GameModel, GameViewModel>();

            CreateMap<GameModel, Game>();
            CreateMap<Game, GameModel>();

            CreateMap<PlayMoveViewModel, PlayMoveModel>();
            CreateMap<PlayMoveModel, PlayMoveViewModel>();
            CreateMap<PlayMoveModel, BoardTile>()
                .ForMember(dm => dm.BoardId, mp => mp.MapFrom(sm => sm.GameId));
        }
    }
}
