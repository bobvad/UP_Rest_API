namespace API_Rest.Models
{
    public class UserGallery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PuzzleId { get; set; }
        public int UserPuzzleId { get; set; }
        public DateTime CompletedDate { get; set; }
        public int MissedDays { get; set; }
        public int SelectedDays { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Users User { get; set; }
        public Puzzles Puzzle { get; set; }
        public UserPuzzle UserPuzzle { get; set; }
    }
}
