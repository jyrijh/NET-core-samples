using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Sample.Command;

public class TestErrorCommandHandler : IRequestHandler<TestErrorCommand, bool>
{
    private readonly ISampleErrorService _service;

    public TestErrorCommandHandler(ISampleErrorService service)
    {
        _service = service;
    }

    public Task<bool> Handle(TestErrorCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_service.PrintLine(request.Value));
    }
}

