using XadrezConsole;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;


try
{
    PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
    while (!partidaDeXadrez.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

        Console.WriteLine();
        Console.Write("Digite a Posição de Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

        bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();

        Console.Clear();
        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, posicoesPossiveis);

        Console.WriteLine();
        Console.Write("Digite a Posição de Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
        partidaDeXadrez.ExecutaMovimento(origem, destino);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

