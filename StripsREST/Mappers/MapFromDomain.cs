using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Exceptions;
using StripsREST.Model;

namespace StripsREST.Mappers;

public class MapFromDomain {
    public static ReeksOutputDto MapFromStripDomain(string url, Reeks reeks) {
        try {
            string reeksUrl = $"{url}/beheer/reeks/{reeks.ID}";
            List<StripRESToutputDto> stripDto = reeks.Strips
                .Select(strip => new StripRESToutputDto(strip.Nr, strip.Titel, $"{url}/beheer/strip/{strip.ID}"))
                .OrderBy(x => x.Nr)
                .ToList();

            ReeksOutputDto dto = new ReeksOutputDto(reeks.Naam, reeksUrl,reeks.ID, stripDto);
            return dto;
        }
        catch (Exception) {
            throw new StripException("Reeks kon niet worden omgezet naar DTO");
        }
 
    }
}