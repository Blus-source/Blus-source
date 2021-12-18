using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DouceSody.WebUIWithIdp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }

}

