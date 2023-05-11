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

    public bool existeMovimentosPossiveis()
    {
        bool[,] movimentos = MovimentosPossiveis();
        for (int i = 0; i < TabuleiroJogo.Linhas; i++)
        {
            for (int j = 0; j < TabuleiroJogo.Colunas; j++)
            {
                if (movimentos[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool PodeMoverPara(Posicao pos)
    {
        return MovimentosPossiveis()[pos.Linha, pos.Coluna];
    }

    public abstract bool[,] MovimentosPossiveis();
    public void IncrementarQuantidadeDeMovimentos()
    {
        QtdMovimentos++;
    }
}
