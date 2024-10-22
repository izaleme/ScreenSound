using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenSound.Models;

public class Musica
{
    #region Attributes/Properties

    private int? anoLancamento;

    [Key]
    public int Id { get; set; }
    public string Nome { get; }
    public Artista Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    [Obsolete("Use o método ExibirFichaTecnica() para obter informações sobre a música.")]
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";

    public int? AnoLancamento
    {
        get => anoLancamento;
        set => anoLancamento = value <= 0 ? (int?)null : value;
    }

    public List<Genero> Generos { get; set; }

    #endregion

    #region Builders

    public Musica() { }

    public Musica(string nome) => Nome = nome;

    public Musica(Artista artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

    #endregion

    #region Methods

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");

        if (AnoLancamento != null)
        {
            Console.WriteLine($"Ano de Lançamento: {AnoLancamento}");
        }

        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }

    #endregion
}