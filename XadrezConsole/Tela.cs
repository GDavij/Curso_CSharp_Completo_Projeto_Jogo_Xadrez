using XadrezConsole.Tabuleiro;
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
                if (tab.Peca(i, j) == null)
                {
                    Console.Write(" - ");
                }
                else
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("+  a  b  c  d  e  f  g  h");
    }

    public static void ImprimirPeca(Peca p)
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
