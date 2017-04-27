/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:42 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CabsaCoreTransporte.ClasesBD;
using CabsaCoreTransporte.Interfaces;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of DatosNacimiento.
  /// </summary>
  public class DatosNacimiento
  {
    public virtual HayCambios cambiosNacimiento { get; set; }
    //    ITransporte objTransporta;
    DatosNacimientoBD objBD;
    
    public int Id;
    public int SocioId;
    public DateTime FechaNacimiento;
    
    #region Setter
    public Boolean SetId(int valor)
    {
      cambiosNacimiento.EstableceCambios("Id", valor);
      this.Id = valor;
      return true;
    }
    
    public Boolean SetSocioId(int valor)
    {
      cambiosNacimiento.EstableceCambios("SocioId", valor);
      this.SocioId = valor;
      return true;
    }
    
    public Boolean SetFechaNacimiento(DateTime valor)
    {
      cambiosNacimiento.EstableceCambios("FechaNacimiento", valor);
      this.FechaNacimiento = valor;
      return true;
    }
    
    #endregion
    
    
    #region Getters
    public int GetId()
    {
      return this.Id;
    }
    
    public int GetSocioId()
    {
      return this.SocioId;
    }
    
    public DateTime GetFechaNacimiento()
    {
      return this.FechaNacimiento;
    }
    #endregion
    
    public DatosNacimiento()
    {
      objBD = new DatosNacimientoBD();
      cambiosNacimiento = new HayCambios();
    }
    

    public DatosNacimiento Registrar(){

      if(objBD.Transporta(cambiosNacimiento)){
        this.SetId(objBD.Id);
      }
      
      return this;
    }
  }
}
