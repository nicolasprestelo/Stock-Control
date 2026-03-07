
class Produto
{
     public Produto(string nome, int estoque)
    {
        Nome = nome;
        if (estoque >= 0)
        {
            Estoque = estoque;
        }
        else
        {
            Estoque = 0;
        }
    }

    public string Nome { get;}
    public int Estoque { get; private set; }

    public decimal Preco { get; private set; }

    public void AlterarPreco(decimal novoPreco)
    {
        if (novoPreco > 0)
        {
            Preco = novoPreco;
        }
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade > 0)
        {
            Estoque += quantidade;
        }
    }

    public void RemoverEstoque (int quantidade)
    {
        if (quantidade < 0) 
        {
            Console.WriteLine("Insira um número positivo para que haja a remoção do estoque.");
        }
        else if (quantidade > Estoque) 
        {
            Console.WriteLine($"Infelizmente só temos {Estoque} unidades em estoque.");
        }
        else if (quantidade > 0)
        {
            Estoque -= quantidade;      
        }
    }
    public void ExibirInformacoes() =>
    Console.WriteLine($" Nome do produto: {Nome}\n Preço: {Preco}R$\n Quantidade em Estoque: {Estoque}");
}