using BeerCollection.Interface;
using BeerCollection.Models;

namespace BeerCollection.Repository
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerDBContext _dbContext;

        public BeerRepository(BeerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBeer(BeerObj beerObj)
        {
            _dbContext.Beers.Add(new BeerObj
            {
                Name = beerObj.Name,
                Type = beerObj.Type,
                Rating = beerObj.Rating
            });

            _dbContext.SaveChanges();
        }

        public IEnumerable<BeerObj> GetAllBeers()
        {
            if (!GetAll().Any())
                return Enumerable.Empty<BeerObj>();

            return GetAll();
        }

        public IEnumerable<BeerObj> Search(string name)
        {
            if (!GetAll().Any())
                return Enumerable.Empty<BeerObj>();

            return GetAll().Where(b => b.Name.Contains(name)).ToList();
        }

        public bool UpdateRating(int beerId)
        {
            var beer = GetAll().FirstOrDefault(b => b.Id == beerId);
            if (beer is null)
                return false;

            var averageRate = GetAll().Average(r => r.Rating);

            beer.Rating = averageRate;
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<BeerObj> GetAll() => _dbContext.Beers.ToList();
    }
}