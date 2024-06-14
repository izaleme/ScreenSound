using ScreenSound.Models;

namespace ScreenSound.Test
{
    public class MusicaTest
    {
        [Fact]
        public void TesteNomeInicializouCorretamente()
        {
            // Arrange
            string nomeMsc = "New song test name";
            Banda banda = new Banda("Wallows");

            // Act
            Musica musica = new Musica(banda, nomeMsc);

            // Assert
            Assert.Equal(nomeMsc, musica.Nome);
        }

    }
}