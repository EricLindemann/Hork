using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hork_Api.Entities;
using Hork_Api.Services;
using Hork_Api.Models;

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
        public async Task<ActionResult> PostUserProfile(UserProfileModel userProfileModel)
        {
            await _userProfileService.Insert(userProfileModel.Email, userProfileModel.Password);
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