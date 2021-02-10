namespace MovieExplorer.Web.Areas.Administration.Controllers
{
    using MovieExplorer.Common;
    using MovieExplorer.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
