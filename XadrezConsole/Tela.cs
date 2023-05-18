using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;
namespace XadrezConsole;

public class Tela
{
    public static void ImprimirPartida(PartidaDeXadrez partida)
    {
        Tela.ImprimirTabuleiro(partida.Tabuleiro);
        Console.WriteLine();

        ImprimirPecasCapturadas(partida);
        Console.WriteLine();

        Console.WriteLine("Turno: " + partida.Turno);
        Console.WriteLine("Aguradando Jogada: " + partida.JogadorAtual);
        if (partida.Xeque)
        {
            Console.WriteLine("Você está em Xeque");
        }
    }

    public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
    {
        Console.WriteLine($"Peças Capturadas");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
        Console.WriteLine();

        Console.Write("Pretas: ");

        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        Console.ForegroundColor = aux;

        Console.WriteLine();
    }

    public static void ImprimirConjunto(HashSet<Peca> conjuntoPecas)
    {
        Console.Write("[");
        foreach (Peca p in conjuntoPecas)
            Console.Write(p + ", ");

        Console.Write("]");

    }
    public static void ImprimirTabuleiro(TabuleiroJogo tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write((8 - i) + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                ImprimirPeca(tab.Peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("+  a  b  c  d  e  f  g  h");
    }

    public static void ImprimirTabuleiro(TabuleiroJogo tab, bool[,] posicoesPossiveis)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkBlue;
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write((8 - i) + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (posicoesPossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                ImprimirPeca(tab.Peca(i, j));
                Console.BackgroundColor = fundoOriginal;

            }
            Console.WriteLine();
        }
        Console.WriteLine("+  a  b  c  d  e  f  g  h");
    }

    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string? s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse("" + s[1]);
        return new PosicaoXadrez(coluna, linha);
    }

    public static void ImprimirPeca(Peca? p)
    {
        if (p == null)
        {
            Console.Write(" - ");
        }
        else
        {
            if (p.Cor == Cor.Preta)
            {
                ConsoleColor aux = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {p} ");
                Console.ForegroundColor = aux;
                return;
            }

            Console.Write($" {p} ");
        }
    }
}
