using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int IdKlienta { get; set; }
    public string Imie { get; set; } = string.Empty;
    public string Nazwisko { get; set; } = string.Empty;
    public string NrTelefonu { get; set; } = string.Empty;
}
