using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Repositorio<TEntity> : Domain.IRepositorio<TEntity> where TEntity : Entity
    {
        private readonly Context _context;

        public Repositorio(Context context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(d => d.Id == id);
        }

        public void Save(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
