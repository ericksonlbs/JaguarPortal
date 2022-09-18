using System;
using System.Collections.Generic;
using System.Linq;

namespace JaguarWebAPI.Models
{
    public class ErrorsModel
    {
        public IEnumerable<ErrorModel> Errors { get; set; }
        public DateTime DateTimeError { get { return DateTime.Now; } }
    }

    public class ErrorModel
    {
        public long Code { get; set; }
        public string Message { get; set; }
    }

    public class ErrorsUtil
    {
        public static ErrorsModel CreateErrorsModel(long code, string message)
        {
            ErrorsModel model = new()
            {
                Errors = new List<ErrorModel>()
                {
                    new ErrorModel() {
                        Code = code,
                        Message = message
                    }
                }
            };

            return model;
        }
    }
}
