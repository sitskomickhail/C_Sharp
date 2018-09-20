using BuildLibrary.Interfaces;
using System;

namespace BuildLibrary.TeamBuilders
{
    internal class Worker : IWorker
    {
        #region FILEDS
        private int _output;
        private string[] _outInfo;
        private string _name;
        private readonly string _position;
        #endregion

        #region CTORS
        public Worker(string name)
        {
            Name = name;
            _position = "Builder";
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
                if (!BuildExceptions.WorkerException.NameException(value))
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

        public void CheckWork(IPart obj, int _workRemaining)
        {
            _outInfo[_output] = $"{obj.GetType()} {obj.Remained(_workRemaining)} {obj.IsCreated(_workRemaining)}";
            _output++;
        }
        #endregion

        public int Output
        {
            get { return _output; }
            protected set
            {
                _output = value;
                _outInfo = new string[value];
            }
        }
    }
}
