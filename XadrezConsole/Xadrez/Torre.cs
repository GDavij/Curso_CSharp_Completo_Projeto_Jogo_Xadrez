using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Torre : Peca
{
    public Torre(TabuleiroJogo tabuleiroJogo, Cor cor) : base(tabuleiroJogo, cor) { }

    public override string ToString()
    {
        return "T";
    }

    private bool PodeMover(Posicao pos)
    {
        Peca? p = TabuleiroJogo.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] movimentos = new bool[TabuleiroJogo.Linhas, TabuleiroJogo.Colunas];
        Posicao pos = new Posicao(0, 0);

        //Acima
        pos.DefinirValores(Posicao!.Linha - 1, Posicao.Coluna);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.Linha--;
        }

        //Abaixo
        pos.DefinirValores(Posicao!.Linha + 1, Posicao.Coluna);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.Linha++;
        }


        //Direita
        pos.DefinirValores(Posicao!.Linha, Posicao.Coluna + 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.Coluna++;
        }

        //Esquerda
        pos.DefinirValores(Posicao!.Linha, Posicao.Coluna - 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.Coluna--;
        }

        return movimentos;
    }

}
