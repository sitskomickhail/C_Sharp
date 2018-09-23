using BuildLibrary.Interfaces;
using System;

namespace BuildLibrary.TeamBuilders
{
    public class Worker : IWorker
    {
        #region FILEDS
        private int _output;
        private string[] _outInfo;
        private string _name;
        private readonly string _position;
        #endregion

        #region CTORS
        internal Worker(string name)
        {
            Name = name;
            _position = "Builder";
            Output = 100;
        }
        #endregion

        #region IRELIS
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!BuildExceptions.Exception.NameException(value))
                    throw new ArgumentNullException("Неправильно введены данные");
                _name = value;
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }
        }

        public bool CheckWork(IPart obj)
        {
            if (obj.Pct == 100)
                return true;
            return false;
        }
        #endregion

        #region METHODS
        internal void AddSlice(IPart obj)
        {
            string[] _tempType;
            _tempType = obj.GetType().ToString().Split('.');

            obj.AddSlice(this);
            _outInfo[_output] = $"Name: {this.Name}      Position: {this.Position}         Type: {_tempType[2]}         Percent: {obj.Pct}";
            _output++;
        }
        #endregion

        #region PROPS
        internal int Output
        {
            get { return _output; }
            set
            {
                _outInfo = new string[value];
            }
        }

        internal string[] OutputInfo
        {
            get { return _outInfo; }
        }
        #endregion
    }
}
