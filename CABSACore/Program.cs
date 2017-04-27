/*
 * Created by SharpDevelop.
 * User: Leonel
 * Date: 06/04/2017
 * Time: 03:20 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using CabsaCoreTransporte.Interfaces;
using CabsaCoreTransporte.Clases;
using CABSACore.Clases;
using CABSACore.ClasesBD;
using System.Reflection;

namespace CABSACore
{
  class Program
  {
    
    public static void Main(string[] args)
    {
   
      bool crearNuevoRegistro = false;
      do{
        
        Conexion nConexion ;
        Persona nSocio;
        bool eleccionFondo = false;
        Console.WriteLine("");
        string fondo = "";
        
        do{
          fondo =  SeleccionarFondo();
          
          switch(fondo){
              #region Conexion
            case "1":
              
              nConexion = new Conexion(new ConexionSISNAP());
              if(nConexion.HacerConexion()){
                Console.WriteLine("CONEXION A BD SISNAP CON EXITO:\n");
                fondo = "SISNAP";
                eleccionFondo = true;
              }
              break;
            case "2":
              
              nConexion = new Conexion(new ConexionFAS());
              if(nConexion.HacerConexion()){
                Console.WriteLine("CONEXION A BD FAS CON EXITO:\n");
                fondo = "FAS";
                eleccionFondo = true;
              }
              break;
            default:
              Console.WriteLine("NUMERO INVALIDO !");
              
              break;
              #endregion
          }
        }while(eleccionFondo == false);
        
        
        //Se declara un nuevo objeto tipo persona.
        Console.WriteLine("DECLARANDO UN NUEVO SOCIO DE TIPO " + fondo);
        nSocio = fSocio.DeclaraSocio(fondo);
        
        if(nSocio != null){
          
          nSocio.SetFondo(fondo);
          nSocio = RegistrarNuevoSocio(nSocio, fondo);
          
          if(nSocio.Registrar()){
            //Se registran los datos de nacimiento y se asigna objeto a nuevo Socio.
            nSocio.SetDatosNacimiento(RegistrarDatosNacimiento(nSocio.Id,fondo));
            
            Console.WriteLine("SOCIO REGISTRADO CON EXITO.");
            
            Console.WriteLine("\n**** DESEAS CONSULTAR LOS DATOS DEL SOCIO REGISTRADO?(S/N) ****");
            
            #region Consulta de valores y propiedades
            
            string r = Console.ReadLine();
            
            if(r == "s" || r == "S"){
              
              ConsultarSocio(nSocio,fondo);
  
              #region Datos del Nacimiento
              if( nSocio.DatosNacimiento.cambiosNacimiento != null ){
                foreach (var lc in nSocio.DatosNacimiento.cambiosNacimiento.lcambios)
                {
                  Console.WriteLine(lc.Campo.ToString() + ": " + lc.Valor.ToString());
                }
              }
              #endregion
              
            }
            #endregion

          }
          
        }
        
        Console.WriteLine("\n**** DESEAS EMPEZAR DE NUEVO?(S/N) ****");
        string res = Console.ReadLine();
        
        if(res == "s" || res == "S"){
          crearNuevoRegistro = true;
        }else{
          crearNuevoRegistro = false;
        }
        
      }while(crearNuevoRegistro == true );
      
      
      Console.WriteLine("\nENTER PARA SALIR");
      Console.ReadLine( );
    }
    
    
    public static string SeleccionarFondo(){
      Console.WriteLine("FAVOR DE SELECCIONAR UN NUMERO PARA SELECCIONAR EL FONDO Y DAR ENTER:");
      
      Console.Write("1. SISNAP\n2. FAS\n\n");
      return Console.ReadLine();
    }
    
    public static Persona RegistrarNuevoSocio(Persona nSocio,string fondo){
      
      if(nSocio.GetFondo() == "SISNAP" ){
        nSocio.SetRfc("MUOL840917UX1");
        nSocio.SetPaterno("Muñoz");
        nSocio.SetMaterno("Ortiz");
        nSocio.SetNombreUno("Leonel");
        nSocio.SetFechaIngresoSEC(DateTime.Parse("2000-01-05"));
        nSocio.SetEsquema("Nuevo");
      }else {
        nSocio.SetRfc("MOPL851026UCE");
        nSocio.SetPaterno("Moreno");
        nSocio.SetMaterno("Preciado");
        nSocio.SetNombreUno("Marilu");
        nSocio.SetFechaIngresoSEC(DateTime.Parse("2010-10-05"));
        nSocio.SetEsquema("Viejo");
      }
      
      #region Mostrar datos
      //        Console.WriteLine("RFC: " + nSocio.GetRfc());
      //        //      nSocio.SetRfc(Console.ReadLine());
//
      //        Console.WriteLine("Apellido paterno: " + nSocio.GetPaterno());
      //        //      nSocio.SetPaterno(Console.ReadLine());
//
      //        Console.WriteLine("Apellido materno: " + nSocio.GetMaterno());
      //        //      nSocio.SetMaterno(Console.ReadLine());
//
      //        Console.WriteLine("Nombre: " + nSocio.GetNombreUno());
      //        //      nSocio.SetNombreUno(Console.ReadLine());
//
      //        Console.WriteLine("Fecha Ingreso (yyyy-mm-dd): " + nSocio.GetFechaIngresoSEC());
      //        //      nSocio.SetFechaIngresoSEC(DateTime.Parse(Console.ReadLine()));
//
      //        Console.WriteLine("Esquema (Nuevo/Anterior): " + nSocio.GetEsquema());
      //        //      nSocio.SetEsquema(Console.ReadLine());
      #endregion
      
      return nSocio;
    }
    
    public static DatosNacimiento RegistrarDatosNacimiento( int socio_id, string fondo){
      DatosNacimiento nDatosNac = new DatosNacimiento();
      if(fondo == "SISNAP" ){
        nDatosNac.SetFechaNacimiento(DateTime.Parse("1984-09-17"));
      }else {
        nDatosNac.SetFechaNacimiento(DateTime.Parse("198-10-26"));
      }
      
      //Se asignan los valores.
      //      nDatosNac.SetFechaNacimiento(DateTime.Parse(Console.ReadLine()));
      nDatosNac.SetSocioId(socio_id);
      
      //      Console.WriteLine("\nFecha de Nacimiento (yyyy-mm-dd): " + nDatosNac.GetFechaNacimiento());
      
      //Se registran los datos de nacimiento y se asigna al objeto nSocio
      return nDatosNac.Registrar();
      
    }
    
    public static void ConsultarSocio (Persona nSocio,string fondo){
      //Creamos una nueva instancia para el ejemplo
      Persona consultarSocio = fSocio.DeclaraSocio(fondo);
      
      consultarSocio.ConsultarPorId(nSocio.Id);
      
      //Se recorren los cambios para mostrar en pantalla
      if( consultarSocio.cambios != null ){
        foreach (var lc in consultarSocio.cambios.lcambios)
        {
          Console.WriteLine(lc.Campo.ToString() + ": " + lc.Valor.ToString());
        }
      }
      
      
    }
  
  }
}