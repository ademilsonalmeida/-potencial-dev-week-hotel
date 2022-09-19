using potencial_dev_week_hotel.src.models;
using potencial_dev_week_hotel.src.services;

namespace potencial_dev_week_hotel.src
{
    public class App
    {
        private bool _finalizarSistema = false;        
        private HospedeService _hospedeService = new HospedeService();
        private SuiteService _suiteService = new SuiteService();
        private ReservaService _reservaService = new ReservaService();

        public App()
        {
            CarregarMenu();
        }

        private void CarregarMenu()
        {
            while (!_finalizarSistema)
            {
                ExibirMenu();

                int.TryParse(Console.ReadLine(), out int opcao);

                switch (opcao)
                {
                    case 1:
                        IncluirHospede();
                        break;
                    case 2:
                        IncluirSuite();
                        break;
                    case 3:
                        IncluirReserva();
                        break;
                    case 4:
                        RelatorioReservas();
                        break;
                    case 99:
                        FinalizarSistema();
                        break;
                    default:
                        ExibirMenu();
                        break;
                }

                Console.ReadLine();
            }            
        }

        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("===========================================MENU");
            Console.WriteLine("| 1. Incluir Hóspede                          |");
            Console.WriteLine("| 2. Incluir Suíte                            |");
            Console.WriteLine("| 3. Incluir Reserva                          |");
            Console.WriteLine("| 4. Relatório Reservas                       |");
            Console.WriteLine("|99. Finalizar o Sistema                      |");
            Console.WriteLine("===============================================");
        }

        private void IncluirHospede()
        {
            Console.Clear();
            Console.Write("Informe o nome do hóspede: ");
            var nome = Console.ReadLine();
            Console.Write("Informe o email do hóspdede: ");
            var email = Console.ReadLine();

            var jaExiste = _hospedeService.GetByEmail(email);

            if (!(jaExiste is null))
            {
                Console.Clear();
                Console.WriteLine("==============================LISTA DE HOSPEDES");                
                Console.WriteLine("======= ATENCAO! HOSPEDE JA CADASTRADO! =======");
                return;
            }
            
            var hospede = new Hospede(nome, email);            
            _hospedeService.Add(hospede);
        }

        private void IncluirSuite()
        {
            Console.Clear();
            Console.Write("Informe o nome da suíte: ");
            var nome = Console.ReadLine();
            Console.Write("Informe o número da suíte: ");
            int.TryParse(Console.ReadLine(), out int numero);
            Console.Write("Informe o valor da suíte: ");
            decimal.TryParse(Console.ReadLine(), out decimal valor);

            var suite = new Suite(nome, numero, valor);    
            _suiteService.Add(suite);
        }

        private void IncluirReserva()
        {
            Console.Clear();
            Console.Write("Informe o código do hóspede: ");
            int.TryParse(Console.ReadLine(), out int codigoHospede);
            var hospede = _hospedeService.GetById(codigoHospede);

            Console.Write("Informe o código da suíte: ");
            int.TryParse(Console.ReadLine(), out int codigoSuite);
            var suite = _suiteService.GetById(codigoSuite);

            Console.Write("Informe o número de hóspede(s): ");
            int.TryParse(Console.ReadLine(), out int quantidadeDeHospedes);

            Console.Write("Informe o número de dia(s) reserva: ");
            int.TryParse(Console.ReadLine(), out int quantidadeDiasReserva);
            
            var reserva = new Reserva(hospede, suite, quantidadeDeHospedes, quantidadeDiasReserva);
            _reservaService.Add(reserva);
        }

        private void RelatorioReservas()
        {
            Console.Clear(); 

            var reservas = _reservaService.GetAll();
            
            if (!reservas.Any())
            {
                Console.WriteLine("==============================LISTA DE HOSPEDES");
                Console.WriteLine("======== Nenhum Hóspede Cadastrado! :( ========");
                return;
            }

            Console.WriteLine("==============================LISTA DE HOSPEDES");
            Console.WriteLine("===========NOME|==========SUITE|==========VALOR");

            foreach (var reserva in reservas)
            {
                var nome = reserva.Hospede.Nome.Length > 15 
                    ? reserva.Hospede.Nome.Substring(0, 15) 
                    : reserva.Hospede.Nome.PadRight(15, '-');

                var numeroSuite = reserva.Suite.Numero.ToString().PadLeft(3, '0');                
                    
                var nomeSuite = reserva.Suite.Nome.Length > 11 
                    ? reserva.Suite.Nome.Substring(0, 11) 
                    : reserva.Suite.Nome.PadRight(11, '-');

                var valor = reserva.ValorTotal.ToString("C2").PadLeft(15, '-');                

                Console.WriteLine($"{nome}|{numeroSuite}-{nomeSuite}|{valor}");
            }

            Console.WriteLine("=================QTDE. HOSPEDES|==========TOTAL");

            var qtdeHospedes = reservas.Sum(s => s.QuantidadeHospedes).ToString().PadLeft(31, '-');
            var valorTotal = reservas.Sum(s => s.ValorTotal).ToString("C2").PadLeft(15, '-');

            Console.WriteLine($"{qtdeHospedes}|{valorTotal}");
        }

        private void FinalizarSistema()
        {
            _finalizarSistema = true;
            Console.Clear();
            Console.WriteLine("O programa se encerrou");
        }            
    }
}