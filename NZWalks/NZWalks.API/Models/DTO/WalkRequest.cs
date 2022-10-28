namespace NZWalks.API.Models.DTO
{
    public class WalkRequest
    {
        public string Name { get; set; }

        public long Length { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
