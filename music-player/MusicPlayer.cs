using System;

public class MusicPlayer
{
    public int uid = 1;

    public Player player = new Player();
    public List<Song> songs = [];
    public List<string> mainMenuOptions = ["Music List", "Edit List", "Exit"];
    public List<string> playerOptions =
    [
        "b: \u23EE",
        "p: \u25B6/\u23F8",
        "n: \u23ED",
        "r: \u1F504",
        "esc: \u21A9"
    ];

    public string playButton = "\u25B6";
    public string musicNote = "\u266A";
    public string pauseButton = "\u23F8";

    public MusicPlayer()
    {
        songs.Add(
            new Song
            {
                name = "Blinding Lights",
                artist = "The Weeknd",
                duration = "3:20",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Levitating",
                artist = "Dua Lipa",
                duration = "3:23",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Peaches",
                artist = "Justin Bieber",
                duration = "3:18",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Save Your Tears",
                artist = "The Weeknd",
                duration = "3:35",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Good 4 U",
                artist = "Olivia Rodrigo",
                duration = "2:58",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Solo un Eco",
                artist = "Cultura Profetica",
                duration = "4:45",
                id = GenerateId()
            }
        );
    }

    public void Init()
    {
        Console.CursorVisible = false;
        SongList();
    }

    public void DisplaySongs(int selectedSong)
    {
        Console.WriteLine("Songs: \n");
        for (int i = 0; i < songs.Count; i++)
        {
            if (i == selectedSong)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ResetColor();
            }

            Song song = songs[i];
            Console.WriteLine(
                $"{song.name} - {song.artist} ({song.duration}) {(player.nowPlaying?.id == song.id ? $"{musicNote}\t" : "")}"
            );
        }
        Console.ResetColor();
    }

    void DisplayMenu(List<string> options)
    {
        System.Console.WriteLine("\n");
        for (int i = 0; i < options.Count; i++)
        {
            System.Console.Write($"{options[i]}\t");
        }
    }

    public void SongList()
    {
        int selectedSong = 0;

        ConsoleKey key;
        do
        {
            Console.Clear();
            DisplaySongs(selectedSong);
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    selectedSong = (selectedSong + 1) % songs.Count;
                    break;
                case ConsoleKey.UpArrow:
                    selectedSong = (selectedSong - 1 + songs.Count) % songs.Count;
                    break;
                case ConsoleKey.N:
                    player.playNextSong(songs, selectedSong);
                    break;
                case ConsoleKey.B:
                    player.playPreviousSong(songs, selectedSong);
                    break;
                case ConsoleKey.P:
                    player.isPlaying = !player.isPlaying;
                    break;
                case ConsoleKey.R:
                    player.playRandomSong(songs, selectedSong);
                    break;
                case ConsoleKey.Enter:
                    player.playSong(songs, selectedSong);
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }

    public int GenerateId()
    {
        return uid++;
    }
}
