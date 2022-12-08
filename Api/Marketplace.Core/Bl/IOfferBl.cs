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

namespace Marketplace.Core.Bl
{
    /// <summary>
    /// Contract for the Offer logic
    /// </summary>
    /// 
    public interface IOfferBl
    {
        #region Methods

        /// <summary>
        /// Gets the Offer.
        /// </summary>
        /// <returns>LIst of Offers</returns>
        Task<IEnumerable<Offer>> GetOffersAsync();

        Task<IEnumerable<Offer>> GetOffersPaginatedAsync(int pageNumber, int pageSize);

        Task<int> GetOffersCountAsync();

        /// <summary>
        /// Save or Update Offer.
        /// </summary>
        /// <returns>Id Offer</returns>
        Task Save(Offer offer);

        #endregion
    }
}
