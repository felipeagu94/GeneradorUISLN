using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class DefaultModel
    {
        public string formId { get; set; }
        public string cols { get; set; }
        public string action { get; set; }
        public string method { get; set; }
        public List<InputModel> input { get; set; }
        public List<ButtonModel> button { get; set; }
        public List<SelectModel> select { get; set; }
    }
}
