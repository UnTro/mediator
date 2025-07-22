using MediatR;
using MediatrStudying.Classes;
using System.Net.NetworkInformation;

namespace MediatrStudying.Handlers
{
    public class GenericPingHandler<T> : IRequestHandler<GenericPing<T>, T>
        where T : class, IPinger
    {
        public Task<T> Handle(GenericPing<T> request, CancellationToken cancellationToken)
        { 
            return Task.FromResult(request.Ping!); 
        }
    }
}
