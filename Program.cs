using System.Threading;

var produtos = new Dictionary<string, Produto>();

void MostrarMenu()
{
    Console.Clear();

    Console.WriteLine("╔══════════════════════════════╗");
    Console.WriteLine("║       Stock Control          ║");
    Console.WriteLine("║   Sistema de Estoque v1.0    ║");
    Console.WriteLine("╠══════════════════════════════╣");
    Console.WriteLine("║ 1 - Cadastrar Produto        ║");
    Console.WriteLine("║ 2 - Alterar Preço            ║");
    Console.WriteLine("║ 3 - Adicionar Estoque        ║");
    Console.WriteLine("║ 4 - Remover Estoque          ║");
    Console.WriteLine("║ 5 - Listar Produtos          ║");
    Console.WriteLine("║ 0 - Sair                     ║");
    Console.WriteLine("╚══════════════════════════════╝");
    Console.Write("Escolha uma opção: ");
}
void MenuInicial()
{
    MostrarMenu();

    int.TryParse(Console.ReadLine(), out int resposta);

    switch (resposta)
    {
        case 1:
            CadastroDeProdutos();
            break;

        case 2:
            AlteracaoDePreco();
            break;

        case 3:
            AdicionarEstoque();
            break;

        case 4:
            RemoverEstoque();
            break;

        case 5:
            ListarProdutos();
            break;

        case 0:
            Console.WriteLine("Encerrando programa...");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            MensagemInicial();
            break;
    }
}

void CadastroDeProdutos()
{
    Thread.Sleep(1000);
    Console.Clear();

    Console.Write("Nome do produto: ");
    string nome = Console.ReadLine();

    if (produtos.ContainsKey(nome))
    {
        Console.WriteLine("Produto já existe no cadastro.");
        MensagemInicial();
    }
    else
    {
        Console.Write("Quantidade inicial em estoque: ");
        int.TryParse(Console.ReadLine(), out int estoque);

        Produto novoProduto = new Produto(nome, estoque);
        produtos.Add(nome, novoProduto);

        Console.WriteLine("Produto cadastrado com sucesso!!");
        MensagemInicial();
    }
}

void AlteracaoDePreco()
{
    Thread.Sleep(1000);  
    Console.Clear();

    Console.Write("Qual produto deseja alterar o preço? ");
    string nomeProduto = Console.ReadLine();

    if (produtos.ContainsKey(nomeProduto))
    {
        Produto produtoAlterarPreco = produtos[nomeProduto];

        Console.Write("Novo preço: ");

        if (decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
        {
            produtoAlterarPreco.AlterarPreco(novoPreco);
            Console.WriteLine("Preço alterado com sucesso!!");
        }
        else
        {
            Console.WriteLine("Preço inválido.");
        }
    }
    else
    {
        Console.WriteLine("Produto não encontrado.");
    }

    MensagemInicial();
}

void AdicionarEstoque()
{
    Console.Write("Produto: ");
    string verificarProduto = Console.ReadLine();

    if (produtos.ContainsKey(verificarProduto))
    {
        Produto produtoAdicionar = produtos[verificarProduto];
        Console.WriteLine("Quantidade: ");
        int.TryParse(Console.ReadLine(), out int qtd);
        produtoAdicionar.AdicionarEstoque(qtd);
    }
    else
    {
        Console.WriteLine("Produto não localizado. ");
    }
    MensagemInicial();
}

void RemoverEstoque()
{
    Console.Write("Produto: ");
    string verificarProduto = Console.ReadLine();

    if (produtos.ContainsKey(verificarProduto))
    {
        Produto produtoRemover = produtos[verificarProduto];

        Console.WriteLine("Quantidade: ");
        int.TryParse(Console.ReadLine(), out int qtd);

        produtoRemover.RemoverEstoque(qtd);
    }
    else
    {
        Console.WriteLine("Produto não localizado. ");
    }
    MensagemInicial();
}

void ListarProdutos()
{
    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
    }
    else
    {
        foreach (var produto in produtos)
        {
            produto.Value.ExibirInformacoes();
        }
    }
    MensagemInicial();
}
void MensagemInicial()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial: ");
    Console.ReadKey();
    Console.Clear();
    MenuInicial() ;
}
MenuInicial();