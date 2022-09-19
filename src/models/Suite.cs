namespace potencial_dev_week_hotel.src.models
{
    public class Suite
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        public decimal Valor { get; private set; }        

        public Suite(string nome, int numero, decimal valor)
        {            
            Nome = nome;
            Numero = numero;
            Valor = valor;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}