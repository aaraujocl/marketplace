using System;
using System.Collections.Generic;
// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Model.Pagination
{
    public class Response<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the Succeded.
        /// </summary>
        /// <value>
        /// The Response.
        /// </value>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the Errors.
        /// </summary>
        /// <value>
        /// The Errors present.
        /// </value>
        public string[] Errors { get; set; }

        /// <summary>
        /// Gets or sets the Messsage.
        /// </summary>
        /// <value>
        /// The Message of the response.
        /// </value>
        public string Message { get; set; }

        #endregion
        public Response() { }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

    }
}
