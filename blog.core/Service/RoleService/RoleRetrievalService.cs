using AutoMapper;
using blog.core.Entities;
using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IRoleService;
using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Service.RoleService
{
    public class RoleRetrievalService : IRoleRetrievalService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public RoleRetrievalService(
            IMapper mapper,
            IRoleRepository roleRepository) 
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleListViewModel> GetAllRoles()
        {
            var model = new RoleListViewModel();
            try
            {
                var roles = await _roleRepository.GetAll();

                model.Data = roles
                    .Select(n => _mapper.Map<Role, RoleViewModel>(n))
                    .ToList();
                model.Success = true;
            }
            catch(Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }
    }
}
