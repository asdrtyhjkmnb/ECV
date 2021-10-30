using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    /// <summary>
    /// реализация логики, которая должна отрабатывать перед выполнением команды
    /// </summary>
    /// <typeparam name="TRequest">Объект запроса, переданный через метод IMediator.Send</typeparam>
    /// <typeparam name="TResponse">Асинхронное продолжение</typeparam>
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;

        public Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
