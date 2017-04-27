/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 24/02/2017
 * Time: 03:17 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using CabsaCoreTransporte.Interfaces;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of Conexion.
  /// </summary>
  public class Conexion
  {
    private IConectar conexiones;
    
    public Conexion(IConectar laConexion){
      conexiones = laConexion;
    }
    
    public bool HacerConexion(){
      return conexiones.Conectar();
    }
    
    public IDbConnection HacerConexionConSql(){
      return conexiones.ConexionPorSqlCommand();
    }
  }
}
