using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Models;
public class FormGroup : AbstractControl
{
    public Dictionary<string, AbstractControl> Controls { get; set; }
}
