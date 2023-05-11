namespace XadrezConsole.Tabuleiro;

public abstract class Peca
{
    public Posicao? Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public TabuleiroJogo TabuleiroJogo { get; protected set; }

    public Peca(TabuleiroJogo tabuleiroJogo, Cor cor)
    {
        Posicao = null;
        TabuleiroJogo = tabuleiroJogo;
        Cor = cor;
        QtdMovimentos = 0;
    }

    public abstract bool[,] MovimentosPossiveis();
    public void IncrementarQuantidadeDeMovimentos()
    {
        QtdMovimentos++;
    }
}
