public class MusicPlayer
{
    public int uid = 1;

    public Player player = new Player();
    public List<Song> songs = [];
    public List<string> mainMenu = ["Music List", "Edit List"];
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
        songs.Add(
            new Song
            {
                name = "Shape of You",
                artist = "Ed Sheeran",
                duration = "3:53",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Rolling in the Deep",
                artist = "Adele",
                duration = "3:48",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Uptown Funk",
                artist = "Mark Ronson ft. Bruno Mars",
                duration = "4:30",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Happy",
                artist = "Pharrell Williams",
                duration = "3:53",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Bad Guy",
                artist = "Billie Eilish",
                duration = "3:14",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Someone Like You",
                artist = "Adele",
                duration = "4:45",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Thinking Out Loud",
                artist = "Ed Sheeran",
                duration = "4:41",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Old Town Road",
                artist = "Lil Nas X ft. Billy Ray Cyrus",
                duration = "2:37",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Roar",
                artist = "Katy Perry",
                duration = "3:42",
                id = GenerateId()
            }
        );
        songs.Add(
            new Song
            {
                name = "Can't Stop the Feeling!",
                artist = "Justin Timberlake",
                duration = "3:56",
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
            Console.WriteLine("~* Music Player ~*");
            DisplayMenu(index);
            Console.Write("\nMove: ↑/↓   Select: Enter   Exit: Esc");
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
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
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
            Console.Write("\nMove: ↑/↓  Play Song: Enter  Go Back: Esc");
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    selectedSong = (selectedSong + 1) % songs.Count;
                    break;
                case ConsoleKey.UpArrow:
                    selectedSong = (selectedSong - 1 + songs.Count) % songs.Count;
                    break;
                case ConsoleKey.Enter:
                    player.playSong(songs[selectedSong]);
                    NowPlaying();
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
            Console.Write(
                $"\nSelect: {arrowUp}/{arrowDown}  Add: A  Edit: E  Delete: D  Go back: Esc"
            );

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
                case ConsoleKey.E:
                    EditSong(index);
                    break;
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

    void EditSong(int index)
    {
        string newName = "";
        string newArtist = "";
        string newDuration = "";
        var song = songs[index];

        Console.Clear();
        Console.WriteLine("Edit song: \n");
        Console.CursorVisible = true;
        Console.Write($"Name: {song.name} => ");
        newName = Console.ReadLine() ?? "";
        Console.Write($"Artist: {song.artist} => ");
        newArtist = Console.ReadLine() ?? "";
        Console.Write($"Duration: {song.duration} => ");
        newDuration = Console.ReadLine() ?? "";

        if (
            !string.IsNullOrEmpty(newName)
            && !string.IsNullOrEmpty(newArtist)
            && !string.IsNullOrEmpty(newDuration)
        )
        {
            song.name = newName;
            song.artist = newArtist;
            song.duration = newDuration;
            Console.CursorVisible = false;

            return;
        }
        Console.CursorVisible = false;
        Console.Write("\nName, Artist or Duration can not be empty, want to try again? \n");
        Console.WriteLine("\nY: Yes   N: No");
        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    EditSong(index);
                    break;
            }
        } while (key != ConsoleKey.N);
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
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                songs.Remove(song);
                if (player.nowPlaying?.id == song.id)
                {
                    player.isPlaying = false;
                    player.playNextSong(songs, index + 1);
                }
                Console.WriteLine($"{song.name} has been deleted");
                return;
            }
        } while (key != ConsoleKey.N);
    }

    void NowPlaying()
    {
        ConsoleKey key;
        do
        {
            var volumeIncon = player.volume > 0 ? "🔈" : "🔇";
            if (player.volume > 50)
                volumeIncon = "🔊";
            var playMode = player.isRandom ? "🔀" : "🔤";
            var isPlaying = player.isPlaying ? "⏸️" : "▶️";

            Console.Clear();
            Console.WriteLine(
                $@"Now playing: {player.nowPlaying?.name} - {player.nowPlaying?.artist}            {player.nowPlaying?.duration}"
            );

            Console.Write($"\n{playMode}  {isPlaying}\n");
            Console.Write($"\n{volumeIncon}  {player.volume}%\n");
            Console.Write(
                $"\nRandomize/Loop: R   Previous: ←  Play/Pause: P  Next: →  Volume: ↑/↓  Go back: Esc\n"
            );
            var song = player.nowPlaying;
            var index = songs.IndexOf(song!);
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    player.playPreviousSong(songs, index);
                    break;
                case ConsoleKey.RightArrow:
                    if (player.isRandom)
                    {
                        player.playRandomSong(songs, index);
                        break;
                    }
                    player.playNextSong(songs, index);
                    break;
                case ConsoleKey.R:
                    player.isRandom = !player.isRandom;
                    break;
                case ConsoleKey.P:
                    player.isPlaying = !player.isPlaying;
                    break;
                case ConsoleKey.UpArrow:
                    player.volumeUp();
                    break;
                case ConsoleKey.DownArrow:
                    player.volumeDown();
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }

    public int GenerateId()
    {
        return uid++;
    }
}
