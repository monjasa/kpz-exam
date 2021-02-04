using ApplicationModel.Models;
using AutoMapper;

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