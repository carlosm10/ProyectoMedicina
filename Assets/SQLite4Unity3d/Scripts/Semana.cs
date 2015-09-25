using SQLite4Unity3d;

public class Semana  {
	
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Nombre { get; set; }
	
	public override string ToString ()
	{
		return string.Format ("Pregunta: Id={0}, Nombre={1}", Id, Nombre);
	}
}