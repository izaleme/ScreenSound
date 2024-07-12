namespace ScreenSound.Models;

internal class Episodio
{
    #region Attributes/Properties

    private List<string> convidados = new();

    public int Ordem { get; }
    public string Titulo { get; }
    public int? Duracao { get; }
    public string Resumo => $"{Ordem}. {Titulo} ({Duracao} min) - {string.Join(", ", convidados)}";

    #endregion

    #region Builders

    public Episodio(int ordem, string titulo, int? duracao)
    {
        Titulo = titulo;
        Ordem = ordem;
        Duracao = duracao;
    }

    #endregion

    #region Methods

    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }

    #endregion
}
