// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Dal.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public OfferRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Offer[]> GetAllOffersAsync()
        {
            return await this.context.Offers.ToArrayAsync();
        }

        public async Task<Offer[]> GetAllOffersPaginatedAsync(int pageNumber, int pageSize)
        {
            return await context.Offers.Include(x=>x.Category)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToArrayAsync();
        }

        public async Task<int> GetOffersCountAsync()
        {
            return await this.context.Offers.CountAsync();
        }

        public async Task Save(Offer offer)
        {
            
            var offerfound = this.context.Offers.Where(b => b.Title == offer.Title).FirstOrDefault();
            if (offerfound == null)
            {
                var entity = this.context.Add(offer);
            }
            else
            {
                offerfound.CategoryId = offer.CategoryId;
                offerfound.Title = offer.Title;
                offerfound.PictureUrl = offer.PictureUrl;
                offerfound.Location = offer.Location;
                offerfound.Description = offer.Description;
                offerfound.UserId = offer.UserId;
                this.context.Update(offerfound);
            }
            await this.context.SaveChangesAsync();
        }

        #endregion

    }
}
