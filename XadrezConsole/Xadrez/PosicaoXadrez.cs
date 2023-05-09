using XadrezConsole.Tabuleiro;
namespace XadrezConsole.Xadrez;


public class PosicaoXadrez
{
    public char Coluna { get; set; }
    public int Linha { get; set; }

    public PosicaoXadrez(char coluna, int linha)
    {
        Coluna = coluna;
        Linha = linha;
    }
    public Posicao ToPosicao()
    {
        return new Posicao(8 - Linha, Coluna - 97);//(Coluna - 'a') ou também (Coluna - 97) 
    }

    public override string ToString()
    {
        return $"{Coluna}{Linha}";
    }
}
