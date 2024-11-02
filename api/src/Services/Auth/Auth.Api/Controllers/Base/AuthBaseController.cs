using Microsoft.AspNetCore.Mvc;
using UpWatch.Mvc;

namespace Auth.Api.Controllers.Base;

[Route("api/[controller]")]
public abstract class AuthBaseController : UpWatchBaseController
{
}
