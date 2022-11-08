﻿using MedprModels.Interfaces;
using MedprModels.Links;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedprModels.Requests;

public class DrugModel: IHateoas
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(15, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Required(ErrorMessage = "Drug should belong to some pharmaceutical group")]
    public string PharmGroup { get; set; }

    [Required(ErrorMessage = "Cmon, it should cost something")]
    [Column(TypeName = "decimal(18, 2)")]
    [Range(1, int.MaxValue, ErrorMessage = "Input something greater than 0"), DataType(DataType.Currency)]
    public int Price { get; set; }

    public List<Link> Links { get; set; }
}
