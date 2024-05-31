public class Song
{
    public string name { set; get; } = string.Empty;
    public string artist { set; get; } = string.Empty;
    public string duration { set; get; } = string.Empty;
    public int id { set; get; }
}

//TODO: Move to its own file
public class Player
{
    public bool isRandom = false;
    public bool isPlaying = false;
    public Song? previousSong;
    public Song? nowPlaying;
    public int volume = 50;

    public void playSong(Song song)
    {
        if (nowPlaying?.id == song.id)
            return;

        nowPlaying = song;
        isPlaying = true;
    }

    public void playRandomSong(List<Song> Songs, int selectedSong)
    {
        previousSong = nowPlaying;
        nowPlaying = Songs[Random.Shared.Next(0, Songs.Count)];
    }

    public void playNextSong(List<Song> Songs, int selectedSong)
    {
        previousSong = nowPlaying;
        nowPlaying = Songs[(selectedSong + 1) % Songs.Count];
    }

    public void playPreviousSong(List<Song> Songs, int selectedSong)
    {
        nowPlaying = Songs[(selectedSong - 1 + Songs.Count) % Songs.Count];
    }

    public void volumeUp()
    {
        if (volume >= 100)
        {
            return;
        }
        volume += 5;
    }

    public void volumeDown()
    {
        if (volume <= 0)
        {
            return;
        }
        volume -= 5;
    }
}
