public class MusicPlayer
{
    private int Id = 1;
    private Player Player = new Player();
    private List<Song> Songs = [];
    private List<string> MainMenu = ["Music List", "Edit List"];
    private string ArrowUp = "\u2191";
    private string ArrowDown = "\u2193";
    private string MusicNote = "\u266A";

    public MusicPlayer()
    {
        Songs.Add(
            new Song
            {
                name = "Blinding Lights",
                artist = "The Weeknd",
                duration = "3:20",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Levitating",
                artist = "Dua Lipa",
                duration = "3:23",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Peaches",
                artist = "Justin Bieber",
                duration = "3:18",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Save Your Tears",
                artist = "The Weeknd",
                duration = "3:35",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Good 4 U",
                artist = "Olivia Rodrigo",
                duration = "2:58",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Solo un Eco",
                artist = "Cultura Profetica",
                duration = "4:45",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Shape of You",
                artist = "Ed Sheeran",
                duration = "3:53",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Rolling in the Deep",
                artist = "Adele",
                duration = "3:48",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Uptown Funk",
                artist = "Mark Ronson ft. Bruno Mars",
                duration = "4:30",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Happy",
                artist = "Pharrell Williams",
                duration = "3:53",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Bad Guy",
                artist = "Billie Eilish",
                duration = "3:14",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Someone Like You",
                artist = "Adele",
                duration = "4:45",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Thinking Out Loud",
                artist = "Ed Sheeran",
                duration = "4:41",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Old Town Road",
                artist = "Lil Nas X ft. Billy Ray Cyrus",
                duration = "2:37",
                id = GenerateId()
            }
        );
        Songs.Add(
            new Song
            {
                name = "Roar",
                artist = "Katy Perry",
                duration = "3:42",
                id = GenerateId()
            }
        );
        Songs.Add(
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
                    index = (index + 1) % MainMenu.Count;
                    break;
                case ConsoleKey.UpArrow:
                    index = (index - 1 + MainMenu.Count) % MainMenu.Count;
                    break;
                case ConsoleKey.Enter:
                    Controller(index);
                    break;
            }
        } while (key != ConsoleKey.Escape);

        Console.CursorVisible = true;
        Console.Clear();
    }

    private void Controller(int index)
    {
        switch (index)
        {
            case 0:
                ShowSongList();
                break;
            case 1:
                EditSongList();
                break;
            case 2:
                return;
        }
    }

    private void DisplaySongs(int index)
    {
        if (Songs.Count == 0)
        {
            Console.WriteLine("You list is empty. Try adding some Songs!");
            return;
        }

        for (int i = 0; i < Songs.Count; i++)
        {
            if (i == index)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ResetColor();
            }

            Song song = Songs[i];
            Console.WriteLine(
                $"{song.name} - {song.artist} ({song.duration}) {(Player.nowPlaying?.id == song.id ? $"{MusicNote}  " : string.Empty)}"
            );
        }
        Console.ResetColor();
    }

    private void DisplayMenu(int selected)
    {
        System.Console.WriteLine("\n");
        for (int i = 0; i < MainMenu.Count; i++)
        {
            if (i == selected)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                System.Console.ResetColor();
            }

            System.Console.WriteLine($"{MainMenu[i]}");
        }
        Console.ResetColor();
    }

    private void ShowSongList()
    {
        var index = 0;

        ConsoleKey key;
        do
        {
            Console.Clear();
            DisplaySongs(index);
            Console.Write("\nMove: ↑/↓  Play Song: Enter  Go Back: Esc");
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    index = (index + 1) % Songs.Count;
                    break;
                case ConsoleKey.UpArrow:
                    index = (index - 1 + Songs.Count) % Songs.Count;
                    break;
                case ConsoleKey.Enter:
                    Player.playSong(Songs[index]);
                    NowPlaying();
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }

    private void EditSongList()
    {
        var index = 0;
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine("Edit Songs: \n");

            DisplaySongs(index);
            Console.Write(
                $"\nSelect: {ArrowUp}/{ArrowDown}  Add: A  Edit: E  Delete: D  Go back: Esc"
            );

            key = Console.ReadKey().Key;

            if (
                Songs.Count == 0
                && (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.D)
            )
            {
                key = ConsoleKey.None;
            }
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    index = (index + 1) % Songs.Count;
                    break;
                case ConsoleKey.UpArrow:
                    index = (index - 1 + Songs.Count) % Songs.Count;
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

    private void AddSong()
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
        Songs.Add(
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

    private void EditSong(int index)
    {
        string newName = "";
        string newArtist = "";
        string newDuration = "";
        var song = Songs[index];

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

    private void DeleteSong(int index)
    {
        var song = Songs[index];
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine($"Are you sure you wan't to delete {song.name} by {song.artist}? \n");
            Console.WriteLine("Y: Yes   N: No");
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                Songs.Remove(song);
                if (Player.nowPlaying?.id == song.id)
                {
                    Player.isPlaying = false;
                    Player.playNextSong(Songs, index + 1);
                }
                Console.WriteLine($"{song.name} has been deleted");
                return;
            }
        } while (key != ConsoleKey.N);
    }

    private void NowPlaying()
    {
        ConsoleKey key;
        do
        {
            var volumeIncon = Player.volume > 0 ? "🔈" : "🔇";
            if (Player.volume > 50)
                volumeIncon = "🔊";
            var playMode = Player.isRandom ? "🔀" : "🔤";
            var isPlaying = Player.isPlaying ? "⏸️" : "▶️";

            Console.Clear();
            Console.WriteLine(
                $@"Now playing: {Player.nowPlaying?.name} - {Player.nowPlaying?.artist}            {Player.nowPlaying?.duration}"
            );

            Console.Write($"\n{playMode}  {isPlaying}\n");
            Console.Write($"\n{volumeIncon}  {Player.volume}%\n");
            Console.Write(
                $"\nRandomize/Loop: R   Previous: ←  Play/Pause: P  Next: →  Volume: ↑/↓  Go back: Esc\n"
            );
            var song = Player.nowPlaying;
            var index = Songs.IndexOf(song!);
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    Player.playPreviousSong(Songs, index);
                    break;
                case ConsoleKey.RightArrow:
                    if (Player.isRandom)
                    {
                        Player.playRandomSong(Songs, index);
                        break;
                    }
                    Player.playNextSong(Songs, index);
                    break;
                case ConsoleKey.R:
                    Player.isRandom = !Player.isRandom;
                    break;
                case ConsoleKey.P:
                    Player.isPlaying = !Player.isPlaying;
                    break;
                case ConsoleKey.UpArrow:
                    Player.volumeUp();
                    break;
                case ConsoleKey.DownArrow:
                    Player.volumeDown();
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }

    private int GenerateId()
    {
        return Id++;
    }
}
