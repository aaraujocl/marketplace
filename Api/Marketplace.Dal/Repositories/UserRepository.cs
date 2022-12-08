// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Dal.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public UserRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<Marketplace.Core.Model.User[]> GetAllUsersAsync()
        {
            return await this.context.Users.ToArrayAsync();
        }

        public Marketplace.Core.Model.User GetAuthenticationUserAsync(string username, string password)
        {
            var userfound = this.context.Users.Where(b => b.Username == username && b.Password == password).FirstOrDefault();
            
            return userfound;
        }

        public async Task<int> SaveUser(Marketplace.Core.Model.User user)
        {
            int id = 0;
            var userfound =   this.context.Users.Where(b => b.Username == user.Username).FirstOrDefault();
            if (userfound == null)
            {                
                var entity = this.context.Add(user);
                id = entity.Entity.Id;
            }
            else
            {
                userfound.Lastname = user.Lastname;
                userfound.Firstname = user.Firstname;
                userfound.Password = user.Password;
                this.context.Update(userfound);
                id = userfound.Id;
            }
            await this.context.SaveChangesAsync();

            return id;
        }

    

        



        #endregion
    }
}