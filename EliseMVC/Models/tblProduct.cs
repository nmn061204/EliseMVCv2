﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EliseMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblDetailBills = new HashSet<tblDetailBill>();
            imageProduct1 = "~/Content/Img/add.png";
            imageProduct2 = "~/Content/Img/add.png";
            imageProduct3 = "~/Content/Img/add.png";
        }
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("MÃ SẢN PHẨM")]
        public string codeProduct { get; set; }
        [DisplayName("TÊN SẢN PHẨM")]
        public string nameProduct { get; set; }
        [DisplayName("SỐ LƯỢNG")]
        public Nullable<int> quantityProductInput { get; set; }
        [DisplayName("GIÁ")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public Nullable<double> priceProductInput { get; set; }

        [DisplayName("SIZE")]
        public string sizePro { get; set; }
        [NotMapped]
        [DisplayName("DANH SÁCH SIZE")]
        public List<string> ListOfSizes {  get; set; }  
       
        [DisplayName("IMAGE 1")]
        public string imageProduct1 { get; set; }
        [DisplayName("IMAGE 2")]
        public string imageProduct2 { get; set; }
        [DisplayName("IMAGE 3")]
        public string imageProduct3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDetailBill> tblDetailBills { get; set; }
    }
}
