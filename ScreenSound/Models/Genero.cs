using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Models;

public class Genero
{
    [Key]
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    // Fazer aqui uma relação com o Chat GPT para trazer a descrição do gênero automaticamente ao cadastrar.
}
