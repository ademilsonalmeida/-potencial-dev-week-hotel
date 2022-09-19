using potencial_dev_week_hotel.src.models;

namespace potencial_dev_week_hotel.src.services
{
    public class HospedeService
    {
        private readonly Dictionary<int, Hospede> _hospedeDictionary;

        public HospedeService()
        {
            _hospedeDictionary = new Dictionary<int, Hospede>();
        }

        public IEnumerable<Hospede> GetAll()
        {
            return _hospedeDictionary.Values;
        }

        public Hospede GetById(int id)
        {
            Hospede hospede;
            _hospedeDictionary.TryGetValue(id, out hospede);

            return hospede;
        }

        public Hospede GetByEmail(string email)
        {            
            var hospede = _hospedeDictionary.FirstOrDefault(w => w.Value.Email == email);

            return hospede.Value;
        }

        public Hospede Add(Hospede hospede)
        {
            int id = _hospedeDictionary.Count() + 1;
            hospede.SetId(id);

            _hospedeDictionary.Add(id, hospede);

            return hospede;
        }

        public Hospede Update(int id, Hospede user)
        {
            _hospedeDictionary[id] = user;

            return user;
        }

        public void Delete(int id)
        {
            _hospedeDictionary.Remove(id);
        }
    }
}