using FBDTemp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBDTemp.Model
{
    public class InputAlgoritm<T> : IIOAlgoritm<T>
    {
        #region Connections
        protected List<IConnectionModel> _connection;
     /*   public List<IConnectionModel> Connection
        {
            get { return _connection; }
            set
            {
                if (_connection == value) return;
                _connection = value;
                AlgoritmUpdated(this, new AlgoritmEventArgs(this, CommandType.None));
            }
        }*/
        public IConnectionModel AddConnection(IConnectionModel item)
        {

            if (!_connection.Contains(item))
            {
               //нужна проверка на соответсвие типов данных
                _connection.Add(item);
            }
            else return null;

            return item;

        }
        public IConnectionModel RemoveConnection(IConnectionModel item)
        {
            if (_connection.Contains(item))
                _connection.Remove(item);
            else return null;

            return item;
        }
        public void RemoveAllConnections()
        {
            _connection.RemoveAll(item => item is IConnectionModel);
        }
        #endregion

        #region Ctors
        public InputAlgoritm(T value) :this()
        {
            _output = value;
             Init();
        }
        public InputAlgoritm()
        {
            _algoritmName = "Выход";
            _visualContent = _algoritmName;
             Init();
        }
        public InputAlgoritm(string name)
       {
            _algoritmName = name;
            _visualContent = _algoritmName;
            Init();
        }
        public InputAlgoritm(string name, T obj)
        {
            _algoritmName = name;
            _visualContent = _algoritmName;
            _output = obj;
            Init();
        }
        #endregion
        private void Init()
        {
            _connection = new List<IConnectionModel>();
            _parametrs = new SettingCollection(this);
        }
        

        #region IIOAlgoritm inherit
        public virtual void Run()
        {
          //  AlgoritmCalculated(this, new EventArgs());
        }
        public virtual void Reset()
      {
          _output = (T)Activator.CreateInstance(typeof(T));
      }
        protected object _visualContent;
        public object VisualContent
        {
            get { return _visualContent; }
            set { _visualContent = value;}
        }
        protected string _algoritmName;
        public string AlgoritmName
        {
            get { return _algoritmName; }
            set { _algoritmName = value; }
            
            
        }
        public event EventHandler AlgoritmCalculated = delegate { };
        public event EventHandler<AlgoritmEventArgs> AlgoritmUpdated = delegate { };

        private SettingCollection _parametrs;
        public SettingCollection Parametrs
        {
            get { return _parametrs; }
            set 
            { 
                _parametrs = value;
                 AlgoritmUpdated(this, new AlgoritmEventArgs(this));
            }
        }

        protected T _output;

        public T GetValue()
        {
             return _output;
        }
        public void SetValue(T val)
            {
                if (_output != null)
                {
                    if (!_output.Equals(val))
                    {
                        _output = val;
                        AlgoritmCalculated(this, new EventArgs());
                    }
                }
                else
                {
                    _output = val;
                    AlgoritmCalculated(this, new EventArgs());
                }
            }

        #endregion


        public CustomProperty AddParametrs(CustomProperty item)
        {
            for (int i = 0; i < _parametrs.Count; i++)
            {
                if (string.Compare(_parametrs[i].Name, item.Name) == 0)
                    return null;
            }
              _parametrs.Add(item);
              AlgoritmUpdated(this, new AlgoritmEventArgs(this));
              return item;
        }
        public CustomProperty AddParametrs(string name, Type type)
        {
            for (int i = 0; i < _parametrs.Count; i++)
            {
                if (string.Compare(_parametrs[i].Name, name) == 0)
                    return null;
            }
            CustomProperty item = new CustomProperty(name, true, true, type);
            _parametrs.Add(item);
            AlgoritmUpdated(this, new AlgoritmEventArgs(this));
            return item;
        }
    }
}
