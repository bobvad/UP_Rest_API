namespace API_Rest.Models
{
    public class UserPuzzle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PuzzleId { get; set; }
        public int SelectedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public int MissedDays { get; set; } = 0;
        public int CurrentDay { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Users User { get; set; }
        public Puzzles Puzzle { get; set; }
        public ICollection<UserPiece> UserPieces { get; set; }
        public ICollection<UserGallery> UserGalleries { get; set; }
    }
}
