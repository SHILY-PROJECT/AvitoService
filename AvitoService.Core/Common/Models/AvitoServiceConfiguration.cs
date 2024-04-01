using System.ComponentModel.DataAnnotations;

namespace AvitoService.Core.Common.Models;

public class AvitoServiceConfiguration
{
    public required string AvitoDbContextConnection { get; set; }
}