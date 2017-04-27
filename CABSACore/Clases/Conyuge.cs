/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 05/04/2017
 * Time: 03:11 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CabsaCoreTransporte.Clases;
using CabsaCoreTransporte.ClasesBD;
using CabsaCoreTransporte.Interfaces;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of Conyuge.
  /// </summary>
  public class Conyuge : Persona
  {
    
    public virtual HayCambios cambiosConyuge { get; set; }
    //    ITransporte objTransporta;
    ConyugeBD objBD;
    
    public string Rfc;
    public int Sexo;
    public DateTime FechaUnion;
    
    #region Setter
    public virtual Boolean SetRfc(string valor)
    {
      cambiosConyuge.EstableceCambios("Rfc", valor);
      this.Rfc = valor;
      return true;
    }
    
    public virtual Boolean SetSexo(int valor)
    {
      cambiosConyuge.EstableceCambios("Sexo", valor);
      this.Sexo = valor;
      return true;
    }
    
    public virtual Boolean SetFechaUnion(DateTime valor)
    {
      cambiosConyuge.EstableceCambios("FechaUnion", valor);
      this.FechaUnion = valor;
      return true;
    }
    
    #endregion
    
    #region Getters
    
    public string GetRfc()
    {
      return this.Rfc;
    }
    
    public int GetSexo()
    {
      return this.Sexo;
    }
    
    public DateTime GetFechaUnion()
    {
      return this.FechaUnion;
    }
    
    #endregion
    
    
    public Conyuge()
    {
      objBD = new ConyugeBD();
      //      objTransporta = new ConyugeBD();
      cambiosConyuge = new HayCambios();
    }
    
    public Conyuge Registrar(){

      if(objBD.Transporta(cambiosConyuge)){
        //      if(objTransporta.Transporta(cambiosConyuge)){
        this.SetId(objBD.Id);
      }
      
      return this;
    }
    
    
  }
}
