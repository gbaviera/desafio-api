using FluentValidation.Results;

namespace Desafio.Domain.Base
{
    public class ExecutionResult<T>
    {
        public T Data { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
