namespace StripsREST.Model;

public class ReeksOutputDto {
    public ReeksOutputDto(string naam, string id,int nr, List<StripRESToutputDto> strips) {
        ID = id;
        NR = nr;
        Naam = naam;
        Strips = strips;
    }

    public int? NR { get; set; }
    public string ID { get; set; }
    public string Naam { get; set; }
    public List<StripRESToutputDto> Strips { get; set; } = new List<StripRESToutputDto>();
}