/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 07/04/2017
 * Time: 11:05 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CABSACore.Clases;
using CabsaCoreTransporte.Clases;

namespace CABSACore.Clases
{
  /// <summary>
  /// Description of fSocio.
  /// </summary>
  public class fSocio
  {
    public fSocio()
    {
    }
    
    public static Persona DeclaraSocio(string fondo){
      switch(fondo){
        case "SISNAP":
          return new SocioSISNAP();
          
        case "FAS":
          return new SocioFAS();
          
        default:
          return null;
          
      }
    }
  }
}
