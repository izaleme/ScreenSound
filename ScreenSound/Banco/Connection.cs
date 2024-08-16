using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.Models;
using System.Diagnostics.Metrics;

namespace ScreenSound.Banco;

internal class Connection
{
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(connectionString);
    }

    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = ObterConexao();
        connection.Open();

        string sql = "select * from Artistas";
        SqlCommand sqlCommand = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = sqlCommand.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);

            Artista artist  = new Artista(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artist);
        }

        return lista;
    }
}
