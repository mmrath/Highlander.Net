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

using System;

namespace Orion.Analytics.Equities 
{
  public class Stock : IComparable
  {
      public double Dollars { get; set; }
      public string StockName { get; set; }
    
    public Stock(String stockName, Double dollars)
    {
      StockName = stockName;
      Dollars = dollars;
    }

    int IComparable.CompareTo(object obj)
    {
      var c = (Stock)obj;
      if (Dollars < c.Dollars)
        return 1;
      if (Dollars == c.Dollars)
          return 0;
      return -1;
    }
  }
}
