using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRepositorio<TEntity>
    {
        TEntity GetById(int id);
        void Save(TEntity entity);
    }
}
