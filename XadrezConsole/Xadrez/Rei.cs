using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class Rei : Peca
{
    private PartidaDeXadrez Partida;
    public Rei(TabuleiroJogo tabuleiroJogo, Cor cor, PartidaDeXadrez partida) : base(tabuleiroJogo, cor)
    {
        Partida = partida;
    }

    public override string ToString()
    {
        return "R";
    }
    private bool PodeMover(Posicao pos)
    {
        Peca? p = TabuleiroJogo.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    private bool TesteTorreParaRoque(Posicao pos)
    {
        Peca? p = TabuleiroJogo.Peca(pos);
        return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
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

        // #Jogada especial - Roque
        if (QtdMovimentos == 0 && !Partida.Xeque)
        {
            // #Jogada Especial - Roque Pequeno  
            Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
            if (TesteTorreParaRoque(posT1))
            {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                if (TabuleiroJogo.Peca(p1) == null && TabuleiroJogo.Peca(p2) == null) movimentos[Posicao.Linha, Posicao.Coluna + 2] = true;
            }

            // #Jogada Especial - Roque Grande
            Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
            if (TesteTorreParaRoque(posT2))
            {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                if (TabuleiroJogo.Peca(p1) == null && TabuleiroJogo.Peca(p2) == null && TabuleiroJogo.Peca(p3) == null)
                    movimentos[Posicao.Linha, Posicao.Coluna - 2] = true;
            }
        }



        return movimentos;
    }
}
