﻿using System;
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
            get { return "BuildingSimulator2Command"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---
            RhinoApp.WriteLine("The {0} command will add a line right now.", EnglishName);

            Point3d pt0;
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select the start point");
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No start point was selected.");
                    return getPointAction.CommandResult();
                }
                pt0 = getPointAction.Point();
            }

            Point3d pt1;
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select the end point");
                getPointAction.SetBasePoint(pt0, true);
                getPointAction.DynamicDraw +=
                  (sender, e) => e.Display.DrawLine(pt0, e.CurrentPoint, System.Drawing.Color.DarkRed);
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No end point was selected.");
                    return getPointAction.CommandResult();
                }
                pt1 = getPointAction.Point();
            }

            doc.Objects.AddLine(pt0, pt1);
            doc.Views.Redraw();
            RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName);

            // ---

            return Result.Success;
        }
    }
}
