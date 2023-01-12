using BeerCollection.Models;

namespace BeerCollection.Interface
{
    public interface IBeerRepository
    {
        void AddBeer(BeerObj beerObj);
        IEnumerable<BeerObj> GetAllBeers();
        IEnumerable<BeerObj> Search(string name);
        bool UpdateRating(int beerId);
    }
}