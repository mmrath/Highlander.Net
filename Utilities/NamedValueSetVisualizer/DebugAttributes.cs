/*
 Copyright (C) 2019 Alex Watt (alexwatt@hotmail.com)

 This file is part of Highlander Project https://github.com/alexanderwatt/Highlander.Net

 Highlander is free software: you can redistribute it and/or modify it
 under the terms of the Highlander license.  You should have received a
 copy of the license along with this program; if not, license is
 available at <https://github.com/alexanderwatt/Highlander.Net/blob/develop/LICENSE>.

 This program is distributed in the hope that it will be useful, but WITHOUT
 ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 FOR A PARTICULAR PURPOSE.  See the license for more details.
*/

#region Using directives

using System.Diagnostics;

using Microsoft.VisualStudio.DebuggerVisualizers;
using Orion.NVS.DebuggerVisualizer;
using Orion.Util.NamedValues;

#endregion

#region Attributes


[assembly: DebuggerVisualizer(typeof(DebuggerSide), typeof(VisualizerObjectSource), Target = typeof(NamedValueSet), Description = "NamedValueSet Visualizer")]


#endregion
