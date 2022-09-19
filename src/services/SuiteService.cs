using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using potencial_dev_week_hotel.src.models;

namespace potencial_dev_week_hotel.src.services
{
    public class SuiteService
    {
        private readonly Dictionary<int, Suite> _suiteDictionary;

        public SuiteService()
        {
            _suiteDictionary = new Dictionary<int, Suite>();
        }

        public IEnumerable<Suite> GetAll()
        {
            return _suiteDictionary.Values;
        }

        public Suite GetById(int id)
        {
            Suite suite;
            _suiteDictionary.TryGetValue(id, out suite);

            return suite;
        }        

        public Suite Add(Suite suite)
        {
            int id = _suiteDictionary.Count() + 1;
            suite.SetId(id);

            _suiteDictionary.Add(id, suite);

            return suite;
        }

        public Suite Update(int id, Suite suite)
        {
            _suiteDictionary[id] = suite;

            return suite;
        }

        public void Delete(int id)
        {
            _suiteDictionary.Remove(id);
        }
    }
}