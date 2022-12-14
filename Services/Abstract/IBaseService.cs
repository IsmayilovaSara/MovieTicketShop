using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DTO;

namespace Services.Abstract
{
    public interface IBaseService<TReq, TEntity, TRes> where TEntity : class
    {
        public TRes Get(int id);
        public IEnumerable<TRes> Get();
        public TRes Create(TReq user);
        public TRes Update(TReq user);
        public virtual void Delete(int id) { }
    }
}
