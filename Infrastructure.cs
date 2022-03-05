using Npgsql;
using NotaAPI.Domain;

namespace NotaAPI.Infrastructure;

public class Repository
{
    private readonly string _connString;
    public Repository(string connString)
    {
        _connString = connString;
    }
    async public void InsereNota(Nota nota)
    {        

        await using var conn = new NpgsqlConnection(_connString);
        await conn.OpenAsync();

        // Insert some data
        await using (var cmd = new NpgsqlCommand("INSERT INTO notas (RM, NOME, MATERIA, NOTA) VALUES (@RM, @NOME, @MATERIA, @NOTA)", conn))
        {
            cmd.Parameters.AddWithValue("RM", nota.rm);
            cmd.Parameters.AddWithValue("NOME", nota.nome);
            cmd.Parameters.AddWithValue("MATERIA", nota.materia);
            cmd.Parameters.AddWithValue("NOTA", nota.nota);
            await cmd.ExecuteNonQueryAsync();
        }               
    }

    async public Task<IEnumerable<Nota>> ListaNotas(){
        await using var conn = new NpgsqlConnection(_connString);
        await conn.OpenAsync();
        // Retrieve all rows
        var result = new List<Nota>();
        await using (var cmd = new NpgsqlCommand("SELECT * FROM notas", conn))
        
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            
            while (await reader.ReadAsync())
                result.Add(new Nota(rm: reader.GetString(0),
                                    nome:reader.GetString(1),
                                    materia:reader.GetString(2),
                                    nota:reader.GetInt16(3)));  
        }
        return result;
    }
}