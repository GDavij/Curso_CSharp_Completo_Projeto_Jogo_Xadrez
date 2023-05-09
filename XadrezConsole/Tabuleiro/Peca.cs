namespace XadrezConsole.Tabuleiro;

public class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public TabuleiroJogo TabuleiroJogo { get; protected set; }

    public Peca(Posicao posicao, TabuleiroJogo tabuleiroJogo, Cor cor)
    {
        Posicao = posicao;
        TabuleiroJogo = tabuleiroJogo;
        Cor = cor;
        QtdMovimentos = 0;
    }
}
