public class Program
{
    public static void Main(string[] args)
    {
        string[,] tabuleiro = new string[3, 3];
        int linha  = 3,colunas = 3;
        int posicaoLinha, posicaoColuna, qntdJogadas=1;
        string jogadordavez;
        string jogador1, jogador2;
        

        Console.WriteLine("  |  | ");
        Console.WriteLine("--+--+-----");
        Console.WriteLine("  |  | ");
        Console.WriteLine("--+--+-----");
        Console.WriteLine("  |  | ");

        Console.WriteLine("Quem inicia x ou o:");
        jogadordavez = Console.ReadLine();

        while (jogadordavez != "x" && jogadordavez != "o")
        {
            Console.WriteLine("Errado. Tente novamente");
            jogadordavez = Console.ReadLine();
        }

        Console.WriteLine("Escolha o nome do jogador 1: ");
        jogador1 = Console.ReadLine();

        Console.WriteLine("Escolha o nome do jogador 2: ");
        jogador2 = Console.ReadLine();

        do
        {
          
            Console.WriteLine("Jogador {0}, escolha a linha: ", jogadordavez);
            posicaoLinha = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Jogador {0}, escolha a coluna: ", jogadordavez);
            posicaoColuna = int.Parse(Console.ReadLine()) - 1;

            if (posicaoLinha >= 3 || posicaoColuna >= 3 || posicaoLinha < 0 || posicaoColuna < 0 )
            {
                Console.WriteLine(" Posição invalida. Tente novamente");
            }
            else
            {
                if (tabuleiro[posicaoLinha, posicaoColuna] == null)
                {
                    tabuleiro[posicaoLinha, posicaoColuna] = jogadordavez;
                    if(jogadordavez == "x")
                    {
                        jogadordavez = "o";
                    }
                    else
                    {
                        jogadordavez = "x"; 
                    }
                    qntdJogadas = qntdJogadas + 1;

                    Console.WriteLine(" {0} | {1}  | {2} ", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
                    Console.WriteLine(" -----+-----+---");
                    Console.WriteLine(" {0} | {1}  | {2} ", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
                    Console.WriteLine(" --+--+-----+---");
                    Console.WriteLine(" {0} | {1}  | {2} ", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
                 }
                else
                {
                    Console.WriteLine("Posição já está ocupada. Escolha outra!");
                }
            }
           
           


        } while (qntdJogadas <= 9);

    }
}
