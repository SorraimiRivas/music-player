public class Song
{
    public required string name;
    public required string artist;

    public required string duration;

    public int id;
}

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

    public void playRandomSong(List<Song> songs, int selectedSong)
    {
        previousSong = nowPlaying;
        nowPlaying = songs[Random.Shared.Next(0, songs.Count)];
    }

    public void playNextSong(List<Song> songs, int selectedSong)
    {
        previousSong = nowPlaying;
        nowPlaying = songs[(selectedSong + 1) % songs.Count];
    }

    public void playPreviousSong(List<Song> songs, int selectedSong)
    {
        nowPlaying = songs[(selectedSong - 1 + songs.Count) % songs.Count];
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
