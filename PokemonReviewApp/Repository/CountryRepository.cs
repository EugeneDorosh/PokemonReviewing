using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(x => x.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(x => x.Name).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.Id == id);
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(x => x.Id == ownerId).Select(x => x.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(x => x.Country.Id == countryId).ToList();
        }
    }
}
