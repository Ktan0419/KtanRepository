using Lessons.Strategy.Interfaces;

namespace Lessons.Strategy.Means
{
    public sealed class TaxiTransportMean : ITransportMean
    {
        public string Name { get; }
        public float Speed { get; }
        public decimal Price { get; }
        public int AvailableFromHour { get; }
        public int AvailableToHour { get; }

        public TaxiTransportMean(string name, float speed, decimal price)
        {
            Name = name;
            Speed = speed;
            Price = price;
            AvailableFromHour = 0;
            AvailableToHour = 23;
        }
    }
}