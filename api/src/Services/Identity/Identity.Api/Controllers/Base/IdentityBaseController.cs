using Microsoft.AspNetCore.Mvc;
using UpWatch.Mvc;

namespace Identity.Api.Controllers.Base;

[Route("api/[controller]")]
public abstract class IdentityBaseController : UpWatchBaseController
{
}
