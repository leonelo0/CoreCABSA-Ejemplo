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
using CABSACore.ClasesBD;
using System.Reflection;

namespace CabsaCoreTransporte.Clases
{
  /// <summary>
  /// Description of SocioSISNAP.
  /// </summary>
  public class SocioSISNAP : Socio
  {
    //    public virtual HayCambios cambios { get; set; }
    //    ITransporte objTransporta;
    SocioSISNAPBD objBD;
    private DateTime FechaIngresoSEC;
    
    #region Setter
    public override  Boolean SetFechaIngresoSEC(DateTime valor)
    {
      cambios.EstableceCambios("FechaIngresoSEC", valor);
      this.FechaIngresoSEC = valor;
      return true;
    }
    
    #endregion
    
    #region Getters
    public  override DateTime GetFechaIngresoSEC()
    {
      return this.FechaIngresoSEC;
    }
    
    #endregion
    
    public SocioSISNAP()
    {
      objBD = new SocioSISNAPBD();
    }
    
    public override bool Registrar(){
      
      //      try{
      if( objBD.Transporta(cambios)){
        //Se asigna el nuevo ID del objeto objBD
        this.SetId(objBD.Id);
      }else{
        return false;
      }
      //      }catch{
      //        return false;
      //      }
      
      return true;
    }
    
    
    public override void ConsultarPorId(int id){
      objBD = objBD.FindByPersonaId(id);
      
      if(objBD != null || objBD.Id != 0){
        Type t = objBD.GetType();
        object valor;
        
        
        PropertyInfo[] propiedadesObjBD = t.GetProperties();
        
        foreach (PropertyInfo pro in propiedadesObjBD){
          
          #region Swich para asignar valores a los setters de esta clase
          switch(pro.Name){
            case "Id":
              valor = pro.GetValue(objBD,null);
              
              //Se asigna los valores de consulta, hay q validar que traigan valores para q no truene antes de hacer los sets
              SetId(((int)valor));
              
              break;
            case "Rfc":
              valor = pro.GetValue(objBD,null);
              
              SetRfc(((string)valor));
              
              break;
            case "Paterno":
              valor = pro.GetValue(objBD,null);
              
              SetPaterno(((string)valor));
              
              break;
            case "Materno":
              valor = pro.GetValue(objBD,null);
              
              SetMaterno(((string)valor));
              
              break;
            case "NombreUno":
              valor = pro.GetValue(objBD,null);
              
              SetNombreUno(((string)valor));
              
              break;
            case "FechaIngresoSEC":
              valor = pro.GetValue(objBD,null);
              
              SetFechaIngresoSEC(((DateTime)valor));
              
              break;
            case "Fondo":
              valor = pro.GetValue(objBD,null);
              
              SetFondo(((string)valor));
              
              break;
          }
          #endregion          
        
        }
      }
      
//      return this;
    }
  
  
  }
}
