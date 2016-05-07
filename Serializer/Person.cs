using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Serializer.Properties;

namespace Serializer
{
    [Serializable]
    class Person : ISerializable
    {
        private string _name;
        private string _address;
        private string _phone;
        private DateTime _dateOfRecording;
        [NonSerialized] private int _serialNumber;

        public string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public DateTime DateOfRecording { get { return _dateOfRecording; } }
        public int SerialNumber { get { return _serialNumber; } set { _serialNumber = value; } }

        public Person()
        {

        }

        public Person(string name, string address, string phone)
        {
            this._name = name;
            this._address = address;
            this._phone = phone;
            this._dateOfRecording = DateTime.Now;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("Name");
            _address = info.GetString("Address");
            _phone = info.GetString("Phone");
            _dateOfRecording = info.GetDateTime("Date of recording");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("Address", _address);
            info.AddValue("Phone", _phone);
            info.AddValue("Date of recording", _dateOfRecording);
        }
    }
}
