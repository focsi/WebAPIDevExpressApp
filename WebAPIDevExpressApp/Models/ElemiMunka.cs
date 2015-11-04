using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.OData.Query;

namespace WebAPIDevExpressApp.Models
{
    public class ElemiMunka
    {
        [Key]
        public decimal AZONOSITO { get; set; }
        public string MAIN { get; set; }
        public string KESZULTSEG { get; set; }
        public string PRIORITAS { get; set; }
        public string IDO { get; set; }
        public string BEJSZ { get; set; }
        public string MUNKASZAM { get; set; }
        public string CIM { get; set; }
        public string START_IDO { get; set; }
        public decimal KOMPLEX_MUNKA_AZONOSITO { get; set; }
        public decimal SORSZAM { get; set; }
        public decimal STATUSZ { get; set; }
        public System.DateTime TERVEZETT_KEZDET_IDO { get; set; }
        public System.DateTime TERVEZETT_VEG_IDO { get; set; }
        public System.DateTime VEGREHAJTAS_KEZDET_IDO { get; set; }
        public System.DateTime VEGREHAJTAS_VEG_IDO { get; set; }
        public decimal KANORMTEV_AZONOSITO { get; set; }
        public decimal KOV_KOPRIO_AZONOSITO { get; set; }
        public string KOV_KANORMTEV_MEGNEVEZES { get; set; }
        public string KOV_KOPRIO_MEGNEVEZES { get; set; }
        public System.DateTime MUNKAKEZDES { get; set; }
        public System.DateTime MUNKABEFEJEZES { get; set; }
        public System.DateTime OSYSDATE { get; set; }
        public string MAIN_ICON { get; set; }
        public string ICON0 { get; set; }
        public string ICON1 { get; set; }

        private const int COUNT = 1000;
        public static int GetCount()
        {
            return COUNT;
        }
        public static IEnumerable<ElemiMunka> GetAll()
        {
            using (MIRTUSZContext.MIRTUSZDataContext mirtuszDC = new MIRTUSZContext.MIRTUSZDataContext())
            {
                mirtuszDC.Connection.Open();
                return mirtuszDC.VELEMIMUNKAINMLISTs.Take(COUNT).Select(dbe => new ElemiMunka()
                {
                    AZONOSITO = dbe.AZONOSITO,
                    CIM = dbe.CIM,
                    MAIN = dbe.MAIN,
                    KESZULTSEG = dbe.KESZULTSEG,
                    PRIORITAS = dbe.PRIORITAS
                }).ToArray();
            }
        }

        internal static IEnumerable<ElemiMunka> GetPage(int skip, int top)
        {
            using (MIRTUSZContext.MIRTUSZDataContext mirtuszDC = new MIRTUSZContext.MIRTUSZDataContext())
            {
                mirtuszDC.Connection.Open();
                return mirtuszDC.VELEMIMUNKAINMLISTs.Skip(skip).Take(top).Select(dbe => new ElemiMunka()
                {
                    AZONOSITO = dbe.AZONOSITO,
                    CIM = dbe.CIM,
                    MAIN = dbe.MAIN,
                    KESZULTSEG = dbe.KESZULTSEG,
                    PRIORITAS = dbe.PRIORITAS
                }).ToArray();
            }

        }
    }
}