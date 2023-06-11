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
        Console.WriteLine("\nDigite 1 para cadastrar vôos.");
        Console.WriteLine("Digite 2 para cadastrar passageiros.");
        Console.WriteLine("Digite 3 para ver vôos.");
        Console.WriteLine("Digite 4 para ver passageiros."); 
        Console.WriteLine("Digite 5 para alterar um passageiro.");
        Console.WriteLine("Digite 6 para excluir passageiro.");
        Console.WriteLine("Digite 7 para alterar um vôo.");
        Console.WriteLine("Digite 8 para excluir vôo.");
        Console.WriteLine("Digite 0 para sair do menu.");
        int opcaoEscolhida = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("\nDigite sua opção:");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out opcaoEscolhida)){
                entradaValida = true;
            }else{
                Console.WriteLine("Opção inválida. Por favor, digite um número inteiro válido.");
            }
        }
        switch(opcaoEscolhida)
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
                Console.WriteLine("Você selecionou uma opção inválida. Por favor, tente novamente.");
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

        for(int i = 0; i < quantidadeVoo; i++){  // Procurar o vôo com base no código
            if(codVoo == listaVoos[i, 0]){
                indiceVoo = i;
                break;
            }
        }
        if(indiceVoo != -1){
            Console.WriteLine($"\nVoo encontrado! Código: {listaVoos[indiceVoo, 0]}, Distância: {listaVoos[indiceVoo, 1]} KM, Quantidade de assentos: {listaVoos[indiceVoo, 2]}\n");
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
        }else{
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
        for(int i = 0; i < quantidadeVoo; i++) // Percorre todos os voos no vetor listaVoos.
        {
            if(i != a) // Verifica se o índice atual é diferente do índice do voo a ser excluído.
            {
                for(int j = 0; j < 2; j++) // Copia as informações do voo para o vetor auxiliar, exceto o voo a ser excluído.
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
        for(int i = 0; i < quantidadeVoo; i++) // Percorre todos os voos no vetor listaVoos.
        {
            if(codVoo == listaVoos[i, 0]) // Verifica se o código do voo atual corresponde ao código informado pelo usuário.
            {
                indiceVoo = i;
                break;
            }
        }
        if(indiceVoo != -1) // Verifica se o voo foi encontrado com base no código informado.
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
        Console.WriteLine("\nDigite sua opção:");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch (opcaoEscolhida)
        {
            case 1:
                verVoos();
                break;
            case 2: //voosMaisPassageiros();
                voosMaisPassageiros();
                break;
            case 3: //voosMenosPassageiros();
                voosMenosPassageiros();
                break;
            case 4: //voosMaiorDistancia();
                voosMaiorDistancia();
                break;
            case 5: // voosMenorDistancia()
                voosMenorDistancia();
                break;
            case 6: //ocupacaoMediaVoos()
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

        void voosMaisPassageiros(){
            Console.Clear();
            exibirTitulo("Vôos com mais passageiros");
            // Encontra o número máximo de passageiros entre todos os voos
            int maxPassageiros = 0;
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos
            {
                int passageiros = int.Parse(listaVoos[i, 2]); // Obtém o número de passageiros do voo atual
                if (passageiros > maxPassageiros) // Verifica se o número de passageiros é maior que o máximo atual
                {
                    maxPassageiros = passageiros; // Atualiza o número máximo de passageiros
                }
            }
            // Exibe os voos com o número máximo de passageiros
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos novamente
            {
                int passageiros = int.Parse(listaVoos[i, 2]); // Obtém o número de passageiros do voo atual
                if (passageiros == maxPassageiros) // Verifica se o número de passageiros é igual ao máximo encontrado 
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}"); // Exibe o número do voo 
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km"); // Exibe a distância do voo 
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n"); // Exibe o número de passageiros do voo 
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal"); 
            Console.ReadKey(); // Aguarda o usuário pressionar uma tecla antes de continuar 
            Console.Clear(); // Limpa a tela do console 
            exibirOpcoes(); // Chama a função "exibirOpcoes()" para exibir o menu de opções novamente
            //Seguirá o mesmo padrão nos demais códigos
        }

        void voosMenosPassageiros(){ 
            Console.Clear(); 
            exibirTitulo("Vôos com menos passageiros"); 
            // Encontra o número mínimo de passageiros entre todos os voos 
            int minPassageiros = int.MaxValue; // Variável para armazenar o número mínimo de passageiros 
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos 
            {
                int passageiros = int.Parse(listaVoos[i, 2]); // Obtém o número de passageiros do voo atual 
                if (passageiros < minPassageiros) // Verifica se o número de passageiros é menor que o mínimo atual 
                {
                    minPassageiros = passageiros; // Atualiza o número mínimo de passageiros 
                }
            } 
            // Exibe os voos com o número mínimo de passageiros 
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos novamente 
            { 
                int passageiros = int.Parse(listaVoos[i, 2]); // Obtém o número de passageiros do voo atual 
                if (passageiros == minPassageiros) // Verifica se o número de passageiros é igual ao mínimo encontrado 
                { 
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}"); // Exibe o número do voo 
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km"); // Exibe a distância do voo 
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n"); // Exibe o número de passageiros do voo 
                } 
            } 
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal"); 
            Console.ReadKey();  
            Console.Clear(); 
            exibirOpcoes(); 
        }

        void voosMaiorDistancia(){ 
            Console.Clear(); 
            exibirTitulo("Vôos com maior distância");
            // Encontra a distância máxima entre os voos
            int maxDistancia = 0; // Variável para armazenar a distância máxima
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos 
            { 
                int distancia = int.Parse(listaVoos[i, 1]); // Obtem a distância do voo atual 
                if (distancia > maxDistancia) // Verifica se a distância é maior que a máxima atual 
                {
                    maxDistancia = distancia; // Atualiza a distância máxima 
                } 
            } 
            // Exibe os voos com a distância máxima 
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos novamente 
            { 
                int distancia = int.Parse(listaVoos[i, 1]); // Obtém a distância do voo atual 
                if (distancia == maxDistancia) // Verifica se a distância é igual à máxima encontrada 
                { 
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}"); // Exibe o número do voo 
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km"); // Exibe a distância do voo 
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n"); // Exibe o número de passageiros do voo 
                }
            } 
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal"); 
            Console.ReadKey(); 
            Console.Clear(); 
            exibirOpcoes(); 
        }

        void voosMenorDistancia(){ 
            Console.Clear(); 
            exibirTitulo("Vôos com menor distância"); 
            // Encontra a distância mínima entre todos os voos 
            int minDistancia = int.MaxValue; // Variável para armazenar a distância mínima 
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos 
            { 
                int distancia = int.Parse(listaVoos[i, 1]); // Obtém a distância do voo atual 
                if (distancia < minDistancia) // Verifica se a distância é menor que a mínima atual 
                { 
                    minDistancia = distancia; // Atualiza a distância mínima 
                } 
            } 
            // Exibe os voos com a distância mínima 
            for (int i = 0; i < quantidadeVoo; i++) // Loop para percorrer todos os voos novamente 
            {
                int distancia = int.Parse(listaVoos[i, 1]); // Obtém a distância do voo atual 
                if (distancia == minDistancia) // Verifica se a distância é igual à mínima encontrada 
                {
                    Console.WriteLine($"Vôo: {listaVoos[i, 0]}"); // Exibe o número do voo 
                    Console.WriteLine($"Distância: {listaVoos[i, 1]}km"); // Exibe a distância do voo
                    Console.WriteLine($"Passageiros: {listaVoos[i, 2]}\n"); // Exibe o número de passageiros do voo
                }
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }

        void ocupacaoMediaVoos(){
            Console.Clear();
            exibirTitulo("Ocupação média dos vôos");
            int totalPassageiros = 0; // Variável para armazenar o total de passageiros de todos os voos
            // Loop que percorre os voos e calcula o total de passageiros
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
        //criação de um vetor auxiliar para guardar as informações do outro vetor e fazer uma substituição em seguida com a adição de novas informações.
        string[,] listaPassageiros_aux = new string[quantidadePassageiro + 1, 2];
        for (int i = 0; i < quantidadePassageiro; i++){
            for (int j = 0; j < 2; j++){
                listaPassageiros_aux[i, j] = listaPassageiros[i, j];
            }
        }
        for (int j = 0; j < 2; j++){
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
        for (int j = 0; j < 2; j++){
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
        for(int i = 0; i < quantidadePassageiro; i++){
            if(codPassageiro == listaPassageiros[i, 0]){
                indicePassageiro = i;
                break;
            }
        }

    if(indicePassageiro != -1){
        Console.WriteLine($"\nPassageiro encontrado! Código: {listaPassageiros[indicePassageiro, 0]}, Nome: {listaPassageiros[indicePassageiro, 1]}\n");
        Console.Write("Digite o novo código do passageiro: ");
        string novoCodigo = Console.ReadLine()!;
        Console.Write("Digite o novo nome do passageiro: ");
        string novoNome = Console.ReadLine()!;
        listaPassageiros[indicePassageiro, 0] = novoCodigo;
        listaPassageiros[indicePassageiro, 1] = novoNome;
        Console.WriteLine("\nPassageiro alterado com sucesso!");
    }else{
        Console.WriteLine($"\nNão existe passageiro com o código {codPassageiro} informado!");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    exibirOpcoes();
}
    static void excluiPassageiro(int a){
        string[,] listaPassageiros_aux = new string[quantidadePassageiro - 1, 2];
        int indiceAuxiliar = 0;
        for(int i = 0; i < quantidadePassageiro; i++){
            if(i != a){
                for(int j = 0; j < 2; j++){
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
        for(int i = 0; i < quantidadePassageiro; i++){
            if(codPassageiro == listaPassageiros[i, 0]){
                indicePassageiro = i;
                break;
            }
        }
        if(indicePassageiro != -1){
            excluiPassageiro(indicePassageiro);
            Console.WriteLine("Passageiro excluído com sucesso!");
        }else{
            Console.WriteLine($"Não existe passageiro com o código {codPassageiro} informado!");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoes();
    }
    static void ListaDosPassageiros(){
        for(int i = 0; i < quantidadePassageiro; i++){
            Console.WriteLine($"Código: {listaPassageiros[i, 0]}");
            Console.WriteLine($"Nome: {listaPassageiros[i, 1]}\n");
        }
    }
    static void verTodosPassageiros(){
        Console.Clear();
        exibirTitulo("Ver Passageiros");
        Console.WriteLine("\nDigite 1 para ver um passageiro específico.");
        Console.WriteLine("Digite 2 para ver todos os passageiros desse vôo.");
        Console.WriteLine("Digite 0 para voltar ao menu principal.");
        Console.WriteLine("\nDigite sua opção:");
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
            if(quantidadePassageiro == 0){
                Console.WriteLine("Não há passageiros cadastrados.");
            }else{
                exibirTitulo("Exibição de todos os passageiros registrados.");
                ListaDosPassageiros();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            //faz com que qualquer tecla que for digitada faça ir para o menu
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }
        void verPassageiroEspecifico(){
            Console.Clear();
            if(quantidadePassageiro == 0){
                Console.WriteLine("Não há passageiros cadastrados.");
            }else{
                exibirTitulo("Exibição de passageiros registrados.");
                Console.Write("Digite o codigo do passageiro que deseja pesquisar:");
                string codPassageiro = Console.ReadLine()!;
                bool passageiroEncontrado = false;
                for(int i = 0; i < quantidadePassageiro; i++){
                    if(codPassageiro == listaPassageiros[i, 0]){
                        Console.WriteLine($"O passageiro do código {codPassageiro} é {listaPassageiros[i, 1]}");
                        passageiroEncontrado = true;
                        break;
                    }
                }
                if(!passageiroEncontrado){
                Console.WriteLine($"Não existe passageiro com o código {codPassageiro} informado!");
                }
            }
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoes();
        }
    }
    static void cadastroPassageiros(){
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

        static void exibirTitulo(string titulo){
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

        public static void Main(string[] args){
            exibirMensagem();
            exibirOpcoes();
        }
}
