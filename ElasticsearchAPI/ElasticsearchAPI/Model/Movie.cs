namespace ElasticsearchAPI.Model;

public class Movie
{
    public string PosterLink { get; set; }
    public string SeriesTitle { get; set; }
    public int ReleaseYear { get; set; }
    public string Certificate { get; set; }
    public string Runtime { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public string Overview { get; set; }
    public ushort MetaScore { get; set; }
    public string Director { get; set; }
    public string Star1 { get; set; }
    public string Star2 { get; set; }
    public string Star3 { get; set; }
    public string Star4 { get; set; }
    public ulong NumberOfVotes { get; set; }
    public string Gross { get; set; }
}