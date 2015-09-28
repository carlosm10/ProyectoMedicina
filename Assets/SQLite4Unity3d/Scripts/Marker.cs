using SQLite4Unity3d;

public class Marker  {
	
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Nombre { get; set; }
	public int Size { get; set;}
	public int Semana_id { get; set;}
	
	public override string ToString ()
	{
		return string.Format ("Pregunta: Id={0}, Nombre={1}, Size={2}, Semana_id={3}", Id, Nombre, Size, Semana_id);
	}
}