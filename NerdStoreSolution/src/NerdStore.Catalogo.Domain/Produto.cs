using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain;

public class Produto(string? nome, string? descricao, bool ativo, decimal valor, Guid CategoriaId, string? imagem) : Entity, IAggregateRoot
{
    public string? Nome { get; private set; } = nome;
    public string? Descricao { get; private set; } = descricao;
    public bool Ativo { get; private set; } = ativo;
    public decimal Valor { get; private set; } = valor;
    public DateTime DataCadastro { get; private set; } = DateTime.Now;
    public string? Imagem { get; private set; } = imagem;
    public int QuantidadeEstoque { get; private set; } = 0;

    public Guid CategoriaId { get; private set; }
    public Categoria? Categoria { get; private set; }

    public void Ativar() => Ativo = true;
    public void Desativar() => Ativo = false;

    public void AlterarCategoria(Categoria? categoria)
    {
        if (categoria is null) return;

        Categoria = categoria;
        CategoriaId = categoria.Id;
    } 

    public void AlterarDescricao(string? descricao)
    {
        Descricao = descricao;
    }

    public void DebitarEstoque(int quantidade)
    {
        if(quantidade == 0) return;

        if (quantidade < 0) quantidade *= -1;
        QuantidadeEstoque -= quantidade;
    }

    public void ReporEstoque(int quantidade)
    {
        if (quantidade == 0) return;

        QuantidadeEstoque += quantidade;
    }

    public bool PossuiEstoque(int quantidade)
    {
        return (QuantidadeEstoque > quantidade);
    }

    public void Validar()
    {

    }
}