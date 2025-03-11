using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResponseMessage
    {
        public ResponseMessage()
        {
            Id = default;
            Message = string.Empty;
        }
        public ResponseMessage(int id, string message)
        {
            Id = id;
            Message = message;
        }
        public int Id { get; set; }
        public string Message { get; set; }
    }
    public class SerializeResponse<T> : ResponseMessage
    {
        private List<T> _arrayOfResponse;

        public SerializeResponse()
        {
            _arrayOfResponse = new List<T>();
        }
        public SerializeResponse(int id, string message)
        {
            _arrayOfResponse = new List<T>();
            Id = id;
            Message = message;
        }
        public List<T> ArrayOfResponse
        {
            get { return _arrayOfResponse; }
            set { _arrayOfResponse = value; }
        }
    }
}
