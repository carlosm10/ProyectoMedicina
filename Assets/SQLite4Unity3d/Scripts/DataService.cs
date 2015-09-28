using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){
		Debug.Log ("Create DataService");
#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/database/{0}", DatabaseName);
			Debug.Log(DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateDB(){	
		CrearTablaMarker ();
		CrearTablaSemana ();
		CrearTablaPregunta ();
		CrearTablaRespuesta ();
	}

	public void CrearTablaMarker(){
		_connection.DropTable<Marker> ();
		_connection.CreateTable<Marker> ();
		_connection.InsertAll (new[]{
			new Marker{
				Nombre = "Marca1",
				Size = 100,
				Semana_id = 1
			}
		});
	}

	public void CrearTablaSemana(){
		_connection.DropTable<Semana> ();
		_connection.CreateTable<Semana>();
		_connection.InsertAll (new[]{
			
			new Semana{
				Nombre = "Semana 1"
			}			
		});
	}

	public void CrearTablaPregunta(){
		_connection.DropTable<Pregunta> ();
		_connection.CreateTable<Pregunta> ();
		
		_connection.InsertAll (new[]{
			new Pregunta{
				Semana_id = 1,
				Texto = "Pregunta 1"
			}
		});
	}

	public void CrearTablaRespuesta(){
		_connection.DropTable<Respuesta> ();
		_connection.CreateTable<Respuesta>();
		_connection.InsertAll(new[]{
			
			new Respuesta{
				Pregunta_id = 1,
				Texto = "Respuesta 1",
				Correcto = 1
			}
		});
	}


	public Pregunta CreatePregunta(int Semana, string pregunta_texto){
		var p = new Pregunta{
			Semana_id = Semana,
			Texto = pregunta_texto,
		};
		_connection.Insert (p);
		return p;
	}

	public IEnumerable<Marker> GetMarcas()
	{
		return _connection.Query<Marker> ("select * from Marker");
	}

	public IEnumerable<Semana> GetSemanas()
	{
		return _connection.Query<Semana> ("select * from Semana");
	}

	public IEnumerable<Pregunta> GetPreguntas (int semana_id)
	{
		return _connection.Query<Pregunta> ("select * from Pregunta where Semana_id = ?", semana_id );
	}

	public IEnumerable<Respuesta> GetRespuestas (int pregunta_id)
	{
		return _connection.Query<Respuesta> ("select * from Respuesta where Pregunta_id = ?", pregunta_id );
	}


}
