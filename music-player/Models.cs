public class Song
{
    public required string name;
    public required string artist;

    public required string duration;

    public int id;
}

public class Player
{
    public bool isPlaying = false;
    public Song? previousSong;
    public Song? nowPlaying;
    public bool isRandom;
    public int volume;

    public void playSong(List<Song> songs, int selectedSong)
    {
        if (nowPlaying?.id == songs[selectedSong].id)
            return;

        nowPlaying = songs[selectedSong];
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
        nowPlaying = songs[selectedSong - 1];
    }
}
