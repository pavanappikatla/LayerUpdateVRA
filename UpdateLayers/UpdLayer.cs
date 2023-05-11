
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using System.IO;

namespace UpdateLayers
{
    public class UpdLayer
    {

        [CommandMethod("Pavan",CommandFlags.UsePickSet)]
        public void ModifyLayer()
        {
            try
            {
                WindowsFormsApp1.Program.Main();
            }
            catch(System.Exception ex) {
                File.WriteAllText ("Errrlog.txt", ex.ToString());
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ex.ToString());
            }
           
        }
    }
}

/*
[CommandMethod("CHANGELAYER", CommandFlags.UsePickSet)]
public static void ChangeLayerSample()
{
    var doc = Application.DocumentManager.MdiActiveDocument;
    var db = doc.Database;
    var ed = doc.Editor;

    // get the selected enities (return if none)
    var psr = ed.SelectImplied();
    if (psr.Status != PromptStatus.OK)
        return;

    // start a transaction
    using (var tr = db.TransactionManager.StartTransaction())
    {
        var layerName = "foo";

        // check if the layer already exists
        var lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
        if (!lt.Has(layerName))
        {
            // if not create it
            var layer = new LayerTableRecord()
            {
                Name = layerName,
                Color = Color.FromRgb(200, 30, 80)
            };
            lt.UpgradeOpen();
            lt.Add(layer);
        }

        // set this layer to selected entites
        foreach (SelectedObject so in psr.Value)
        {
            var ent = (Entity)tr.GetObject(so.ObjectId, OpenMode.ForWrite);
            ent.Layer = layerName;
        }
        tr.Commit();
    }
}*/
