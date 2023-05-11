using XadrezConsole;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;


try
{
    PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
    while (!partidaDeXadrez.Terminada)
    {
        try
        {

            Console.Clear();
            Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
            Console.WriteLine("Aguradando Jogada: " + partidaDeXadrez.JogadorAtual);
            Console.WriteLine();
            Console.Write("Digite a Posição de Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

            partidaDeXadrez.ValidarPosicaoOrigem(origem);
            bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.Peca(origem)!.MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Digite a Posição de Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partidaDeXadrez.ValidarPosicaoDestino(origem, destino);
            partidaDeXadrez.RealizaJogada(origem, destino);
        }
        catch (Exception e)
        {
            Console.WriteLine();
            Console.WriteLine(e.Message);
            Console.WriteLine("Pressione ENTER para continuar Jogo");
            Console.ReadLine();
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

