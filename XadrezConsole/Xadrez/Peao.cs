using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Peao : Peca
{
    private PartidaDeXadrez Partida;
    public Peao(TabuleiroJogo tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
        Partida = partida;
    }

    public override string ToString()
    {
        return "P";
    }

    private bool ExisteInimigo(Posicao pos)
    {
        Peca? p = TabuleiroJogo.Peca(pos);
        return p != null && p.Cor != Cor;
    }

    private bool Livre(Posicao pos)
    {
        return TabuleiroJogo.Peca(pos) == null;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[TabuleiroJogo.Linhas, TabuleiroJogo.Colunas];

        Posicao pos = new Posicao(0, 0);

        if (Cor == Cor.Branca)
        {
            pos.DefinirValores(Posicao!.Linha - 1, Posicao.Coluna);
            if (TabuleiroJogo.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
            Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
            if (TabuleiroJogo.PosicaoValida(p2) && Livre(p2) && TabuleiroJogo.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (TabuleiroJogo.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (TabuleiroJogo.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #Jogada Especial - En Passant
            if (Posicao.Linha == 3)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if (TabuleiroJogo.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && TabuleiroJogo.Peca(esquerda) == Partida.VulneravelEnPassant)
                    mat[esquerda.Linha - 1, esquerda.Coluna] = true;

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if (TabuleiroJogo.PosicaoValida(direita) && ExisteInimigo(direita) && TabuleiroJogo.Peca(direita) == Partida.VulneravelEnPassant)
                    mat[direita.Linha - 1, direita.Coluna] = true;
            }
        }
        else
        {
            pos.DefinirValores(Posicao!.Linha + 1, Posicao!.Coluna);
            if (TabuleiroJogo.PosicaoValida(pos) && Livre(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
            Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);

            if (TabuleiroJogo.PosicaoValida(p2) && Livre(p2) && TabuleiroJogo.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (TabuleiroJogo.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (TabuleiroJogo.PosicaoValida(pos) && ExisteInimigo(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #Jogada Especial - En Passant
            if (Posicao.Linha == 4)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if (TabuleiroJogo.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && TabuleiroJogo.Peca(esquerda) == Partida.VulneravelEnPassant)
                    mat[esquerda.Linha + 1, esquerda.Coluna] = true;

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if (TabuleiroJogo.PosicaoValida(direita) && ExisteInimigo(direita) && TabuleiroJogo.Peca(direita) == Partida.VulneravelEnPassant)
                    mat[direita.Linha + 1, direita.Coluna] = true;
            }
        }

        return mat;
    }
}
