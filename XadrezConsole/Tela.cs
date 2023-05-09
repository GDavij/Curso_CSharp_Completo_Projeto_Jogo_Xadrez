using XadrezConsole.Tabuleiro;
namespace XadrezConsole;

public class Tela
{
    public static void ImprimirTabuleiro(TabuleiroJogo tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (tab.Peca(i, j) == null)
                {
                    Console.Write(" - ");
                }
                else
                {
                    Console.Write($" {tab.Peca(i, j)} ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("+  a  b  c  d  e  f  g  h ");
    }
}
