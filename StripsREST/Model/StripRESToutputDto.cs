namespace StripsREST.Model;

public class StripRESToutputDto {
    public int? Nr { get; set; }
    public string Titel { get; set; }
    public string Url { get; set; }

    public StripRESToutputDto(int? nr, string titel, string url) {
        Nr = nr;
        Titel = titel;
        Url = url;
    }
}