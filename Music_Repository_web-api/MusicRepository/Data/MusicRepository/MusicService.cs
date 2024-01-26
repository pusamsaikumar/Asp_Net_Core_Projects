using MusicRepository.Models;

namespace MusicRepository.Data.MusicRepository
{
    public class MusicService : IMusicService
    {
        private readonly MusicDBContext _dbcontext;

        public MusicService(MusicDBContext  dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Music> AddMusic(Music music)
        {
           if(music is not null)
            {
              await  _dbcontext.Music.AddAsync(music);
               await _dbcontext.SaveChangesAsync();
            }
            return music;
        }

        public bool DeleteMusic(Guid id)
        {
           var music = GetMusicById(id);
            if(music is not null)
            {
                _dbcontext.Music.Remove(music);
                _dbcontext.SaveChanges();
                return true;
            } 
            return false;
        }

        public Music GetMusicById(Guid id)
        {
            return _dbcontext.Music.FirstOrDefault(m => m.Id == id);
        }

        //public Task<Music> GetMusicByTitle(string title)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Music> GetMusicList()
        {
            return _dbcontext.Music.OrderByDescending(m=>m.ReleaseTime).ToList();
        }

        public async Task<Music> UpdateMusic(Guid id, Music music)
        {
           var musicDetails = GetMusicById(id);
            if (musicDetails is not null)
            {
                musicDetails.Title = music.Title;
                musicDetails.ReleaseTime = music.ReleaseTime;
                musicDetails.Artist = music.Artist;
                musicDetails.Rate = music.Rate;

                await _dbcontext.SaveChangesAsync();
            }
            return musicDetails;
        }
    }
}
