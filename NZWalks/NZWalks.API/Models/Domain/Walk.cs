namespace NZWalks.API.Models.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Length { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Guid RegionId { get; set; }

        //Navigation Property

        public Region Region{ get; set; }

        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
