using FluentValidation.Results;
using System.Net;

namespace ExtratoSalarial.Core.Domain.UseCases
{
    public class ResponseUseCase
    {
        public object Result { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ResponseUseCase(HttpStatusCode statusCode, object result)
        {
            Result = result;
            Errors = new List<string>();
            IsSuccess = true;
            StatusCode = statusCode;
        }

        public ResponseUseCase(HttpStatusCode statusCode, IEnumerable<string> errors)
        {
            Errors = errors;
            IsSuccess = false;
            StatusCode = statusCode;
        }

        public ResponseUseCase(List<ValidationFailure> validationErrors) : this(HttpStatusCode.BadRequest, validationErrors.Select(x => x.ErrorMessage)) { }

        public ResponseUseCase(HttpStatusCode statusCode, string error) : this(statusCode, new string[] { error }) { }

        public static ResponseUseCase Ok(object result)
            => new(HttpStatusCode.OK, result);

        public static ResponseUseCase Created(object result)
            => new(HttpStatusCode.Created, result);

        public static ResponseUseCase BadRequest(List<ValidationFailure> validationErrors)
            => new(validationErrors);

        public static ResponseUseCase NotFound(string error)
            => new(HttpStatusCode.NotFound, error);
    }
}
