using MusicRepository.Models;

namespace MusicRepository.Data.MusicRepository
{
    public interface IMusicService
    {
        IEnumerable<Music> GetMusicList();
        Music GetMusicById(Guid id);
       // Task<Music> GetMusicByTitle(string title);
        Task<Music> AddMusic(Music music);
       // Task<Music> UpdateMusic(Music music);
        Task<Music> UpdateMusic(Guid id, Music music);
        bool DeleteMusic(Guid id);

    }
}
