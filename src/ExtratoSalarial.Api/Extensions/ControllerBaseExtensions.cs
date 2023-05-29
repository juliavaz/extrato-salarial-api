using ExtratoSalarial.Core.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoSalarial.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult ResponseFromUseCase(this ControllerBase controllerBase, ResponseUseCase responseUseCase)
        {
            object apiResult = responseUseCase.IsSuccess switch
            {
                true => responseUseCase.Result,
                false => new
                {
                    responseUseCase.Errors
                }
            };

            return controllerBase.StatusCode((int)responseUseCase.StatusCode, apiResult);
        }
    }
}
