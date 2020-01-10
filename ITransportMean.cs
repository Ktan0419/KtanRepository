namespace Lessons.Strategy.Interfaces
{
    public interface ITransportMean
    {
        string Name { get; }
        float Speed { get; }
        decimal Price { get; }
        int AvailableFromHour { get; }
        int AvailableToHour { get; }
    }
}