using Microsoft.AspNetCore.Mvc;

namespace SocialNetworkBE.Application.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }

        return new BadRequestObjectResult(result.ErrorMessage);
    }
}