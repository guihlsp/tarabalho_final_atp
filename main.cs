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
        Console.WriteLine(
            @"
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
        Console.WriteLine("\nDigite 1 para cadastrar vôos.");
        Console.WriteLine("Digite 2 para cadastrar passageiros.");
        Console.WriteLine("Digite 3 para ver vôos.");
        Console.WriteLine("Digite 4 para ver passageiros.");
        Console.WriteLine("Digite 5 para alterar um passageiro.");
        Console.WriteLine("Digite 6 para excluir passageiro.");
        Console.WriteLine("Digite 7 para alterar um vôo.");
        Console.WriteLine("Digite 8 para excluir vôo.");
        Console.WriteLine("Digite 0 para sair do menu.");
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
            case 7:
                alteraVoo();
                break;
            case 8:
                deletarVoo();
                break;
            case 0:
                Console.WriteLine("Até mais, volte sempre!");
                break;
            default:
                Console.Clear();
                Console.WriteLine(
                    "Você selecionou uma opção inválida. Por favor, tente novamente."
                );
                exibirOpcoes();
                break;
        }
    }

    static void addVoo(string[] voo)
    {
        string[,] listaVoos_aux = new string[quantidadeVoo + 1, 3]; // Criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        for (int i = 0; i < quantidadeVoo; i++) // Copia as informações do vetor original para o vetor auxiliar.
        {
            for (int j = 0; j < 3; j++)
            {
                listaVoos_aux[i, j] = listaVoos[i, j];
            }
        }
        for (int j = 0; j < 3; j++) // Adiciona as informações do novo voo ao final do vetor auxiliar.
        {
            listaVoos_aux[quantidadeVoo, j] = voo[j];
        }
        listaVoos = new string[quantidadeVoo + 1, 3]; // Cria um novo vetor para armazenar as informações atualizadas, com um tamanho maior para acomodar o novo voo.
        quantidadeVoo++; // Incrementa a quantidade de voos.
        listaVoos = listaVoos_aux; // Substitui o vetor original pelo vetor auxiliar atualizado.
    }

    static string[] retornaVoo(int a)
    {
        string[] retorno = new string[3]; // Cria um novo vetor de strings para armazenar as informações do voo a ser retornado.
        for (int j = 0; j < 3; j++) // Percorre os elementos da linha 'a' do vetor listaVoos.
        {
            retorno[j] = listaVoos[a, j]; // Atribui cada elemento da linha 'a' do vetor listaVoos ao vetor retorno.
        }
        return retorno; // Retorna o vetor com as informações do voo.
    }

    static void alteraVoo()
    {
        Console.Clear();
        exibirTitulo("Alterar Voo");
        Console.Write("Digite o código do vôo que deseja alterar: ");
        string codVoo = Console.ReadLine()!;
        int indiceVoo = -1;

        for (int i = 0; i < quantidadeVoo; i++)
        { // Procurar o vôo com base no código
            if (codVoo == listaVoos[i, 0])
            {
                indiceVoo = i;
                break;
            }
        }
        if (indiceVoo != -1)
        {
            Console.WriteLine(
                $"\nVoo encontrado! Código: {listaVoos[indiceVoo, 0]}, Distância: {listaVoos[indiceVoo, 1]} KM, Quantidade de assentos: {listaVoos[indiceVoo, 2]}\n"
            );
            Console.Write("Digite o novo código do vôo: ");
            string novoCodigo = Console.ReadLine()!;
            Console.Write("Digite a nova distância do vôo em KM: ");
            string novaDistancia = Console.ReadLine()!;
            Console.Write("Digite a nova quantidade de assentos do vôo: ");
            string novaQtdAssentos = Console.ReadLine()!;
            listaVoos[indiceVoo, 0] = novoCodigo; // Atualiza o código do vôo no vetor listaVoos.
            listaVoos[indiceVoo, 1] = novaDistancia; // Atualiza a distância do vôo no vetor listaVoos.
            listaVoos[indiceVoo, 2] = novaQtdAssentos; // Atualiza a quantidade de assentos do vôo no vetor listaVoos.
            Console.WriteLine("\nVôo alterado com sucesso!");
        }
        else
        {
            Console.WriteLine($"\nNão existe vôo com o código {codVoo} informado!");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
    }

    static void excluiVoo(int a)
    {
        string[,] listaVoos_aux = new string[quantidadeVoo - 1, 2]; // Cria um novo vetor auxiliar com tamanho reduzido para armazenar os voos restantes após a exclusão.
        int indiceAuxiliar = 0;
        for (int i = 0; i < quantidadeVoo; i++) // Percorre todos os voos no vetor listaVoos.
        {
            if (i != a) // Verifica se o índice atual é diferente do índice do voo a ser excluído.
            {
                for (int j = 0; j < 2; j++) // Copia as informações do voo para o vetor auxiliar, exceto o voo a ser excluído.
                {
                    listaVoos_aux[indiceAuxiliar, j] = listaVoos[i, j];
                }
                indiceAuxiliar++;
            }
        }
        quantidadeVoo--; // Reduz a quantidade de voos.
        listaVoos = listaVoos_aux; // Substitui o vetor original pelo vetor auxiliar atualizado.
    }

    static void deletarVoo()
    {
        Console.Clear();
        exibirTitulo("Excluir Voos");
        Console.Write("Digite o código do vôo que deseja excluir: ");
        string codVoo = Console.ReadLine()!;
        int indiceVoo = -1;
        for (int i = 0; i < quantidadeVoo; i++) // Percorre todos os voos no vetor listaVoos.
        {
            if (codVoo == listaVoos[i, 0]) // Verifica se o código do voo atual corresponde ao código informado pelo usuário.
            {
                indiceVoo = i;
                break;
            }
        }
        if (indiceVoo != -1) // Verifica se o voo foi encontrado com base no código informado.
        {
            excluiVoo(indiceVoo); // Chama a função excluiVoo para remover o voo do vetor listaVoos.
            Console.WriteLine("Voo excluído com sucesso!");
        }
        else
        {
            Console.WriteLine($"Não existe vôo com o código {codVoo} informado!");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
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
        Console.WriteLine("Digite 2 para ver os vôos com mais passageiros.");
        Console.WriteLine("Digite 3 para ver os vôos com menos passageiros.");
        Console.WriteLine("Digite 4 para ver os vôos com maior distância.");
        Console.WriteLine("Digite 5 para ver os vôos com menor distância.");
        Console.WriteLine("Digite 6 para ver os vôos com ocupação média dos vôos");
        Console.WriteLine("Digite 0 para voltar ao menu.");
        Console.Write("\nDigite sua opção:");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (opcaoEscolhida)
        {
            case 1:
                verVoos();
                break;
            case 2:
                voosMaisPassageiros();
                break;
            case 3:
                voosMenosPassageiros();
                break;
            case 4:
                voosMaiorDistancia();
                break;
            case 5:
                voosMenorDistancia();
                break;
            case 6:
                ocupacaoMediaVoos();
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
            Console.Clear();
            exibirTitulo("Vôos com mais passageiros");
            // Encontra o número máximo de passageiros entre todos os voos
            int maxPassageiros = 0;
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int passageiros = int.Parse(listaVoos[i, 2]);
                if (passageiros > maxPassageiros)
                {
                    maxPassageiros = passageiros;
                }
            }

            // Exibe os voos com o número máximo de passageiros
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int passageiros = int.Parse(listaVoos[i, 2]);
                if (passageiros == maxPassageiros)
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}");
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km");
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n");
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void voosMenosPassageiros()
        {
            Console.Clear();
            exibirTitulo("Vôos com menos passageiros");
            // Encontra o número mínimo de passageiros entre todos os voos
            int minPassageiros = int.MaxValue;
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int passageiros = int.Parse(listaVoos[i, 2]);
                if (passageiros < minPassageiros)
                {
                    minPassageiros = passageiros;
                }
            }

            // Exibe os voos com o número mínimo de passageiros
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int passageiros = int.Parse(listaVoos[i, 2]);
                if (passageiros == minPassageiros)
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}");
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km");
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n");
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void voosMaiorDistancia()
        {
            Console.Clear();
            exibirTitulo("Vôos com maior distância");
            // Encontra a distância máxima entre todos os voos
            int maxDistancia = 0;
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int distancia = int.Parse(listaVoos[i, 1]);
                if (distancia > maxDistancia)
                {
                    maxDistancia = distancia;
                }
            }

            // Exibe os voos com a distância máxima
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int distancia = int.Parse(listaVoos[i, 1]);
                if (distancia == maxDistancia)
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}");
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km");
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n");
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void voosMenorDistancia()
        {
            Console.Clear();
            exibirTitulo("Vôos com menor distância");

            // Encontra a distância mínima entre todos os voos
            int minDistancia = int.MaxValue;
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int distancia = int.Parse(listaVoos[i, 1]);
                if (distancia < minDistancia)
                {
                    minDistancia = distancia;
                }
            }

            // Exibe os voos com a distância mínima
            for (int i = 0; i < quantidadeVoo; i++)
            {
                int distancia = int.Parse(listaVoos[i, 1]);
                if (distancia == minDistancia)
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}");
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km");
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n");
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void ocupacaoMediaVoos()
        {
            Console.Clear();
            exibirTitulo("Ocupação média dos vôos");
            int totalPassageiros = 0; //
            //Loop que percorre os voos
            for (int i = 0; i < quantidadeVoo; i++)
            {
                totalPassageiros += int.Parse(listaVoos[i, 2]); // Adiciona a quantidade de passageiros do voo atual ao totalPassageiros
            }
            double mediaOcupacao = (double)totalPassageiros / quantidadeVoo; // Calcula a média de ocupação dos voos
            Console.WriteLine($"Ocupação média dos vôos: {mediaOcupacao:N2} passageiros");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }
    }

    static void cadastrarVoos()
    {
        Console.Clear();
        exibirTitulo("Cadastro de vôos");
        Console.Write("Digite o codigo do vôo:");
        string codigoVoo = Console.ReadLine()!;
        Console.Write("Digite a distância do vôo em KM:");
        string distanciaVoo = Console.ReadLine()!;
        Console.Write("Digite a quantidade de assentos desse vôo:");
        string assentosVoo = Console.ReadLine()!;
        addVoo(new string[3] { codigoVoo, distanciaVoo, assentosVoo }); // Chama a função addVoo para cadastrar o vôo com as informações fornecidas.
        Console.WriteLine($"O vôo de codigo {codigoVoo} foi cadastrado com sucesso!");
        //Thread.Sleep(3000); //faz o carregamento de alguns segundos
        Console.Clear();
        exibirOpcoes();
    }

    static void adicionaPassageiro(string[] passageiro)
    {
        // Criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] listaPassageiros_aux = new string[quantidadePassageiro + 1, 2];

        // Copia os valores do vetor original para o vetor auxiliar
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                listaPassageiros_aux[i, j] = listaPassageiros[i, j];
            }
        }

        // Adiciona as informações do novo passageiro ao vetor auxiliar
        for (int j = 0; j < 2; j++)
        {
            listaPassageiros_aux[quantidadePassageiro, j] = passageiro[j];
        }

        listaPassageiros = new string[quantidadePassageiro + 1, 2]; // Cria um novo vetor com tamanho atualizado
        quantidadePassageiro++; // Incrementa a quantidade de passageiros
        listaPassageiros = listaPassageiros_aux; // Substitui o vetor original pelo vetor auxiliar atualizado
    }

    static string[] retornaPassageiro(int a)
    {
        string[] ret = new string[2];

        // Retorna os valores da linha do vetor de passageiros
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

        // Procura o passageiro com base no código
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
            Console.WriteLine(
                $"\nPassageiro encontrado! Código: {listaPassageiros[indicePassageiro, 0]}, Nome: {listaPassageiros[indicePassageiro, 1]}\n"
            );
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

        // Copia os valores do vetor original para o vetor auxiliar, excluindo o passageiro no índice especificado
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

        quantidadePassageiro--; // Decrementa a quantidade de passageiros
        listaPassageiros = listaPassageiros_aux; // Substitui o vetor original pelo vetor auxiliar atualizado
    }

    static void deletarPassageiro()
    {
        Console.Clear();
        exibirTitulo("Excluir Passageiros");
        Console.Write("Digite o código do passageiro que deseja excluir: ");
        string codPassageiro = Console.ReadLine()!;
        int indicePassageiro = -1;

        // Procura o passageiro com base no código
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
        // Exibe a lista de passageiros, mostrando código e nome de cada um
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
    }

    static void verTodosOsPassageiros()
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

    static void verPassageiroEspecifico()
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

            // Procura o passageiro com base no código
            for (int i = 0; i < quantidadePassageiro; i++)
            {
                if (codPassageiro == listaPassageiros[i, 0])
                {
                    // Se o código do passageiro for igual ao código especificado,
                    // imprime o nome do passageiro correspondente ao código encontrado
                    Console.WriteLine(
                        $"O passageiro do código {codPassageiro} é {listaPassageiros[i, 1]}"
                    );
                    passageiroEncontrado = true;
                    break; // Interrompe o loop, pois o passageiro foi encontrado
                }
            }
            if (!passageiroEncontrado)
            {
                // Se nenhum passageiro for encontrado, exibe uma mensagem informando
                Console.WriteLine($"Não existe passageiro com o código {codPassageiro} informado!");
            }
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
    }

    static void cadastroPassageiros()
    {
        Console.Clear();
        exibirTitulo("Cadastro De Passageiros");
        Console.Write("Digite o codigo do passageiro:");
        string codigoPassageiro = Console.ReadLine()!;
        Console.Write("Digite o nome do passageiro:");
        string nomePassageiro = Console.ReadLine()!;
        adicionaPassageiro(new string[2] { codigoPassageiro, nomePassageiro });
        Console.WriteLine(
            $"O passageiro(a) {nomePassageiro} de codigo {codigoPassageiro} foi cadastrado com sucesso!"
        );
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
