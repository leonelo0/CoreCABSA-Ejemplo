/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 12:22 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CabsaCoreTransporte.Clases;
using System.Collections.Generic;
using Castle.ActiveRecord;
using NHibernate;

namespace CabsaCoreTransporte.ClasesBD
{
  /// <summary>
  /// Description of GuardarBD.
  /// </summary>
  public class GuardarBD
  {
    private string query;
    private string clase;
    
    public GuardarBD(string laClase)
    {
      clase = laClase;
    }
    
    public bool Ejecutar(int id, List<PropiedadesConCambios> lcambios)
    {

      query = String.Concat("UPDATE ", clase.Split('.')[clase.Split('.').Length - 1], " SET ", UpdateParam(lcambios), " WHERE Id =  :Id");

      ISession session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(ActiveRecordBase));
      try
      {
        if (!session.IsOpen)
        {
          session.Connection.Open();
        }
        IQuery crit = session.CreateQuery(query);
        crit.SetParameter("Id", id);

        foreach (var p in lcambios)
        {

          crit.SetParameter(p.Campo, p.Valor);
        }
        crit.ExecuteUpdate();
        return true;

      }
      catch
      {
        return false;
      }
    }

    private string UpdateParam(List<PropiedadesConCambios> lchanges)
    {
      string str = "";
      foreach (var i in lchanges)
      {
        if (!str.Equals(""))
          str += ",";
        str += String.Concat(i.Campo, " = ", ":", i.Campo);
      }
      return str;
    }
    
  }
}
