/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:41 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of Maestro.
  /// </summary>
  public class Maestro : Persona
  {
    
    private string Materno;
    private string Rfc;
    
    #region Setter
    
    public override Boolean SetMaterno(string valor)
    {
      if ((this.Materno != valor))
      {
        cambios.EstableceCambios("Materno", valor);
        this.Materno = valor;
        return true;
      }
      return false;
    }
    
    public override Boolean SetRfc(string valor)
    {
      if ((this.Rfc != valor))
      {
        cambios.EstableceCambios("Rfc", valor);
        this.Rfc = valor;
        return true;
      }
      return false;
    }
    
    #endregion
    
    #region Getters

    public override string GetMaterno()
    {
      return this.Materno;
    }
    
    
    public override string GetRfc()
    {
      return this.Rfc;
    }

    #endregion
    
    public Maestro()
    {
      
    }
  }
}
