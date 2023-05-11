using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.EditorInput;
using LayerUpd;

[assembly:CommandClass(typeof(LayerUpd.UpdateLayers))]
namespace LayerUpd
{
    public class UpdateLayers
    {
        [CommandMethod("ABCDEF")]
        public void ModifyLayer()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\abcd.txt"))
            {
                writer.WriteLine("Monica Rathbun");
            }
            try
            {
                Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database database = doc.Database;
                Editor ed = doc.Editor;
                ed.WriteMessage("Hello this is hit");

                using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\abcd.txt"))
                {
                    writer.WriteLine("Monica Rathbun");
                }


                //File.WriteAllText(@"C:\Users\Public\abcd.txt", doc.ToString());

                using (Transaction trans = database.TransactionManager.StartTransaction())
                {
                    LayerTable lTable = trans.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;

                    foreach(ObjectId ltId in lTable)
                    {
                        ed.WriteMessage("Hello this is hit");
                        ed.WriteMessage(ltId.ToString());
                        //Console.WriteLine(ltId.ToString());
                    }
                }

            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\error.txt"))
                {
                    writer.WriteLine(ex.Message.ToString());
                }


                //File.WriteAllText(@"C:\Users\Public\error.txt", ex.Message.ToString());
            }
        }

    }
}