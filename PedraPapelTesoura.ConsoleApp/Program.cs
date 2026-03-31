using System.Security;

namespace PedraPapelTesoura.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Variaveis
        string[] PedraJogador = {
        "     _______   ",
        " ---'   ____)  ",
        "       (_____) ",
        "       (_____) ",
        "       (____)  ",
        " ---.__(___)   ",
        };
        string[] PedraPC = {
        "   _______     ",
        "  (____   '--- ",
        " (_____)       ",
        " (_____)       ",
        "  (____)       ",
        "   (___)__.--- ",
        };
        string[] PapelJogador = {
        "      _______       ",
        " ---'    ____)____  ",
        "            ______) ",
        "           _______) ",
        "          _______)  ",
        " ---.__________)    ",
        };
        string[] PapelPC = {
        "       _______      ",
        "  ____(____    '--- ",
        " (______            ",
        "  (_______          ",
        "   (_______         ",
        "    (__________.--- ",
        };
        string[] TesouraJogador = {
        "     _______        ",
        " ---'   ____)____   ",
        "           ______)  ",
        "        __________) ",
        "       (____)       ",
        " ---.__(___)        ",
        };
        string[] TesouraPC = {
        "         _______     ",
        "   _____(___    '--- ",
        "  (______            ",
        " (__________         ",
        "       (____)        ",
        "        (___)___.--- ",
        };
        string[] desenhoJogador;
        string[] desenhoPC;
        string[] jogadas = {"Pedra", "Papel", "Tesoura"};
        string escolhaJogador;
        string resultado;

        while(true)
        {   
            InicioCabecalho();                                                                          // Inicio do Menu
            escolhaJogador = JogadaPlayer(jogadas);                                                     // Entrada do Jogador
            if (escolhaJogador == "SAIR")break;                                                         // Verificar se quer encerrar
            string escolhaPC = JogadaPC(jogadas);                                                       // Entrada do PC
            resultado = VerificarEscolhas(escolhaJogador, escolhaPC);                                   // Pegar os resultados e comparar
            desenhoJogador = ObterDesenho(escolhaJogador, PedraJogador, PapelJogador, TesouraJogador);  // Pegar o desenho do Jogador
            desenhoPC = ObterDesenho(escolhaPC, PedraPC, PapelPC, TesouraPC);                           // Pegar o desenho do Computador
            Pausa();                                                                                    // Esperar o Usuario iniciar
            DesenhoDoJogo(desenhoJogador, desenhoPC);                                                   // Desenhar o jogo
            ResultadoFinal(escolhaJogador, escolhaPC, resultado);                                       // Printar o resultado Final

            Console.WriteLine("\nJogar Novamente? (s/N)");
            string? ContinuarJogando = Console.ReadLine();

            if(ContinuarJogando?.ToUpper() == "S") continue;
            else break;
        }
    }
    static void InicioCabecalho()
    {
        Console.Clear();
        Console.WriteLine("- = - = - = - = - = - = - = - = - = -");
        Console.WriteLine("      Jogo - Pedra Papel Tesoura     ");
        Console.WriteLine("- = - = - = - = - = - = - = - = - = -");
    }
    static string JogadaPlayer(string[] jogadas)
    {
        while (true)
        {
            Console.WriteLine("\nDigite o número Correpondente a sua escolha: ");
            Console.WriteLine(" 1 - Pedra");
            Console.WriteLine(" 2 - Papel");
            Console.WriteLine(" 3 - Tesoura");
            Console.WriteLine(" 0 - Encerrar");

            string? escolha = Console.ReadLine();

            if (escolha == "1") return jogadas[0];
            else if (escolha == "2") return jogadas[1];
            else if (escolha == "3") return jogadas[2];
            else if (escolha == "0") return "SAIR";
            else 
            {
                Console.WriteLine("Opção Invalida! Tente novamente");
                Console.ReadKey();
            }
        }
    }
    static string JogadaPC(string[] jogadas)
    {
        Random random = new Random();
        int indice = random.Next(jogadas.Length);
        string escolhaPC = jogadas[indice];
        return escolhaPC;
    }
    static void Pausa()
    {
        Console.Write("\nDigite ENTER para Jogar");
        Console.ReadLine();
    }
    static string VerificarEscolhas(string escolhaJogador, string escolhaPC)
    {
        if( escolhaJogador == escolhaPC)
        {
            return "Empate";
        }

        if (
        (escolhaJogador == "Pedra" && escolhaPC == "Tesoura") ||
        (escolhaJogador == "Papel" && escolhaPC == "Pedra") ||
        (escolhaJogador == "Tesoura" && escolhaPC == "Papel")
        )
            return "Jogador venceu";
        
        return "Computador venceu";
    }
    static string[] ObterDesenho(string jogada, string[] pedra, string[] papel, string[] tesoura)
    {
        if (jogada == "Pedra") return pedra;
        else if (jogada == "Papel") return papel;
        else return tesoura;
    }
    static void DesenhoDoJogo(string[] desenhoJogador, string[] desenhoPC)
    {
        for (int i = 0; i < desenhoJogador.Length; i++)
        {
            Console.WriteLine(desenhoJogador[i] + "   VS   " + desenhoPC[i]);
        }
    }
    static void ResultadoFinal(string escolhaJogador, string escolhaPC, string resultado)
    {
        Console.WriteLine();
        Console.WriteLine($"\nA escolha do Jogador foi:       {escolhaJogador}");
        Console.WriteLine($"A escolha do Computador foi:    {escolhaPC}");
        Console.WriteLine($"\nResultado foi: {resultado}");
    }
}
