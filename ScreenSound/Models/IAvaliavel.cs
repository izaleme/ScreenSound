namespace ScreenSound.Models;

internal interface IAvaliavel
{
    // Interface não é um código executável, mas uma assinatura

    void AdicionarNota(Avaliacao nota);
    double Media { get; }
}
