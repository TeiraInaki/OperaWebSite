using OperaWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperaWebSite.Data
{
    public class OperaInitializer : DropCreateDatabaseAlways<OperaDBContext>
    {
        //Cada vez que inicio mi app se crea la base de datos con los siguientes datos, al cerrarla se borra.
        //Ideal para testing en etapa de desarrollo
        protected override void Seed(OperaDBContext context)
        {
            var operas = new List<Opera>
            {
                new Opera
                {
                    Title = "Cosi Fan Tute",
                    Year = 1790,
                    Composer = "Mozart"
                }
            };

            //Metodo foreach con expresion lambda
            operas.ForEach(s => context.Operas.Add(s));

            context.SaveChanges();
        }
    }
}