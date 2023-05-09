using XadrezConsole;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;


TabuleiroJogo tab = new TabuleiroJogo(8, 8);

tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));


tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));
tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(6, 6));
tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(6, 5));

Tela.ImprimirTabuleiro(tab);