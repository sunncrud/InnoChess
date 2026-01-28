using FluentValidation;

namespace InnoChess.Presentation.Filters;

public class ValidationFilter<TRequest> : IEndpointFilter where TRequest : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<TRequest>>();

        var argument = context.Arguments.OfType<TRequest>().FirstOrDefault();

        if (validator is not null && argument is not null)
        {
            var validationResult = await validator.ValidateAsync(argument);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
        }

        return await next(context);
    }
}