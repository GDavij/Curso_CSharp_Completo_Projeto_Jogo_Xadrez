using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Rei : Peca
{
    public Rei(TabuleiroJogo tabuleiroJogo, Cor cor) : base(tabuleiroJogo, cor) { }

    public override string ToString()
    {
        return "R";
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
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Nordeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Sudeste 
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Abaixo
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Sudoeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        //Noroeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (TabuleiroJogo.PosicaoValida(pos) && PodeMover(pos))
        {
            movimentos[pos.Linha, pos.Coluna] = true;
        }

        return movimentos;
    }
}
