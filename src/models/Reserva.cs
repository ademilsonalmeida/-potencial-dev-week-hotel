namespace potencial_dev_week_hotel.src.models
{
    public class Reserva
    {
        public int Id { get; private set; }
        public Hospede Hospede { get; private set; }
        public Suite Suite { get; private set; }
        public int QuantidadeHospedes { get; private set; }
        public int QuantidadeReserva { get; private set; }
        public decimal ValorTotal { get; private set; }              

        public Reserva(Hospede hospede, Suite suite, int numeroDeHospedes, int quantidadeDiasReserva)
        {
           Hospede = hospede;
           Suite = suite;
           QuantidadeHospedes = numeroDeHospedes;
           QuantidadeReserva = quantidadeDiasReserva;
           ValorTotal = CalcularValorTotal(suite.Valor, QuantidadeReserva);
        }  

        public void SetId(int id)      
        {
            Id = id;
        }

        private decimal CalcularValorTotal(decimal valor, int quantidadeReservas)
        {
             if (quantidadeReservas > 10)
                return (valor * quantidadeReservas) - ((valor * quantidadeReservas) * 10 / 100);
             return valor * quantidadeReservas;
        }
    }
}