// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using Marketplace.Core.Bl;
using Marketplace.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Marketplace.Core.Model.Pagination;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace Marketplace.Api.Controllers
{

    /// <summary>
    /// Services for Offer
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OfferController> logger;

        private readonly IOfferBl offerBl;

        private readonly IUriBl uriBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The offer business logic.</param>
        public OfferController(ILogger<OfferController> logger, IOfferBl offerBl, IUriBl uriBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
            this.uriBl = uriBl;
        }

        #endregion

        #region Methods

        

        /// <summary>
        /// Gets the list Paginated of Offer.
        /// </summary>
        /// <returns>List of offer</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetPaginated([FromQuery] PaginationFilter filter)
        {
            IEnumerable<Offer> result;
            var route = Request.Path.Value;

            try
            {
                result = await this.offerBl.GetOffersPaginatedAsync(filter.PageNumber, filter.PageSize).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            var totalRecords = await this.offerBl.GetOffersCountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Offer>(result.ToList(), filter, totalRecords, uriBl, route);
            return Ok(pagedReponse);
      
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Offer offer)
        {
            try
            {
                if (offer is null)
                {
                    this.logger.LogError("Offer is null.");
                    return BadRequest("Offer object is null");
                }
                if (!ModelState.IsValid)
                {
                    this.logger.LogError("Invalid offer object.");
                    return BadRequest("Invalid model object");
                }

                 await this.offerBl.Save(offer).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside Create Offer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

    }
}
