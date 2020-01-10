using Lessons.Strategy.Interfaces;

namespace Lessons.Strategy.Means
{
    public sealed class BusTransportMean : ITransportMean
    {
        public string Name { get; }
        public float Speed { get; }
        public decimal Price { get; }
        public int AvailableFromHour { get; }
        public int AvailableToHour { get; }

        public BusTransportMean(string name, float speed)
        {
            Name = name;
            Speed = speed;
            AvailableFromHour = 10;
            AvailableToHour = 19;
            Price = 40;
        }
    }
}