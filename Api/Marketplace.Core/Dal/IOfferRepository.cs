// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contract for the Offer data access
/// </summary>

namespace Marketplace.Core.Dal
{
    public interface IOfferRepository
    {
        #region Methods

        /// <summary>
        /// Gets all offer asynchronous.
        /// </summary>
        /// <returns>Array of offer</returns>
        Task<Offer[]> GetAllOffersAsync();

        Task<Offer[]> GetAllOffersPaginatedAsync(int pageNumber, int pageSize);

        Task<int> GetOffersCountAsync();

        /// <summary>
        /// Save or Update Offer.
        /// </summary>
        /// <returns>void</returns>
        Task Save(Offer offer);

        #endregion
    }
}
