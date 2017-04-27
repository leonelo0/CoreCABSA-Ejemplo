/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 24/02/2017
 * Time: 03:19 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace CabsaCoreTransporte.Interfaces
{
  /// <summary>
  /// Description of IConectar.
  /// </summary>
  public interface IConectar
  {
    bool Conectar();
    IDbConnection ConexionPorSqlCommand();
  }
}
