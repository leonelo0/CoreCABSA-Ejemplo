/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:42 a.m.
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
  /// Description of DatosNacimientoBD.
  /// </summary>
  [ActiveRecord("datos_nacimiento", Lazy = true)]
  public class DatosNacimientoBD : ActiveRecordBase<DatosNacimientoBD>, ITransporte
  {
    
    //Clase guardar
    public virtual GuardarBD objGuardar { get; set; }
    //Lista con cambios en las propiedades
    public virtual HayCambios Cambios { get; set; }
    
    #region Variables
    private int _id;
    private int _socioId;
    private DateTime _fechaNacimiento;
    
    #endregion
    
    #region Propiedades
    [Property ("fecha_nacimiento")]
    public virtual DateTime FechaNacimiento {
      get { return _fechaNacimiento; }
      set { _fechaNacimiento = value; }
    }
    
    [PrimaryKey]
    public virtual int Id {
      get { return _id; }
      set { _id = value; }
    }
    
    [Property("socio_id")]
    public virtual int SocioId {
      get { return _socioId; }
      set { _socioId = value; }
    }
    #endregion
    
    public DatosNacimientoBD()
    {
      objGuardar = new GuardarBD(this.GetType().Name);
    }
    
       
    public virtual bool Transporta(HayCambios losCambios)
    {
      Cambios = losCambios;
      foreach (var lc in Cambios.lcambios)
      {
        GetType().GetProperty(lc.Campo).SetValue(this, lc.Valor);
        GetType().GetProperties();
      }
      var resultado = Guardar();
      return resultado;
    }
    
    public virtual bool Guardar()
    {
      if (Cambios.HuboCambios())
      {
        if (this.Id.Equals(0))
        {
          base.Save();
        }
        else
        {
          objGuardar.Ejecutar(this.Id, Cambios.lcambios);
        }
      }
      return true;
    }
 

  }
}
