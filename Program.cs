var produtos = new Dictionary<string, Produto>();


void MenuInicial()
{
    Console.WriteLine("Bem-vindo ao controle de estoque de seus produtos!!");
    Console.WriteLine("1 - Cadastrar produto");
    Console.WriteLine("2 - Alterar preço");
    Console.WriteLine("3 - Adicionar estoque");
    Console.WriteLine("4 - Remover estoque");
    Console.WriteLine("5 - Listar produtos");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite a sua opção: ");
    int resposta = int.Parse(Console.ReadLine());

    switch (resposta)
    {
        case 1: CadastroDeProdutos();
            break;
        case 2: AlteracaoDePreco();
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break; 
        case 6:
            break;
    }
}

void CadastroDeProdutos()
{
    Thread.Sleep(2000);
    Console.Clear();

    Console.Write("Nome do produto: ");
    string nome = Console.ReadLine();
    Console.Write("Quantidade inicial em estoque: ");
    int estoque = int.Parse(Console.ReadLine());
    Produto novoProduto = new Produto(nome, estoque);
    produtos.Add(nome, novoProduto);

    limparConsole();
    MenuInicial();
}

void AlteracaoDePreco()
{
    Thread.Sleep(2000);  
    Console.Clear();

    Console.Write("Qual produto deseja alterar o preço? ");
    string nomeProduto = Console.ReadLine();
    //Verificar se tem no dictionary

    if (produtos.ContainsKey(nomeProduto))
    {
        Produto produtoAlterarPreco = produtos[nomeProduto];

        Console.Write("Novo preço: ");
        decimal novoPreco = decimal.Parse(Console.ReadLine());
         produtoAlterarPreco.AlterarPreco(novoPreco);
    }

    //se nao, nao encontrou
    else
    {
        Console.WriteLine("Produto não encontrado.");
    }

    limparConsole();
    MenuInicial();
}
void limparConsole()
{
    Console.WriteLine("Digite qualquer tecla para voltar ao menu inicial: ");
    Console.ReadKey();
    Thread.Sleep(2000);
    Console.Clear();
}
MenuInicial();