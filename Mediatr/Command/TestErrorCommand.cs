using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Sample.Command;

public class TestErrorCommand :IRequest<bool>
{
    required public string Value { get; init; }
    public string Other { get; } = "Other value";
}

