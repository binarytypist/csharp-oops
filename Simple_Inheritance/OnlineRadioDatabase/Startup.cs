using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4_OnlineRadioDatabase
{
    class Startup
    {
        private static void Main(string[] args)
        {
            // Dummy input data simulates user-provided song entries
            List<string> inputData = new List<string>
            {
                "Coldplay;Yellow;4:30",
                "Adele;Hello;3:45",
                "Metallica;One;7:08",
                "InvalidSong;BadData;10:70",   // invalid seconds (will trigger exception)
                "LinkinPark;Numb;3:05"
            };

            // Collection to store successfully created songs
            List<Song> songs = new List<Song>();

            foreach (var input in inputData)
            {
                try
                {
                    // Split raw input into structured parts
                    var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    string artistName = tokens[0];
                    string songName = tokens[1];

                    List<long> timeTokens;

                    try
                    {
                        // Parse duration (minutes:seconds)
                        timeTokens = tokens[2]
                            .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToList();
                    }
                    catch
                    {
                        // Validation layer for format correctness
                        throw new ArgumentException("Invalid song length.");
                    }

                    long minutes = timeTokens[0];
                    long seconds = timeTokens[1];

                    // Object creation triggers validation inside Song class (encapsulation)
                    Song song = new Song(artistName, songName, minutes, seconds);

                    // Add valid song to playlist
                    songs.Add(song);

                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException ae)
                {
                    // Centralized error handling for domain validation rules
                    Console.WriteLine(ae.Message);
                }
            }

            // Summary: total number of successfully added songs
            Console.WriteLine($"Songs added: {songs.Count}");

            // Aggregation: calculate total playlist duration using LINQ
            TimeSpan totalTime = TimeSpan.FromSeconds(
                songs.Sum(s => s.SongLength.TotalSeconds)
            );

            // Output formatted playlist duration
            Console.WriteLine(
                $"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s"
            );
        }
    }
}