using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Models;

public class MusicaGenero
{
    public int MusicaId { get; set; }
    public Musica Musica { get; set; }

    public int GeneroId { get; set; }
    public Genero Genero { get; set; }
}