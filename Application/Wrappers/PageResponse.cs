using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PageResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int Pagesize { get; set; }

        /// <summary>
        /// Returns the page number, page size, and the data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        public PageResponse(T data, int PageNumber, int PageSize)
        {
            this.PageNumber = PageNumber;
            this.Pagesize = PageSize;
            this.Data = data;
            this.Message = null;
            this.Success = true;
            this.Errors = null;
        }

        /// <summary>
        /// Returns the data, page number, page size, and a message 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="message"></param>
        public PageResponse(T data, int PageNumber, int PageSize, string message)
        {

            this.PageNumber = PageNumber;
            this.Pagesize = PageSize;
            this.Data = data;
            this.Message = message;
            this.Success = true;
            this.Errors = null;
        }

        /// <summary>
        /// Return the Erros id occurs
        /// </summary>
        /// <param name="errors"></param>
        public PageResponse(List<string> errors)
        {

            this.PageNumber = 0;
            this.Pagesize = 0;
            this.Data = default(T);
            this.Message = null;
            this.Success = false;
            this.Errors = errors;
        }
    }
}
