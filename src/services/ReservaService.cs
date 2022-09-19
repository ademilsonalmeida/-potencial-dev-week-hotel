using potencial_dev_week_hotel.src.models;

namespace potencial_dev_week_hotel.src.services
{
    public class ReservaService
    {
        private readonly Dictionary<int, Reserva> _reservaDictionary;

        public ReservaService()
        {
            _reservaDictionary = new Dictionary<int, Reserva>();
        }

        public IEnumerable<Reserva> GetAll()
        {
            return _reservaDictionary.Values;
        }

        public Reserva GetById(int id)
        {
            Reserva reserva;
            _reservaDictionary.TryGetValue(id, out reserva);

            return reserva;
        }        

        public Reserva Add(Reserva reserva)
        {
            int id = _reservaDictionary.Count() + 1;
            reserva.SetId(id);

            _reservaDictionary.Add(id, reserva);

            return reserva;
        }

        public Reserva Update(int id, Reserva reserva)
        {
            _reservaDictionary[id] = reserva;

            return reserva;
        }

        public void Delete(int id)
        {
            _reservaDictionary.Remove(id);
        }
    }
}