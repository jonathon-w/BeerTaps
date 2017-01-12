using System;

namespace BeerTaps.WebApi.Handlers
{
    public class NullUserContext : IDisposable
    {
        public void Dispose() { }
    }
}