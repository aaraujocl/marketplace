﻿// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using Marketplace.Api.Controllers;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Services for Categoria
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Fields

        private readonly ILogger<CategoryController> logger;

        private readonly ICategoryBl categoryBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="categoriaBl">The categoria business logic.</param>
        public CategoryController(ILogger<CategoryController> logger, ICategoryBl categoryBl)
        {
            this.logger = logger;
            this.categoryBl = categoryBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of categorys.
        /// </summary>
        /// <returns>List of categorys</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable<Category> result;

            try
            {
                result = await this.categoryBl.GetCategorysAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        #endregion
    }
}
