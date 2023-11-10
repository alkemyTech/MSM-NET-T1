﻿using Wall_Net.DataAccess;
using Wall_Net.Repositories;

namespace Wall_Net.UnitOfWorks
{
    public class UnitOfWork
    {
        private readonly WallNetDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IAccountsRepository _accountsRepository;
        private readonly IFixedTermDepositRepository _fixedTermDepositRepository;

        public UnitOfWork(WallNetDbContext dbContext, 
            IUserRepository userRepository,
            IRolesRepository rolesRepository,
            IAccountsRepository accountsRepository,
            IFixedTermDepositRepository fixedTermDepositRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
            _accountsRepository = accountsRepository;
            _fixedTermDepositRepository = fixedTermDepositRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IRolesRepository RolesRepository => _rolesRepository;
        public IAccountsRepository AccountsRepository => _accountsRepository;
        public IFixedTermDepositRepository FixedTermDepositRepository => _fixedTermDepositRepository;

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}