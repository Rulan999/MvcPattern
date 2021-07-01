using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CA.Application;
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure
{
    public class CityRepository : BaseRepository<City>
    {
        public CityRepository(BaseDBContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<City>> FindAsync(Expression<Func<City, bool>> predicate)
        {
            return await _appDbContext.CityEntities.Include(x => x.Country)
               .Where(predicate).ToListAsync();
        }

        public override City Update(City entity)
        {
            var artist = _appDbContext.CityEntities
                .Single(c => c.Id == entity.Id);

            artist.Update(artist.Id, 
                          entity.CityName,
                          entity.Country,
                          entity.User);

            return base.Update(artist);
        }

    }
}
