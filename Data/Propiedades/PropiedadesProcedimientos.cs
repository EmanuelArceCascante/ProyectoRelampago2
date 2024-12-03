using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Propiedades
{
    public class PropiedadesProcedimientos
    {


        public int IdProcedimiento { get; set; }

        public int? IdEje { get; set; }

        public int? IdArea { get; set; }

        public int? IdDependencia { get; set; }

        
        public string? TipoProcedimiento { get; set; }

       
        public string? Estado { get; set; }

        
        public string? Teletrabajado { get; set; }

        public int? IdMacroproceso { get; set; }

        public int? IdEjeEstrategico { get; set; }

       
        public string? TipoDocumento { get; set; }

        
        public string? NombreProcedimiento { get; set; }

        
        public string? ApoyoTecnologico { get; set; }

        public int? AnioActualizacion { get; set; }
        public PropiedadesProcedimientos(
       int idProcedimiento,
       int? idEje = null,
       int? idArea = null,
       int? idDependencia = null,
       string? tipoProcedimiento = null,
       string? estado = null,
       string? teletrabajado = null,
       int? idMacroproceso = null,
       int? idEjeEstrategico = null,
       string? tipoDocumento = null,
       string? nombreProcedimiento = null,
       string? apoyoTecnologico = null,
       int? anioActualizacion = null)
        {
            IdProcedimiento = idProcedimiento;
            IdEje = idEje;
            IdArea = idArea;
            IdDependencia = idDependencia;
            TipoProcedimiento = tipoProcedimiento;
            Estado = estado;
            Teletrabajado = teletrabajado;
            IdMacroproceso = idMacroproceso;
            IdEjeEstrategico = idEjeEstrategico;
            TipoDocumento = tipoDocumento;
            NombreProcedimiento = nombreProcedimiento;
            ApoyoTecnologico = apoyoTecnologico;
            AnioActualizacion = anioActualizacion;
        }

    }



}

