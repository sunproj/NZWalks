namespace NZWalks.API.Models.DTO
{
    public class Regiondto
    {
        public Guid Id { get; set; }

        public string RCode { get; set; }

        public string RName { get; set; }

        public double RArea { get; set; }

        public double RLat { get; set; }

        public double RLong { get; set; }

        public long RPopulation { get; set; }

    }
}
