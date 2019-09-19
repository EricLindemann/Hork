using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hork_Api.Entities;
using Hork_Api.Services;
using Hork_Api.Models;
using Hork_Api.Enums;

namespace Hork_Api.Controllers
{
    [Route("api/userProfile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileService _userProfileService;

        public UserProfileController(
            UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost]
        [Route("admin")]
        public async Task<ActionResult> PostAdminUserProfile(UserProfileModel userProfileModel)
        {
            await _userProfileService.Insert(userProfileModel.Email, userProfileModel.Password, (int)RoleEnum.Administrator);
            return Ok();
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult<bool>> ValidatePassword(UserProfileModel userProfileModel) {
            var valid = await _userProfileService.ValidatePassword(userProfileModel);
            return valid;
        }

    }
}