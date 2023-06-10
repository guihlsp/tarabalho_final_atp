using System;
using System.Threading;

class TrabalhoFinal
{
    //criação da matriz que recebe as informaçôes para cadastro de um voo
    static string[,] listaVoos = new string[1, 3]; //codigo = [0], distancia = [1], assentos = [2]
    static int quantidadeVoo = 0;
    static string[,] listaPassageiros = new string[1, 2]; //codigoPassageiro = [0], nome = [1],
    static int quantidadePassageiro = 0;
    static void exibirMensagem()
    {
        Console.WriteLine(@"
                                            ███╗░░██╗░█████╗░██████╗░███╗░░██╗██╗░█████╗░
                                            ████╗░██║██╔══██╗██╔══██╗████╗░██║██║██╔══██╗
                                            ██╔██╗██║███████║██████╔╝██╔██╗██║██║███████║
                                            ██║╚████║██╔══██║██╔══██╗██║╚████║██║██╔══██║
                                            ██║░╚███║██║░░██║██║░░██║██║░╚███║██║██║░░██║
                                            ╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝

                                ██████╗░░█████╗░░██████╗░██████╗░█████╗░░██████╗░███████╗███╗░░██╗░██████╗
                                ██╔══██╗██╔══██╗██╔════╝██╔════╝██╔══██╗██╔════╝░██╔════╝████╗░██║██╔════╝
                                ██████╔╝███████║╚█████╗░╚█████╗░███████║██║░░██╗░█████╗░░██╔██╗██║╚█████╗░
                                ██╔═══╝░██╔══██║░╚═══██╗░╚═══██╗██╔══██║██║░░╚██╗██╔══╝░░██║╚████║░╚═══██╗
                                ██║░░░░░██║░░██║██████╔╝██████╔╝██║░░██║╚██████╔╝███████╗██║░╚███║██████╔╝
                                ╚═╝░░░░░╚═╝░░╚═╝╚═════╝░╚═════╝░╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░

                                        ░█████╗░███████╗██████╗░███████╗░█████╗░░██████╗
                                        ██╔══██╗██╔════╝██╔══██╗██╔════╝██╔══██╗██╔════╝
                                        ███████║█████╗░░██████╔╝█████╗░░███████║╚█████╗░
                                        ██╔══██║██╔══╝░░██╔══██╗██╔══╝░░██╔══██║░╚═══██╗
                                        ██║░░██║███████╗██║░░██║███████╗██║░░██║██████╔╝
                                        ╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═════╝░");

        Console.WriteLine(" \nSeja bem vindo a Narnia Passagens Aéreas ");
    }

    static void exibirOpcoes()
    {
        Console.WriteLine(" \n--------- MENU --------- ");
        Console.WriteLine("\nDigite 1 para cadastrar vôos."); //Feito
        Console.WriteLine("Digite 2 para cadastrar passageiros."); //Feito
        Console.WriteLine("Digite 3 para ver vôos."); //Feito
        Console.WriteLine("Digite 4 para ver passageiros.");  //Feito
        Console.WriteLine("Digite 5 para alterar um passageiro."); //Feito
        Console.WriteLine("Digite 6 para excluir passageiro."); //Feito
        Console.WriteLine("Digite 7 para alterar um vôo."); //A fazer
        Console.WriteLine("Digite 8 para excluir vôo."); // A fazer
        Console.WriteLine("Digite 0 para sair do menu."); // Feito
        Console.Write("\nDigite sua opção:");
        int opcaoEscolhida = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.Write("Digite sua opção: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out opcaoEscolhida))
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, digite um número inteiro válido.");
            }
        }
        switch (opcaoEscolhida)
        {
            case 1:
                cadastrarVoos();
                break;
            case 2:
                cadastroPassageiros();
                break;
            case 3:
                verVoos();
                break;
            case 4:
                verTodosPassageiros();
                break;
            case 5:
                alteraPassageiro();
                break;
            case 6:
                deletarPassageiro();
                break;
            case 7: //alterarUmVoo();
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 8: // excluirVoo();
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 0:
                Console.WriteLine("Até mais, volte sempre!");
                break;
            default:
                Console.Clear();
                Console.WriteLine("Você selecionou uma opção inválida. Por favor, tente novamente.");
                exibirOpcoes();
                break;
        }
    }

    static void addVoo(string[] voo)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] listaVoos_aux = new string[quantidadeVoo + 1, 3];
        for (int i = 0; i < quantidadeVoo; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                listaVoos_aux[i, j] = listaVoos[i, j];
            }
        }
        for (int j = 0; j < 3; j++)
        {
            listaVoos_aux[quantidadeVoo, j] = voo[j];
        }
        listaVoos = new string[quantidadeVoo + 1, 3];
        quantidadeVoo++;
        listaVoos = listaVoos_aux;
    }

    static string[] retornaVoo(int a)
    {
        string[] retorno = new string[3];
        //retorna linha

        for (int j = 0; j < 3; j++)
        {
            retorno[j] = listaVoos[a, j];
        }

        return retorno;
    }

    static void excluiVoo(int a)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição.
        string[,] listaVoos_aux = new string[quantidadeVoo - 1, 3];
        for (int i = 0; i < quantidadeVoo; i++)
        {
            if (i < a)
            {
                for (int j = 0; j < 3; j++)
                {
                    listaVoos_aux[i, j] = listaVoos[i, j];
                }
            }
            else if (i > a)
            {
                for (int j = 0; j < 3; j++)
                {
                    listaVoos_aux[i - 1, j] = listaVoos[i, j];
                }
            }
        }
        quantidadeVoo--;
        listaVoos = listaVoos_aux;
    }

    static void listaDosVoos()
    {
        for (int i = 0; i < quantidadeVoo; i++)
        {
            //Console.WriteLine($"Vôos: {listaDosVoos[i]}");
            Console.WriteLine($"Vôo: {listaVoos[i, 0]}");
            Console.WriteLine($"Distância: {listaVoos[i, 1]}km");
            Console.WriteLine($"Assentos: {listaVoos[i, 2]}\n");
        }
    }

    static void verVoos()
    {
        Console.Clear();
        exibirTitulo("Ver vôos disponiveis");
        Console.WriteLine("\nDigite 1 para ver todos os vôos.");
        Console.WriteLine("Digite 2 para ver os vôos com mais passageiros."); //A fazer
        Console.WriteLine("Digite 3 para ver os vôos com menos passageiros."); //A fazer
        Console.WriteLine("Digite 4 para ver os vôos com maior distância."); //A fazer
        Console.WriteLine("Digite 5 para ver os vôos com menor distância."); //A fazer
        Console.WriteLine("Digite 6 para ver os vôos com ocupação média dos vôos"); //A fazer
        Console.WriteLine("Digite 0 para voltar ao menu.");
        Console.Write("\nDigite sua opção:");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (opcaoEscolhida)
        {
            case 1:
                verVoos();
                //Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 2: //voosMaisPassageiros();
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 3: //voosMenosPassageiros();
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 4: //voosMaiorDistancia();
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 5: // voosMenorDistancia()
                Console.WriteLine($"Sua escolha foi {opcaoEscolhida}");
                break;
            case 6: //ocupacaoMediaVoos()
                visualizarOcupacaoMedia();
                break;
            case 0:
                Console.Clear();
                exibirOpcoes();
                break;
            default:
                Console.Clear();
                Console.WriteLine(
                    "Você selecionou uma opção inválida. Por favor tente novamente.\n"
                );
                Thread.Sleep(2500);
                verVoos();
                break;
        }

        void verVoos()
        {
            Console.Clear();
            exibirTitulo("Exibição de todos os vôos registrados.");

            listaDosVoos();

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            //faz com que qualquer tecla que for digitada faça ir para o menu
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void voosMaisPassageiros()
        {
            Voo[] voos = new Voo[5];
            // VooMaisPassageiro
            Voo vooMaisPassageiro = EncontrarVooMaisPassageiro(voos);
            Console.WriteLine("Voo com mais passageiros:");
            if (vooMaisPassageiro != null)
            {
                Console.WriteLine($"Número do voo: {vooMaisPassageiro.NumeroVoo}");
                Console.WriteLine($"Número de passageiros: {vooMaisPassageiro.NumeroPassageiros}");
                // Adicione aqui qualquer outra informação que deseje exibir
            }
            else
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }
        }

        void voosMenosPassageiros()
        {
            // VoosMenosPassageiros
            Voo vooMenosPassageiros = EncontrarVooMenosPassageiros(voos);
            Console.WriteLine("Voo com menos passageiros:");
            if (vooMenosPassageiros != null)
            {
                Console.WriteLine($"Número do voo: {vooMenosPassageiros.NumeroVoo}");
                Console.WriteLine($"Número de passageiros: {vooMenosPassageiros.NumeroPassageiros}");
                // Adicione aqui qualquer outra informação que deseje exibir
            }
            else
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }

            // VoosMaiorDistancia
            Voo vooMaiorDistancia = EncontrarVooMaiorDistancia(voos);
            Console.WriteLine("Voo com maior distância percorrida:");
            if (vooMaiorDistancia != null)
            {
                Console.WriteLine($"Número do voo: {vooMaiorDistancia.NumeroVoo}");
                Console.WriteLine($"Distância percorrida: {vooMaiorDistancia.DistanciaPercorrida}");
                // Adicione aqui qualquer outra informação que deseje exibir
            }
            else
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }
        }


        void voosMaiorDistancia()
        {
            // VoosMaiorDistancia
            Voo vooMaiorDistancia = EncontrarVooMaiorDistancia(voos);
            Console.WriteLine("Voo com maior distância percorrida:");
            if (vooMaiorDistancia != null)
            {
                Console.WriteLine($"Número do voo: {vooMaiorDistancia.NumeroVoo}");
                Console.WriteLine($"Distância percorrida: {vooMaiorDistancia.DistanciaPercorrida}");
                // Adicione aqui qualquer outra informação que deseje exibir
            }
            else
            {
                Console.WriteLine("Nenhum voo encontrado.");
            }
        }

        void voosMenorDistancia()
        {
            Voo EncontrarVooMenorDistancia(Voo[] voos)
            {
                Voo vooMenorDistancia = null;
                double minDistancia = double.MaxValue;

                foreach (Voo voo in voos)
                {
                    if (voo.DistanciaPercorrida < minDistancia)
                    {
                        vooMenorDistancia = voo;
                        minDistancia = voo.DistanciaPercorrida;
                    }
                }

                return vooMenorDistancia;
            }
        }

        void ocupacaoMediaVoos()
        {
            static void visualizarOcupacaoMedia()
            {
                Console.Clear();
                exibirTitulo("Ocupação Média de Voos");

                if (listaVoos.Count == 0)
                {
                    Console.WriteLine("Não há voos cadastrados.");
                }
                else
                {
                    int totalAssentos = 0;
                    int totalAssentosOcupados = 0;

                    foreach (var voo in listaVoos)
                    {
                        int assentosVoo = int.Parse(voo[2]);  // Obtém a quantidade de assentos do voo
                        totalAssentos += assentosVoo;  // Soma a quantidade de assentos ao total

                        // Calcula a quantidade de assentos ocupados
                        int assentosOcupados = assentosVoo - ObterAssentosDisponiveis(voo[0]);
                        totalAssentosOcupados += assentosOcupados;  // Soma a quantidade de assentos ocupados ao total
                    }

                    if (totalAssentos == 0)
                    {
                        Console.WriteLine("Não há assentos disponíveis em nenhum voo.");
                    }
                    else
                    {
                        double ocupacaoMedia = (double)totalAssentosOcupados / totalAssentos * 100;

                        Console.WriteLine($"A ocupação média de voos é de: {ocupacaoMedia:F2}%");
                    }
                }

                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                exibirOpcoes();
            }

            static int ObterAssentosDisponiveis(string codigoVoo)
            {
                // Percorra a lista de passageiros e conte quantos estão associados ao voo
                int assentosOcupados = 0;
                foreach (var passageiro in listaPassageiros)
                {
                    if (passageiro[2] == codigoVoo)  // Verifica se o código do voo do passageiro corresponde ao voo atual
                    {
                        assentosOcupados++;
                    }
                }
                return assentosOcupados;
            }


        }
    }

    static void cadastrarVoos()
    {
        Console.Clear();
        exibirTitulo("Cadastro de vôos");
        Console.Write("Digite o codigo do vôo:");
        string codigoVoo = Console.ReadLine()!;
        Console.Write("Digite a distância do vôo:");
        string distanciaVoo = Console.ReadLine()!;
        Console.Write("Digite a quantidades de assentos desse Vôo:");
        string assentosVoo = Console.ReadLine()!;
        addVoo(new string[3] { codigoVoo, distanciaVoo, assentosVoo });
        Console.WriteLine($"O vôo de codigo {codigoVoo} foi cadastrado com sucesso!");
        //Thread.Sleep(3000); //faz o carregamento de alguns segundos
        Console.Clear();
        exibirOpcoes();
    }

    static void adicionaPassageiro(string[] passageiro)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] listaPassageiros_aux = new string[quantidadePassageiro + 1, 2];
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                listaPassageiros_aux[i, j] = listaPassageiros[i, j];
            }
        }
        for (int j = 0; j < 2; j++)
        {
            listaPassageiros_aux[quantidadePassageiro, j] = passageiro[j];
        }
        listaPassageiros = new string[quantidadePassageiro + 1, 2];
        quantidadePassageiro++;
        listaPassageiros = listaPassageiros_aux;
    }

    static string[] retornaPassageiro(int a)
    {
        string[] ret = new string[2];
        //retorna linha
        for (int j = 0; j < 2; j++)
        {
            ret[j] = listaPassageiros[a, j];
        }
        return ret;
    }

    static void alteraPassageiro()
    {
        Console.Clear();
        exibirTitulo("Alterar Passageiro");
        Console.Write("Digite o código do passageiro que deseja alterar: ");
        string codPassageiro = Console.ReadLine()!;
        int indicePassageiro = -1;

        // Procurar o passageiro com base no código
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            if (codPassageiro == listaPassageiros[i, 0])
            {
                indicePassageiro = i;
                break;
            }
        }

        if (indicePassageiro != -1)
        {
            Console.WriteLine($"\nPassageiro encontrado! Código: {listaPassageiros[indicePassageiro, 0]}, Nome: {listaPassageiros[indicePassageiro, 1]}\n");
            Console.Write("Digite o novo código do passageiro: ");
            string novoCodigo = Console.ReadLine()!;
            Console.Write("Digite o novo nome do passageiro: ");
            string novoNome = Console.ReadLine()!;
            listaPassageiros[indicePassageiro, 0] = novoCodigo;
            listaPassageiros[indicePassageiro, 1] = novoNome;
            Console.WriteLine("\nPassageiro alterado com sucesso!");
        }
        else
        {
            Console.WriteLine($"\nNão existe passageiro com o código {codPassageiro} informado!");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
    }
    static void excluiPassageiro(int a)
    {
        string[,] listaPassageiros_aux = new string[quantidadePassageiro - 1, 2];
        int indiceAuxiliar = 0;
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            if (i != a)
            {
                for (int j = 0; j < 2; j++)
                {
                    listaPassageiros_aux[indiceAuxiliar, j] = listaPassageiros[i, j];
                }
                indiceAuxiliar++;
            }
        }
        quantidadePassageiro--;
        listaPassageiros = listaPassageiros_aux;
    }

    static void deletarPassageiro()
    {
        Console.Clear();
        exibirTitulo("Excluir Passageiros");
        Console.Write("Digite o código do passageiro que deseja excluir: ");
        string codPassageiro = Console.ReadLine()!;
        int indicePassageiro = -1;
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            if (codPassageiro == listaPassageiros[i, 0])
            {
                indicePassageiro = i;
                break;
            }
        }
        if (indicePassageiro != -1)
        {
            excluiPassageiro(indicePassageiro);
            Console.WriteLine("Passageiro excluído com sucesso!");
        }
        else
        {
            Console.WriteLine($"Não existe passageiro com o código {codPassageiro} informado!");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
    }
    static void ListaDosPassageiros()
    {
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            Console.WriteLine($"Código: {listaPassageiros[i, 0]}");
            Console.WriteLine($"Nome: {listaPassageiros[i, 1]}\n");
        }
    }
    static void verTodosPassageiros()
    {
        Console.Clear();
        exibirTitulo("Ver Passageiros");
        Console.WriteLine("\nDigite 1 para ver um passageiro específico.");
        Console.WriteLine("Digite 2 para ver todos os passageiros desse vôo.");
        Console.WriteLine("Digite 0 para voltar ao menu principal.");
        Console.Write("\nDigite sua opção:");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (opcaoEscolhida)
        {
            case 1:
                verPassageiroEspecifico();
                break;
            case 2:
                verTodosOsPassageiros();
                break;
            case 0:
                Console.Clear();
                exibirOpcoes();
                break;
            default:
                Console.Clear();
                Console.WriteLine(
                    "Você selecionou uma opção inválida. Por favor tente novamente.\n"
                );
                Thread.Sleep(2500);
                verTodosPassageiros();
                break;
        }

        void verTodosOsPassageiros()
        {
            Console.Clear();
            if (quantidadePassageiro == 0)
            {
                Console.WriteLine("Não há passageiros cadastrados.");
            }
            else
            {
                exibirTitulo("Exibição de todos os passageiros registrados.");
                ListaDosPassageiros();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            //faz com que qualquer tecla que for digitada faça ir para o menu
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }
        void verPassageiroEspecifico()
        {
            Console.Clear();
            if (quantidadePassageiro == 0)
            {
                Console.WriteLine("Não há passageiros cadastrados.");
            }
            else
            {
                exibirTitulo("Exibição de passageiros registrados.");
                Console.Write("Digite o codigo do passageiro que deseja pesquisar:");
                string codPassageiro = Console.ReadLine()!;
                bool passageiroEncontrado = false;
                for (int i = 0; i < quantidadePassageiro; i++)
                {
                    if (codPassageiro == listaPassageiros[i, 0])
                    {
                        Console.WriteLine($"O passageiro do código {codPassageiro} é {listaPassageiros[i, 1]}");
                        passageiroEncontrado = true;
                        break;
                    }
                }
                if (!passageiroEncontrado)
                {
                    Console.WriteLine($"Não existe passageiro com o código {codPassageiro} informado!");
                }
            }
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }
    }
    static void cadastroPassageiros()
    {
        Console.Clear();
        exibirTitulo("Cadastro De Passageiros");
        Console.Write("Digite o codigo do passageiro:");
        string codigoPassageiro = Console.ReadLine()!; // Lê o código do passageiro e o sinal (!) identifica que o mesmo não é nulo.
        Console.Write("Digite o nome do passageiro:");
        string nomePassageiro = Console.ReadLine()!; //Lê o nome do passageiro e o sinal (!) identifica que o mesmo não é nulo.
        adicionaPassageiro(new string[2] { codigoPassageiro, nomePassageiro });
        Console.WriteLine(
            $"O passageiro(a) {nomePassageiro} de codigo {codigoPassageiro} foi cadastrado com sucesso!"
        );
        // Thread.Sleep(3500);
        Console.Clear();
        exibirOpcoes();
    }

    static void exibirTitulo(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public static void Main(string[] args)
    {
        exibirMensagem();
        exibirOpcoes();
    }
}
