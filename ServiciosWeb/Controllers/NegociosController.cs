using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using ServiciosWeb.Models;

namespace ServiciosWeb.Controllers
{
    public class NegociosController : Controller
    {

        SqlConnection con = new SqlConnection("server=.;database=Negocios2017;uid=sa;pwd=sql");


        List<tb_clientes> listado() {
            List<tb_clientes> lista = new List<tb_clientes>();

            SqlCommand cmd = new SqlCommand("select * from tb_clientes",con);
            con.Open();

           SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                tb_clientes reg = new tb_clientes();

                reg.idcliente = dr.GetString(0);
                reg.nombrecia = dr.GetString(1);
                reg.direccion = dr.GetString(2);
                reg.idpais = dr.GetString(3);
                reg.telefono = dr.GetString(4);

                lista.Add(reg);

            }

            con.Close();
            dr.Close();
            return lista;
        }


        int numereg = 10;
        // GET: Negocios
        public ActionResult clienteListado( int ? pag=0)
        {
            int c = listado().Count();

            ViewBag.numereg = (c % numereg != 0 ) ?( c / numereg + 1 ):( c / numereg);


            int pagact = (int)pag;
            int regini = pagact * numereg;
            int regfin = regini + numereg;
            List<tb_clientes> lista = new List<tb_clientes>();

            for (int i = regini; i < regfin; i++) {
                if (i == c) break;
                lista.Add(listado().ToList()[i]);
            }
            
            return View(lista);
            
        }
    }
}