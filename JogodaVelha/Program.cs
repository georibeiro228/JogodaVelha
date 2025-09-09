using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        string[,] tabuleiro = new string[3, 3];
        int linha = 3, colunas = 3;
        int posicaoLinha=0, posicaoColuna=0, qntdJogadas = 1;
        string jogadordavez=" ";
        string jogador1 = "", jogador2 = "", nomeDaVez = "";
        int jogadores = 1 ;
        int placar1=0, placar2=0;
        bool vezDaMaquina = false;
        bool houveGanhador = false;

        Console.WriteLine("Seja bem vindo ao Jogo da Velha!! ");

        Console.WriteLine("Com quantos jogadores deseja jogar? (1 ou 2) ");
        jogadores=int.Parse(Console.ReadLine());

        if (jogadores == 1)
        {
          Console.WriteLine("Jogo para 1 jogador selecionado");
          Console.WriteLine("Voce irá jogar a máquina");

          Console.WriteLine("Digite o simbolo que irá jogar: X ou O ");
          jogadordavez=(Console.ReadLine()).ToString();

            LimparTabuleiro(tabuleiro);

          
            do
            {
              
                MostrarTabuleiroPreenchido(tabuleiro);
                if (vezDaMaquina == true)
                { 
                    bool maquinaPreencheu= false;
                    do
                    {
                        Random random = new Random();
                        posicaoLinha = random.Next(0, 3);
                        posicaoColuna = random.Next(0, 3);

                        if (tabuleiro[posicaoLinha,posicaoColuna]==" ")
                        {
                            tabuleiro[posicaoLinha, posicaoColuna]= jogadordavez.ToString();
                            maquinaPreencheu = true;
                            qntdJogadas++;

                            if(jogadordavez == "X")
                            {
                                jogadordavez = "O";
                            }
                            else
                            {
                                jogadordavez = "X";

                            }
                        }


                    } while (maquinaPreencheu == false);

                    vezDaMaquina = false;
                }
            

                else
                {
                    EscolhaPosicao(ref nomeDaVez, ref posicaoColuna, ref posicaoLinha, ref jogadordavez, ref jogador1, ref jogador2, ref tabuleiro, ref qntdJogadas,  ref vezDaMaquina);
                    



                }
                Ganhador(ref tabuleiro, ref qntdJogadas, ref houveGanhador);
                if (houveGanhador == true) 
                {   
                
                    MostrarTabuleiroPreenchido(tabuleiro);
                    break;   
                }

            } while (qntdJogadas <= 9);




         }
        else
        {
            DefinirSimboloIniciante(jogadordavez, jogador1, jogador2);

            LimparTabuleiro(tabuleiro);

            MostrarTabuleiroVazio();

            if (jogadordavez == "X")
            {
                nomeDaVez = jogador1;

            }
            else
            {
                nomeDaVez = jogador2;
            }

            do
            {
                EscolhaPosicao(ref nomeDaVez, ref posicaoColuna, ref posicaoLinha, ref jogadordavez, ref jogador1,ref jogador2, ref tabuleiro,ref qntdJogadas,ref vezDaMaquina);



  
            } while (qntdJogadas <= 9);

            Console.WriteLine("Jogo para 1 jogador selecionado: ");
            Console.WriteLine("Voce jogará com a máquina ");
        }
    }

        
    private static void MostrarTabuleiroVazio()
    {
        Console.WriteLine("   |   | ");
        Console.WriteLine("---+---+---");
        Console.WriteLine("   |   | ");
        Console.WriteLine("---+---+---");
        Console.WriteLine("   |   | ");

    }

    private static void LimparTabuleiro(string[,] tabuleiro)
    {
        tabuleiro[0, 0] = " ";
        tabuleiro[0, 1] = " ";
        tabuleiro[0, 2] = " ";
        tabuleiro[1, 0] = " ";
        tabuleiro[1, 1] = " ";
        tabuleiro[1, 2] = " ";
        tabuleiro[2, 0] = " ";
        tabuleiro[2, 1] = " ";
        tabuleiro[2, 2] = " ";

    }

    private static void DefinirSimboloIniciante(string jogadordavez,string jogador1, string jogador2)
    {
        Console.WriteLine("Escolha o nome do X: ");
        jogador1 = Console.ReadLine();
        Console.WriteLine("Escolha o nome do O: ");
        jogador2 = Console.ReadLine();

        Console.WriteLine("Quem inicia x ou o:");
        jogadordavez = Console.ReadLine();

        while (jogadordavez != "x" && jogadordavez != "o")
        {
            Console.WriteLine("Errado. Tente novamente");
            jogadordavez = Console.ReadLine();
        }
    }

    private static void MostrarTabuleiroPreenchido(string[,]tabuleiro)
    {
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
    }

    private static void EscolhaPosicao (ref string nomeDaVez,ref int posicaoColuna, ref int posicaoLinha, ref string jogadordavez,ref string jogador1,ref string jogador2,ref string[,] tabuleiro,ref int qntdJogadas,ref bool vezDaMaquina )
    {
        bool deuCerto;
        do
        {

            Console.WriteLine("Jogador {0}, escolha a linha: ", nomeDaVez);
            deuCerto = int.TryParse(Console.ReadLine(), out posicaoLinha);
            if (deuCerto == true)
            {
                posicaoLinha--;
            }
        }
        while (deuCerto == false);

        do
        {
            Console.WriteLine("Jogador {0}, escolha a coluna: ", nomeDaVez);
            deuCerto = int.TryParse(Console.ReadLine(), out posicaoColuna);
            if (deuCerto == true)
            {
                posicaoColuna--;
            }
        }
        while (deuCerto == false);

        if (posicaoLinha >= 3 || posicaoColuna >= 3 || posicaoLinha < 0 || posicaoColuna < 0)
        {
            Console.WriteLine(" Posição invalida. Tente novamente");
        }
        else
        {
            if (tabuleiro[posicaoLinha, posicaoColuna] == " ")
             {
                tabuleiro[posicaoLinha, posicaoColuna] = jogadordavez;
                if (jogadordavez == "X")
                {
                    jogadordavez = "O";
                    nomeDaVez = jogador2;
                }
                else
                {
                    jogadordavez = "X";
                    nomeDaVez = jogador1;
                }
                qntdJogadas = qntdJogadas + 1;
                vezDaMaquina = true;


            }
            else
            {
                Console.WriteLine("Posição já está ocupada. Escolha outra!");

            }

        }
    }

    private static void Ganhador(ref string[,] tabuleiro, ref int qntdJogadas, ref bool houveGanhador)
    {
        if ((tabuleiro[0, 0] == "X" && tabuleiro[0, 1] == "X" && tabuleiro[0, 2] == "X") ||
                 (tabuleiro[1, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[1, 2] == "X") ||
                 (tabuleiro[2, 0] == "X" && tabuleiro[2, 1] == "X" && tabuleiro[2, 2] == "X") ||
                 (tabuleiro[0, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 2] == "X") ||
                 (tabuleiro[0, 2] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 0] == "X") ||
                 (tabuleiro[0, 0] == "X" && tabuleiro[1, 0] == "X" && tabuleiro[2, 0] == "X") ||
                 (tabuleiro[0, 1] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 1] == "X") ||
                 (tabuleiro[0, 2] == "X" && tabuleiro[1, 2] == "X" && tabuleiro[2, 2] == "X")
                 )
        {
            Console.WriteLine("Venceu o jogo!");
            houveGanhador = true;
        }
        else
              if ((tabuleiro[0, 0] == "O" && tabuleiro[0, 1] == "O" && tabuleiro[0, 2] == "O") ||
              (tabuleiro[1, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[1, 2] == "O") ||
              (tabuleiro[2, 0] == "O" && tabuleiro[2, 1] == "O" && tabuleiro[2, 2] == "O") ||
              (tabuleiro[0, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 2] == "O") ||
              (tabuleiro[0, 2] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 0] == "O") ||
              (tabuleiro[0, 0] == "O" && tabuleiro[1, 0] == "O" && tabuleiro[2, 0] == "O") ||
              (tabuleiro[0, 1] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 1] == "O") ||
              (tabuleiro[0, 2] == "O" && tabuleiro[1, 2] == "O" && tabuleiro[2, 2] == "O"))
        {
            Console.WriteLine("Venceu o jogo!");
            houveGanhador = true;
        }
        else
               if (qntdJogadas == 10)
        {
            Console.WriteLine("Empate");
            houveGanhador = false;
        }
    }

}

