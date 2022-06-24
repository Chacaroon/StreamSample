using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Models;
internal class FormArray : AbstractControl
{
    public IEnumerable<AbstractControl> Controls { get; set; }

    public AbstractControl ControlSchema { get; set; }
}
