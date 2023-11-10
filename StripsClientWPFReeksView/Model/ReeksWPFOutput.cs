using System.Collections.Generic;
using System.ComponentModel;
using StripsREST.Model;

namespace StripsClientWPFReeksView.Model; 

public class ReeksWPFOutput {
    private int reeksId;
    private string naam;
    private int aantalStrips;
    private List<string> strips = new List<string>();
    
    public ReeksWPFOutput(ReeksOutputDto reeks, int id) {
        reeksId = id;
        naam = reeks.Naam;
        aantalStrips = reeks.Strips.Count;
        foreach (var strip in reeks.Strips) {
            strips.Add(strip.Titel);
        }
    }
    
    public int ReeksId {
        get { return reeksId; }
        set {
            reeksId = value;
            OnPropertyChanged("ReeksId");
        }
    }
    
    public string Naam {
        get { return naam; }
        set {
            naam = value;
            OnPropertyChanged("Naam");
        }
    }
    
    public int AantalStrips {
        get { return aantalStrips; }
        set {
            aantalStrips = value;
            OnPropertyChanged("AantalStrips");
        }
    }
    
    public List<string> Strips {
        get { return strips; }
        set {
            strips = value;
            OnPropertyChanged("Strips");
        }
    }
    
    public override string ToString() {
        return $"{Naam} ({AantalStrips})";
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}