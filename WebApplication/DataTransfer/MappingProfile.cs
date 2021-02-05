using ApplicationModel.Models;
using AutoMapper;
using WebApplication.DataTransfer.PlaylistResources;
using WebApplication.DataTransfer.TrackResources;

namespace WebApplication.DataTransfer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Playlist, PlaylistDTO>();
            CreateMap<PlaylistInfoDTO, Playlist>();
            
            CreateMap<Track, TrackDTO>();
            CreateMap<TrackInfoDTO, Track>();
        }
    }
}