/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:41 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CabsaCoreTransporte.ClasesBD;
using CabsaCoreTransporte.Interfaces;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of Socio.
  /// </summary>
  public class Socio : Maestro
  {
    
    private string NombreUno;
    
    #region Setter
    public override Boolean SetNombreUno(string valor)
    {
      cambios.EstableceCambios("NombreUno", valor);
      this.NombreUno = valor;
      return true;
    }
    
    #endregion
    
    #region Getters
    public override string GetNombreUno()
    {
      return this.NombreUno;
    }
    
    #endregion
        
    public Socio()
    {
    }
  }
}
