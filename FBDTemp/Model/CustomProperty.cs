using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
  public  class CustomProperty : Notifier
    {
      private string _name;
      private bool _iswritable;
      private bool _isvisible;
      private object _value;
      private Type _type;
      private string _category;

      public CustomProperty(string s_name, bool b_iswritable, bool b_isvisible, Type t_type )
      {
          this._name = s_name;
          this._iswritable = b_iswritable;
          this._isvisible = b_isvisible;
          this._type = t_type;
         // this._value = 
          
      }

      public string Name 
      { 
          get { return _name; }
          set {
              if (_name != value)
              {
                  _name = value;
                  NotifyChanged("Name");
              }
          } 
      }
      public bool IsWritable
      {
          get { return _iswritable; }
          set { _iswritable = value; }
      }
      public bool IsVisible
      {
          get { return _isvisible; }
          set { _isvisible = value; }
      }
      public object Value
      {
          get { return _value; }
          set 
          {
              if (_value != value)
              {
                  _value = value;
                  NotifyChanged("Value");
              }
          }
      }
      public Type TypeValue
      {
          get { return _type; }
      }
      public string Category
      {
          get { return _category; }
          set { _category = value; }
      }
    }
}
