using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Dama : Peca
{

    public Dama(TabuleiroJogo tab, Cor cor) : base(tab, cor) { }

    public override string ToString()
    {
        return "D";
    }

    private bool PodeMover(Posicao pos)
    {
        Peca? p = TabuleiroJogo.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[TabuleiroJogo.Linhas, TabuleiroJogo.Colunas];

        Posicao pos = new Posicao(0, 0);

        // esquerda
        pos.DefinirValores(Posicao!.Linha, Posicao.Coluna - 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna - 1);
        }

        // direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha, pos.Coluna + 1);
        }

        // acima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna);
        }

        // abaixo
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna);
        }

        // NO
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
        }

        // NE
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
        }

        // SE
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
        }

        // SO
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        while (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (TabuleiroJogo.Peca(pos) != null && TabuleiroJogo.Peca(pos)!.Cor != Cor)
            {
                break;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
        }

        return mat;
    }
}
