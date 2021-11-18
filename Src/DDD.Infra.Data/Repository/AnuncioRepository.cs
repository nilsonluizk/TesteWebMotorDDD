using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Repository
{
    public class AnuncioRepository : Repository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        //public Customer GetByEmail(string email)
        //{
        //    return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        //}
    }
}
