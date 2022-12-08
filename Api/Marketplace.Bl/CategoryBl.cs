// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

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
    /// Categorys' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.ICategoryBl" />
    public class CategoryBl : ICategoryBl
    {
        #region Fields

        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryBl"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CategoryBl(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #endregion

        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            return await this.categoryRepository.GetAllCategorysAsync().ConfigureAwait(false);
        }
    }
}
