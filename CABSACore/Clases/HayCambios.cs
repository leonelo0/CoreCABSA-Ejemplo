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
using System.Threading.Tasks;
using CabsaCoreTransporte.Clases;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of HayCambios.
  /// </summary>
  public class HayCambios
  {
    public List<PropiedadesConCambios> lcambios = new List<PropiedadesConCambios>();
    private Boolean Cambios { get; set; }

    public HayCambios()
    {
      Cambios = false;
    }

    public void EstableceCambios(string Propiedad, object valor)
    {
      Cambios = true;
      lcambios.Add(new PropiedadesConCambios() { Campo = Propiedad, Valor = valor });
    }
    public Boolean HuboCambios()
    {
      return Cambios || lcambios.Count > 0;
    }
  }
}
