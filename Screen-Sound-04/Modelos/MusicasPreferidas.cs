using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Screen_Sound_04.Modelos
{
    class MusicasPreferidas
    {
        public string Nome { get; set; }
        public List<Musica> ListaDeMusicasFavoritas { get; }

        public MusicasPreferidas(string nome)
        {
            Nome = nome;
            ListaDeMusicasFavoritas = new List<Musica>();
        }

        public void AdicionarMusicasFavoritas(Musica musica)
        {
            ListaDeMusicasFavoritas.Add(musica);
        }

        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine($"Essas são as musicas favoritas -> {Nome}");
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
            }
        }

        public void GerarArquivoJson()
        {
            // Para gerar um arquivo Json é preciso o nome do arquivo e a Serialização Json
            var json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = ListaDeMusicasFavoritas
            });

            string nomeDoArquivo = $"musicas-favoritas-{Nome}.Json";

            // Aqui onde ele escreve todo texto em Json
            File.WriteAllText(nomeDoArquivo, json);

            //Localizar o arquivo Json
            Console.WriteLine($"O arquivo Json foi gerado com sucesso! " +
                $"{Path.GetFullPath(nomeDoArquivo)}");
        }

        public void GerarDocumentoTXTComAsMusicasFavoritas()
        {
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.text";
            using (StreamWriter arquivo = new StreamWriter(nomeDoArquivo))
            {
                arquivo.WriteLine($"Musicas favoritas do {Nome}\n");
                foreach (var musica in ListaDeMusicasFavoritas)
                {
                    arquivo.WriteLine($"- {musica.Nome}");
                }

                arquivo.Close();
            }

            Console.WriteLine("txt gerado com sucesso!");
        }
    }
}
