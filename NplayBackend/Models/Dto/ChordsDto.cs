namespace NplayBackend.Models.Dto
{
    public class ChordsMinimalDto
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public List<string> ChromaArray { get; set; }
    }
}
