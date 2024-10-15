using Screen_Sound_04.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Screen_Sound_04.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
        {
            var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();
            foreach (var genero in todosOsGenerosMusicais)
            {
                Console.WriteLine($"- {genero}");
            }
        }

        public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
        {
            var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
            Console.WriteLine($"Exibindo os artistas por gênero musical >>> {genero}");
            foreach (var artista in artistasPorGeneroMusical)
            {
                Console.WriteLine($"- {artista}");
            }
        }

        public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
        {
            var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
            Console.WriteLine(nomeDoArtista);
            foreach (var musica in musicasDoArtista)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }        

        internal static void FiltrarTonalidade(List<Musica> musicas, string tonalidade)
        {
            var musicaTonalidade = musicas
                .Where(musica => musica.Tonalidade.Equals(tonalidade))
                .Select(musica => musica.Nome)
                .ToList();

            if(musicaTonalidade.Count == 0)
            {
                Console.WriteLine("Não existe musicas com essa tonalidade");

            }
            else
            {
                Console.WriteLine($"Musicas em {tonalidade}");
                foreach(var musica in musicaTonalidade)
                {
                    Console.WriteLine($"- {musica}");
                }
            }
            
        }
    }
}
