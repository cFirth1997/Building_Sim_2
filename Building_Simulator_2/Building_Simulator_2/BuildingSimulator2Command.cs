using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace Building_Simulator_2
{
    [System.Runtime.InteropServices.Guid("6086473e-0e60-4d46-8e4d-369329e1e303")]
    public class BuildingSimulator2Command : Command
    {
        public BuildingSimulator2Command()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static BuildingSimulator2Command Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "BuildingSimulator"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
           
            RhinoApp.WriteLine("Building simulator begins");

          

            //getBuildingSite();    // select curve and set as site explode and measure lengths
            //GetLengths();                        // check the max and the min of the site, is it the right size for building
            //FindFront();                                  // set front/side and back parameters
            // BreakUpSite();                               //create the deep soil percentage
            //FindBuildingParameters();                                    //take out the other percentage of site thats buildable
            //SplitBuilding();                                             // create two buildings
            //CreateBlocks();                                            // extrude up to maximums storys 
            //CreateStoreys                                        //divide for levels                                     
            // set colour scheme for different 
           
            
            
            
          
        {
        
            GetObject obj = new GetObject();
        obj.GeometryFilter = Rhino.DocObjects.ObjectType.Curve;
            obj.SetCommandPrompt("Please select a curve represent the site.");

            GetResult res = obj.Get();

        Curve site;

            if (res != GetResult.Object)
            {
                RhinoApp.WriteLine(" the user did not select a curve");
                return Result.Failure;

           }

            if (obj.ObjectCount == 1)

             {
                site = obj.Object(0).Curve();

}

            else
            {
                return Result.Failure;
            
            }
            doc.Views.Redraw();
            RhinoApp.WriteLine("simulator is complete");

            return Result.Success;




     
        }

      

        }
    }
}
