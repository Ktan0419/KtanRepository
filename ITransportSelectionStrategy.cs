using System;
using System.Collections.Generic;

namespace Lessons.Strategy.Interfaces
{
    public interface ITransportSelectionStrategy
    {
        ITransportMean SelectTransportMean(DateTime time, IEnumerable<ITransportMean> transport);
    }
}