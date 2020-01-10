using System;
using FluentAssertions;
using Lessons.Strategy.Interfaces;
using Lessons.Strategy.Means;
using Lessons.Strategy.Strategies;
using Xunit;
using Xunit.Abstractions;

namespace Lessons.Tests.Strategy
{
    public class CheapestTransportSelectionStrategyTests
    {
        private readonly ITransportSelectionStrategy _selector;
        
        public CheapestTransportSelectionStrategyTests(ITestOutputHelper output)
        {
            var logger = new XUnitLogger(output);
            _selector = new CheapestTransportSelectionStrategy(logger);
            logger.WriteLine("Test classes successfully initialized.");
        }
        
        [Fact]
        public void ShouldSelectCheapestTransportMean()
        {
            var date = new DateTime(2019, 03, 15, 15, 0, 0);
            var means = new ITransportMean[]
            {
                new BusTransportMean("Slow slow bus", 12),
                new BusTransportMean("Rather fast bus", 30),
                new TaxiTransportMean("Very fast taxi", 50, 12),
                new TaxiTransportMean("Very cheap taxi", 10, 10)
            };
            
            var response = _selector.SelectTransportMean(date, means);
            response.Should().NotBeNull();
            response.Name.Should().Be("Very cheap taxi");
            response.Speed.Should().Be(10);
        }
    }
}