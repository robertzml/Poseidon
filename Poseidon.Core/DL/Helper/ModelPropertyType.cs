using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poseidon.Core.DL
{
    /// <summary>
    /// 模型类型
    /// </summary>
    public enum ModelPropertyType
    {
        [Display(Name = "Null")]
        Null = 0,

        [Display(Name = "Int16")]
        Int16,

        [Display(Name = "Int32")]
        Int32,

        [Display(Name = "Int64")]
        Int64,

        [Display(Name = "Bit")]
        Bit,

        [Display(Name = "Boolean")]
        Boolean,

        [Display(Name = "String")]
        String,

        [Display(Name = "DateTime")]
        DateTime,

        [Display(Name = "Float")]
        Float,

        [Display(Name = "Double")]
        Double,

        [Display(Name = "Decimal")]
        Decimal
    }
}
