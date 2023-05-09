using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Rei : Peca
{
    public Rei(TabuleiroJogo tabuleiroJogo, Cor cor) : base(tabuleiroJogo, cor) { }

    public override string ToString()
    {
        return "R";
    }
}
