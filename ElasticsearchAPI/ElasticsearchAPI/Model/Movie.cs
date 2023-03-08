namespace ElasticsearchAPI.Model;

public record Movie
{
    public Movie(string posterLink, string seriesTitle, string releasedYear, string certificate, string runtime, string genre, string imdbRating, string overview, string metaScore, string director, string star1, string star2, string star3, string star4, string noOfVotes, string gross)
    {
        Poster_Link = posterLink;
        Series_Title = seriesTitle;
        Released_Year = releasedYear;
        Certificate = certificate;
        Runtime = runtime;
        Genre = genre;
        IMDB_Rating = imdbRating;
        Overview = overview;
        Meta_score = metaScore;
        Director = director;
        Star1 = star1;
        Star2 = star2;
        Star3 = star3;
        Star4 = star4;
        No_of_Votes = noOfVotes;
        Gross = gross;
    }
    public string Poster_Link { get; set; }
    public string Series_Title { get; set; }
    public string Released_Year { get; set; }
    public string Certificate { get; set; }
    public string Runtime { get; set; }
    public string Genre { get; set; }
    public string IMDB_Rating { get; set; }
    public string Overview { get; set; }
    public string Meta_score { get; set; }
    public string Director { get; set; }
    public string Star1 { get; set; }
    public string Star2 { get; set; }
    public string Star3 { get; set; }
    public string Star4 { get; set; }
    public string No_of_Votes { get; set; }
    public string Gross { get; set; }
}