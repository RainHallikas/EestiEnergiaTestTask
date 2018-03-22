using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarApp.Models
{
    public class EditModel
    {
        public CarMark CarMark { get; set; }
        public List<CarMark> CarMarks { get; set; }

        public SparePart SparePart { get; set; }
        public List<SparePart> SpareParts { get; set; }

        public CarSparePart carSparePart { get; set; }
        public List<CarSparePart> CarSpareParts { get; set; }

        public int SelectedCarMarkId { get; set; }
        public int SelectedSparePartId { get; set; }
    }
}