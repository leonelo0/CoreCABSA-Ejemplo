/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 05/04/2017
 * Time: 03:11 p.m.
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

namespace CabsaCoreTransporte.ClasesBD
{
  /// <summary>
  /// Description of ConyugeBD.
  /// </summary>
  [ActiveRecord("conyuges", Lazy = true )]
  public class ConyugeBD : ActiveRecordBase<ConyugeBD>, ITransporte
  {
    
    //Clase guardar
    public virtual GuardarBD objGuardar { get; set; }
    //Lista con cambios en las propiedades
    public virtual HayCambios cambios { get; set; }
    
    #region Variables
    private int _id;
    private int _socio_id;
    private string _rfc;
    private string _paterno;
    private string _materno;
    private string _nombre;
    private int _sexo;
    private DateTime _fechaUnion;   
        
    #endregion
    
    #region Propiedades
    [Property("fecha_union")]
    public virtual  DateTime FechaUnion {
      get { return _fechaUnion; }
      set { _fechaUnion = value; }
    }
    
    [Property]
    public virtual int Sexo {
      get { return _sexo; }
      set { _sexo = value; }
    }
    
    [Property("nombres")]
    public virtual string Nombre {
      get { return _nombre; }
      set { _nombre = value; }
    }
    
    [Property]
    public virtual string Materno {
      get { return _materno; }
      set { _materno = value; }
    }
    
    [Property]
    public virtual string Paterno {
      get { return _paterno; }
      set { _paterno = value; }
    }
    
    [Property]
    public virtual string Rfc {
      get { return _rfc; }
      set { _rfc = value; }
    }
    
    [Property]
    public virtual int Socio_id {
      get { return _socio_id; }
      set { _socio_id = value; }
    }
    
    [PrimaryKey]
    public virtual int Id {
      get { return _id; }
      set { _id = value; }
    }
    #endregion
    
    public ConyugeBD()
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
    
  }
}
