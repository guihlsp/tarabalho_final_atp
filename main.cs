using System;
using System.Threading;

class TrabalhoFinal
{
    //criação da matriz que recebe as informaçôes para cadastro de um voo
    static string[,] vetorListaDosVoos = new string[1, 3];//codigo = [0], distancia = [1], assentos = [2]
    static int quantidadeVoo = 0;

    static string[,] vetorListaDosPassageiros = new string[1, 2];//codigoPassageiro = [0], nome = [1],
    static int quantidadePassageiro = 0;
    static void exibirMensagemBoasVindas()
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

    static void exibirOpcoesDoMenu()
    {
        Console.WriteLine(" \n--------- MENU --------- ");
        Console.WriteLine("\nDigite 1 para Cadastrar vôos.");
        Console.WriteLine("Digite 2 Cadastrar passageiros.");
        Console.WriteLine("Digite 3 Ver vôos.");
        Console.WriteLine("Digite 4 Ver passageiros.");
        Console.WriteLine("Digite 5 Alterar um passageiro.");
        Console.WriteLine("Digite 6 Excluir passageiro.");
        Console.WriteLine("Digite 7 Alterar um vôo.");
        Console.WriteLine("Digite 8 Excluir vôo.");
        Console.WriteLine("Digite 0 para sair do menu.");
        Console.Write("\nDigite sua opção:");
        int OpcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (OpcaoEscolhida)
        {
            case 1:
                CadastrarVoos();
                break;
            case 2:
                CadastroDePassageiros();
                break;
            case 3:
                verVoos();
                break;
            case 4:
                verTodosPassageiros();
                break;
            case 5: //alterarUmPassageiro();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;
            case 6: //excluirUmPassageiro();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;
            case 7: //alterarUmVoo();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;
            case 8: // excluirVoo();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;
            case 0:
                Console.WriteLine("Tchaauu, volte sempre!");
                break;
            default:
                Console.Clear();
                Console.WriteLine("Você selecionou uma opção inválida, por favor tente novamente\n");
                exibirOpcoesDoMenu();
                break;
        }
    }

    static void AddVoo(string[] voo)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] vetorListaDosVoos_aux = new string[quantidadeVoo + 1, 3];
        for (int i = 0; i < quantidadeVoo; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                vetorListaDosVoos_aux[i, j] = vetorListaDosVoos[i, j];
            }
        }
        for (int j = 0; j < 3; j++)
        {
            vetorListaDosVoos_aux[quantidadeVoo, j] = voo[j];
        }
        vetorListaDosVoos = new string[quantidadeVoo + 1, 3];
        quantidadeVoo++;
        vetorListaDosVoos = vetorListaDosVoos_aux;
    }

    static string[] retornaVoo(int a)
    {

        string[] retorno = new string[3];
        //retorna linha

        for (int j = 0; j < 3; j++)
        {

            retorno[j] = vetorListaDosVoos[a, j];

        }

        return retorno;

    }

    static void excluiVoo(int a)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição.
        string[,] vetorListaDosVoos_aux = new string[quantidadeVoo - 1, 3];
        for (int i = 0; i < quantidadeVoo; i++)
        {
            if (i < a)
            {
                for (int j = 0; j < 3; j++)
                {
                    vetorListaDosVoos_aux[i, j] = vetorListaDosVoos[i, j];
                }
            }
            else if (i > a)
            {
                for (int j = 0; j < 3; j++)
                {
                    vetorListaDosVoos_aux[i - 1, j] = vetorListaDosVoos[i, j];
                }
            }
        }
        quantidadeVoo--;
        vetorListaDosVoos = vetorListaDosVoos_aux;
    }


    static void ListaDosVoos()
    {

        for (int i = 0; i < quantidadeVoo; i++)
        {
            //Console.WriteLine($"Vôos: {ListaDosVoos[i]}");      
            Console.WriteLine($"Vôo: {vetorListaDosVoos[i, 0]}");
            Console.WriteLine($"Distância: {vetorListaDosVoos[i, 1]}km");
            Console.WriteLine($"Assentos: {vetorListaDosVoos[i, 2]}\n");
        }


    }


    static void verVoos()
    {
        Console.Clear();
        exibirTitulo("Ver vôos disponiveis");


        Console.WriteLine("\nDigite 1 para ver todos os vôos.");
        Console.WriteLine("Digite 2 para ver os vôos com mais passageiros."); //atenção
        Console.WriteLine("Digite 3 para ver os vôos com menos passageiros."); //atenção
        Console.WriteLine("Digite 4 para ver os vôos com maior distância."); //atenção
        Console.WriteLine("Digite 5 para ver os vôos com menor distância."); //atenção
        Console.WriteLine("Digite 6 para ver os vôos com ocupação média dos vôos"); //atenção
        Console.WriteLine("Digite 0 para voltar ao menu.");

        Console.Write("\nDigite sua opção:");
        int OpcaoEscolhida = int.Parse(Console.ReadLine()!);

        switch (OpcaoEscolhida)
        {
            case 1:
                verTodosOsVoos();
                //Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 2: //voosMaisPassageiros();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 3: //voosMenosPassageiros();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 4: //voosMaiorDistancia();
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 5: // voosMenorDistancia()
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 6: //ocupacaoMediaVoos()
                Console.WriteLine($"Sua escolha foi {OpcaoEscolhida}");
                break;

            case 0:
                Console.Clear();
                exibirOpcoesDoMenu();
                break;

            default:
                Console.Clear();
                Console.WriteLine("Você selecionou uma opção inválida. Por favor tente novamente.\n");
                Thread.Sleep(2500);
                verVoos();
                break;
        }

        void verTodosOsVoos()
        {
            Console.Clear();
            exibirTitulo("Exibição de todos os vôos registrados.");

            ListaDosVoos();

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            //faz com que qualquer tecla que for digitada faça ir para o menu
            Console.ReadKey();
            Console.Clear();
            exibirOpcoesDoMenu();

        }


        /*void voosMaisPassageiros(){

        }


        void voosMenosPassageiros(){
            
        }

         void voosMaiorDistancia(){
            
        }

        void voosMenorDistancia(){
            
        }

        void ocupacaoMediaVoos(){
            
        }*/

    }


    static void CadastrarVoos()
    {
        Console.Clear();
        exibirTitulo("Cadastro de vôos");

        Console.Write("Digite o codigo do vôo:");
        string CodigoVoo = Console.ReadLine()!;
        Console.Write("Digite a distância do vôo:");
        string DistanciaVoo = Console.ReadLine()!;
        Console.Write("Digite a quantidades de assentos desse Vôo:");
        string assentosDoVoo = Console.ReadLine()!;



        AddVoo(new string[3] { CodigoVoo, DistanciaVoo, assentosDoVoo });

        Console.WriteLine($"O vôo de codigo {CodigoVoo} foi cadastrado com sucesso!");

        //Thread.Sleep(3000); //faz o carregamento de alguns segundos

        Console.Clear();
        exibirOpcoesDoMenu();

    }


    static void AdicionaPassageiro(string[] passageiro)
    {

        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] vetorListaDosPassageiros_aux = new string[quantidadePassageiro + 1, 2];

        for (int i = 0; i < quantidadePassageiro; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                vetorListaDosPassageiros_aux[i, j] = vetorListaDosPassageiros[i, j];
            }
        }
        for (int j = 0; j < 2; j++)
        {
            vetorListaDosPassageiros_aux[quantidadePassageiro, j] = passageiro[j];
        }
        vetorListaDosPassageiros = new string[quantidadePassageiro + 1, 2];
        quantidadePassageiro++;
        vetorListaDosPassageiros = vetorListaDosPassageiros_aux;
    }

    static string[] retornaPassageiro(int a)
    {
        string[] ret = new string[2];
        //retorna linha
        for (int j = 0; j < 2; j++)
        {
            ret[j] = vetorListaDosPassageiros[a, j];
        }
        return ret;
    }

    static void excluiPassageiro(int a)
    {
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição.
        string[,] vetorListaDosPassageiros_aux = new string[quantidadePassageiro - 1, 2];
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            if (i < a)
            {
                for (int j = 0; j < 2; j++)
                {
                    vetorListaDosPassageiros_aux[i, j] = vetorListaDosPassageiros[i, j];
                }
            }
            else if (i > a)
            {
                for (int j = 0; j < 2; j++)
                {
                    vetorListaDosPassageiros_aux[i - 1, j] = vetorListaDosPassageiros[i, j];
                }
            }
        }
        quantidadePassageiro--;
        vetorListaDosPassageiros = vetorListaDosPassageiros_aux;
    }

    static void exclusão()
    {
        Console.Clear();
        exibirTitulo("Excluir Passageiros");
        Console.Write("Digite o codigo do passageiro que deseja excluir:");
        string codPassageiro = Console.ReadLine()!;
        for (int i = 0; i < vetorListaDosPassageiros.Length; i++)
        {
            if (codPassageiro == vetorListaDosPassageiros[i, 0])
            {
                Console.Write("Passageiro excluido com sucesso!");
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                //faz com que qualquer tecla que for digitada faça ir para o menu
                Console.ReadKey();
                Console.Clear();
                exibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine($"\nNão existe passageiro com o {codPassageiro} informado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                exibirOpcoesDoMenu();
            }
        }
    }

    static void ListaDosPassageiros()
    {
        for (int i = 0; i < quantidadePassageiro; i++)
        {
            Console.WriteLine($"Código: {vetorListaDosPassageiros[i, 0]}");
            Console.WriteLine($"Nome: {vetorListaDosPassageiros[i, 1]}\n");
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
        int OpcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (OpcaoEscolhida)
        {
            case 1:
                verPassageiroEspecifico();
                break;
            case 2:
                verTodosOsPassageiros();
                break;
            case 0:
                Console.Clear();
                exibirOpcoesDoMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Você selecionou uma opção inválida. Por favor tente novamente.\n");
                Thread.Sleep(2500);
                verTodosPassageiros();
                break;
        }


        void verTodosOsPassageiros()
        {
            Console.Clear();
            exibirTitulo("Exibição de todos os passageiros registrados.");
            ListaDosPassageiros();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            //faz com que qualquer tecla que for digitada faça ir para o menu
            Console.ReadKey();
            Console.Clear();
            exibirOpcoesDoMenu();
        }

        void verPassageiroEspecifico()
        {
            Console.Clear();
            exibirTitulo("Exibição de passageiros registrados.");
            Console.Write("Digite o codigo do passageiro que deseja pesquisar:");
            string codPassageiro = Console.ReadLine()!;
            for (int i = 0; i < vetorListaDosPassageiros.Length; i++)
            {
                if (codPassageiro == vetorListaDosPassageiros[i, 0])
                {
                    Console.Write($"O passageiro do codigo {codPassageiro} é {vetorListaDosPassageiros[i, 1]}");

                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                    //faz com que qualquer tecla que for digitada faça ir para o menu
                    Console.ReadKey();
                    Console.Clear();
                    exibirOpcoesDoMenu();
                }
                else
                {
                    Console.WriteLine($"\nNão existe passageiro com o {codPassageiro} informado!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    exibirOpcoesDoMenu();
                }
            }
        }
    }

    static void CadastroDePassageiros()
    {
        Console.Clear();
        exibirTitulo("Cadastro De Passageiros");
        Console.Write("Digite o codigo do passageiro:");
        string codigoPassageiro = Console.ReadLine()!;
        Console.Write("Digite o nome do passageiro:");
        string nomePassageiro = Console.ReadLine()!.ToLower();
        AdicionaPassageiro(new string[2] { codigoPassageiro, nomePassageiro });
        Console.WriteLine($"O passageiro(a) {nomePassageiro} de codigo {codigoPassageiro} foi cadastrado com sucesso!");
        // Thread.Sleep(3500);
        Console.Clear();
        exibirOpcoesDoMenu();
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
        exibirMensagemBoasVindas();
        exibirOpcoesDoMenu();
    }
}