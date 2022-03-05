namespace NotaAPI.Domain;

public class Nota {    

    public Nota(string rm, string nome, string materia, int nota)
    {
        this.rm = rm;
        this.nome = nome;
        this.materia = materia;
        this.nota = nota;
    }
    public string rm { get; set; }
    public string nome { get; set; }
    public string materia { get; set; }
    public int nota { get; set; }
}