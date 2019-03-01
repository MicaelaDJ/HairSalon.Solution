using System;
using System.Collections.Generic;
using HairSalon;

namespace HairSalon.Models
{
  public class StylistClass
  {
    private int _id;
    private string _name;

    public StylistClass(string name)
    {
      _name = name;
    }

    public StylistClass(int id, string name)
    {
      _id = id;
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }
  }
}
