using SQLite4Unity3d;

public class Respuesta  {
	
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Pregunta_id { get; set; }
	public string Texto { get; set; }
	public int Correcto { get; set; }
	
	public override string ToString ()
	{
		return string.Format ("[Person: Id={0}, Pregunta_id={1}, Texto={2}, Correcto={3}]", Id, Pregunta_id, Texto, Correcto);
	}
}
