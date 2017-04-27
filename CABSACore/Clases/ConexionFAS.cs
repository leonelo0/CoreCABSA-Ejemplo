/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 06/04/2017
 * Time: 03:59 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CabsaCoreTransporte.Interfaces;
using Castle.ActiveRecord.Framework.Config;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using System.Data;
using MySql.Data.MySqlClient;
using CabsaCoreTransporte.ClasesBD;
using CABSACore.ClasesBD;

namespace CABSACore.Clases
  
{
  /// <summary>
  /// Description of ConexionFAS.
  /// </summary>
  public class ConexionFAS :IConectar
  {
    public static string docAppConfigOnlineBDFAS = "appconfigFAS_prueba.xml";// Servidor Pruebas
    public static string ruta = AppDomain.CurrentDomain.BaseDirectory.ToString();//es la ruta de la carpeta raiz del proyecto
    
    public bool Conectar()
    {
      
      ActiveRecordStarter.ResetInitializationFlag();
      XmlConfigurationSource source = new XmlConfigurationSource(docAppConfigOnlineBDFAS);
      InciarActiveRecord(source);

      return true;

    }
    
    public bool InciarActiveRecord(XmlConfigurationSource source)
    {

      ActiveRecordStarter.Initialize(source,
                                     typeof (SocioFASBD), typeof (DatosNacimientoBD), typeof (ConyugeBD)
                                    );


      return true;
    }
    
    public IDbConnection ConexionPorSqlCommand()
    {
      try {
        IDbConnection conexion = new MySqlConnection(getConectionString());
        
        return conexion;
      }catch {
        return null;
      }
    }
    
    public string getConectionString()
    {
      string strconneccion = "";

      System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load(ruta + "\\" + docAppConfigOnlineBDFAS);
      foreach (System.Xml.Linq.XElement atrib in doc.Element("activerecord").Element("config").Elements())
      {
        switch (atrib.Attribute("key").Value.ToString())
        {
          case "connection.connection_string":
            {
              strconneccion = atrib.Attribute("value").Value.ToString();

            }
            break;
        }
      }
      return strconneccion;

    }
    
  }
}
