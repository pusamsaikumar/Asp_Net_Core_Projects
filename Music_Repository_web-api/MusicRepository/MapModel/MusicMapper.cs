using MusicRepository.DTO;
using MusicRepository.Models;

namespace MusicRepository.MapModel
{
    public class MusicMapper : AutoMapper.Profile
    {
        public MusicMapper()
        {
            // source => target
            // CreateMap<source,target>();
            // use inside Request
            CreateMap<Music, MusicDTO>();
            // Use inside Response
            CreateMap<MusicDTO, Music >();
        }
    }
}
