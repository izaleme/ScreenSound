namespace ScreenSound.Models;

internal class Podcast
{
    #region Attributes/Properties
    
    private List<Episodio> episodios = new();

    public string Host { get; }
    public string Nome { get; }
    public int TotalEpisodios => episodios.Count;

    public List<Episodio> Episodio => episodios;

    #endregion

    #region Builders

    public Podcast(string strNome, string strHost)
    {
        Nome = strNome;
        Host = strHost;
    }

    #endregion

    #region Methods

    public void AdicionarEpisodio(Episodio episodio)
    {
        episodios.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast {Nome} apresentado por {Host}");
        Console.WriteLine($"Total de episódios: {TotalEpisodios}");
        if (episodios.Count > 0)
        {
            Console.WriteLine($"Lista de episódios:");
            foreach (Episodio episodio in episodios.OrderBy(e => e.Ordem))
            {
                Console.WriteLine(episodio.Resumo);
            }
        }
        Console.WriteLine();
    }

    #endregion
}
