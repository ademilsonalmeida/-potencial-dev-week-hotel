namespace potencial_dev_week_hotel.src.models
{
    public class Hospede : Pessoa
    {
        public Hospede(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public override void SetId(int id)
        {
            Id = id;
        }
    }
}