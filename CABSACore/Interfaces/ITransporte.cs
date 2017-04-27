/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 04/04/2017
 * Time: 11:43 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabsaCoreTransporte.Clases;

namespace CabsaCoreTransporte.Interfaces
{
  /// <summary>
  /// Description of ITransporte.
  /// </summary>
  public interface ITransporte
  {
    Boolean Transporta(HayCambios LisCambios);
  }
}
