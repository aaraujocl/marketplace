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
    /// Contract for the Categoria logic
    /// </summary>
    /// 
    public interface ICategoryBl
    {

        #region Methods

        /// <summary>
        /// Gets the categorys.
        /// </summary>
        /// <returns>LIst of categorys</returns>
        Task<IEnumerable<Category>> GetCategorysAsync();

        #endregion
    }
}
