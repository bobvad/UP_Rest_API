namespace API_Rest.Models
{
    public class UserPiece
    {
        public int Id { get; set; }
        public int UserPuzzleId { get; set; }
        public int PieceNumber { get; set; }
        public DateTime CollectedDate { get; set; } = DateTime.Now;

        public UserPuzzle UserPuzzle { get; set; }
    }
}
