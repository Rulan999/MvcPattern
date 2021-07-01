using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Application;
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure
{
    public class CountryRepository : BaseRepository<Country>
    {
        public CountryRepository(BaseDBContext context) : base(context)
        {
        }

        public override Country Update(Country entity)
        {
            var artist = _appDbContext.CountryEntities
                .Single(c => c.Id == entity.Id);

            artist.Update(artist.Id, 
                          entity.CountryName,
                          entity.User);

            return base.Update(artist);
        }

    }
}
