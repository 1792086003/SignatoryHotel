using System;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace Lanxess.CN.SignatoryHotel.BussinessEntity
{
    /// <summary>
    /// 酒店合同实体类
    /// </summary>
    public class Contract
    {
        //主键
        public virtual int ContractID { get; set; }
        //可不填，酒店联系人
        [MaxLength(30, ErrorMessage = "Must less than 30 characters")]
        public virtual string Contacter { get; set; }
        //可不填，酒店联系人座机
        [DataType(DataType.PhoneNumber)]
        public virtual string Telephone { get; set; }
        //可不填，酒店联系人手机
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Wrong mobile")]
        public virtual string Mobile { get; set; }
        //可不填，酒店联系人电子邮箱
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }
        //必填，合同生效日
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public virtual DateTime Start { get; set; }
        //必填，合同失效日
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [GreaterThan("Start")]
        public virtual DateTime End { get; set; }
        //合同签订酒店
        public virtual Hotel Hotel { get; set; }
        //外键
        public virtual int HotelID { get; set; }
        
    }
}
