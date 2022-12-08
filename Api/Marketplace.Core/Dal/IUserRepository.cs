// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Core.Dal
{
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the User data access
    /// </summary>
    public interface IUserRepository
    {
        #region Methods

        /// <summary>
        /// Gets all users asynchronous.
        /// </summary>
        /// <returns>Array of users</returns>
        Task<User[]> GetAllUsersAsync();

        /// <summary>
        /// Get the user.
        /// </summary>
        /// <returns>Get users</returns>
        User GetAuthenticationUserAsync(string username, string password);

        /// <summary>
        /// Save or Update users.
        /// </summary>
        /// <returns>Id User</returns>
        Task<int> SaveUser(User user);

        #endregion
    }
}