using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditorExcelController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private readonly UserManager<T_Usuario> _UserManager;
        private ApplicationDbContext _db;

        public EditorExcelController(IContenedorTrabajo context, UserManager<T_Usuario> UserManager, ApplicationDbContext db)
        {
            _context = context;
            _UserManager = UserManager;
            _db = db;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerarGubernatura()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdGobernador();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosGubernatura.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarPresidencias()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdPresidencia();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosPresidencia.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarDiputaciones()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdDiputados();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosDiputacion.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarRegidores()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdRegidores();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosRegidurias.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarGubernaturaMunicipal()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdGobernadorMunicipal();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosGubernatura.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarPresidenciasMunicipal()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdPresidenciaMunicipal();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosPresidencia.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarDiputacionesMunicipal()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdDiputadosMunicipal();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosDiputacion.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarRegidoresMunicipal()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdRegidoresMunicipal();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosRegidurias.xlsx");
        }

        [HttpGet]
        public IActionResult GenerarPaquetes()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdPaquetesINE();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosPaquetes.xlsx");
        }

        public IActionResult GenerarPaquetesMunicipal()
        {
            //aqui mandas llamar el arreglo de bytes y lo retornas como archivo
            byte[] buffer = BdPaquetesMunicipal();
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileDownloadName: "BaseDatosPaquetes.xlsx");
        }

        public byte[] BdGobernador()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using(MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using(ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Gubernatura");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Resultados_Actas.ResultadosExcel(1);
                    var Votos = _context.Resultados_Actas.VotosExcel(1);
                    var Causal = _context.Resultados_Actas.Causales(1);
                    var Complementaria = _context.Resultados_Actas.Complementaria(1);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    

                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString() ;
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = "1733";
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 47].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 47].Style.Font.Size = 12;
                    Hoja.Cells[2, 47].AutoFitColumns();
                    Hoja.Cells[2, 47].Style.Font.Bold = true;
                    Hoja.Cells[2, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 47].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 47].Style.Font.Size = 12;
                    Hoja.Cells[3, 47].AutoFitColumns();
                    Hoja.Cells[3, 47].Style.Font.Bold = true;
                    Hoja.Cells[3, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 47].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 47].Style.Font.Size = 12;
                    Hoja.Cells[4, 47].AutoFitColumns();
                    Hoja.Cells[4, 47].Style.Font.Bold = true;
                    Hoja.Cells[4, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 50].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 50].Style.Font.Size = 12;
                    Hoja.Cells[2, 50].AutoFitColumns();
                    Hoja.Cells[2, 50].Style.Font.Bold = true;
                    Hoja.Cells[2, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 50].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 50].Style.Font.Size = 12;
                    Hoja.Cells[3, 50].AutoFitColumns();
                    Hoja.Cells[3, 50].Style.Font.Bold = true;
                    Hoja.Cells[3, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 50].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 50].Style.Font.Size = 12;
                    Hoja.Cells[4, 50].AutoFitColumns();
                    Hoja.Cells[4, 50].Style.Font.Bold = true;
                    Hoja.Cells[4, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 53].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 53].Style.Font.Size = 12;
                    Hoja.Cells[2, 53].AutoFitColumns();
                    Hoja.Cells[2, 53].Style.Font.Bold = true;
                    Hoja.Cells[2, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 53].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 53].Style.Font.Size = 12;
                    Hoja.Cells[3, 53].AutoFitColumns();
                    Hoja.Cells[3, 53].Style.Font.Bold = true;
                    Hoja.Cells[3, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 53].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 53].Style.Font.Size = 12;
                    Hoja.Cells[4, 53].AutoFitColumns();
                    Hoja.Cells[4, 53].Style.Font.Bold = true;
                    Hoja.Cells[4, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 56].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 56].Style.Font.Size = 12;
                    Hoja.Cells[2, 56].AutoFitColumns();
                    Hoja.Cells[2, 56].Style.Font.Bold = true;
                    Hoja.Cells[2, 56].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 56].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 56].Style.Font.Size = 12;
                    Hoja.Cells[3, 56].AutoFitColumns();
                    Hoja.Cells[3, 56].Style.Font.Bold = true;
                    Hoja.Cells[3, 56].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {
                      
                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "GOB";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x=> x.IdDetalleVotosActa).ToList();
                        foreach(var partidos in vots)
                        {
                            col++;
                            Hoja.Cells[i, col].Value = partidos.Votos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if(validacion.Count()!= 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if(Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value ="Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        
                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        
                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                       
                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }

                   

                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdPresidencia()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Presidencias y Sindicaturas");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Resultados_Actas.ResultadosExcel(2);
                    var Votos = _context.Resultados_Actas.VotosExcel(2);
                    var Causal = _context.Resultados_Actas.Causales(2);
                    var Complementaria = _context.Resultados_Actas.Complementaria(2);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = "1733";
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 49].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 49].Style.Font.Size = 12;
                    Hoja.Cells[2, 49].AutoFitColumns();
                    Hoja.Cells[2, 49].Style.Font.Bold = true;
                    Hoja.Cells[2, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 49].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 49].Style.Font.Size = 12;
                    Hoja.Cells[3, 49].AutoFitColumns();
                    Hoja.Cells[3, 49].Style.Font.Bold = true;
                    Hoja.Cells[3, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 49].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 49].Style.Font.Size = 12;
                    Hoja.Cells[4, 49].AutoFitColumns();
                    Hoja.Cells[4, 49].Style.Font.Bold = true;
                    Hoja.Cells[4, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 52].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 52].Style.Font.Size = 12;
                    Hoja.Cells[2, 52].AutoFitColumns();
                    Hoja.Cells[2, 52].Style.Font.Bold = true;
                    Hoja.Cells[2, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 52].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 52].Style.Font.Size = 12;
                    Hoja.Cells[3, 52].AutoFitColumns();
                    Hoja.Cells[3, 52].Style.Font.Bold = true;
                    Hoja.Cells[3, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 52].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 52].Style.Font.Size = 12;
                    Hoja.Cells[4, 52].AutoFitColumns();
                    Hoja.Cells[4, 52].Style.Font.Bold = true;
                    Hoja.Cells[4, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 55].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 55].Style.Font.Size = 12;
                    Hoja.Cells[2, 55].AutoFitColumns();
                    Hoja.Cells[2, 55].Style.Font.Bold = true;
                    Hoja.Cells[2, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 55].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 55].Style.Font.Size = 12;
                    Hoja.Cells[3, 55].AutoFitColumns();
                    Hoja.Cells[3, 55].Style.Font.Bold = true;
                    Hoja.Cells[3, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 55].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 55].Style.Font.Size = 12;
                    Hoja.Cells[4, 55].AutoFitColumns();
                    Hoja.Cells[4, 55].Style.Font.Bold = true;
                    Hoja.Cells[4, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 58].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 58].Style.Font.Size = 12;
                    Hoja.Cells[2, 58].AutoFitColumns();
                    Hoja.Cells[2, 58].Style.Font.Bold = true;
                    Hoja.Cells[2, 58].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 58].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 58].Style.Font.Size = 12;
                    Hoja.Cells[3, 58].AutoFitColumns();
                    Hoja.Cells[3, 58].Style.Font.Bold = true;
                    Hoja.Cells[3, 58].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAND_IND_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    

                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "PYS";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if(vots.Where(x=> x.IdPartido == 9 ).Count()!= 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }                        
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdIndependiente != 0).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdIndependiente != 0);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdDiputados()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Diputaciones");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Resultados_Actas.ResultadosExcel(3);
                    var Votos = _context.Resultados_Actas.VotosExcel(3);
                    var Causal = _context.Resultados_Actas.Causales(3);
                    var Complementaria = _context.Resultados_Actas.Complementaria(3);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = "1733";
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 50].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 50].Style.Font.Size = 12;
                    Hoja.Cells[2, 50].AutoFitColumns();
                    Hoja.Cells[2, 50].Style.Font.Bold = true;
                    Hoja.Cells[2, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 50].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 50].Style.Font.Size = 12;
                    Hoja.Cells[3, 50].AutoFitColumns();
                    Hoja.Cells[3, 50].Style.Font.Bold = true;
                    Hoja.Cells[3, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 50].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 50].Style.Font.Size = 12;
                    Hoja.Cells[4, 50].AutoFitColumns();
                    Hoja.Cells[4, 50].Style.Font.Bold = true;
                    Hoja.Cells[4, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 53].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 53].Style.Font.Size = 12;
                    Hoja.Cells[2, 53].AutoFitColumns();
                    Hoja.Cells[2, 53].Style.Font.Bold = true;
                    Hoja.Cells[2, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 53].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 53].Style.Font.Size = 12;
                    Hoja.Cells[3, 53].AutoFitColumns();
                    Hoja.Cells[3, 53].Style.Font.Bold = true;
                    Hoja.Cells[3, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 53].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 53].Style.Font.Size = 12;
                    Hoja.Cells[4, 53].AutoFitColumns();
                    Hoja.Cells[4, 53].Style.Font.Bold = true;
                    Hoja.Cells[4, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 57].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 57].Style.Font.Size = 12;
                    Hoja.Cells[2, 57].AutoFitColumns();
                    Hoja.Cells[2, 57].Style.Font.Bold = true;
                    Hoja.Cells[2, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 57].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 57].Style.Font.Size = 12;
                    Hoja.Cells[3, 57].AutoFitColumns();
                    Hoja.Cells[3, 57].Style.Font.Bold = true;
                    Hoja.Cells[3, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 57].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 57].Style.Font.Size = 12;
                    Hoja.Cells[4, 57].AutoFitColumns();
                    Hoja.Cells[4, 57].Style.Font.Bold = true;
                    Hoja.Cells[4, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 60].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 60].Style.Font.Size = 12;
                    Hoja.Cells[2, 60].AutoFitColumns();
                    Hoja.Cells[2, 60].Style.Font.Bold = true;
                    Hoja.Cells[2, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 60].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 60].Style.Font.Size = 12;
                    Hoja.Cells[3, 60].AutoFitColumns();
                    Hoja.Cells[3, 60].Style.Font.Bold = true;
                    Hoja.Cells[3, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "ID_DISTRITO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "DISTRITO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.Id;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.NoDistrito +" - " + Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "DIP";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if (vots.Where(x => x.IdPartido == 9).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                       
                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdRegidores()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Regídurias");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Resultados_Actas.ResultadosExcel(4);
                    var Votos = _context.Resultados_Actas.VotosExcel(4);
                    var Causal = _context.Resultados_Actas.Causales(4);
                    var Complementaria = _context.Resultados_Actas.Complementaria(4);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = "1733";
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 51].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 51].Style.Font.Size = 12;
                    Hoja.Cells[2, 51].AutoFitColumns();
                    Hoja.Cells[2, 51].Style.Font.Bold = true;
                    Hoja.Cells[2, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 51].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 51].Style.Font.Size = 12;
                    Hoja.Cells[3, 51].AutoFitColumns();
                    Hoja.Cells[3, 51].Style.Font.Bold = true;
                    Hoja.Cells[3, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 51].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 51].Style.Font.Size = 12;
                    Hoja.Cells[4, 51].AutoFitColumns();
                    Hoja.Cells[4, 51].Style.Font.Bold = true;
                    Hoja.Cells[4, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 54].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 54].Style.Font.Size = 12;
                    Hoja.Cells[2, 54].AutoFitColumns();
                    Hoja.Cells[2, 54].Style.Font.Bold = true;
                    Hoja.Cells[2, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 54].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 54].Style.Font.Size = 12;
                    Hoja.Cells[3, 54].AutoFitColumns();
                    Hoja.Cells[3, 54].Style.Font.Bold = true;
                    Hoja.Cells[3, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 54].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 54].Style.Font.Size = 12;
                    Hoja.Cells[4, 54].AutoFitColumns();
                    Hoja.Cells[4, 54].Style.Font.Bold = true;
                    Hoja.Cells[4, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 57].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 57].Style.Font.Size = 12;
                    Hoja.Cells[2, 57].AutoFitColumns();
                    Hoja.Cells[2, 57].Style.Font.Bold = true;
                    Hoja.Cells[2, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 57].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 57].Style.Font.Size = 12;
                    Hoja.Cells[3, 57].AutoFitColumns();
                    Hoja.Cells[3, 57].Style.Font.Bold = true;
                    Hoja.Cells[3, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 57].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 57].Style.Font.Size = 12;
                    Hoja.Cells[4, 57].AutoFitColumns();
                    Hoja.Cells[4, 57].Style.Font.Bold = true;
                    Hoja.Cells[4, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 60].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 60].Style.Font.Size = 12;
                    Hoja.Cells[2, 60].AutoFitColumns();
                    Hoja.Cells[2, 60].Style.Font.Bold = true;
                    Hoja.Cells[2, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 60].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 60].Style.Font.Size = 12;
                    Hoja.Cells[3, 60].AutoFitColumns();
                    Hoja.Cells[3, 60].Style.Font.Bold = true;
                    Hoja.Cells[3, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_DEMARCACION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "DEMARCACION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAND_IND_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDemarcacion.No_Demarcacion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDemarcacion.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "REG";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if (vots.Where(x => x.IdPartido == 9).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdIndependiente != 0).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdIndependiente != 0);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdGobernadorMunicipal()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Gubernatura");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Id = _UserManager.GetUserId(User);
                    var usuario = _db.Usuarios.Find(Id);
                    var oficina = _db.Oficinas.Find(usuario.OficinaId);
                    var mun = _db.Municipios.Find(oficina.MunicipioId);
                    var totalcasillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
                    var Resultado = _context.Resultados_Actas.ResultadosExcelMunicipal(1, mun.Id);
                    var Votos = _context.Resultados_Actas.VotosExcelMunicipal(1, mun.Id);
                    var Causal = _context.Resultados_Actas.CausalesMunicipal(1, mun.Id);
                    var Complementaria = _context.Resultados_Actas.ComplementariaMunicipal(1, mun.Id);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = totalcasillas.Count();
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 47].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 47].Style.Font.Size = 12;
                    Hoja.Cells[2, 47].AutoFitColumns();
                    Hoja.Cells[2, 47].Style.Font.Bold = true;
                    Hoja.Cells[2, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 47].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 47].Style.Font.Size = 12;
                    Hoja.Cells[3, 47].AutoFitColumns();
                    Hoja.Cells[3, 47].Style.Font.Bold = true;
                    Hoja.Cells[3, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 47].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 47].Style.Font.Size = 12;
                    Hoja.Cells[4, 47].AutoFitColumns();
                    Hoja.Cells[4, 47].Style.Font.Bold = true;
                    Hoja.Cells[4, 47].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 50].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 50].Style.Font.Size = 12;
                    Hoja.Cells[2, 50].AutoFitColumns();
                    Hoja.Cells[2, 50].Style.Font.Bold = true;
                    Hoja.Cells[2, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 50].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 50].Style.Font.Size = 12;
                    Hoja.Cells[3, 50].AutoFitColumns();
                    Hoja.Cells[3, 50].Style.Font.Bold = true;
                    Hoja.Cells[3, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 50].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 50].Style.Font.Size = 12;
                    Hoja.Cells[4, 50].AutoFitColumns();
                    Hoja.Cells[4, 50].Style.Font.Bold = true;
                    Hoja.Cells[4, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 53].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 53].Style.Font.Size = 12;
                    Hoja.Cells[2, 53].AutoFitColumns();
                    Hoja.Cells[2, 53].Style.Font.Bold = true;
                    Hoja.Cells[2, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 53].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 53].Style.Font.Size = 12;
                    Hoja.Cells[3, 53].AutoFitColumns();
                    Hoja.Cells[3, 53].Style.Font.Bold = true;
                    Hoja.Cells[3, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 53].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 53].Style.Font.Size = 12;
                    Hoja.Cells[4, 53].AutoFitColumns();
                    Hoja.Cells[4, 53].Style.Font.Bold = true;
                    Hoja.Cells[4, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 56].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 56].Style.Font.Size = 12;
                    Hoja.Cells[2, 56].AutoFitColumns();
                    Hoja.Cells[2, 56].Style.Font.Bold = true;
                    Hoja.Cells[2, 56].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 56].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 56].Style.Font.Size = 12;
                    Hoja.Cells[3, 56].AutoFitColumns();
                    Hoja.Cells[3, 56].Style.Font.Bold = true;
                    Hoja.Cells[3, 56].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "GOB";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();
                        foreach (var partidos in vots)
                        {
                            col++;
                            Hoja.Cells[i, col].Value = partidos.Votos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdPresidenciaMunicipal()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Presidencias y Sindicaturas");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Id = _UserManager.GetUserId(User);
                    var usuario = _db.Usuarios.Find(Id);
                    var oficina = _db.Oficinas.Find(usuario.OficinaId);
                    var mun = _db.Municipios.Find(oficina.MunicipioId);
                    var totalcasillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
                    var Resultado = _context.Resultados_Actas.ResultadosExcelMunicipal(2, mun.Id);
                    var Votos = _context.Resultados_Actas.VotosExcelMunicipal(2, mun.Id);
                    var Causal = _context.Resultados_Actas.CausalesMunicipal(2, mun.Id);
                    var Complementaria = _context.Resultados_Actas.ComplementariaMunicipal(2, mun.Id);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = totalcasillas.Count();
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 49].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 49].Style.Font.Size = 12;
                    Hoja.Cells[2, 49].AutoFitColumns();
                    Hoja.Cells[2, 49].Style.Font.Bold = true;
                    Hoja.Cells[2, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 49].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 49].Style.Font.Size = 12;
                    Hoja.Cells[3, 49].AutoFitColumns();
                    Hoja.Cells[3, 49].Style.Font.Bold = true;
                    Hoja.Cells[3, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 49].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 49].Style.Font.Size = 12;
                    Hoja.Cells[4, 49].AutoFitColumns();
                    Hoja.Cells[4, 49].Style.Font.Bold = true;
                    Hoja.Cells[4, 49].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 52].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 52].Style.Font.Size = 12;
                    Hoja.Cells[2, 52].AutoFitColumns();
                    Hoja.Cells[2, 52].Style.Font.Bold = true;
                    Hoja.Cells[2, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 52].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 52].Style.Font.Size = 12;
                    Hoja.Cells[3, 52].AutoFitColumns();
                    Hoja.Cells[3, 52].Style.Font.Bold = true;
                    Hoja.Cells[3, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 52].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 52].Style.Font.Size = 12;
                    Hoja.Cells[4, 52].AutoFitColumns();
                    Hoja.Cells[4, 52].Style.Font.Bold = true;
                    Hoja.Cells[4, 52].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 55].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 55].Style.Font.Size = 12;
                    Hoja.Cells[2, 55].AutoFitColumns();
                    Hoja.Cells[2, 55].Style.Font.Bold = true;
                    Hoja.Cells[2, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 55].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 55].Style.Font.Size = 12;
                    Hoja.Cells[3, 55].AutoFitColumns();
                    Hoja.Cells[3, 55].Style.Font.Bold = true;
                    Hoja.Cells[3, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 55].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 55].Style.Font.Size = 12;
                    Hoja.Cells[4, 55].AutoFitColumns();
                    Hoja.Cells[4, 55].Style.Font.Bold = true;
                    Hoja.Cells[4, 55].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 58].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 58].Style.Font.Size = 12;
                    Hoja.Cells[2, 58].AutoFitColumns();
                    Hoja.Cells[2, 58].Style.Font.Bold = true;
                    Hoja.Cells[2, 58].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 58].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 58].Style.Font.Size = 12;
                    Hoja.Cells[3, 58].AutoFitColumns();
                    Hoja.Cells[3, 58].Style.Font.Bold = true;
                    Hoja.Cells[3, 58].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAND_IND_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "PYS";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if (vots.Where(x => x.IdPartido == 9).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdIndependiente != 0).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdIndependiente != 0);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdDiputadosMunicipal()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Diputaciones");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Id = _UserManager.GetUserId(User);
                    var usuario = _db.Usuarios.Find(Id);
                    var oficina = _db.Oficinas.Find(usuario.OficinaId);
                    var mun = _db.Municipios.Find(oficina.MunicipioId);
                    var totalcasillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
                    var Resultado = _context.Resultados_Actas.ResultadosExcelMunicipal(3, mun.Id);
                    var Votos = _context.Resultados_Actas.VotosExcelMunicipal(3, mun.Id);
                    var Causal = _context.Resultados_Actas.CausalesMunicipal(3, mun.Id);
                    var Complementaria = _context.Resultados_Actas.ComplementariaMunicipal(3, mun.Id);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = totalcasillas.Count();
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 50].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 50].Style.Font.Size = 12;
                    Hoja.Cells[2, 50].AutoFitColumns();
                    Hoja.Cells[2, 50].Style.Font.Bold = true;
                    Hoja.Cells[2, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 50].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 50].Style.Font.Size = 12;
                    Hoja.Cells[3, 50].AutoFitColumns();
                    Hoja.Cells[3, 50].Style.Font.Bold = true;
                    Hoja.Cells[3, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 50].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 50].Style.Font.Size = 12;
                    Hoja.Cells[4, 50].AutoFitColumns();
                    Hoja.Cells[4, 50].Style.Font.Bold = true;
                    Hoja.Cells[4, 50].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 53].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 53].Style.Font.Size = 12;
                    Hoja.Cells[2, 53].AutoFitColumns();
                    Hoja.Cells[2, 53].Style.Font.Bold = true;
                    Hoja.Cells[2, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 53].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 53].Style.Font.Size = 12;
                    Hoja.Cells[3, 53].AutoFitColumns();
                    Hoja.Cells[3, 53].Style.Font.Bold = true;
                    Hoja.Cells[3, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 53].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 53].Style.Font.Size = 12;
                    Hoja.Cells[4, 53].AutoFitColumns();
                    Hoja.Cells[4, 53].Style.Font.Bold = true;
                    Hoja.Cells[4, 53].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 57].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 57].Style.Font.Size = 12;
                    Hoja.Cells[2, 57].AutoFitColumns();
                    Hoja.Cells[2, 57].Style.Font.Bold = true;
                    Hoja.Cells[2, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 57].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 57].Style.Font.Size = 12;
                    Hoja.Cells[3, 57].AutoFitColumns();
                    Hoja.Cells[3, 57].Style.Font.Bold = true;
                    Hoja.Cells[3, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 57].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 57].Style.Font.Size = 12;
                    Hoja.Cells[4, 57].AutoFitColumns();
                    Hoja.Cells[4, 57].Style.Font.Bold = true;
                    Hoja.Cells[4, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 60].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 60].Style.Font.Size = 12;
                    Hoja.Cells[2, 60].AutoFitColumns();
                    Hoja.Cells[2, 60].Style.Font.Bold = true;
                    Hoja.Cells[2, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 60].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 60].Style.Font.Size = 12;
                    Hoja.Cells[3, 60].AutoFitColumns();
                    Hoja.Cells[3, 60].Style.Font.Bold = true;
                    Hoja.Cells[3, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);


                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "ID_DISTRITO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "DISTRITO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.Id;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.NoDistrito + " - " + Excel.LActaDetalle.LCasilla.LSeccion.LDistrito.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "DIP";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if (vots.Where(x => x.IdPartido == 9).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdRegidoresMunicipal()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Regídurias");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];
                    var Id = _UserManager.GetUserId(User);
                    var usuario = _db.Usuarios.Find(Id);
                    var oficina = _db.Oficinas.Find(usuario.OficinaId);
                    var mun = _db.Municipios.Find(oficina.MunicipioId);
                    var totalcasillas = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Resultados_Actas.ResultadosExcelMunicipal(4, mun.Id);
                    var Votos = _context.Resultados_Actas.VotosExcelMunicipal(4, mun.Id);
                    var Causal = _context.Resultados_Actas.CausalesMunicipal(4, mun.Id);
                    var Complementaria = _context.Resultados_Actas.ComplementariaMunicipal(4, mun.Id);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "CASILLAS APROBADAS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "COMPUTADAS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = totalcasillas.Count();
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 51].Value = "Causal 1 - El Paquete Electoral fue entregado sin el AECC";
                    Hoja.Cells[2, 51].Style.Font.Size = 12;
                    Hoja.Cells[2, 51].AutoFitColumns();
                    Hoja.Cells[2, 51].Style.Font.Bold = true;
                    Hoja.Cells[2, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 51].Value = "Causal 2 - Votos Nulos mayor a la diferencia entre el 1er y 2do lugar";
                    Hoja.Cells[3, 51].Style.Font.Size = 12;
                    Hoja.Cells[3, 51].AutoFitColumns();
                    Hoja.Cells[3, 51].Style.Font.Bold = true;
                    Hoja.Cells[3, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 51].Value = "Causal 3 - Total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[4, 51].Style.Font.Size = 12;
                    Hoja.Cells[4, 51].AutoFitColumns();
                    Hoja.Cells[4, 51].Style.Font.Bold = true;
                    Hoja.Cells[4, 51].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 54].Value = "Causal 4 - Total de votos del sistema diferente al total de votos del AECC";
                    Hoja.Cells[2, 54].Style.Font.Size = 12;
                    Hoja.Cells[2, 54].AutoFitColumns();
                    Hoja.Cells[2, 54].Style.Font.Bold = true;
                    Hoja.Cells[2, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 54].Value = "Causal 5 - Votos para un solo Partido Político, Coalición o Candidato Independiente";
                    Hoja.Cells[3, 54].Style.Font.Size = 12;
                    Hoja.Cells[3, 54].AutoFitColumns();
                    Hoja.Cells[3, 54].Style.Font.Bold = true;
                    Hoja.Cells[3, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 54].Value = "Causal 6 - Acta ilegible";
                    Hoja.Cells[4, 54].Style.Font.Size = 12;
                    Hoja.Cells[4, 54].AutoFitColumns();
                    Hoja.Cells[4, 54].Style.Font.Bold = true;
                    Hoja.Cells[4, 54].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 57].Value = "Causal 7 - Acta con alteraciones";
                    Hoja.Cells[2, 57].Style.Font.Size = 12;
                    Hoja.Cells[2, 57].AutoFitColumns();
                    Hoja.Cells[2, 57].Style.Font.Bold = true;
                    Hoja.Cells[2, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 57].Value = "Causal 8 - Paquete con muestras de alteraciones";
                    Hoja.Cells[3, 57].Style.Font.Size = 12;
                    Hoja.Cells[3, 57].AutoFitColumns();
                    Hoja.Cells[3, 57].Style.Font.Bold = true;
                    Hoja.Cells[3, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 57].Value = "Causal 9 - Ciudadanos que votaron diferente al total de votos del sistema";
                    Hoja.Cells[4, 57].Style.Font.Size = 12;
                    Hoja.Cells[4, 57].AutoFitColumns();
                    Hoja.Cells[4, 57].Style.Font.Bold = true;
                    Hoja.Cells[4, 57].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[2, 60].Value = "Causal 10 - Boletas sobrantes más ciudadanos que votaron mayor a boletas entregadas";
                    Hoja.Cells[2, 60].Style.Font.Size = 12;
                    Hoja.Cells[2, 60].AutoFitColumns();
                    Hoja.Cells[2, 60].Style.Font.Bold = true;
                    Hoja.Cells[2, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 60].Value = "Causal 11 - Boletas sobrantes más total de votos del sistema mayor a boletas entregadas";
                    Hoja.Cells[3, 60].Style.Font.Size = 12;
                    Hoja.Cells[3, 60].AutoFitColumns();
                    Hoja.Cells[3, 60].Style.Font.Bold = true;
                    Hoja.Cells[3, 60].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_DEMARCACION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "DEMARCACION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO_ACTA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "PAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MC";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "VIVA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MLN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "RSP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "FXM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAND_IND_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRI";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PAN_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PRI_PRD";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_PVEM";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PT_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_MORENA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "PVEM_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MORENA_NAN";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;
                    Hoja.Cells[6, col].Value = "NO_REGISTRADOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NULOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_VOTOS_SISTEMA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLETAS_SOBRANTES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONAS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "REPRESENTANTES_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "TOTAL_CIUDADANOS_VOTARON";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SACADOS_URNA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "CAUSAL_1";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_2";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_3";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_4";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_5";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_6";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_7";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_8";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_9";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_10";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CAUSAL_11";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TOTAL_CAUSAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Resultado)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDemarcacion.No_Demarcacion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LDemarcacion.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LActaDetalle.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = "REG";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        var vots = Votos.Where(x => x.IdVotosActa == Excel.IdRegistroVotos).OrderBy(x => x.IdDetalleVotosActa).ToList();

                        col++;
                        if (vots.Where(x => x.IdPartido == 9).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 9);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 11).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 11);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 12).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 12);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 13).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 13);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 14).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 14);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 16).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 16);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 17).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 17);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 18).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 18);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 19).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 19);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 21).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 21);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 22).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 22);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 23).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 23);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdPartido == 24).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdPartido == 24);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdIndependiente != 0).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdIndependiente != 0);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 93).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 93);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 94).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 94);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 95).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 95);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 96).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 96);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 97).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 97);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 98).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 98);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 99).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 99);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 100).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 100);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 101).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 101);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 102).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 102);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 103).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 103);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 104).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 104);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 105).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 105);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 106).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 106);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (vots.Where(x => x.IdCombinacion == 107).Count() != 0)
                        {
                            var totalvoto = vots.FirstOrDefault(x => x.IdCombinacion == 107);
                            Hoja.Cells[i, col].Value = totalvoto.Votos;
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.NoRegistrados;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nulos;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.Total;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.TotalSistema;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);


                        var validacion = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).ToList();
                        if (validacion.Count() != 0)
                        {
                            var Comple = Complementaria.Where(x => x.IdActaDetalle == Excel.LActaDetalle.IdActaDetalle).FirstOrDefault();
                            col++;
                            Hoja.Cells[i, col].Value = Comple.Sobrantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosCiudadanos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosRepresentantes;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.TotalVotos;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = Comple.VotosUrnas;
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                        else
                        {
                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                            col++;
                            Hoja.Cells[i, col].Value = "----";
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                            Hoja.Cells[i, col].AutoFitColumns();
                            Hoja.Cells[i, col].Style.Font.Bold = false;
                            Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        var Caus = Causal.Where(x => x.CasillaId == Excel.LActaDetalle.LCasilla.Id).FirstOrDefault();
                        col++;
                        if (Caus.Causal1 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal2 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal3 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal4 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal5 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        };
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal6 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Caus.Causal7 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal8 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal9 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Caus.Causal10 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        if (Caus.Causal11 == true)
                        {
                            Hoja.Cells[i, col].Value = "Aplica";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "-";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Caus.Total_Causales;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }
                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdPaquetes()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Paquetes Recibidos");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Casilla.GetAll().Where(x=> x.Recibido == true).ToList();
                    var Paquetes = _context.Resultados_Actas.Paquetes();
                    //var Causal = _context.Resultados_Actas.Causales(1);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "PAQUETES ESPERADOS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "RECIBIDOS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = "1733";
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                   

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "FECHA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "HORA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PUESTO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "MEDIO_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SOBRE_PREP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLSA_CME";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "ALTERACIONES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Paquetes)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.FechaRecepcion.ToString("dd - MM - yyyy");
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.HoraRecepcion.ToString("HH : mm");
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nombre_Entrega;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if(Excel.Cargo_Entrega == 1)
                        {
                            Hoja.Cells[i, col].Value = "Presidente/a de Casilla";
                        }
                        else if(Excel.Cargo_Entrega == 2)
                        {
                            Hoja.Cells[i, col].Value = "Secretario/a de Casilla";
                        }
                        else if(Excel.Cargo_Entrega == 3)
                        {
                            Hoja.Cells[i, col].Value = "Escrutador/a";
                        }
                        else if (Excel.Cargo_Entrega == 4)
                        {
                            Hoja.Cells[i, col].Value = "Otro/a";
                        }
                       
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                       
                        if(Excel.Medio_Entrega == 1)
                        {
                            Hoja.Cells[i, col].Value = "DAT - Dispositivo de Acopio y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 2)
                        {
                            Hoja.Cells[i, col].Value = "CRyT FIJO -Centro de Recepción y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 3)
                        {
                            Hoja.Cells[i, col].Value = "CRyT ITINERANTE - Centro de Recepción y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 4)
                        {
                            Hoja.Cells[i, col].Value = "DAT - CRyT FIJO";
                        }
                        else if (Excel.Medio_Entrega == 5)
                        {
                            Hoja.Cells[i, col].Value = "DAT - CRyT ITINERANTE";
                        }
                            Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if(Excel.SobrePrep == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;

                        if (Excel.PaqueteElec == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;

                        if (Excel.Alteracion == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        

                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }

        public byte[] BdPaquetesINE()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Paquetes Recibidos");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Resultado = _context.Casilla.GetAll().Where(x => x.Recibido == true).ToList();
                    var Paquetes = _context.Resultados_Actas.PaquetesINE();
                    //var Causal = _context.Resultados_Actas.Causales(1);

                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[1, col].Value = "ID_ESTADO";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "NOMBRE_ESTADO";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "ID_DISTRITO_FED";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "CABECERA_DISTRITAL_FED";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "ID_DISTRITO_LOC";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "CABECERA_DISTRITAL_LOC";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "ID_MUNICIPIO";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[1, col].Value = "MUNICIPIO";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "SECCION";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "ID_CASILLA";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "TIPO_CASILLA";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "FECHA_HORA_RECEPCION";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "ESTADO_DEL_PAQUETE";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "CARGO_RESPONSABLE_ENTREGA";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "PAQUETE_SELLADO";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "PAQUETE_SELLADO_ETIQUETA_SEG";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[1, col].Value = "ESTATUS_PAQUETE";
                    Hoja.Cells[1, col].Style.Font.Size = 12;
                    Hoja.Cells[1, col].AutoFitColumns();
                    Hoja.Cells[1, col].Style.Font.Bold = true;
                    Hoja.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 2;
                    foreach (var Excel in Paquetes)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "--";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "--";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LDistrito.Id;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LDistrito.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LMunicipio.Id;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LMunicipio.Municipio;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LTipoCasilla.Siglas;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        Hoja.Cells[i, col].Value = Excel.FechaRecepcion.ToString("dd / MM / yyyy") + " " + Excel.HoraRecepcion.ToString("HH : mm"); 
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);                        
                        
                        col++;
                        if(Excel.Alteracion == false)
                        {
                            if(Excel.Firma == true)
                            {
                                Hoja.Cells[i, col].Value = " 1 ";
                            }
                            else
                            {
                                Hoja.Cells[i, col].Value = " 2 ";
                            }
                        }
                        else
                        {
                            if (Excel.Firma == true)
                            {
                                Hoja.Cells[i, col].Value = " 3 ";
                            }
                            else
                            {
                                Hoja.Cells[i, col].Value = " 4 ";
                            }
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                      
                        col++;
                        if (Excel.Cargo_Entrega == 1)
                        {
                            Hoja.Cells[i, col].Value = "P";
                        }
                        else if (Excel.Cargo_Entrega == 2)
                        {
                            Hoja.Cells[i, col].Value = "S";
                        }
                        else if (Excel.Cargo_Entrega == 3)
                        {
                            Hoja.Cells[i, col].Value = " 1 ";
                        }
                        else if (Excel.Cargo_Entrega == 4)
                        {
                            Hoja.Cells[i, col].Value = " 2 ";
                        }

                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if(Excel.Alteracion == false)
                        {
                            Hoja.Cells[i, col].Value = "S";

                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "N";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Excel.Cinta == true)
                        {
                            Hoja.Cells[i, col].Value = "S";
                        }
                        else 
                        {
                            Hoja.Cells[i, col].Value = "N";
                        }                        
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                             
                        col++;                     
                        Hoja.Cells[i, col].Value = "2";                        
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        i++;

                    }
                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }
        public byte[] BdPaquetesMunicipal()
        {
            //Uso memory estream para poder crear el libro de excel we 
            using (MemoryStream ms = new MemoryStream())
            {
                //Debes indicar que es de uso no comercial para que no tengas pedos
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                //Este paquete nos facilita la creacion del libro y cada una de sus hojas we
                using (ExcelPackage ep = new ExcelPackage())
                {
                    //Le agrego la hoja de gubernatura
                    ep.Workbook.Worksheets.Add("Paquetes Recibidos");
                    ExcelWorksheet Hoja = ep.Workbook.Worksheets[0];

                    //Empiezo a pintar las cedas uno a uno
                    var Id = _UserManager.GetUserId(User);
                    var usuario = _db.Usuarios.Find(Id);
                    var oficina = _db.Oficinas.Find(usuario.OficinaId);
                    var mun = _db.Municipios.Find(oficina.MunicipioId);
                    var Resultado = _context.Casilla.GetAll().Where(x => x.MunicipioId == mun.Id).ToList();
                    var Paquetes = _context.Resultados_Actas.PaquetesMunicipal(mun.Id);
                    //var Causal = _context.Resultados_Actas.Causales(1);
                    //Informacion primeras columnas//
                    Hoja.Cells[1, 1].Value = DateTime.Now.ToString("HH:mm") + " horas (UTC-6)";
                    Hoja.Cells[1, 1].Style.Font.Size = 12;
                    Hoja.Cells[1, 1].AutoFitColumns();
                    Hoja.Cells[1, 1].Style.Font.Bold = true;
                    Hoja.Cells[1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    Hoja.Cells[2, 1].Value = DateTime.Now.ToLongDateString();
                    Hoja.Cells[2, 1].Style.Font.Size = 12;
                    Hoja.Cells[2, 1].AutoFitColumns();
                    Hoja.Cells[2, 1].Style.Font.Bold = true;
                    Hoja.Cells[2, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 1].Value = "PAQUETES ESPERADOS";
                    Hoja.Cells[3, 1].Style.Font.Size = 12;
                    Hoja.Cells[3, 1].AutoFitColumns();
                    Hoja.Cells[3, 1].Style.Font.Bold = true;
                    Hoja.Cells[3, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[3, 2].Value = "RECIBIDOS";
                    Hoja.Cells[3, 2].Style.Font.Size = 12;
                    Hoja.Cells[3, 2].AutoFitColumns();
                    Hoja.Cells[3, 2].Style.Font.Bold = true;
                    Hoja.Cells[3, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 1].Value = Resultado.Count();
                    Hoja.Cells[4, 1].Style.Font.Size = 12;
                    Hoja.Cells[4, 1].AutoFitColumns();
                    Hoja.Cells[4, 1].Style.Font.Bold = true;
                    Hoja.Cells[4, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    Hoja.Cells[4, 2].Value = Resultado.Where(x=> x.Recibido == true).Count();
                    Hoja.Cells[4, 2].Style.Font.Size = 12;
                    Hoja.Cells[4, 2].AutoFitColumns();
                    Hoja.Cells[4, 2].Style.Font.Bold = true;
                    Hoja.Cells[4, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                    //Estas son los encabezados
                    int col = 1;
                    Hoja.Cells[6, col].Value = "ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "NOMBRE ESTADO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "MUNICIPIO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "CABECERA_MUNICIPAL";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "SECCION";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "ID_CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "TIPO CASILLA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;
                    Hoja.Cells[6, col].Value = "EXT_CONTIGUA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "FECHA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "HORA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PERSONA_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "PUESTO";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "MEDIO_ENTREGA";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "SOBRE_PREP";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "BOLSA_CME";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;

                    Hoja.Cells[6, col].Value = "ALTERACIONES";
                    Hoja.Cells[6, col].Style.Font.Size = 12;
                    Hoja.Cells[6, col].AutoFitColumns();
                    Hoja.Cells[6, col].Style.Font.Bold = true;
                    Hoja.Cells[6, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    col++;


                    //temrina de poner los encabezados we 

                    //Despues recorres la lista que vallas a obtener voy a simular que llenamos algo para que veas el resultado


                    int i = 7;
                    foreach (var Excel in Paquetes)
                    {

                        col = 1;
                        Hoja.Cells[i, col].Value = "18";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = "NAYARIT";
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.MunicipioId;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.LMunicipio.Cabecera_Municipal;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.LSeccion.Seccion;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.LCasilla.NoCasilla;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LCasilla.LTipoCasilla.Nombre;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        Hoja.Cells[i, col].Value = Excel.LCasilla.ExtContigua;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.FechaRecepcion.ToString("dd - MM - yyyy");
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.HoraRecepcion.ToString("HH : mm");
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;
                        Hoja.Cells[i, col].Value = Excel.Nombre_Entrega;
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;
                        if (Excel.Cargo_Entrega == 1)
                        {
                            Hoja.Cells[i, col].Value = "Presidente/a de Casilla";
                        }
                        else if (Excel.Cargo_Entrega == 2)
                        {
                            Hoja.Cells[i, col].Value = "Secretario/a de Casilla";
                        }
                        else if (Excel.Cargo_Entrega == 3)
                        {
                            Hoja.Cells[i, col].Value = "Escrutador/a";
                        }
                        else if (Excel.Cargo_Entrega == 4)
                        {
                            Hoja.Cells[i, col].Value = "Otro/a";
                        }

                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;


                        if (Excel.Medio_Entrega == 1)
                        {
                            Hoja.Cells[i, col].Value = "DAT - Dispositivo de Acopio y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 2)
                        {
                            Hoja.Cells[i, col].Value = "CRyT FIJO -Centro de Recepción y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 3)
                        {
                            Hoja.Cells[i, col].Value = "CRyT ITINERANTE - Centro de Recepción y Traslado";
                        }
                        else if (Excel.Medio_Entrega == 4)
                        {
                            Hoja.Cells[i, col].Value = "DAT - CRyT FIJO";
                        }
                        else if (Excel.Medio_Entrega == 5)
                        {
                            Hoja.Cells[i, col].Value = "DAT - CRyT ITINERANTE";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        if (Excel.SobrePrep == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;

                        if (Excel.PaqueteElec == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        col++;

                        if (Excel.Alteracion == true)
                        {
                            Hoja.Cells[i, col].Value = "Si";
                        }
                        else
                        {
                            Hoja.Cells[i, col].Value = "No";
                        }
                        Hoja.Cells[i, col].Style.Font.Size = 12;
                        Hoja.Cells[i, col].AutoFitColumns();
                        Hoja.Cells[i, col].Style.Font.Bold = false;
                        Hoja.Cells[i, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);



                        i++;

                    }



                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray(); //convierto el excle en arreglo de bytes para poderlo mandar por http
                    return buffer;
                }
            }
        }
    }
}