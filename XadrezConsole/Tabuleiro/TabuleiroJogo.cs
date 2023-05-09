namespace XadrezConsole.Tabuleiro;

public class TabuleiroJogo
{
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    private Peca[,] Pecas;

    public TabuleiroJogo(int linhas, int colunas)
    {
        Linhas = linhas;
        Colunas = colunas;
        Pecas = new Peca[linhas, colunas];
    }

    public Peca Peca(int linha, int coluna)
    {
        return Pecas[linha, coluna];
    }

    public void ColocarPeca(Peca p, Posicao pos)
    {
        Pecas[pos.Linha, pos.Coluna] = p;
        p.Posicao = pos;
    }
}
