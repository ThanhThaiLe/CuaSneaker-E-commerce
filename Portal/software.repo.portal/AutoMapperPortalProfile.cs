using AutoMapper;
using software.entity.system;
using software.repo.DataAccess;

namespace software.repo.portal
{
    public class AutoMapperPortalProfile : Profile
    {
        public AutoMapperPortalProfile()
        {
            CreateMap<portal_user_model, sys_user_db>();
        }
    }
}
