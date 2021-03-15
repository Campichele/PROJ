using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BergerSebastien2.Models;

namespace BergerSebastien2.Controller
{
    class FormGeomController
    {
        private NorthwindContext Context;
        private List<FormGeom> listForm;

        public FormGeomController()
        {
            try
            {
                Context = new NorthwindContext();
                listForm = new List<FormGeom>();
                var q = from d in Context.FormGeoms
                        select d;
                foreach (var item in q)
                {
                    listForm.Add(item);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void displayList()
        {
            Console.WriteLine("Liste des formes");
            Console.WriteLine("===================");
            foreach(var item in listForm)
            {
                Console.WriteLine("FormName: " + item.FormName);
                Console.WriteLine("Dim1 :" + item.Dim1);
                Console.WriteLine("Dim2 :" + item.Dim2);
                Console.WriteLine("Surface : " + item.calculateSurface());
                Console.WriteLine("----------------------------");
            }
        }
    }
}
