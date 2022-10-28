namespace NZWalks.API.Models.DTO
{
    public class Walkdto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Length { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Guid RegionId { get; set; }

        public Regiondto Region { get; set; }

        public WalkDifficultydto WalkDifficulty { get; set; }
    }
}
