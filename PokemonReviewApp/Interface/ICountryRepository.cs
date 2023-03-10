using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountries();
        public Country GetCountry(int id);
        public Country GetCountryByOwner(int ownerId);
        public ICollection<Owner> GetOwnersFromACountry(int countryId);
        public bool CountryExists(int id);
        public bool CreateCountry(Country country);
        public bool UpdateCountry(Country country);
        public bool DeleteCountry(Country country);
        bool Save();
    }
}
