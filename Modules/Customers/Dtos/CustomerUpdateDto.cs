namespace AssetControl.SmallBiz.Modules.Customers.Dtos;

using System.ComponentModel.DataAnnotations;

public class CustomerUpdateDto
{
    [StringLength(200)]
    public string? Name { get; set; }

    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; set; }

    [Phone]
    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }
}

