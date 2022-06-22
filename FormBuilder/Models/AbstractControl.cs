using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Models;

public class AbstractControl
{
    public object Value { get; set; }

    public Validator[] Validators { get; set; }
}
