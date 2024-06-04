namespace ScreenSound.Models;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
         Nota = nota;
    }

    public int Nota { get; }

    public static Avaliacao Parse(string texto) // Static para não precisar ficar usando new Avaliacao()
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}
