using ScreenSound.Models;

namespace ScreenSound.Banco;

internal class ArtistaDAL : DAL<Artista>
{
    public ArtistaDAL(ScreenSoundContext context) : base(context) { }

}