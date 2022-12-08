// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using Marketplace.Core.Model.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Bl
{
    /// <summary>
    /// Contract for the Page Uri logic
    /// </summary>
    public interface IUriBl
    {
        /// <summary>
        /// Gets the Page Uri.
        /// </summary>
        /// <returns>LIst of PageUri</returns>
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
