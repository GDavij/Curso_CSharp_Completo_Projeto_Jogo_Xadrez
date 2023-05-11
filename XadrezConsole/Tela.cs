using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;
namespace XadrezConsole;

public class Tela
{
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
