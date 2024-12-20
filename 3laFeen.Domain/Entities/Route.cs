namespace _3laFeen.Domain.Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public required string From { get; set; }
        public required string To { get; set; }
        public required string Transportation { get; set; }
    }
}
