namespace API_Rest.Models
{
    public class Puzzles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullImage { get; set; }
        public int TotalPieces { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<UserPuzzle> UserPuzzles { get; set; }
        public ICollection<UserGallery> UserGalleries { get; set; }

    }
}
