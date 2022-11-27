using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserService : IBaseService<UserDTO, User, UserDTO>
    {
        public UserDTO Login(UserDTO user);
        public IEnumerable<UserDTO> GetUserList();
        public IEnumerable<UserDTO> GetFilter(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null);
    }
}
