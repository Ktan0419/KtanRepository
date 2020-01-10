using System;
using System.Collections.Generic;
using System.Linq;
using Lessons.Strategy.Interfaces;

namespace Lessons.Strategy.Strategies
{
    public sealed class FastestTransportSelectionStrategy : ITransportSelectionStrategy
    {
        private readonly ILogger _logger;

        public FastestTransportSelectionStrategy(ILogger logger) => _logger = logger;

        public ITransportMean SelectTransportMean(DateTime journeyTime, IEnumerable<ITransportMean> transport)
        {
            _logger.WriteLine($"Selecting fastest mean available at {journeyTime}...");
            var hour = journeyTime.Hour;
            var bestOne = transport
                .Where(mean => hour > mean.AvailableFromHour && hour < mean.AvailableToHour)
                .OrderByDescending(mean => mean.Speed)
                .FirstOrDefault();

            _logger.WriteLine(bestOne != null
                ? $"Successfully selected {bestOne.GetType().Name}, name: {bestOne.Name}"
                : $"Unable to find any appropriate mean for {journeyTime}.");
            return bestOne;
        }
    }
}