﻿using SEP_JMS.Model.Api.Request;
using SEP_JMS.Model;
using SEP_JMS.Model.Models;

namespace SEP_JMS.Repository.IRepositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        public Task<PagingModel<Company>> GetCompanies(CompanyFilterRequest model);
        public Task<Company?> GetCompanyById(Guid id);
        public Task<Company?> GetCompany(Guid companyId);
    }
}
