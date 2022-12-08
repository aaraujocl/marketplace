using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Bl
{
    /// <summary>
    /// Offers' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IOfferBl" />
    /// 
    public class OfferBl : IOfferBl
    {
        #region Fields

        private readonly IOfferRepository offerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferBl"/> class.
        /// </summary>
        /// <param name="offerRepository">The offer repository.</param>
        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        #endregion

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await this.offerRepository.GetAllOffersAsync().ConfigureAwait(false);
        }

        public async Task<int> GetOffersCountAsync()
        {
            return await this.offerRepository.GetOffersCountAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Offer>> GetOffersPaginatedAsync(int pageNumber, int pageSize)
        {
            return await this.offerRepository.GetAllOffersPaginatedAsync(pageNumber, pageSize).ConfigureAwait(false);
        }

        public async Task Save(Offer offer)
        {
            await this.offerRepository.Save(offer).ConfigureAwait(false);
        }
    }
}
