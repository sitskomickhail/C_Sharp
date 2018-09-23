using BuildLibrary.BuildElems;
using BuildLibrary.Interfaces;
using System;

namespace BuildLibrary.TeamBuilders
{
    internal class TeamLeader : IWorker
    {
        #region FIELDS
        private string _name;
        private string _position;
        private string[] _report;
        #endregion

        #region CTOR
        public TeamLeader(string name, int workersCount)
        {
            Name = name;
            _position = "Team leader";
            _report = new string[workersCount * 100];
        }
        #endregion

        #region METHODS
        public void SetWork(IPart obj, Worker[] builders)
        {
            builders[Randomer.Next(builders.Length)].AddSlice(obj);
        }

        public string[] MakeReport(Worker[] builders)
        {
            _report[0] = $"         Report made by team leader: {this.Name}\n";
            int count = 1;
            for (int i = 0; i < builders.Length; i++)
            {
                string[] info = builders[i].OutputInfo;
                for (int j = 0; j < builders[i].Output; j++)
                {
                    _report[count] = info[j];
                    count++;
                }
            }
            return _report;
        }
        #endregion

        #region REALIS
        public bool CheckWork(IPart obj)
        {
            if (obj.Pct != 100)
                return false;
            return true;
        }

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
        #endregion

        #region PROPS
        public string[] GetReport
        {
            get
            {
                int count = 0;
                while (_report[count] != null)
                {
                    count++;
                }
                string[] outFunc = new string[count];
                for (int i = 0; i < count; i++)
                {
                    outFunc[i] = _report[i];
                }
                return outFunc;
            }
        }
        #endregion
    }
}
