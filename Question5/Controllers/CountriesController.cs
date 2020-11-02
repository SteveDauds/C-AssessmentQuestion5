using Question5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Question5.Controllers
{
    public class CountriesController : ApiController
    {

        IList<CountryList> countries = new List<CountryList>()
        {
            new CountryList() { countryId = 1, countryName="Spain"},
            new CountryList() { countryId = 2, countryName="Nigeria"},
            new CountryList() { countryId = 3, countryName="United States of America"},
            new CountryList() { countryId = 4, countryName="Australia"},
            new CountryList() { countryId = 5, countryName="Argentina"},
            new CountryList() { countryId = 6, countryName="Russia"},
            new CountryList() { countryId = 7, countryName="India"}
        };
        public IList <CountryList> GetCountries ()
        {
            return countries;
        }
        public CountryList GetCountryDetails (int id)
        {
            var country = countries.FirstOrDefault(c => c.countryId == id);
            if(country == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return country;
        }

        //Post via Uri
        public IHttpActionResult Post([FromUri]string countryName)
        {
            countries.Add(new CountryList() { countryId = (countries.LastOrDefault().countryId) + 1, countryName = countryName });
            return Ok(countries);
        }
        
    }
}
