//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuntCome.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        public int Order_id { get; set; }
        public int Aunt_id { get; set; }
        public int User_id { get; set; }
        public string Auntname { get; set; }
        public string Username { get; set; }
        public string Aunt_paypal { get; set; }
        public string User_paypal { get; set; }
        public int Aunt_phone { get; set; }
        public int User_phone { get; set; }
        public int Payment { get; set; }
        public System.DateTime Time { get; set; }
    }
}
