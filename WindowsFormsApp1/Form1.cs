using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Hit try block");
                var doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                var database = doc.Database;
                var editor = doc.Editor;
                //editor.Command(CommandFlags.UsePickSet);

                //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Editor db etc fine");
                //editor.WriteMessage("Hello this is hit");

                using (Transaction trans = database.TransactionManager.StartTransaction())
                {
                    //editor.WriteMessage("Hello this is hit 1");
                   // LayerTable lTable = trans.GetObject(database.LayerTableId, OpenMode.ForRead) as LayerTable;
                    //editor.WriteMessage("Hello this is hit 2");
                   // Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Retriedved layer table");

                    var selection = editor.SelectImplied();

                    //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(selection.Status.ToString());
                    if (selection.Status == PromptStatus.OK)
                    {
                        //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Selection status is fine");

                        //var selectedObjects = selection.Value;
                        String newLayerName;
                            if (radioButton1.Checked == true)
                            {
                                newLayerName = radioButton1.Text;
                            }
                            else if (radioButton2.Checked == true)
                            {
                                newLayerName = radioButton2.Text;
                            }
                            else if (radioButton3.Checked == true)
                            {
                                newLayerName = radioButton3.Text;
                            }
                            else
                            {
                                newLayerName = radioButton4.Text;
                            }

                        //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Radio buttons ok");

                        //bool writeMode = false;
                        //var selObj = 0;
                        using (DocumentLock dockLock = doc.LockDocument())
                        {
                            foreach (SelectedObject so in selection.Value)
                            {
                                //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Selected objects loop");
                                // var selObj = (Entity)trans.GetObject(so.ObjectId)

                                try
                                {
                                    var selObj = (Entity)trans.GetObject(so.ObjectId, OpenMode.ForWrite);
                                    selObj.Layer = newLayerName;
                                }
                                catch(System.Exception ex)
                                {
                                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Doubtful Area"+ex.ToString());
                                }


                                //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Before Crucial Step:"+selObj.Layer.ToString());

                                //Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog();

                               
                                //trans.Commit();

                            }
                            trans.Commit();
                        }
                           
                        Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(selection.Value.Count.ToString()+" objects layer updated to "+newLayerName+" Successfully");
                        //PDF_A-ANNO-DIMS


                        /* foreach(Object id in selectedObjects.GetObjectIds())
                         {
                             DBObject abc = trans.GetObject((ObjectId)id, OpenMode.ForRead);
                             var curObj = (Entity)trans.GetObject((ObjectId)id, OpenMode.ForWrite);
                             //The following line works.
                             String objectType = abc.GetType().ToString();
                             Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(abc.GetType().ToString());

                             LayerTable lt = (LayerTable)trans.GetObject(database.LayerTableId, OpenMode.ForRead);
                             foreach(ObjectId layerId in lt)
                             {
                                 LayerTableRecord ltRecord = (LayerTableRecord)trans.GetObject(layerId, OpenMode.ForRead);
                                 Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Hip Hip"+ltRecord.Name);
                             }



                                 /*switch(objectType)
                                 {
                                     case "Autodesk.AutoCAD.DatabaseServices.Line":
                                         curObj.Layer = "Required Layer";
                                         break;

                                 }


                                 Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(id.ToString());

                         }*/


                        //var obj = id.GetObject(OpenMode.ForWrite);
                        //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(id.ObjectClass.Name);

                    }
                    else
                    {
                        Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("No Object Selected. Select atleast one object");
                    }



            
                }

            }
            catch (System.Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(ex.ToString());
                File.WriteAllText("Errrlog.txt", ex.ToString());
                //editor.WriteMessage("Hello this is hit 4");
            }




            //CheckedListBox.CheckedItemCollection selectedLayer = checkedListBox1.CheckedItems;
            //foreach(ListViewItem item in selectedLayer)
            //{
            //MessageBox.Show(item.Name);
            //}


        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int formWidth = this.Width;
            this.Location = new Point(screenWidth - formWidth-50, 0);
        }

       
    }
}
