public class MusicPlayer
{
    public int uid = 1;

    public Player player = new Player();
    public List<Song> songs = [];
    public List<string> mainMenu = ["Music List", "Edit List", "Turn off"];
    public List<string> playerMenu =
    [
        "b: \u23EE",
        "p: \u25B6/\u23F8",
        "n: \u23ED",
        "r: \u1F504",
        "esc: \u21A9"
    ];

    public string arrowUp = "\u2191";
    public string arrowDown = "\u2193";
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

        var index = 0;

        ConsoleKey key;
        do
        {
            Console.Clear();
            DisplayMenu(index);
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    index = (index + 1) % mainMenu.Count;
                    break;
                case ConsoleKey.UpArrow:
                    index = (index - 1 + mainMenu.Count) % mainMenu.Count;
                    break;
                case ConsoleKey.Enter:
                    Controller(index);
                    break;
            }
        } while (key != ConsoleKey.Escape);

        Console.CursorVisible = true;
        Console.Clear();
    }

    void Controller(int index)
    {
        switch (index)
        {
            case 0:
                SongList();
                break;
            case 1:
                EditSongList();
                break;
            case 2:
                return;
        }
    }

    public void DisplaySongs(int selectedSong)
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("You list is empty. Try adding some songs!");
            return;
        }

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
                $"{song.name} - {song.artist} ({song.duration}) {(player.nowPlaying?.id == song.id ? $"{musicNote}  " : "")}"
            );
        }
        Console.ResetColor();
    }

    void DisplayMenu(int selected)
    {
        System.Console.WriteLine("\n");
        for (int i = 0; i < mainMenu.Count; i++)
        {
            if (i == selected)
            {
                System.Console.BackgroundColor = ConsoleColor.White;
                System.Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                System.Console.ResetColor();
            }

            System.Console.WriteLine($"{mainMenu[i]}");
        }
        Console.ResetColor();
    }

    public void SongList()
    {
        var selectedSong = 0;

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

    public void MainMenu()
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

    void EditSongList()
    {
        var index = 0;
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine("Edit songs: \n");

            DisplaySongs(index);
            Console.Write($"\nSelect: {arrowUp}/{arrowDown}  Add: A  Delete: D  Go back: Esc/B");

            key = Console.ReadKey().Key;

            if (
                songs.Count == 0
                && (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.D)
            )
            {
                key = ConsoleKey.None;
            }
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    index = (index + 1) % songs.Count;
                    break;
                case ConsoleKey.UpArrow:
                    index = (index - 1 + songs.Count) % songs.Count;
                    break;
                case ConsoleKey.D:
                    DeleteSong(index);
                    break;
                case ConsoleKey.A:
                    AddSong();
                    break;
                // case ConsoleKey.Enter:
                //     player.playSong(songs, index);
                //     break;
            }
        } while (key != ConsoleKey.Escape);
    }

    void AddSong()
    {
        Console.Clear();
        Console.WriteLine("Add new song: \n");
        Console.CursorVisible = true;
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(name))
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Name can not be empty, want to try again? \n");
                Console.WriteLine(@"Y: Yes   N: No");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        AddSong();
                        break;
                }
            } while (key != ConsoleKey.N);
            Console.CursorVisible = false;
        }

        Console.Write("Artist: ");
        string artist = Console.ReadLine() ?? "";
        Console.Write("Duration: ");
        string duration = Console.ReadLine() ?? "";
        songs.Add(
            new Song
            {
                name = name,
                artist = artist,
                duration = duration,
                id = GenerateId()
            }
        );
        Console.CursorVisible = false;
        return;
    }

    void DeleteSong(int index)
    {
        var song = songs[index];
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine($"Are you sure you wan't to delete {song.name} by {song.artist}? \n");
            Console.WriteLine("Y: Yes   N: No");
            Console.Write(index);

            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                songs.Remove(song);
                Console.WriteLine($"{song.name} has been deleted");
                return;
            }
        } while (key != ConsoleKey.N);
    }

    public int GenerateId()
    {
        return uid++;
    }
}
