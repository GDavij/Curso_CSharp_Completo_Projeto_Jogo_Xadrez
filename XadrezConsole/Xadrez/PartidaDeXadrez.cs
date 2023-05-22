using XadrezConsole.Tabuleiro.Exceptions;
using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class PartidaDeXadrez
{
    private HashSet<Peca> Pecas;
    private HashSet<Peca> Capturadas;
    public TabuleiroJogo Tabuleiro { get; private set; }
    public bool Xeque { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }
    public PartidaDeXadrez()
    {
        Tabuleiro = new TabuleiroJogo(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Xeque = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        ColocarPecas();
    }


    public Peca? ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca? p = Tabuleiro.RetirarPeca(origem);
        p?.IncrementarQuantidadeDeMovimentos();

        Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p!, destino);

        if (pecaCapturada != null)
            Capturadas.Add(pecaCapturada);

        return pecaCapturada;
    }

    public void DesfazMovimento(Posicao origem, Posicao destino, Peca? pecaCapturada)
    {
        Peca p = Tabuleiro.RetirarPeca(destino)!;
        p.DecrementarQuantidadeDeMovimentos();
        if (pecaCapturada != null)
        {
            Tabuleiro.ColocarPeca(pecaCapturada, destino);
            Capturadas.Remove(pecaCapturada);
        }

        Tabuleiro.ColocarPeca(p, origem);
    }

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        Peca? pecaCapturada = ExecutaMovimento(origem, destino);
        if (EstaEmXeque(JogadorAtual))
        {
            DesfazMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque");
        }

        if (EstaEmXeque(Adversaria(JogadorAtual)))
        {
            Xeque = true;
        }
        else
        {
            Xeque = false;
        }

        if (TesteXequeMate(Adversaria(JogadorAtual)))
        {
            Terminada = true;
        }
        else
        {
            Turno++;
            MudaJogador();
        }
    }

    public void ValidarPosicaoOrigem(Posicao pos)
    {
        if (Tabuleiro.Peca(pos) == null)
            throw new TabuleiroException("Não Existe Peça na Posição de Origem Escolhida");

        if (JogadorAtual != Tabuleiro.Peca(pos)!.Cor)
            throw new TabuleiroException("A Peça de Origem Escolhida não é Sua");

        if (!Tabuleiro.Peca(pos)!.existeMovimentosPossiveis())
            throw new Exception("Não Existe Movimento Possíveis para esta peça");
    }

    public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if (!Tabuleiro.Peca(origem)!.MovimentoPossivel(destino))
            throw new TabuleiroException("Posição de Destino Inválida");
    }

    private void MudaJogador()
    {
        JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
        return;
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca p in Capturadas)
        {
            if (p.Cor == cor)
            {
                aux.Add(p);
            }
        }

        return aux;
    }

    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca p in Pecas)
        {
            if (p.Cor == cor)
            {
                aux.Add(p);
            }
        }

        aux.ExceptWith(PecasCapturadas(cor));
        return aux;
    }

    private Cor Adversaria(Cor cor)
    {
        return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
    }

    private Peca? Rei(Cor cor)
    {
        foreach (Peca p in PecasEmJogo(cor))
        {
            if (p is Rei) return p;
        }
        return null;
    }

    public bool EstaEmXeque(Cor cor)
    {
        Peca? rei = Rei(cor);
        if (rei == null) throw new TabuleiroException("Não Existe Rei na Partida");

        foreach (Peca x in PecasEmJogo(Adversaria(cor)))
        {
            bool[,] mat = x.MovimentosPossiveis();
            if (mat[rei.Posicao!.Linha, rei.Posicao.Coluna]) return true;
        }
        return false;
    }

    public bool TesteXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor)) return false;

        foreach (Peca p in PecasEmJogo(cor))
        {
            bool[,] mat = p.MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        Posicao origem = p.Posicao!;
                        Posicao destino = new Posicao(i, j);
                        Peca? pecaCapturada = ExecutaMovimento(origem, destino);

                        bool testeXeque = EstaEmXeque(cor);
                        DesfazMovimento(origem, destino, pecaCapturada);
                        if (!testeXeque)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }

    private void ColocarPecas()
    {
        ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branca));

        ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preta));
    }
}
