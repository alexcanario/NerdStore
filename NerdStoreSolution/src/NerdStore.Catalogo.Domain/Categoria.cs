using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain;

public class Categoria(int codigo, string? nome) : Entity
{
    public int Codigo { get; private set; } = codigo;
    public string? Nome { get; private set; } = nome;

    public override string ToString()
    {
        return $"{Nome} - {Codigo}";
    }
}