using XadrezConsole.Tabuleiro.Exceptions;
using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;

public class PartidaDeXadrez
{
    private HashSet<Peca> Pecas;
    private HashSet<Peca> Capturadas;
    public TabuleiroJogo Tabuleiro { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool Terminada { get; private set; }
    public PartidaDeXadrez()
    {
        Tabuleiro = new TabuleiroJogo(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        _ColocarPecas();
    }


    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca? p = Tabuleiro.RetirarPeca(origem);
        p?.IncrementarQuantidadeDeMovimentos();

        Peca? pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p!, destino);

        if (pecaCapturada != null)
            Capturadas.Add(pecaCapturada);
    }

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        ExecutaMovimento(origem, destino);
        Turno++;
        MudaJogador();
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
        if (!Tabuleiro.Peca(origem)!.PodeMoverPara(destino))
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
    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }

    private void _ColocarPecas()
    {
        ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
        ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

        ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
        ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
    }
}
