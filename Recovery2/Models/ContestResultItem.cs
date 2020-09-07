namespace Recovery2.Models
{
    public class ContestResultItem
    {
        public ContestItem Item { get; set; }
        public bool Success { get; set; }
        public long Elapsed { get; set; }
    }
}