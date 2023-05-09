using XadrezConsole;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;

TabuleiroJogo tab = new TabuleiroJogo(8, 8);

try
{
    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
    tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));
    Tela.ImprimirTabuleiro(tab);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}