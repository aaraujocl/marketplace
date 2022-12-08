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
    public class CategoryRepository : ICategoryRepository
    {

        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public CategoryRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Category[]> GetAllCategorysAsync()
        {
            return await this.context.Categories.ToArrayAsync();
        }
        #endregion
    }
}
