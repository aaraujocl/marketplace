// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Services for Users
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly ILogger<UserController> logger;

        private readonly IUserBl userBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userBl">The user business logic.</param>
        public UserController(ILogger<UserController> logger, IUserBl userBl)
        {
            this.logger = logger;
            this.userBl = userBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IEnumerable<User> result;

            try
            {
                result = await this.userBl.GetUsersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            try
            {
                if (user is null)
                {
                    this.logger.LogError("User is null.");
                    return  BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    this.logger.LogError("Invalid user object.");
                    return BadRequest("Invalid model object");
                }

                var result =  await this.userBl.SaveUser(user).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside Create User action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{username}/{password}")]
        public ActionResult<User> GetUser(string username, string password)
        {
            var user = this.userBl.GetAuthenticationUserAsync(username, password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        #endregion
    }
}