/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 07/04/2017
 * Time: 05:14 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using Castle.ActiveRecord;
using CabsaCoreTransporte.Interfaces;
using CabsaCoreTransporte.Clases;
using NHibernate;
using NHibernate.Criterion;
using CabsaCoreTransporte.ClasesBD;

namespace CABSACore.ClasesBD
{
  /// <summary>
  /// Description of SocioSISNAPBD.
  /// </summary>
  [ActiveRecord("socios", Lazy = true)]
  public class SocioSISNAPBD : ActiveRecordBase<SocioSISNAPBD>
  {
    //Clase guardar
    public virtual GuardarBD objGuardar { get; set; }
    //Lista con cambios en las propiedades
    public virtual HayCambios cambios { get; set; }
    
    #region Variables
    private int _id;
    private string _rfc;
    private string  _paterno;
    private string _materno;
    private string _nombreUno;
    private DateTime _fechaIngresoSEC;
    //    private string  _esquema;
    private string _fondo;
    

    #endregion
    
    #region Propiedades
    [Property]
    public virtual string Rfc {
      get { return _rfc; }
      set { _rfc = value; }
    }
    
    [Property]
    public virtual string Fondo {
      get { return _fondo; }
      set { _fondo = value; }
    }
    //    [Property]
    //    public virtual string  Esquema {
    //      get { return _esquema; }
    //      set { _esquema = value; }
    //    }
    
    [Property("fecha_ingreso_sec")]
    public virtual DateTime FechaIngresoSEC {
      get { return _fechaIngresoSEC; }
      set { _fechaIngresoSEC = value; }
    }
    
    [Property("nombres")]
    public virtual string NombreUno {
      get { return _nombreUno; }
      set { _nombreUno = value; }
    }
    
    [Property("materno")]
    public virtual string Materno {
      get { return _materno; }
      set { _materno = value; }
    }
    
    [Property("paterno")]
    public virtual string Paterno {
      get { return _paterno; }
      set { _paterno = value; }
    }
    
    [PrimaryKey]
    public virtual int Id {
      get { return _id; }
      set { _id = value; }
    }
    
    #endregion
    
    public SocioSISNAPBD()
    {
      objGuardar = new GuardarBD(this.GetType().Name);
    }
    
    public virtual bool Transporta(HayCambios losCambios)
    {
      cambios = losCambios;
      foreach (var lc in cambios.lcambios)
      {
        GetType().GetProperty(lc.Campo).SetValue(this, lc.Valor);
        GetType().GetProperties();
      }
      var resultado = Guardar();
      return resultado;
    }
    
    public virtual bool Guardar()
    {
      if (cambios.HuboCambios())
      {
        if (this.Id.Equals(0))
        {
          base.Save();
        }
        else
        {
          objGuardar.Ejecutar(this.Id, cambios.lcambios);
        }
      }
      return true;
    }
    
    public virtual SocioSISNAPBD FindByPersonaId(int id){
      
      SocioSISNAPBD l = Find(id);
      return l;
    }
  }
}
