using Screen_Sound_04.Filtros;
using Screen_Sound_04.Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

using (HttpClient httpClient = new HttpClient())
{
    try
    {
        string resposta = await httpClient.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        //musicas[1].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

        //var musicasPreferidasDoDaniel = new MusicasPreferidas("Daniel");
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[150]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[66]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[666]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[89]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[134]);

        //musicasPreferidasDoDaniel.ExibirMusicasFavoritas();
        //Console.WriteLine();

        LinqFilter.FiltrarTonalidade(musicas, "C#");

        //musicasPreferidasDoDaniel.GerarArquivoJson();
        //musicasPreferidasDoDaniel.GerarDocumentoTXTComAsMusicasFavoritas();
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}


