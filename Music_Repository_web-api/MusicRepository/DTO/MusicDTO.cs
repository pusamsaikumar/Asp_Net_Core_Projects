namespace MusicRepository.DTO
{
    public class MusicDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Artist { get; set; }
        public int Rate { get; set; }
    }
}
