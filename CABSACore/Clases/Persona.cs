/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:41 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabsaCoreTransporte.Clases;
using CABSACore.Clases;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of Persona.
  /// </summary>
  public  class Persona
  {
    public virtual HayCambios cambios { get; set; }
    
    public int Id;
    public string Paterno; //persona
    public string Materno; //Maestro
    public string Rfc;//Maestro
    
    public DatosNacimiento DatosNacimiento;
    public Conyuge Conyuge;
    public DateTime FechaIngresoSEC; //SociosSINAP
    public string NombreUno; //Socio
    public string Esquema;
    public string Fondo;
    
    #region Setter
    public virtual Boolean SetFondo(string valor)
    {
      cambios.EstableceCambios("Fondo", valor);
      this.Fondo = valor;
      return true;
    }
    
    public virtual Boolean SetId(int valor)
    {
      cambios.EstableceCambios("Id", valor);
      this.Id = valor;
      return true;
    }
    
    public virtual Boolean SetPaterno(string valor)
    {
      if ((this.Paterno != valor))
      {
        cambios.EstableceCambios("Paterno", valor);
        this.Paterno = valor;
        return true;
      }
      return false;
    }
    
    public virtual Boolean SetMaterno(string valor)
    {
      //      if ((this.Materno != valor))
      //      {
      //        cambios.EstableceCambios("Materno", valor);
      //        this.Materno = valor;
      return true;
      //      }
      //      return false;
    }
 
    public virtual Boolean SetRfc(string valor)
    {
      //      if ((this.Materno != valor))
      //      {
      //        cambios.EstableceCambios("Materno", valor);
      //        this.Materno = valor;
      return true;
      //      }
      //      return false;
    }
    
    public virtual Boolean SetFechaIngresoSEC(DateTime valor)
    {
      //      cambios.EstableceCambios("FechaIngresoSEC", valor);
      //      this.FechaIngresoSEC = valor;
      return true;
    }
    
    public virtual Boolean SetNombreUno(string valor)
    {
      //      cambios.EstableceCambios("NombreUno", valor);
      this.NombreUno = valor;
      return true;
    }
    
    public virtual Boolean SetDatosNacimiento(DatosNacimiento valor)
    {
      //      cambios.EstableceCambios("NombreUno", valor);
      this.DatosNacimiento = valor;
      return true;
    }
    
    public virtual Boolean SetConyuges(Conyuge valor)
    {
      //      cambios.EstableceCambios("NombreUno", valor);
      this.Conyuge = valor;
      return true;
    }
    
    public virtual Boolean SetEsquema(string valor)
    {
      //      cambios.EstableceCambios("Esquema", valor);
      //      this.Esquema = valor;
      return true;
    }
    #endregion
    
    #region Getters
    public virtual string GetFondo()
    {
      return this.Fondo;
    }
    
    public virtual int GetId()
    {
      return this.Id;
    }
    
    public virtual string GetPaterno()
    {
      return this.Paterno;
    }
    
    public virtual string GetMaterno()
    {
      return this.Materno;
    }
    
    public virtual string GetRfc()
    {
      return this.Rfc;
    }
    
    public virtual DateTime GetFechaIngresoSEC()
    {
      return this.FechaIngresoSEC;
    }

    public virtual string GetNombreUno()
    {
      return this.NombreUno;
    }
    
    public virtual DatosNacimiento  GetDatosNacimiento()
    {
      return this.DatosNacimiento;
    }
    
    public virtual Conyuge  GetConyuge()
    {
      return this.Conyuge;
    }
    
    public  virtual string GetEsquema()
    {
      return this.Esquema;
    }
    #endregion
    
    public Persona()
    {
      cambios = new HayCambios();
    }
    
    
    public virtual bool Registrar(){
      return true;
    }
    
    /// <summary>
    /// Polimorfismo
    /// </summary>
    /// <param name="id"></param>
    public virtual void ConsultarPorId(int id){
      throw new NotImplementedException("Esta funcion solo aplica para socios SISNAP");
    }
    

  }
}
