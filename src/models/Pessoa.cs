namespace potencial_dev_week_hotel.src.models
{
    public abstract class Pessoa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }

        public abstract void SetId(int id);
    }
}