using System;
using System.Collections.Generic;
using HairSalon;

namespace HairSalon.Models
{
  public class StylistClass
  {
    private string _name;

    public StylistClass(string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }
  }
}
