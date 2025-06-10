using MediatR;

namespace MediatrStudying.Classes
{
    public class GenericPing<T> : IRequest<T> where T : class, IPinger
    {
        public T? Ping { get; set; }

    }
}
