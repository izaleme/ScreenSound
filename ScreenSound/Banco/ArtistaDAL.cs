using Microsoft.Data.SqlClient;
using ScreenSound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "select * from Artistas";
        SqlCommand sqlCommand = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = sqlCommand.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = dataReader["Nome"]?.ToString() ?? string.Empty; // Se for nulo, atribui à string vazia
            string bioArtista = dataReader["Bio"]?.ToString() ?? string.Empty;
            int idArtista = dataReader["Id"] != null ? Convert.ToInt32(dataReader["Id"]) : 0;

            Artista artist = new Artista(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artist);
        }

        return lista;
    }

    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "insert into Artistas (Nome, FotoPerfil, Bio) values (@nome, @perfilPadrao, @bio)";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public void Atualizar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = $"update Artistas set Nome = @nome, Bio = @bio where Id = @id";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        //command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public void Deletar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = $"delete from Artistas where Id = @id";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }
}
