using SQLite4Unity3d;

public class Pregunta  {
	
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Semana_id { get; set; }
	public string Texto { get; set; }
		
	public override string ToString ()
	{
		return string.Format ("Pregunta: Id={0}, Semana_id={1}, Texto={2}", Id, Semana_id, Texto);
	}
}