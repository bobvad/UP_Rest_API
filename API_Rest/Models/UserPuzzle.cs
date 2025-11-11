namespace API_Rest.Models
{
    public class UserPuzzle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PuzzleId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Users User { get; set; }
        public Puzzles Puzzle { get; set; }
        public ICollection<UserPiece> UserPieces { get; set; }
        public ICollection<UserGallery> UserGalleries { get; set; }
    }
}