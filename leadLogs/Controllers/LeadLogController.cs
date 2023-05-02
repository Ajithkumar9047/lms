using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lms.config.Models;
using leadReceiptService.Services;
using Microsoft.AspNetCore.Mvc;
using dmsService;

namespace leadReceiptService.Controllers;

[ApiController]
public class LeadLogController : ControllerBase
{
    readonly ILeadLogService leadLogService;
    private readonly ILogger<LeadLogController> _logger;

    public LeadLogController(ILeadLogService leadLogService, ILogger<LeadLogController> logger)
    {
        this.leadLogService = leadLogService;
        this._logger = logger;
    }


    [Route("api/lead")]
    [HttpPost]
    public async Task<IActionResult> LeadLog(LeadRequestModel leadRequestModel)
    {
        try
        {
            dmsService.Class1 d = new Class1();

            string result= await d.check();

            var response = await leadLogService.ProcessLead(leadRequestModel);
            return StatusCode(response.status, response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to Process Lead", ex);
            return UnprocessableEntity(ex);
        }

    }

}


